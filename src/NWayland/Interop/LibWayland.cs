using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NWayland.Protocols.Wayland;

namespace NWayland.Interop
{
    public static unsafe class LibWayland
    {
        private const string Wayland = "libwayland-client.so.0";
        private const string WaylandEgl = "libwayland-egl.so.1";
        private const string libWaylandCursor = "libwayland-cursor.so.0";

        [DllImport(Wayland, SetLastError = true)]
        public static extern IntPtr wl_display_connect(string? name);

        [DllImport(Wayland, SetLastError = true)]
        public static extern int wl_display_dispatch(IntPtr display);

        [DllImport(Wayland, SetLastError = true)]
        public static extern int wl_display_dispatch_pending(IntPtr display);

        [DllImport(Wayland, SetLastError = true)]
        public static extern int wl_display_roundtrip(IntPtr display);

        [DllImport(Wayland)]
        public static extern void wl_display_disconnect(IntPtr display);

        [DllImport(Wayland)]
        public static extern void wl_proxy_destroy(IntPtr proxy);

        [DllImport(Wayland)]
        public static extern void wl_proxy_marshal_array(IntPtr p, uint opcode, WlArgument* args);

        [DllImport(Wayland)]
        public static extern IntPtr wl_proxy_marshal_array_constructor(IntPtr p, uint opcode, WlArgument* args, ref WlInterface iface);

        [DllImport(Wayland)]
        public static extern void wl_callback_destroy(IntPtr callback);

        [DllImport(Wayland)]
        private static extern int wl_proxy_add_dispatcher(IntPtr proxy, WlProxyDispatcherDelegate dispatcherFunc, IntPtr implementation, IntPtr data);

        [DllImport(Wayland)]
        private static extern uint wl_proxy_get_id(IntPtr proxy);

        [DllImport(WaylandEgl)]
        public static extern IntPtr wl_egl_window_create(IntPtr surface, int width, int height);

        [DllImport(WaylandEgl)]
        public static extern IntPtr wl_egl_window_resize(IntPtr window, int width, int heighti, int dx, int dy);

        [DllImport(WaylandEgl)]
        public static extern void wl_egl_window_destroy(IntPtr window);

        [DllImport(libWaylandCursor)]
        public static extern IntPtr wl_cursor_theme_load(string? name, int size, IntPtr shm);

        [DllImport(libWaylandCursor)]
        public static extern void wl_cursor_theme_destroy(IntPtr theme);

        [DllImport(libWaylandCursor)]
        public static extern IntPtr wl_cursor_theme_get_cursor(IntPtr theme, string? name);

        private delegate int WlProxyDispatcherDelegate(IntPtr implementation, IntPtr target, uint opcode, ref WlMessage message, WlArgument* argument);

        private static readonly Dictionary<uint, WeakReference<WlProxy>> Proxies = new();

        private static int WlProxyDispatcher(IntPtr implementation, IntPtr target, uint opcode, ref WlMessage message, WlArgument* arguments)
        {
            var id = ((UIntPtr)implementation.ToPointer()).ToUInt32();

            WlProxy proxy;
            lock (Proxies)
            {
                if (!Proxies.TryGetValue(id, out var weakRef))
                    return 0;
                if (!weakRef.TryGetTarget(out proxy))
                {
                    Proxies.Remove(id);
                    return 0;
                }
            }

            try
            {
                proxy.DispatchEvent(opcode, ref message, arguments);
            }
            catch (Exception e)
            {
                proxy.Display.OnUnhandledException(proxy, e);
            }

            return 0;
        }

        private static readonly WlProxyDispatcherDelegate Dispatcher = WlProxyDispatcher;

        public static uint RegisterProxy(WlProxy wlProxy)
        {
            lock (Proxies)
            {
                var id = wl_proxy_get_id(wlProxy.Handle);
                var idp = (IntPtr)new UIntPtr(id).ToPointer();
                wl_proxy_add_dispatcher(wlProxy.Handle, Dispatcher, idp, idp);
                Proxies[id] = new WeakReference<WlProxy>(wlProxy);
                return id;
            }
        }

        public static void UnregisterProxy(uint id)
        {
            lock (Proxies)
                Proxies.Remove(id);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WlObject
        {
            public WlInterface* Interface;
            public void* Implementation;
            public uint Id;
        }

        public static WlProxy FindByNative(IntPtr proxy)
        {
            lock (Proxies)
            {
                var id = wl_proxy_get_id(proxy);
                if (!Proxies.TryGetValue(id, out var weakRef))
                {
                    // TODO: Investigate
                    // It's unclear if we should create a new managed object for wl_proxy here
                    // since it means that said proxy was created by the native code
                    return null;
                }

                if (!weakRef.TryGetTarget(out var target))
                    Proxies.Remove(id);
                return target;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WlMessage
    {
        public byte* Name;
        public byte* Signature;
        public WlInterface** Types;

        private static readonly WlInterface*[] OneNullType = { null };
        public static WlMessage Create(string name, string signature, WlInterface*[]? types)
        {
            types ??= OneNullType;
            var pTypes = (WlInterface**)Marshal.AllocHGlobal(IntPtr.Size * types.Length);
            for (var c = 0; c < types.Length; c++)
                pTypes[c] = types[c];

            return new WlMessage
            {
                Name = (byte*)Marshal.StringToHGlobalAnsi(name),
                Signature = (byte*)Marshal.StringToHGlobalAnsi(signature),
                Types = pTypes
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WlInterface
    {
        public byte* Name;
        public int Version;
        public int MethodCount;
        public WlMessage* Methods;
        public int EventCount;
        public WlMessage* Events;

        public static WlInterface* GeneratorAddressOf(ref WlInterface s)
        {
            fixed (WlInterface* addr = &s)
                return addr;
        }

        public static T* UnmanagedCopy<T>(T[]? arr) where T : unmanaged
        {
            if (arr == null || arr.Length == 0)
                return null;
            var ptr = (T*)Marshal.AllocHGlobal(sizeof(T) * arr.Length);
            for (var c = 0; c < arr.Length; c++)
                ptr[c] = arr[c];
            return ptr;
        }

        public void Init(string name, int version, WlMessage[]? methods, WlMessage[]? events)
        {
            Name = (byte*)Marshal.StringToHGlobalAnsi(name);
            Version = version;
            MethodCount = methods?.Length ?? 0;
            Methods = UnmanagedCopy(methods);
            EventCount = events?.Length ?? 0;
            Events = UnmanagedCopy(events);
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct WlArgument
    {
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(0)]
        public uint UInt32;
        [FieldOffset(0)]
        public IntPtr IntPtr;

        public static implicit operator WlArgument(int value) => new() { Int32 = value };
        public static implicit operator WlArgument(uint value) => new() { UInt32 = value };
        public static implicit operator WlArgument(IntPtr value) => new() { IntPtr = value };
        public static implicit operator WlArgument(WlProxy value) => new() { IntPtr = value.Handle };
        public static implicit operator WlArgument(SafeHandle? value) => new() { IntPtr = value?.DangerousGetHandle() ?? IntPtr.Zero };
        public static implicit operator WlArgument(WlArray* value) => new() { IntPtr = (IntPtr)value };

        public static readonly WlArgument NewId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe ref struct WlArray
    {
        public IntPtr Size;
        public IntPtr Alloc;
        public IntPtr Data;

        public static Span<T> SpanFromWlArrayPtr<T>(IntPtr wlArrayPointer) where T : unmanaged
            => wlArrayPointer == IntPtr.Zero ? Span<T>.Empty : ((WlArray*)wlArrayPointer.ToPointer())->AsSpan<T>();

        public Span<T> AsSpan<T>() where T : unmanaged
        {
            var size = Size.ToInt32() / sizeof(T);
            return size == 0 ? Span<T>.Empty : new Span<T>(Data.ToPointer(), size);
        }

        public static WlArray FromPointer<T>(T* ptr, int count) where T : unmanaged
        {
            var size = new IntPtr(sizeof(T) * count);
            return new WlArray
            {
                Size = size,
                Alloc = size,
                Data = (IntPtr)ptr
            };
        }
    }
}
