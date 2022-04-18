using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wayland
{
    /// <summary>
    /// The core global object.  This is a special singleton object.  It
    /// is used for internal Wayland protocol features.
    /// </summary>
    public sealed unsafe partial class WlDisplay : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlDisplay()
        {
            WlInterface.Init("wl_display", 1, new WlMessage[] {
                WlMessage.Create("sync", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCallback.WlInterface) }),
                WlMessage.Create("get_registry", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegistry.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("error", "ous", new WlInterface*[] { null, null, null }),
                WlMessage.Create("delete_id", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDisplay.WlInterface);
        }

        /// <summary>
        /// The sync request asks the server to emit the 'done' event
        /// on the returned wl_callback object.  Since requests are
        /// handled in-order and events are delivered in-order, this can
        /// be used as a barrier to ensure all previous requests and the
        /// resulting events have been handled.
        /// 
        /// The object returned by this request will be destroyed by the
        /// compositor after the callback is fired and as such the client must not
        /// attempt to use it after that point.
        /// 
        /// The callback_data passed in the callback is the event serial.
        /// </summary>
        public NWayland.Protocols.Wayland.WlCallback Sync()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlCallback.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlCallback(__ret, Version, Display);
        }

        /// <summary>
        /// This request creates a registry object that allows the client
        /// to list and bind the global objects available from the
        /// compositor.
        /// 
        /// It should be noted that the server side resources consumed in
        /// response to a get_registry request can only be released when the
        /// client disconnects, not when the client side proxy is destroyed.
        /// Therefore, clients should invoke get_registry as infrequently as
        /// possible to avoid wasting memory.
        /// </summary>
        public NWayland.Protocols.Wayland.WlRegistry GetRegistry()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wayland.WlRegistry.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlRegistry(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnError(NWayland.Protocols.Wayland.WlDisplay eventSender, WlProxy @objectId, uint @code, System.String @message);
            void OnDeleteId(NWayland.Protocols.Wayland.WlDisplay eventSender, uint @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnError(this, WlProxy.FromNative<WlProxy>(arguments[0].IntPtr), arguments[1].UInt32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[2].IntPtr));
            if (opcode == 1)
                Events?.OnDeleteId(this, arguments[0].UInt32);
        }

        /// <summary>
        /// These errors are global and can be emitted in response to any
        /// server request.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>server couldn't find object</summary>
            InvalidObject = 0,
            /// <summary>method doesn't exist on the specified interface or malformed request</summary>
            InvalidMethod = 1,
            /// <summary>server is out of memory</summary>
            NoMemory = 2,
            /// <summary>implementation error in compositor</summary>
            Implementation = 3
        }

        public const string InterfaceName = "wl_display";
        public const int InterfaceVersion = 1;
    }

    /// <summary>
    /// The singleton global registry object.  The server has a number of
    /// global objects that are available to all clients.  These objects
    /// typically represent an actual object in the server (for example,
    /// an input device) or they are singleton objects that provide
    /// extension functionality.
    /// 
    /// When a client creates a registry object, the registry object
    /// will emit a global event for each global currently in the
    /// registry.  Globals come and go as a result of device or
    /// monitor hotplugs, reconfiguration or other events, and the
    /// registry will send out global and global_remove events to
    /// keep the client up to date with the changes.  To mark the end
    /// of the initial burst of events, the client can use the
    /// wl_display.sync request immediately after calling
    /// wl_display.get_registry.
    /// 
    /// A client can bind to a global object by using the bind
    /// request.  This creates a client-side handle that lets the object
    /// emit events to the client and lets the client invoke requests on
    /// the object.
    /// </summary>
    public sealed unsafe partial class WlRegistry : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlRegistry()
        {
            WlInterface.Init("wl_registry", 1, new WlMessage[] {
                WlMessage.Create("bind", "usun", new WlInterface*[] { null, null })
            }, new WlMessage[] {
                WlMessage.Create("global", "usu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("global_remove", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegistry.WlInterface);
        }

        public interface IEvents
        {
            void OnGlobal(NWayland.Protocols.Wayland.WlRegistry eventSender, uint @name, System.String @interface, uint @version);
            void OnGlobalRemove(NWayland.Protocols.Wayland.WlRegistry eventSender, uint @name);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGlobal(this, arguments[0].UInt32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[1].IntPtr), arguments[2].UInt32);
            if (opcode == 1)
                Events?.OnGlobalRemove(this, arguments[0].UInt32);
        }

        public const string InterfaceName = "wl_registry";
        public const int InterfaceVersion = 1;

        public WlRegistry(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// Clients can handle the 'done' event to get notified when
    /// the related request is done.
    /// </summary>
    public sealed unsafe partial class WlCallback : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlCallback()
        {
            WlInterface.Init("wl_callback", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("done", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCallback.WlInterface);
        }

        public interface IEvents
        {
            void OnDone(NWayland.Protocols.Wayland.WlCallback eventSender, uint @callbackData);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDone(this, arguments[0].UInt32);
        }

        class ProxyFactory : IBindFactory<WlCallback>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCallback.WlInterface);
            }

            public WlCallback Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlCallback(handle, version, display);
            }
        }

        public static IBindFactory<WlCallback> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_callback";
        public const int InterfaceVersion = 1;

        public WlCallback(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A compositor.  This object is a singleton global.  The
    /// compositor is in charge of combining the contents of multiple
    /// surfaces into one displayable output.
    /// </summary>
    public sealed unsafe partial class WlCompositor : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlCompositor()
        {
            WlInterface.Init("wl_compositor", 4, new WlMessage[] {
                WlMessage.Create("create_surface", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("create_region", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCompositor.WlInterface);
        }

        /// <summary>
        /// Ask the compositor to create a new surface.
        /// </summary>
        public NWayland.Protocols.Wayland.WlSurface CreateSurface()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlSurface.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlSurface(__ret, Version, Display);
        }

        /// <summary>
        /// Ask the compositor to create a new region.
        /// </summary>
        public NWayland.Protocols.Wayland.WlRegion CreateRegion()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wayland.WlRegion.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlRegion(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<WlCompositor>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCompositor.WlInterface);
            }

            public WlCompositor Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlCompositor(handle, version, display);
            }
        }

        public static IBindFactory<WlCompositor> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_compositor";
        public const int InterfaceVersion = 4;

        public WlCompositor(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_shm_pool object encapsulates a piece of memory shared
    /// between the compositor and client.  Through the wl_shm_pool
    /// object, the client can allocate shared memory wl_buffer objects.
    /// All objects created through the same pool share the same
    /// underlying mapped memory. Reusing the mapped memory avoids the
    /// setup/teardown overhead and is useful when interactively resizing
    /// a surface or for many small buffers.
    /// </summary>
    public sealed unsafe partial class WlShmPool : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlShmPool()
        {
            WlInterface.Init("wl_shm_pool", 1, new WlMessage[] {
                WlMessage.Create("create_buffer", "niiiiu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface), null, null, null, null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("resize", "i", new WlInterface*[] { null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShmPool.WlInterface);
        }

        /// <summary>
        /// Create a wl_buffer object from the pool.
        /// 
        /// The buffer is created offset bytes into the pool and has
        /// width and height as specified.  The stride argument specifies
        /// the number of bytes from the beginning of one row to the beginning
        /// of the next.  The format is the pixel format of the buffer and
        /// must be one of those advertised through the wl_shm.format event.
        /// 
        /// A buffer will keep a reference to the pool it was created from
        /// so it is valid to destroy the pool immediately after creating
        /// a buffer from it.
        /// </summary>
        public NWayland.Protocols.Wayland.WlBuffer CreateBuffer(int @offset, int @width, int @height, int @stride, NWayland.Protocols.Wayland.WlShm.FormatEnum @format)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @offset,
                @width,
                @height,
                @stride,
                (uint)@format
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlBuffer.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlBuffer(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This request will cause the server to remap the backing memory
        /// for the pool from the file descriptor passed when the pool was
        /// created, but using the new size.  This request can only be
        /// used to make the pool bigger.
        /// 
        /// This request only changes the amount of bytes that are mmapped
        /// by the server and does not touch the file corresponding to the
        /// file descriptor passed at creation time. It is the client's
        /// responsibility to ensure that the file is at least as big as
        /// the new pool size.
        /// </summary>
        public void Resize(int @size)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @size
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<WlShmPool>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShmPool.WlInterface);
            }

            public WlShmPool Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlShmPool(handle, version, display);
            }
        }

        public static IBindFactory<WlShmPool> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_shm_pool";
        public const int InterfaceVersion = 1;

        public WlShmPool(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A singleton global object that provides support for shared
    /// memory.
    /// 
    /// Clients can create wl_shm_pool objects using the create_pool
    /// request.
    /// 
    /// On binding the wl_shm object one or more format events
    /// are emitted to inform clients about the valid pixel formats
    /// that can be used for buffers.
    /// </summary>
    public sealed unsafe partial class WlShm : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlShm()
        {
            WlInterface.Init("wl_shm", 1, new WlMessage[] {
                WlMessage.Create("create_pool", "nhi", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShmPool.WlInterface), null, null })
            }, new WlMessage[] {
                WlMessage.Create("format", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShm.WlInterface);
        }

        /// <summary>
        /// Create a new wl_shm_pool object.
        /// 
        /// The pool can be used to create shared memory based buffer
        /// objects.  The server will mmap size bytes of the passed file
        /// descriptor, to use as backing memory for the pool.
        /// </summary>
        public NWayland.Protocols.Wayland.WlShmPool CreatePool(int @fd, int @size)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @fd,
                @size
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlShmPool.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlShmPool(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnFormat(NWayland.Protocols.Wayland.WlShm eventSender, FormatEnum @format);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnFormat(this, (FormatEnum)arguments[0].UInt32);
        }

        /// <summary>
        /// These errors can be emitted in response to wl_shm requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>buffer format is not known</summary>
            InvalidFormat = 0,
            /// <summary>invalid size or stride during pool or buffer creation</summary>
            InvalidStride = 1,
            /// <summary>mmapping the file descriptor failed</summary>
            InvalidFd = 2
        }

        /// <summary>
        /// This describes the memory layout of an individual pixel.
        /// 
        /// All renderers should support argb8888 and xrgb8888 but any other
        /// formats are optional and may not be supported by the particular
        /// renderer in use.
        /// 
        /// The drm format codes match the macros defined in drm_fourcc.h, except
        /// argb8888 and xrgb8888. The formats actually supported by the compositor
        /// will be reported by the format event.
        /// 
        /// For all wl_shm formats and unless specified in another protocol
        /// extension, pre-multiplied alpha is used for pixel values.
        /// </summary>
        public enum FormatEnum
        {
            /// <summary>32-bit ARGB format, [31:0] A:R:G:B 8:8:8:8 little endian</summary>
            Argb8888 = 0,
            /// <summary>32-bit RGB format, [31:0] x:R:G:B 8:8:8:8 little endian</summary>
            Xrgb8888 = 1,
            /// <summary>8-bit color index format, [7:0] C</summary>
            C8 = 0x20203843,
            /// <summary>8-bit RGB format, [7:0] R:G:B 3:3:2</summary>
            Rgb332 = 0x38424752,
            /// <summary>8-bit BGR format, [7:0] B:G:R 2:3:3</summary>
            Bgr233 = 0x38524742,
            /// <summary>16-bit xRGB format, [15:0] x:R:G:B 4:4:4:4 little endian</summary>
            Xrgb4444 = 0x32315258,
            /// <summary>16-bit xBGR format, [15:0] x:B:G:R 4:4:4:4 little endian</summary>
            Xbgr4444 = 0x32314258,
            /// <summary>16-bit RGBx format, [15:0] R:G:B:x 4:4:4:4 little endian</summary>
            Rgbx4444 = 0x32315852,
            /// <summary>16-bit BGRx format, [15:0] B:G:R:x 4:4:4:4 little endian</summary>
            Bgrx4444 = 0x32315842,
            /// <summary>16-bit ARGB format, [15:0] A:R:G:B 4:4:4:4 little endian</summary>
            Argb4444 = 0x32315241,
            /// <summary>16-bit ABGR format, [15:0] A:B:G:R 4:4:4:4 little endian</summary>
            Abgr4444 = 0x32314241,
            /// <summary>16-bit RBGA format, [15:0] R:G:B:A 4:4:4:4 little endian</summary>
            Rgba4444 = 0x32314152,
            /// <summary>16-bit BGRA format, [15:0] B:G:R:A 4:4:4:4 little endian</summary>
            Bgra4444 = 0x32314142,
            /// <summary>16-bit xRGB format, [15:0] x:R:G:B 1:5:5:5 little endian</summary>
            Xrgb1555 = 0x35315258,
            /// <summary>16-bit xBGR 1555 format, [15:0] x:B:G:R 1:5:5:5 little endian</summary>
            Xbgr1555 = 0x35314258,
            /// <summary>16-bit RGBx 5551 format, [15:0] R:G:B:x 5:5:5:1 little endian</summary>
            Rgbx5551 = 0x35315852,
            /// <summary>16-bit BGRx 5551 format, [15:0] B:G:R:x 5:5:5:1 little endian</summary>
            Bgrx5551 = 0x35315842,
            /// <summary>16-bit ARGB 1555 format, [15:0] A:R:G:B 1:5:5:5 little endian</summary>
            Argb1555 = 0x35315241,
            /// <summary>16-bit ABGR 1555 format, [15:0] A:B:G:R 1:5:5:5 little endian</summary>
            Abgr1555 = 0x35314241,
            /// <summary>16-bit RGBA 5551 format, [15:0] R:G:B:A 5:5:5:1 little endian</summary>
            Rgba5551 = 0x35314152,
            /// <summary>16-bit BGRA 5551 format, [15:0] B:G:R:A 5:5:5:1 little endian</summary>
            Bgra5551 = 0x35314142,
            /// <summary>16-bit RGB 565 format, [15:0] R:G:B 5:6:5 little endian</summary>
            Rgb565 = 0x36314752,
            /// <summary>16-bit BGR 565 format, [15:0] B:G:R 5:6:5 little endian</summary>
            Bgr565 = 0x36314742,
            /// <summary>24-bit RGB format, [23:0] R:G:B little endian</summary>
            Rgb888 = 0x34324752,
            /// <summary>24-bit BGR format, [23:0] B:G:R little endian</summary>
            Bgr888 = 0x34324742,
            /// <summary>32-bit xBGR format, [31:0] x:B:G:R 8:8:8:8 little endian</summary>
            Xbgr8888 = 0x34324258,
            /// <summary>32-bit RGBx format, [31:0] R:G:B:x 8:8:8:8 little endian</summary>
            Rgbx8888 = 0x34325852,
            /// <summary>32-bit BGRx format, [31:0] B:G:R:x 8:8:8:8 little endian</summary>
            Bgrx8888 = 0x34325842,
            /// <summary>32-bit ABGR format, [31:0] A:B:G:R 8:8:8:8 little endian</summary>
            Abgr8888 = 0x34324241,
            /// <summary>32-bit RGBA format, [31:0] R:G:B:A 8:8:8:8 little endian</summary>
            Rgba8888 = 0x34324152,
            /// <summary>32-bit BGRA format, [31:0] B:G:R:A 8:8:8:8 little endian</summary>
            Bgra8888 = 0x34324142,
            /// <summary>32-bit xRGB format, [31:0] x:R:G:B 2:10:10:10 little endian</summary>
            Xrgb2101010 = 0x30335258,
            /// <summary>32-bit xBGR format, [31:0] x:B:G:R 2:10:10:10 little endian</summary>
            Xbgr2101010 = 0x30334258,
            /// <summary>32-bit RGBx format, [31:0] R:G:B:x 10:10:10:2 little endian</summary>
            Rgbx1010102 = 0x30335852,
            /// <summary>32-bit BGRx format, [31:0] B:G:R:x 10:10:10:2 little endian</summary>
            Bgrx1010102 = 0x30335842,
            /// <summary>32-bit ARGB format, [31:0] A:R:G:B 2:10:10:10 little endian</summary>
            Argb2101010 = 0x30335241,
            /// <summary>32-bit ABGR format, [31:0] A:B:G:R 2:10:10:10 little endian</summary>
            Abgr2101010 = 0x30334241,
            /// <summary>32-bit RGBA format, [31:0] R:G:B:A 10:10:10:2 little endian</summary>
            Rgba1010102 = 0x30334152,
            /// <summary>32-bit BGRA format, [31:0] B:G:R:A 10:10:10:2 little endian</summary>
            Bgra1010102 = 0x30334142,
            /// <summary>packed YCbCr format, [31:0] Cr0:Y1:Cb0:Y0 8:8:8:8 little endian</summary>
            Yuyv = 0x56595559,
            /// <summary>packed YCbCr format, [31:0] Cb0:Y1:Cr0:Y0 8:8:8:8 little endian</summary>
            Yvyu = 0x55595659,
            /// <summary>packed YCbCr format, [31:0] Y1:Cr0:Y0:Cb0 8:8:8:8 little endian</summary>
            Uyvy = 0x59565955,
            /// <summary>packed YCbCr format, [31:0] Y1:Cb0:Y0:Cr0 8:8:8:8 little endian</summary>
            Vyuy = 0x59555956,
            /// <summary>packed AYCbCr format, [31:0] A:Y:Cb:Cr 8:8:8:8 little endian</summary>
            Ayuv = 0x56555941,
            /// <summary>2 plane YCbCr Cr:Cb format, 2x2 subsampled Cr:Cb plane</summary>
            Nv12 = 0x3231564e,
            /// <summary>2 plane YCbCr Cb:Cr format, 2x2 subsampled Cb:Cr plane</summary>
            Nv21 = 0x3132564e,
            /// <summary>2 plane YCbCr Cr:Cb format, 2x1 subsampled Cr:Cb plane</summary>
            Nv16 = 0x3631564e,
            /// <summary>2 plane YCbCr Cb:Cr format, 2x1 subsampled Cb:Cr plane</summary>
            Nv61 = 0x3136564e,
            /// <summary>3 plane YCbCr format, 4x4 subsampled Cb (1) and Cr (2) planes</summary>
            Yuv410 = 0x39565559,
            /// <summary>3 plane YCbCr format, 4x4 subsampled Cr (1) and Cb (2) planes</summary>
            Yvu410 = 0x39555659,
            /// <summary>3 plane YCbCr format, 4x1 subsampled Cb (1) and Cr (2) planes</summary>
            Yuv411 = 0x31315559,
            /// <summary>3 plane YCbCr format, 4x1 subsampled Cr (1) and Cb (2) planes</summary>
            Yvu411 = 0x31315659,
            /// <summary>3 plane YCbCr format, 2x2 subsampled Cb (1) and Cr (2) planes</summary>
            Yuv420 = 0x32315559,
            /// <summary>3 plane YCbCr format, 2x2 subsampled Cr (1) and Cb (2) planes</summary>
            Yvu420 = 0x32315659,
            /// <summary>3 plane YCbCr format, 2x1 subsampled Cb (1) and Cr (2) planes</summary>
            Yuv422 = 0x36315559,
            /// <summary>3 plane YCbCr format, 2x1 subsampled Cr (1) and Cb (2) planes</summary>
            Yvu422 = 0x36315659,
            /// <summary>3 plane YCbCr format, non-subsampled Cb (1) and Cr (2) planes</summary>
            Yuv444 = 0x34325559,
            /// <summary>3 plane YCbCr format, non-subsampled Cr (1) and Cb (2) planes</summary>
            Yvu444 = 0x34325659,
            /// <summary>[7:0] R</summary>
            R8 = 0x20203852,
            /// <summary>[15:0] R little endian</summary>
            R16 = 0x20363152,
            /// <summary>[15:0] R:G 8:8 little endian</summary>
            Rg88 = 0x38384752,
            /// <summary>[15:0] G:R 8:8 little endian</summary>
            Gr88 = 0x38385247,
            /// <summary>[31:0] R:G 16:16 little endian</summary>
            Rg1616 = 0x32334752,
            /// <summary>[31:0] G:R 16:16 little endian</summary>
            Gr1616 = 0x32335247,
            /// <summary>[63:0] x:R:G:B 16:16:16:16 little endian</summary>
            Xrgb16161616f = 0x48345258,
            /// <summary>[63:0] x:B:G:R 16:16:16:16 little endian</summary>
            Xbgr16161616f = 0x48344258,
            /// <summary>[63:0] A:R:G:B 16:16:16:16 little endian</summary>
            Argb16161616f = 0x48345241,
            /// <summary>[63:0] A:B:G:R 16:16:16:16 little endian</summary>
            Abgr16161616f = 0x48344241,
            /// <summary>[31:0] X:Y:Cb:Cr 8:8:8:8 little endian</summary>
            Xyuv8888 = 0x56555958,
            /// <summary>[23:0] Cr:Cb:Y 8:8:8 little endian</summary>
            Vuy888 = 0x34325556,
            /// <summary>Y followed by U then V, 10:10:10. Non-linear modifier only</summary>
            Vuy101010 = 0x30335556,
            /// <summary>[63:0] Cr0:0:Y1:0:Cb0:0:Y0:0 10:6:10:6:10:6:10:6 little endian per 2 Y pixels</summary>
            Y210 = 0x30313259,
            /// <summary>[63:0] Cr0:0:Y1:0:Cb0:0:Y0:0 12:4:12:4:12:4:12:4 little endian per 2 Y pixels</summary>
            Y212 = 0x32313259,
            /// <summary>[63:0] Cr0:Y1:Cb0:Y0 16:16:16:16 little endian per 2 Y pixels</summary>
            Y216 = 0x36313259,
            /// <summary>[31:0] A:Cr:Y:Cb 2:10:10:10 little endian</summary>
            Y410 = 0x30313459,
            /// <summary>[63:0] A:0:Cr:0:Y:0:Cb:0 12:4:12:4:12:4:12:4 little endian</summary>
            Y412 = 0x32313459,
            /// <summary>[63:0] A:Cr:Y:Cb 16:16:16:16 little endian</summary>
            Y416 = 0x36313459,
            /// <summary>[31:0] X:Cr:Y:Cb 2:10:10:10 little endian</summary>
            Xvyu2101010 = 0x30335658,
            /// <summary>[63:0] X:0:Cr:0:Y:0:Cb:0 12:4:12:4:12:4:12:4 little endian</summary>
            Xvyu1216161616 = 0x36335658,
            /// <summary>[63:0] X:Cr:Y:Cb 16:16:16:16 little endian</summary>
            Xvyu16161616 = 0x38345658,
            /// <summary>[63:0]   A3:A2:Y3:0:Cr0:0:Y2:0:A1:A0:Y1:0:Cb0:0:Y0:0  1:1:8:2:8:2:8:2:1:1:8:2:8:2:8:2 little endian</summary>
            Y0l0 = 0x304c3059,
            /// <summary>[63:0]   X3:X2:Y3:0:Cr0:0:Y2:0:X1:X0:Y1:0:Cb0:0:Y0:0  1:1:8:2:8:2:8:2:1:1:8:2:8:2:8:2 little endian</summary>
            X0l0 = 0x304c3058,
            /// <summary>[63:0]   A3:A2:Y3:Cr0:Y2:A1:A0:Y1:Cb0:Y0  1:1:10:10:10:1:1:10:10:10 little endian</summary>
            Y0l2 = 0x324c3059,
            /// <summary>[63:0]   X3:X2:Y3:Cr0:Y2:X1:X0:Y1:Cb0:Y0  1:1:10:10:10:1:1:10:10:10 little endian</summary>
            X0l2 = 0x324c3058,
            Yuv4208bit = 0x38305559,
            Yuv42010bit = 0x30315559,
            Xrgb8888A8 = 0x38415258,
            Xbgr8888A8 = 0x38414258,
            Rgbx8888A8 = 0x38415852,
            Bgrx8888A8 = 0x38415842,
            Rgb888A8 = 0x38413852,
            Bgr888A8 = 0x38413842,
            Rgb565A8 = 0x38413552,
            Bgr565A8 = 0x38413542,
            /// <summary>non-subsampled Cr:Cb plane</summary>
            Nv24 = 0x3432564e,
            /// <summary>non-subsampled Cb:Cr plane</summary>
            Nv42 = 0x3234564e,
            /// <summary>2x1 subsampled Cr:Cb plane, 10 bit per channel</summary>
            P210 = 0x30313250,
            /// <summary>2x2 subsampled Cr:Cb plane 10 bits per channel</summary>
            P010 = 0x30313050,
            /// <summary>2x2 subsampled Cr:Cb plane 12 bits per channel</summary>
            P012 = 0x32313050,
            /// <summary>2x2 subsampled Cr:Cb plane 16 bits per channel</summary>
            P016 = 0x36313050,
            /// <summary>[63:0] A:x:B:x:G:x:R:x 10:6:10:6:10:6:10:6 little endian</summary>
            Axbxgxrx106106106106 = 0x30314241,
            /// <summary>2x2 subsampled Cr:Cb plane</summary>
            Nv15 = 0x3531564e,
            Q410 = 0x30313451,
            Q401 = 0x31303451,
            /// <summary>[63:0] x:R:G:B 16:16:16:16 little endian</summary>
            Xrgb16161616 = 0x38345258,
            /// <summary>[63:0] x:B:G:R 16:16:16:16 little endian</summary>
            Xbgr16161616 = 0x38344258,
            /// <summary>[63:0] A:R:G:B 16:16:16:16 little endian</summary>
            Argb16161616 = 0x38345241,
            /// <summary>[63:0] A:B:G:R 16:16:16:16 little endian</summary>
            Abgr16161616 = 0x38344241
        }

        class ProxyFactory : IBindFactory<WlShm>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShm.WlInterface);
            }

            public WlShm Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlShm(handle, version, display);
            }
        }

        public static IBindFactory<WlShm> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_shm";
        public const int InterfaceVersion = 1;

        public WlShm(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A buffer provides the content for a wl_surface. Buffers are
    /// created through factory interfaces such as wl_shm, wp_linux_buffer_params
    /// (from the linux-dmabuf protocol extension) or similar. It has a width and
    /// a height and can be attached to a wl_surface, but the mechanism by which a
    /// client provides and updates the contents is defined by the buffer factory
    /// interface.
    /// 
    /// If the buffer uses a format that has an alpha channel, the alpha channel
    /// is assumed to be premultiplied in the color channels unless otherwise
    /// specified.
    /// </summary>
    public sealed unsafe partial class WlBuffer : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlBuffer()
        {
            WlInterface.Init("wl_buffer", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("release", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnRelease(NWayland.Protocols.Wayland.WlBuffer eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnRelease(this);
        }

        class ProxyFactory : IBindFactory<WlBuffer>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface);
            }

            public WlBuffer Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlBuffer(handle, version, display);
            }
        }

        public static IBindFactory<WlBuffer> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_buffer";
        public const int InterfaceVersion = 1;

        public WlBuffer(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A wl_data_offer represents a piece of data offered for transfer
    /// by another client (the source client).  It is used by the
    /// copy-and-paste and drag-and-drop mechanisms.  The offer
    /// describes the different mime types that the data can be
    /// converted to and provides the mechanism for transferring the
    /// data directly from the source client.
    /// </summary>
    public sealed unsafe partial class WlDataOffer : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlDataOffer()
        {
            WlInterface.Init("wl_data_offer", 3, new WlMessage[] {
                WlMessage.Create("accept", "u?s", new WlInterface*[] { null, null }),
                WlMessage.Create("receive", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("finish", "3", new WlInterface*[] { }),
                WlMessage.Create("set_actions", "3uu", new WlInterface*[] { null, null })
            }, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null }),
                WlMessage.Create("source_actions", "3u", new WlInterface*[] { null }),
                WlMessage.Create("action", "3u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataOffer.WlInterface);
        }

        /// <summary>
        /// Indicate that the client can accept the given mime type, or
        /// NULL for not accepted.
        /// 
        /// For objects of version 2 or older, this request is used by the
        /// client to give feedback whether the client can receive the given
        /// mime type, or NULL if none is accepted; the feedback does not
        /// determine whether the drag-and-drop operation succeeds or not.
        /// 
        /// For objects of version 3 or newer, this request determines the
        /// final result of the drag-and-drop operation. If the end result
        /// is that no mime types were accepted, the drag-and-drop operation
        /// will be cancelled and the corresponding drag source will receive
        /// wl_data_source.cancelled. Clients may still use this event in
        /// conjunction with wl_data_source.action for feedback.
        /// </summary>
        public void Accept(uint @serial, System.String @mimeType)
        {
            if (@mimeType == null)
                throw new System.ArgumentNullException("mimeType");
            using var __marshalled__mimeType = new NWayland.Interop.NWaylandMarshalledString(@mimeType);
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                __marshalled__mimeType
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// To transfer the offered data, the client issues this request
        /// and indicates the mime type it wants to receive.  The transfer
        /// happens through the passed file descriptor (typically created
        /// with the pipe system call).  The source client writes the data
        /// in the mime type representation requested and then closes the
        /// file descriptor.
        /// 
        /// The receiving client reads from the read end of the pipe until
        /// EOF and then closes its end, at which point the transfer is
        /// complete.
        /// 
        /// This request may happen multiple times for different mime types,
        /// both before and after wl_data_device.drop. Drag-and-drop destination
        /// clients may preemptively fetch data or examine it more closely to
        /// determine acceptance.
        /// </summary>
        public void Receive(System.String @mimeType, int @fd)
        {
            if (@mimeType == null)
                throw new System.ArgumentNullException("mimeType");
            using var __marshalled__mimeType = new NWayland.Interop.NWaylandMarshalledString(@mimeType);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__mimeType,
                @fd
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Notifies the compositor that the drag destination successfully
        /// finished the drag-and-drop operation.
        /// 
        /// Upon receiving this request, the compositor will emit
        /// wl_data_source.dnd_finished on the drag source client.
        /// 
        /// It is a client error to perform other requests than
        /// wl_data_offer.destroy after this one. It is also an error to perform
        /// this request after a NULL mime type has been set in
        /// wl_data_offer.accept or no action was received through
        /// wl_data_offer.action.
        /// 
        /// If wl_data_offer.finish request is received for a non drag and drop
        /// operation, the invalid_finish protocol error is raised.
        /// </summary>
        public void Finish()
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request finish is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Sets the actions that the destination side client supports for
        /// this operation. This request may trigger the emission of
        /// wl_data_source.action and wl_data_offer.action events if the compositor
        /// needs to change the selected action.
        /// 
        /// This request can be called multiple times throughout the
        /// drag-and-drop operation, typically in response to wl_data_device.enter
        /// or wl_data_device.motion events.
        /// 
        /// This request determines the final result of the drag-and-drop
        /// operation. If the end result is that no action is accepted,
        /// the drag source will receive wl_data_source.cancelled.
        /// 
        /// The dnd_actions argument must contain only values expressed in the
        /// wl_data_device_manager.dnd_actions enum, and the preferred_action
        /// argument must only contain one of those values set, otherwise it
        /// will result in a protocol error.
        /// 
        /// While managing an "ask" action, the destination drag-and-drop client
        /// may perform further wl_data_offer.receive requests, and is expected
        /// to perform one last wl_data_offer.set_actions request with a preferred
        /// action other than "ask" (and optionally wl_data_offer.accept) before
        /// requesting wl_data_offer.finish, in order to convey the action selected
        /// by the user. If the preferred action is not in the
        /// wl_data_offer.source_actions mask, an error will be raised.
        /// 
        /// If the "ask" action is dismissed (e.g. user cancellation), the client
        /// is expected to perform wl_data_offer.destroy right away.
        /// 
        /// This request can only be made on drag-and-drop offers, a protocol error
        /// will be raised otherwise.
        /// </summary>
        public void SetActions(NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @dndActions, NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @preferredAction)
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request set_actions is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@dndActions,
                (uint)@preferredAction
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        public interface IEvents
        {
            void OnOffer(NWayland.Protocols.Wayland.WlDataOffer eventSender, System.String @mimeType);
            void OnSourceActions(NWayland.Protocols.Wayland.WlDataOffer eventSender, NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @sourceActions);
            void OnAction(NWayland.Protocols.Wayland.WlDataOffer eventSender, NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @dndAction);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnOffer(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnSourceActions(this, (NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum)arguments[0].UInt32);
            if (opcode == 2)
                Events?.OnAction(this, (NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum)arguments[0].UInt32);
        }

        public enum ErrorEnum
        {
            /// <summary>finish request was called untimely</summary>
            InvalidFinish = 0,
            /// <summary>action mask contains invalid values</summary>
            InvalidActionMask = 1,
            /// <summary>action argument has an invalid value</summary>
            InvalidAction = 2,
            /// <summary>offer doesn't accept this request</summary>
            InvalidOffer = 3
        }

        class ProxyFactory : IBindFactory<WlDataOffer>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataOffer.WlInterface);
            }

            public WlDataOffer Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlDataOffer(handle, version, display);
            }
        }

        public static IBindFactory<WlDataOffer> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_data_offer";
        public const int InterfaceVersion = 3;

        public WlDataOffer(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_data_source object is the source side of a wl_data_offer.
    /// It is created by the source client in a data transfer and
    /// provides a way to describe the offered data and a way to respond
    /// to requests to transfer the data.
    /// </summary>
    public sealed unsafe partial class WlDataSource : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlDataSource()
        {
            WlInterface.Init("wl_data_source", 3, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_actions", "3u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("target", "?s", new WlInterface*[] { null }),
                WlMessage.Create("send", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("cancelled", "", new WlInterface*[] { }),
                WlMessage.Create("dnd_drop_performed", "3", new WlInterface*[] { }),
                WlMessage.Create("dnd_finished", "3", new WlInterface*[] { }),
                WlMessage.Create("action", "3u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataSource.WlInterface);
        }

        /// <summary>
        /// This request adds a mime type to the set of mime types
        /// advertised to targets.  Can be called several times to offer
        /// multiple types.
        /// </summary>
        public void Offer(System.String @mimeType)
        {
            if (@mimeType == null)
                throw new System.ArgumentNullException("mimeType");
            using var __marshalled__mimeType = new NWayland.Interop.NWaylandMarshalledString(@mimeType);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__mimeType
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Sets the actions that the source side client supports for this
        /// operation. This request may trigger wl_data_source.action and
        /// wl_data_offer.action events if the compositor needs to change the
        /// selected action.
        /// 
        /// The dnd_actions argument must contain only values expressed in the
        /// wl_data_device_manager.dnd_actions enum, otherwise it will result
        /// in a protocol error.
        /// 
        /// This request must be made once only, and can only be made on sources
        /// used in drag-and-drop, so it must be performed before
        /// wl_data_device.start_drag. Attempting to use the source other than
        /// for drag-and-drop will raise a protocol error.
        /// </summary>
        public void SetActions(NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @dndActions)
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request set_actions is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@dndActions
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnTarget(NWayland.Protocols.Wayland.WlDataSource eventSender, System.String @mimeType);
            void OnSend(NWayland.Protocols.Wayland.WlDataSource eventSender, System.String @mimeType, int @fd);
            void OnCancelled(NWayland.Protocols.Wayland.WlDataSource eventSender);
            void OnDndDropPerformed(NWayland.Protocols.Wayland.WlDataSource eventSender);
            void OnDndFinished(NWayland.Protocols.Wayland.WlDataSource eventSender);
            void OnAction(NWayland.Protocols.Wayland.WlDataSource eventSender, NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum @dndAction);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTarget(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnSend(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].Int32);
            if (opcode == 2)
                Events?.OnCancelled(this);
            if (opcode == 3)
                Events?.OnDndDropPerformed(this);
            if (opcode == 4)
                Events?.OnDndFinished(this);
            if (opcode == 5)
                Events?.OnAction(this, (NWayland.Protocols.Wayland.WlDataDeviceManager.DndActionEnum)arguments[0].UInt32);
        }

        public enum ErrorEnum
        {
            /// <summary>action mask contains invalid values</summary>
            InvalidActionMask = 0,
            /// <summary>source doesn't accept this request</summary>
            InvalidSource = 1
        }

        class ProxyFactory : IBindFactory<WlDataSource>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataSource.WlInterface);
            }

            public WlDataSource Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlDataSource(handle, version, display);
            }
        }

        public static IBindFactory<WlDataSource> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_data_source";
        public const int InterfaceVersion = 3;

        public WlDataSource(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// There is one wl_data_device per seat which can be obtained
    /// from the global wl_data_device_manager singleton.
    /// 
    /// A wl_data_device provides access to inter-client data transfer
    /// mechanisms such as copy-and-paste and drag-and-drop.
    /// </summary>
    public sealed unsafe partial class WlDataDevice : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlDataDevice()
        {
            WlInterface.Init("wl_data_device", 3, new WlMessage[] {
                WlMessage.Create("start_drag", "?oo?ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataSource.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null }),
                WlMessage.Create("set_selection", "?ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataSource.WlInterface), null }),
                WlMessage.Create("release", "2", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("data_offer", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataOffer.WlInterface) }),
                WlMessage.Create("enter", "uoff?o", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataOffer.WlInterface) }),
                WlMessage.Create("leave", "", new WlInterface*[] { }),
                WlMessage.Create("motion", "uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("drop", "", new WlInterface*[] { }),
                WlMessage.Create("selection", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataOffer.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataDevice.WlInterface);
        }

        /// <summary>
        /// This request asks the compositor to start a drag-and-drop
        /// operation on behalf of the client.
        /// 
        /// The source argument is the data source that provides the data
        /// for the eventual data transfer. If source is NULL, enter, leave
        /// and motion events are sent only to the client that initiated the
        /// drag and the client is expected to handle the data passing
        /// internally. If source is destroyed, the drag-and-drop session will be
        /// cancelled.
        /// 
        /// The origin surface is the surface where the drag originates and
        /// the client must have an active implicit grab that matches the
        /// serial.
        /// 
        /// The icon surface is an optional (can be NULL) surface that
        /// provides an icon to be moved around with the cursor.  Initially,
        /// the top-left corner of the icon surface is placed at the cursor
        /// hotspot, but subsequent wl_surface.attach request can move the
        /// relative position. Attach requests must be confirmed with
        /// wl_surface.commit as usual. The icon surface is given the role of
        /// a drag-and-drop icon. If the icon surface already has another role,
        /// it raises a protocol error.
        /// 
        /// The current and pending input regions of the icon wl_surface are
        /// cleared, and wl_surface.set_input_region is ignored until the
        /// wl_surface is no longer used as the icon surface. When the use
        /// as an icon ends, the current and pending input regions become
        /// undefined, and the wl_surface is unmapped.
        /// </summary>
        public void StartDrag(NWayland.Protocols.Wayland.WlDataSource @source, NWayland.Protocols.Wayland.WlSurface @origin, NWayland.Protocols.Wayland.WlSurface @icon, uint @serial)
        {
            if (@icon == null)
                throw new System.ArgumentNullException("icon");
            if (@origin == null)
                throw new System.ArgumentNullException("origin");
            if (@source == null)
                throw new System.ArgumentNullException("source");
            WlArgument* __args = stackalloc WlArgument[] {
                @source,
                @origin,
                @icon,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This request asks the compositor to set the selection
        /// to the data from the source on behalf of the client.
        /// 
        /// To unset the selection, set the source to NULL.
        /// </summary>
        public void SetSelection(NWayland.Protocols.Wayland.WlDataSource @source, uint @serial)
        {
            if (@source == null)
                throw new System.ArgumentNullException("source");
            WlArgument* __args = stackalloc WlArgument[] {
                @source,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 2)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnDataOffer(NWayland.Protocols.Wayland.WlDataDevice eventSender, WlDataOffer @id);
            void OnEnter(NWayland.Protocols.Wayland.WlDataDevice eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface, int @x, int @y, NWayland.Protocols.Wayland.WlDataOffer @id);
            void OnLeave(NWayland.Protocols.Wayland.WlDataDevice eventSender);
            void OnMotion(NWayland.Protocols.Wayland.WlDataDevice eventSender, uint @time, int @x, int @y);
            void OnDrop(NWayland.Protocols.Wayland.WlDataDevice eventSender);
            void OnSelection(NWayland.Protocols.Wayland.WlDataDevice eventSender, NWayland.Protocols.Wayland.WlDataOffer @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDataOffer(this, new WlDataOffer(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnEnter(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr), arguments[2].Int32, arguments[3].Int32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlDataOffer>(arguments[4].IntPtr));
            if (opcode == 2)
                Events?.OnLeave(this);
            if (opcode == 3)
                Events?.OnMotion(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32);
            if (opcode == 4)
                Events?.OnDrop(this);
            if (opcode == 5)
                Events?.OnSelection(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlDataOffer>(arguments[0].IntPtr));
        }

        public enum ErrorEnum
        {
            /// <summary>given wl_surface has another role</summary>
            Role = 0
        }

        class ProxyFactory : IBindFactory<WlDataDevice>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataDevice.WlInterface);
            }

            public WlDataDevice Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlDataDevice(handle, version, display);
            }
        }

        public static IBindFactory<WlDataDevice> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_data_device";
        public const int InterfaceVersion = 3;

        public WlDataDevice(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_data_device_manager is a singleton global object that
    /// provides access to inter-client data transfer mechanisms such as
    /// copy-and-paste and drag-and-drop.  These mechanisms are tied to
    /// a wl_seat and this interface lets a client get a wl_data_device
    /// corresponding to a wl_seat.
    /// 
    /// Depending on the version bound, the objects created from the bound
    /// wl_data_device_manager object will have different requirements for
    /// functioning properly. See wl_data_source.set_actions,
    /// wl_data_offer.accept and wl_data_offer.finish for details.
    /// </summary>
    public sealed unsafe partial class WlDataDeviceManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlDataDeviceManager()
        {
            WlInterface.Init("wl_data_device_manager", 3, new WlMessage[] {
                WlMessage.Create("create_data_source", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataSource.WlInterface) }),
                WlMessage.Create("get_data_device", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataDevice.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataDeviceManager.WlInterface);
        }

        /// <summary>
        /// Create a new data source.
        /// </summary>
        public NWayland.Protocols.Wayland.WlDataSource CreateDataSource()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlDataSource.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlDataSource(__ret, Version, Display);
        }

        /// <summary>
        /// Create a new data device for a given seat.
        /// </summary>
        public NWayland.Protocols.Wayland.WlDataDevice GetDataDevice(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wayland.WlDataDevice.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlDataDevice(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        [System.Flags]
        /// <summary>
        /// This is a bitmask of the available/preferred actions in a
        /// drag-and-drop operation.
        /// 
        /// In the compositor, the selected action is a result of matching the
        /// actions offered by the source and destination sides.  "action" events
        /// with a "none" action will be sent to both source and destination if
        /// there is no match. All further checks will effectively happen on
        /// (source actions ∩ destination actions).
        /// 
        /// In addition, compositors may also pick different actions in
        /// reaction to key modifiers being pressed. One common design that
        /// is used in major toolkits (and the behavior recommended for
        /// compositors) is:
        /// 
        /// - If no modifiers are pressed, the first match (in bit order)
        /// will be used.
        /// - Pressing Shift selects "move", if enabled in the mask.
        /// - Pressing Control selects "copy", if enabled in the mask.
        /// 
        /// Behavior beyond that is considered implementation-dependent.
        /// Compositors may for example bind other modifiers (like Alt/Meta)
        /// or drags initiated with other buttons than BTN_LEFT to specific
        /// actions (e.g. "ask").
        /// </summary>
        public enum DndActionEnum
        {
            /// <summary>no action</summary>
            None = 0,
            /// <summary>copy action</summary>
            Copy = 1,
            /// <summary>move action</summary>
            Move = 2,
            /// <summary>ask action</summary>
            Ask = 4
        }

        class ProxyFactory : IBindFactory<WlDataDeviceManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlDataDeviceManager.WlInterface);
            }

            public WlDataDeviceManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlDataDeviceManager(handle, version, display);
            }
        }

        public static IBindFactory<WlDataDeviceManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_data_device_manager";
        public const int InterfaceVersion = 3;

        public WlDataDeviceManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface is implemented by servers that provide
    /// desktop-style user interfaces.
    /// 
    /// It allows clients to associate a wl_shell_surface with
    /// a basic surface.
    /// 
    /// Note! This protocol is deprecated and not intended for production use.
    /// For desktop-style user interfaces, use xdg_shell. Compositors and clients
    /// should not implement this interface.
    /// </summary>
    public sealed unsafe partial class WlShell : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlShell()
        {
            WlInterface.Init("wl_shell", 1, new WlMessage[] {
                WlMessage.Create("get_shell_surface", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShellSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShell.WlInterface);
        }

        /// <summary>
        /// Create a shell surface for an existing surface. This gives
        /// the wl_surface the role of a shell surface. If the wl_surface
        /// already has another role, it raises a protocol error.
        /// 
        /// Only one shell surface can be associated with a given surface.
        /// </summary>
        public NWayland.Protocols.Wayland.WlShellSurface GetShellSurface(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlShellSurface.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlShellSurface(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary>given wl_surface has another role</summary>
            Role = 0
        }

        class ProxyFactory : IBindFactory<WlShell>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShell.WlInterface);
            }

            public WlShell Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlShell(handle, version, display);
            }
        }

        public static IBindFactory<WlShell> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_shell";
        public const int InterfaceVersion = 1;

        public WlShell(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An interface that may be implemented by a wl_surface, for
    /// implementations that provide a desktop-style user interface.
    /// 
    /// It provides requests to treat surfaces like toplevel, fullscreen
    /// or popup windows, move, resize or maximize them, associate
    /// metadata like title and class, etc.
    /// 
    /// On the server side the object is automatically destroyed when
    /// the related wl_surface is destroyed. On the client side,
    /// wl_shell_surface_destroy() must be called before destroying
    /// the wl_surface object.
    /// </summary>
    public sealed unsafe partial class WlShellSurface : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlShellSurface()
        {
            WlInterface.Init("wl_shell_surface", 1, new WlMessage[] {
                WlMessage.Create("pong", "u", new WlInterface*[] { null }),
                WlMessage.Create("move", "ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null }),
                WlMessage.Create("resize", "ouu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null, null }),
                WlMessage.Create("set_toplevel", "", new WlInterface*[] { }),
                WlMessage.Create("set_transient", "oiiu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null }),
                WlMessage.Create("set_fullscreen", "uu?o", new WlInterface*[] { null, null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("set_popup", "ouoiiu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null }),
                WlMessage.Create("set_maximized", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("set_title", "s", new WlInterface*[] { null }),
                WlMessage.Create("set_class", "s", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("ping", "u", new WlInterface*[] { null }),
                WlMessage.Create("configure", "uii", new WlInterface*[] { null, null, null }),
                WlMessage.Create("popup_done", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShellSurface.WlInterface);
        }

        /// <summary>
        /// A client must respond to a ping event with a pong request or
        /// the client may be deemed unresponsive.
        /// </summary>
        public void Pong(uint @serial)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Start a pointer-driven move of the surface.
        /// 
        /// This request must be used in response to a button press event.
        /// The server may ignore move requests depending on the state of
        /// the surface (e.g. fullscreen or maximized).
        /// </summary>
        public void Move(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Start a pointer-driven resizing of the surface.
        /// 
        /// This request must be used in response to a button press event.
        /// The server may ignore resize requests depending on the state of
        /// the surface (e.g. fullscreen or maximized).
        /// </summary>
        public void Resize(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial, ResizeEnum @edges)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial,
                (uint)@edges
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Map the surface as a toplevel surface.
        /// 
        /// A toplevel surface is not fullscreen, maximized or transient.
        /// </summary>
        public void SetToplevel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Map the surface relative to an existing surface.
        /// 
        /// The x and y arguments specify the location of the upper left
        /// corner of the surface relative to the upper left corner of the
        /// parent surface, in surface-local coordinates.
        /// 
        /// The flags argument controls details of the transient behaviour.
        /// </summary>
        public void SetTransient(NWayland.Protocols.Wayland.WlSurface @parent, int @x, int @y, TransientEnum @flags)
        {
            if (@parent == null)
                throw new System.ArgumentNullException("parent");
            WlArgument* __args = stackalloc WlArgument[] {
                @parent,
                @x,
                @y,
                (uint)@flags
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Map the surface as a fullscreen surface.
        /// 
        /// If an output parameter is given then the surface will be made
        /// fullscreen on that output. If the client does not specify the
        /// output then the compositor will apply its policy - usually
        /// choosing the output on which the surface has the biggest surface
        /// area.
        /// 
        /// The client may specify a method to resolve a size conflict
        /// between the output size and the surface size - this is provided
        /// through the method parameter.
        /// 
        /// The framerate parameter is used only when the method is set
        /// to "driver", to indicate the preferred framerate. A value of 0
        /// indicates that the client does not care about framerate.  The
        /// framerate is specified in mHz, that is framerate of 60000 is 60Hz.
        /// 
        /// A method of "scale" or "driver" implies a scaling operation of
        /// the surface, either via a direct scaling operation or a change of
        /// the output mode. This will override any kind of output scaling, so
        /// that mapping a surface with a buffer size equal to the mode can
        /// fill the screen independent of buffer_scale.
        /// 
        /// A method of "fill" means we don't scale up the buffer, however
        /// any output scale is applied. This means that you may run into
        /// an edge case where the application maps a buffer with the same
        /// size of the output mode but buffer_scale 1 (thus making a
        /// surface larger than the output). In this case it is allowed to
        /// downscale the results to fit the screen.
        /// 
        /// The compositor must reply to this request with a configure event
        /// with the dimensions for the output on which the surface will
        /// be made fullscreen.
        /// </summary>
        public void SetFullscreen(FullscreenMethodEnum @method, uint @framerate, NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@method,
                @framerate,
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Map the surface as a popup.
        /// 
        /// A popup surface is a transient surface with an added pointer
        /// grab.
        /// 
        /// An existing implicit grab will be changed to owner-events mode,
        /// and the popup grab will continue after the implicit grab ends
        /// (i.e. releasing the mouse button does not cause the popup to
        /// be unmapped).
        /// 
        /// The popup grab continues until the window is destroyed or a
        /// mouse button is pressed in any other client's window. A click
        /// in any of the client's surfaces is reported as normal, however,
        /// clicks in other clients' surfaces will be discarded and trigger
        /// the callback.
        /// 
        /// The x and y arguments specify the location of the upper left
        /// corner of the surface relative to the upper left corner of the
        /// parent surface, in surface-local coordinates.
        /// </summary>
        public void SetPopup(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial, NWayland.Protocols.Wayland.WlSurface @parent, int @x, int @y, TransientEnum @flags)
        {
            if (@parent == null)
                throw new System.ArgumentNullException("parent");
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial,
                @parent,
                @x,
                @y,
                (uint)@flags
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Map the surface as a maximized surface.
        /// 
        /// If an output parameter is given then the surface will be
        /// maximized on that output. If the client does not specify the
        /// output then the compositor will apply its policy - usually
        /// choosing the output on which the surface has the biggest surface
        /// area.
        /// 
        /// The compositor will reply with a configure event telling
        /// the expected new surface size. The operation is completed
        /// on the next buffer attach to this surface.
        /// 
        /// A maximized surface typically fills the entire output it is
        /// bound to, except for desktop elements such as panels. This is
        /// the main difference between a maximized shell surface and a
        /// fullscreen shell surface.
        /// 
        /// The details depend on the compositor implementation.
        /// </summary>
        public void SetMaximized(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// Set a short title for the surface.
        /// 
        /// This string may be used to identify the surface in a task bar,
        /// window list, or other user interface elements provided by the
        /// compositor.
        /// 
        /// The string must be encoded in UTF-8.
        /// </summary>
        public void SetTitle(System.String @title)
        {
            if (@title == null)
                throw new System.ArgumentNullException("title");
            using var __marshalled__title = new NWayland.Interop.NWaylandMarshalledString(@title);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__title
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Set a class for the surface.
        /// 
        /// The surface class identifies the general class of applications
        /// to which the surface belongs. A common convention is to use the
        /// file name (or the full path if it is a non-standard location) of
        /// the application's .desktop file as the class.
        /// </summary>
        public void SetClass(System.String @class)
        {
            if (@class == null)
                throw new System.ArgumentNullException("class");
            using var __marshalled__class = new NWayland.Interop.NWaylandMarshalledString(@class);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__class
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public interface IEvents
        {
            void OnPing(NWayland.Protocols.Wayland.WlShellSurface eventSender, uint @serial);
            void OnConfigure(NWayland.Protocols.Wayland.WlShellSurface eventSender, ResizeEnum @edges, int @width, int @height);
            void OnPopupDone(NWayland.Protocols.Wayland.WlShellSurface eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnPing(this, arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnConfigure(this, (ResizeEnum)arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32);
            if (opcode == 2)
                Events?.OnPopupDone(this);
        }

        [System.Flags]
        /// <summary>
        /// These values are used to indicate which edge of a surface
        /// is being dragged in a resize operation. The server may
        /// use this information to adapt its behavior, e.g. choose
        /// an appropriate cursor image.
        /// </summary>
        public enum ResizeEnum
        {
            /// <summary>no edge</summary>
            None = 0,
            /// <summary>top edge</summary>
            Top = 1,
            /// <summary>bottom edge</summary>
            Bottom = 2,
            /// <summary>left edge</summary>
            Left = 4,
            /// <summary>top and left edges</summary>
            TopLeft = 5,
            /// <summary>bottom and left edges</summary>
            BottomLeft = 6,
            /// <summary>right edge</summary>
            Right = 8,
            /// <summary>top and right edges</summary>
            TopRight = 9,
            /// <summary>bottom and right edges</summary>
            BottomRight = 10
        }

        [System.Flags]
        /// <summary>
        /// These flags specify details of the expected behaviour
        /// of transient surfaces. Used in the set_transient request.
        /// </summary>
        public enum TransientEnum
        {
            /// <summary>do not set keyboard focus</summary>
            Inactive = 0x1
        }

        /// <summary>
        /// Hints to indicate to the compositor how to deal with a conflict
        /// between the dimensions of the surface and the dimensions of the
        /// output. The compositor is free to ignore this parameter.
        /// </summary>
        public enum FullscreenMethodEnum
        {
            /// <summary>no preference, apply default policy</summary>
            Default = 0,
            /// <summary>scale, preserve the surface's aspect ratio and center on output</summary>
            Scale = 1,
            /// <summary>switch output mode to the smallest mode that can fit the surface, add black borders to compensate size mismatch</summary>
            Driver = 2,
            /// <summary>no upscaling, center on output and add black borders to compensate size mismatch</summary>
            Fill = 3
        }

        class ProxyFactory : IBindFactory<WlShellSurface>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlShellSurface.WlInterface);
            }

            public WlShellSurface Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlShellSurface(handle, version, display);
            }
        }

        public static IBindFactory<WlShellSurface> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_shell_surface";
        public const int InterfaceVersion = 1;

        public WlShellSurface(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A surface is a rectangular area that may be displayed on zero
    /// or more outputs, and shown any number of times at the compositor's
    /// discretion. They can present wl_buffers, receive user input, and
    /// define a local coordinate system.
    /// 
    /// The size of a surface (and relative positions on it) is described
    /// in surface-local coordinates, which may differ from the buffer
    /// coordinates of the pixel content, in case a buffer_transform
    /// or a buffer_scale is used.
    /// 
    /// A surface without a "role" is fairly useless: a compositor does
    /// not know where, when or how to present it. The role is the
    /// purpose of a wl_surface. Examples of roles are a cursor for a
    /// pointer (as set by wl_pointer.set_cursor), a drag icon
    /// (wl_data_device.start_drag), a sub-surface
    /// (wl_subcompositor.get_subsurface), and a window as defined by a
    /// shell protocol (e.g. wl_shell.get_shell_surface).
    /// 
    /// A surface can have only one role at a time. Initially a
    /// wl_surface does not have a role. Once a wl_surface is given a
    /// role, it is set permanently for the whole lifetime of the
    /// wl_surface object. Giving the current role again is allowed,
    /// unless explicitly forbidden by the relevant interface
    /// specification.
    /// 
    /// Surface roles are given by requests in other interfaces such as
    /// wl_pointer.set_cursor. The request should explicitly mention
    /// that this request gives a role to a wl_surface. Often, this
    /// request also creates a new protocol object that represents the
    /// role and adds additional functionality to wl_surface. When a
    /// client wants to destroy a wl_surface, they must destroy this 'role
    /// object' before the wl_surface.
    /// 
    /// Destroying the role object does not remove the role from the
    /// wl_surface, but it may stop the wl_surface from "playing the role".
    /// For instance, if a wl_subsurface object is destroyed, the wl_surface
    /// it was created for will be unmapped and forget its position and
    /// z-order. It is allowed to create a wl_subsurface for the same
    /// wl_surface again, but it is not allowed to use the wl_surface as
    /// a cursor (cursor is a different role than sub-surface, and role
    /// switching is not allowed).
    /// </summary>
    public sealed unsafe partial class WlSurface : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlSurface()
        {
            WlInterface.Init("wl_surface", 4, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("attach", "?oii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface), null, null }),
                WlMessage.Create("damage", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("frame", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlCallback.WlInterface) }),
                WlMessage.Create("set_opaque_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) }),
                WlMessage.Create("set_input_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) }),
                WlMessage.Create("commit", "", new WlInterface*[] { }),
                WlMessage.Create("set_buffer_transform", "2i", new WlInterface*[] { null }),
                WlMessage.Create("set_buffer_scale", "3i", new WlInterface*[] { null }),
                WlMessage.Create("damage_buffer", "4iiii", new WlInterface*[] { null, null, null, null })
            }, new WlMessage[] {
                WlMessage.Create("enter", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("leave", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set a buffer as the content of this surface.
        /// 
        /// The new size of the surface is calculated based on the buffer
        /// size transformed by the inverse buffer_transform and the
        /// inverse buffer_scale. This means that at commit time the supplied
        /// buffer size must be an integer multiple of the buffer_scale. If
        /// that's not the case, an invalid_size error is sent.
        /// 
        /// The x and y arguments specify the location of the new pending
        /// buffer's upper left corner, relative to the current buffer's upper
        /// left corner, in surface-local coordinates. In other words, the
        /// x and y, combined with the new surface size define in which
        /// directions the surface's size changes. Setting anything other than 0
        /// as x and y arguments is discouraged, and should instead be replaced
        /// with using the separate wl_surface.offset request.
        /// 
        /// When the bound wl_surface version is 5 or higher, passing any
        /// non-zero x or y is a protocol violation, and will result in an
        /// 'invalid_offset' error being raised. To achieve equivalent semantics,
        /// use wl_surface.offset.
        /// 
        /// Surface contents are double-buffered state, see wl_surface.commit.
        /// 
        /// The initial surface contents are void; there is no content.
        /// wl_surface.attach assigns the given wl_buffer as the pending
        /// wl_buffer. wl_surface.commit makes the pending wl_buffer the new
        /// surface contents, and the size of the surface becomes the size
        /// calculated from the wl_buffer, as described above. After commit,
        /// there is no pending buffer until the next attach.
        /// 
        /// Committing a pending wl_buffer allows the compositor to read the
        /// pixels in the wl_buffer. The compositor may access the pixels at
        /// any time after the wl_surface.commit request. When the compositor
        /// will not access the pixels anymore, it will send the
        /// wl_buffer.release event. Only after receiving wl_buffer.release,
        /// the client may reuse the wl_buffer. A wl_buffer that has been
        /// attached and then replaced by another attach instead of committed
        /// will not receive a release event, and is not used by the
        /// compositor.
        /// 
        /// If a pending wl_buffer has been committed to more than one wl_surface,
        /// the delivery of wl_buffer.release events becomes undefined. A well
        /// behaved client should not rely on wl_buffer.release events in this
        /// case. Alternatively, a client could create multiple wl_buffer objects
        /// from the same backing storage or use wp_linux_buffer_release.
        /// 
        /// Destroying the wl_buffer after wl_buffer.release does not change
        /// the surface contents. Destroying the wl_buffer before wl_buffer.release
        /// is allowed as long as the underlying buffer storage isn't re-used (this
        /// can happen e.g. on client process termination). However, if the client
        /// destroys the wl_buffer before receiving the wl_buffer.release event and
        /// mutates the underlying buffer storage, the surface contents become
        /// undefined immediately.
        /// 
        /// If wl_surface.attach is sent with a NULL wl_buffer, the
        /// following wl_surface.commit will remove the surface content.
        /// </summary>
        public void Attach(NWayland.Protocols.Wayland.WlBuffer @buffer, int @x, int @y)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This request is used to describe the regions where the pending
        /// buffer is different from the current surface contents, and where
        /// the surface therefore needs to be repainted. The compositor
        /// ignores the parts of the damage that fall outside of the surface.
        /// 
        /// Damage is double-buffered state, see wl_surface.commit.
        /// 
        /// The damage rectangle is specified in surface-local coordinates,
        /// where x and y specify the upper left corner of the damage rectangle.
        /// 
        /// The initial value for pending damage is empty: no damage.
        /// wl_surface.damage adds pending damage: the new pending damage
        /// is the union of old pending damage and the given rectangle.
        /// 
        /// wl_surface.commit assigns pending damage as the current damage,
        /// and clears pending damage. The server will clear the current
        /// damage as it repaints the surface.
        /// 
        /// Note! New clients should not use this request. Instead damage can be
        /// posted with wl_surface.damage_buffer which uses buffer coordinates
        /// instead of surface coordinates.
        /// </summary>
        public void Damage(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Request a notification when it is a good time to start drawing a new
        /// frame, by creating a frame callback. This is useful for throttling
        /// redrawing operations, and driving animations.
        /// 
        /// When a client is animating on a wl_surface, it can use the 'frame'
        /// request to get notified when it is a good time to draw and commit the
        /// next frame of animation. If the client commits an update earlier than
        /// that, it is likely that some updates will not make it to the display,
        /// and the client is wasting resources by drawing too often.
        /// 
        /// The frame request will take effect on the next wl_surface.commit.
        /// The notification will only be posted for one frame unless
        /// requested again. For a wl_surface, the notifications are posted in
        /// the order the frame requests were committed.
        /// 
        /// The server must send the notifications so that a client
        /// will not send excessive updates, while still allowing
        /// the highest possible update rate for clients that wait for the reply
        /// before drawing again. The server should give some time for the client
        /// to draw and commit after sending the frame callback events to let it
        /// hit the next output refresh.
        /// 
        /// A server should avoid signaling the frame callbacks if the
        /// surface is not visible in any way, e.g. the surface is off-screen,
        /// or completely obscured by other opaque surfaces.
        /// 
        /// The object returned by this request will be destroyed by the
        /// compositor after the callback is fired and as such the client must not
        /// attempt to use it after that point.
        /// 
        /// The callback_data passed in the callback is the current time, in
        /// milliseconds, with an undefined base.
        /// </summary>
        public NWayland.Protocols.Wayland.WlCallback Frame()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 3, __args, ref NWayland.Protocols.Wayland.WlCallback.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlCallback(__ret, Version, Display);
        }

        /// <summary>
        /// This request sets the region of the surface that contains
        /// opaque content.
        /// 
        /// The opaque region is an optimization hint for the compositor
        /// that lets it optimize the redrawing of content behind opaque
        /// regions.  Setting an opaque region is not required for correct
        /// behaviour, but marking transparent content as opaque will result
        /// in repaint artifacts.
        /// 
        /// The opaque region is specified in surface-local coordinates.
        /// 
        /// The compositor ignores the parts of the opaque region that fall
        /// outside of the surface.
        /// 
        /// Opaque region is double-buffered state, see wl_surface.commit.
        /// 
        /// wl_surface.set_opaque_region changes the pending opaque region.
        /// wl_surface.commit copies the pending region to the current region.
        /// Otherwise, the pending and current regions are never changed.
        /// 
        /// The initial value for an opaque region is empty. Setting the pending
        /// opaque region has copy semantics, and the wl_region object can be
        /// destroyed immediately. A NULL wl_region causes the pending opaque
        /// region to be set to empty.
        /// </summary>
        public void SetOpaqueRegion(NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            WlArgument* __args = stackalloc WlArgument[] {
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// This request sets the region of the surface that can receive
        /// pointer and touch events.
        /// 
        /// Input events happening outside of this region will try the next
        /// surface in the server surface stack. The compositor ignores the
        /// parts of the input region that fall outside of the surface.
        /// 
        /// The input region is specified in surface-local coordinates.
        /// 
        /// Input region is double-buffered state, see wl_surface.commit.
        /// 
        /// wl_surface.set_input_region changes the pending input region.
        /// wl_surface.commit copies the pending region to the current region.
        /// Otherwise the pending and current regions are never changed,
        /// except cursor and icon surfaces are special cases, see
        /// wl_pointer.set_cursor and wl_data_device.start_drag.
        /// 
        /// The initial value for an input region is infinite. That means the
        /// whole surface will accept input. Setting the pending input region
        /// has copy semantics, and the wl_region object can be destroyed
        /// immediately. A NULL wl_region causes the input region to be set
        /// to infinite.
        /// </summary>
        public void SetInputRegion(NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            WlArgument* __args = stackalloc WlArgument[] {
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Surface state (input, opaque, and damage regions, attached buffers,
        /// etc.) is double-buffered. Protocol requests modify the pending state,
        /// as opposed to the current state in use by the compositor. A commit
        /// request atomically applies all pending state, replacing the current
        /// state. After commit, the new pending state is as documented for each
        /// related request.
        /// 
        /// On commit, a pending wl_buffer is applied first, and all other state
        /// second. This means that all coordinates in double-buffered state are
        /// relative to the new wl_buffer coming into use, except for
        /// wl_surface.attach itself. If there is no pending wl_buffer, the
        /// coordinates are relative to the current surface contents.
        /// 
        /// All requests that need a commit to become effective are documented
        /// to affect double-buffered state.
        /// 
        /// Other interfaces may add further double-buffered surface state.
        /// </summary>
        public void Commit()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// This request sets an optional transformation on how the compositor
        /// interprets the contents of the buffer attached to the surface. The
        /// accepted values for the transform parameter are the values for
        /// wl_output.transform.
        /// 
        /// Buffer transform is double-buffered state, see wl_surface.commit.
        /// 
        /// A newly created surface has its buffer transformation set to normal.
        /// 
        /// wl_surface.set_buffer_transform changes the pending buffer
        /// transformation. wl_surface.commit copies the pending buffer
        /// transformation to the current one. Otherwise, the pending and current
        /// values are never changed.
        /// 
        /// The purpose of this request is to allow clients to render content
        /// according to the output transform, thus permitting the compositor to
        /// use certain optimizations even if the display is rotated. Using
        /// hardware overlays and scanning out a client buffer for fullscreen
        /// surfaces are examples of such optimizations. Those optimizations are
        /// highly dependent on the compositor implementation, so the use of this
        /// request should be considered on a case-by-case basis.
        /// 
        /// Note that if the transform value includes 90 or 270 degree rotation,
        /// the width of the buffer will become the surface height and the height
        /// of the buffer will become the surface width.
        /// 
        /// If transform is not one of the values from the
        /// wl_output.transform enum the invalid_transform protocol error
        /// is raised.
        /// </summary>
        public void SetBufferTransform(NWayland.Protocols.Wayland.WlOutput.TransformEnum @transform)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request set_buffer_transform is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                (int)@transform
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// This request sets an optional scaling factor on how the compositor
        /// interprets the contents of the buffer attached to the window.
        /// 
        /// Buffer scale is double-buffered state, see wl_surface.commit.
        /// 
        /// A newly created surface has its buffer scale set to 1.
        /// 
        /// wl_surface.set_buffer_scale changes the pending buffer scale.
        /// wl_surface.commit copies the pending buffer scale to the current one.
        /// Otherwise, the pending and current values are never changed.
        /// 
        /// The purpose of this request is to allow clients to supply higher
        /// resolution buffer data for use on high resolution outputs. It is
        /// intended that you pick the same buffer scale as the scale of the
        /// output that the surface is displayed on. This means the compositor
        /// can avoid scaling when rendering the surface on that output.
        /// 
        /// Note that if the scale is larger than 1, then you have to attach
        /// a buffer that is larger (by a factor of scale in each dimension)
        /// than the desired surface size.
        /// 
        /// If scale is not positive the invalid_scale protocol error is
        /// raised.
        /// </summary>
        public void SetBufferScale(int @scale)
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request set_buffer_scale is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
                @scale
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// This request is used to describe the regions where the pending
        /// buffer is different from the current surface contents, and where
        /// the surface therefore needs to be repainted. The compositor
        /// ignores the parts of the damage that fall outside of the surface.
        /// 
        /// Damage is double-buffered state, see wl_surface.commit.
        /// 
        /// The damage rectangle is specified in buffer coordinates,
        /// where x and y specify the upper left corner of the damage rectangle.
        /// 
        /// The initial value for pending damage is empty: no damage.
        /// wl_surface.damage_buffer adds pending damage: the new pending
        /// damage is the union of old pending damage and the given rectangle.
        /// 
        /// wl_surface.commit assigns pending damage as the current damage,
        /// and clears pending damage. The server will clear the current
        /// damage as it repaints the surface.
        /// 
        /// This request differs from wl_surface.damage in only one way - it
        /// takes damage in buffer coordinates instead of surface-local
        /// coordinates. While this generally is more intuitive than surface
        /// coordinates, it is especially desirable when using wp_viewport
        /// or when a drawing library (like EGL) is unaware of buffer scale
        /// and buffer transform.
        /// 
        /// Note: Because buffer transformation changes and damage requests may
        /// be interleaved in the protocol stream, it is impossible to determine
        /// the actual mapping between surface and buffer damage until
        /// wl_surface.commit time. Therefore, compositors wishing to take both
        /// kinds of damage into account will have to accumulate damage from the
        /// two requests separately and only transform from one to the other
        /// after receiving the wl_surface.commit.
        /// </summary>
        public void DamageBuffer(int @x, int @y, int @width, int @height)
        {
            if (Version < 4)
                throw new System.InvalidOperationException("Request damage_buffer is only supported since version 4");
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        /// <summary>
        /// The x and y arguments specify the location of the new pending
        /// buffer's upper left corner, relative to the current buffer's upper
        /// left corner, in surface-local coordinates. In other words, the
        /// x and y, combined with the new surface size define in which
        /// directions the surface's size changes.
        /// 
        /// Surface location offset is double-buffered state, see
        /// wl_surface.commit.
        /// 
        /// This request is semantically equivalent to and the replaces the x and y
        /// arguments in the wl_surface.attach request in wl_surface versions prior
        /// to 5. See wl_surface.attach for details.
        /// </summary>
        public void Offset(int @x, int @y)
        {
            if (Version < 5)
                throw new System.InvalidOperationException("Request offset is only supported since version 5");
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        public interface IEvents
        {
            void OnEnter(NWayland.Protocols.Wayland.WlSurface eventSender, NWayland.Protocols.Wayland.WlOutput @output);
            void OnLeave(NWayland.Protocols.Wayland.WlSurface eventSender, NWayland.Protocols.Wayland.WlOutput @output);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnEnter(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnLeave(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
        }

        /// <summary>
        /// These errors can be emitted in response to wl_surface requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>buffer scale value is invalid</summary>
            InvalidScale = 0,
            /// <summary>buffer transform value is invalid</summary>
            InvalidTransform = 1,
            /// <summary>buffer size is invalid</summary>
            InvalidSize = 2,
            /// <summary>buffer offset is invalid</summary>
            InvalidOffset = 3
        }

        class ProxyFactory : IBindFactory<WlSurface>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface);
            }

            public WlSurface Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlSurface(handle, version, display);
            }
        }

        public static IBindFactory<WlSurface> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_surface";
        public const int InterfaceVersion = 4;

        public WlSurface(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A seat is a group of keyboards, pointer and touch devices. This
    /// object is published as a global during start up, or when such a
    /// device is hot plugged.  A seat typically has a pointer and
    /// maintains a keyboard focus and a pointer focus.
    /// </summary>
    public sealed unsafe partial class WlSeat : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlSeat()
        {
            WlInterface.Init("wl_seat", 7, new WlMessage[] {
                WlMessage.Create("get_pointer", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface) }),
                WlMessage.Create("get_keyboard", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface) }),
                WlMessage.Create("get_touch", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlTouch.WlInterface) }),
                WlMessage.Create("release", "5", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("capabilities", "u", new WlInterface*[] { null }),
                WlMessage.Create("name", "2s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface);
        }

        /// <summary>
        /// The ID provided will be initialized to the wl_pointer interface
        /// for this seat.
        /// 
        /// This request only takes effect if the seat has the pointer
        /// capability, or has had the pointer capability in the past.
        /// It is a protocol violation to issue this request on a seat that has
        /// never had the pointer capability. The missing_capability error will
        /// be sent in this case.
        /// </summary>
        public NWayland.Protocols.Wayland.WlPointer GetPointer()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wayland.WlPointer.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlPointer(__ret, Version, Display);
        }

        /// <summary>
        /// The ID provided will be initialized to the wl_keyboard interface
        /// for this seat.
        /// 
        /// This request only takes effect if the seat has the keyboard
        /// capability, or has had the keyboard capability in the past.
        /// It is a protocol violation to issue this request on a seat that has
        /// never had the keyboard capability. The missing_capability error will
        /// be sent in this case.
        /// </summary>
        public NWayland.Protocols.Wayland.WlKeyboard GetKeyboard()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlKeyboard(__ret, Version, Display);
        }

        /// <summary>
        /// The ID provided will be initialized to the wl_touch interface
        /// for this seat.
        /// 
        /// This request only takes effect if the seat has the touch
        /// capability, or has had the touch capability in the past.
        /// It is a protocol violation to issue this request on a seat that has
        /// never had the touch capability. The missing_capability error will
        /// be sent in this case.
        /// </summary>
        public NWayland.Protocols.Wayland.WlTouch GetTouch()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.Wayland.WlTouch.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlTouch(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 5)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public interface IEvents
        {
            void OnCapabilities(NWayland.Protocols.Wayland.WlSeat eventSender, CapabilityEnum @capabilities);
            void OnName(NWayland.Protocols.Wayland.WlSeat eventSender, System.String @name);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnCapabilities(this, (CapabilityEnum)arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnName(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        [System.Flags]
        /// <summary>
        /// This is a bitmask of capabilities this seat has; if a member is
        /// set, then it is present on the seat.
        /// </summary>
        public enum CapabilityEnum
        {
            /// <summary>the seat has pointer devices</summary>
            Pointer = 1,
            /// <summary>the seat has one or more keyboards</summary>
            Keyboard = 2,
            /// <summary>the seat has touch devices</summary>
            Touch = 4
        }

        /// <summary>
        /// These errors can be emitted in response to wl_seat requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>get_pointer, get_keyboard or get_touch called on seat without the matching capability</summary>
            MissingCapability = 0
        }

        class ProxyFactory : IBindFactory<WlSeat>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface);
            }

            public WlSeat Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlSeat(handle, version, display);
            }
        }

        public static IBindFactory<WlSeat> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_seat";
        public const int InterfaceVersion = 7;

        public WlSeat(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_pointer interface represents one or more input devices,
    /// such as mice, which control the pointer location and pointer_focus
    /// of a seat.
    /// 
    /// The wl_pointer interface generates motion, enter and leave
    /// events for the surfaces that the pointer is located over,
    /// and button and axis events for button presses, button releases
    /// and scrolling.
    /// </summary>
    public sealed unsafe partial class WlPointer : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlPointer()
        {
            WlInterface.Init("wl_pointer", 7, new WlMessage[] {
                WlMessage.Create("set_cursor", "u?oii", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null }),
                WlMessage.Create("release", "3", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("enter", "uoff", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null }),
                WlMessage.Create("leave", "uo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("motion", "uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("button", "uuuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("axis", "uuf", new WlInterface*[] { null, null, null }),
                WlMessage.Create("frame", "5", new WlInterface*[] { }),
                WlMessage.Create("axis_source", "5u", new WlInterface*[] { null }),
                WlMessage.Create("axis_stop", "5uu", new WlInterface*[] { null, null }),
                WlMessage.Create("axis_discrete", "5ui", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface);
        }

        /// <summary>
        /// Set the pointer surface, i.e., the surface that contains the
        /// pointer image (cursor). This request gives the surface the role
        /// of a cursor. If the surface already has another role, it raises
        /// a protocol error.
        /// 
        /// The cursor actually changes only if the pointer
        /// focus for this device is one of the requesting client's surfaces
        /// or the surface parameter is the current pointer surface. If
        /// there was a previous surface set with this request it is
        /// replaced. If surface is NULL, the pointer image is hidden.
        /// 
        /// The parameters hotspot_x and hotspot_y define the position of
        /// the pointer surface relative to the pointer location. Its
        /// top-left corner is always at (x, y) - (hotspot_x, hotspot_y),
        /// where (x, y) are the coordinates of the pointer location, in
        /// surface-local coordinates.
        /// 
        /// On surface.attach requests to the pointer surface, hotspot_x
        /// and hotspot_y are decremented by the x and y parameters
        /// passed to the request. Attach must be confirmed by
        /// wl_surface.commit as usual.
        /// 
        /// The hotspot can also be updated by passing the currently set
        /// pointer surface to this request with new values for hotspot_x
        /// and hotspot_y.
        /// 
        /// The current and pending input regions of the wl_surface are
        /// cleared, and wl_surface.set_input_region is ignored until the
        /// wl_surface is no longer used as the cursor. When the use as a
        /// cursor ends, the current and pending input regions become
        /// undefined, and the wl_surface is unmapped.
        /// 
        /// The serial parameter must match the latest wl_pointer.enter
        /// serial number sent to the client. Otherwise the request will be
        /// ignored.
        /// </summary>
        public void SetCursor(uint @serial, NWayland.Protocols.Wayland.WlSurface @surface, int @hotspotX, int @hotspotY)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @surface,
                @hotspotX,
                @hotspotY
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 3)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnEnter(NWayland.Protocols.Wayland.WlPointer eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface, int @surfaceX, int @surfaceY);
            void OnLeave(NWayland.Protocols.Wayland.WlPointer eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnMotion(NWayland.Protocols.Wayland.WlPointer eventSender, uint @time, int @surfaceX, int @surfaceY);
            void OnButton(NWayland.Protocols.Wayland.WlPointer eventSender, uint @serial, uint @time, uint @button, ButtonStateEnum @state);
            void OnAxis(NWayland.Protocols.Wayland.WlPointer eventSender, uint @time, AxisEnum @axis, int @value);
            void OnFrame(NWayland.Protocols.Wayland.WlPointer eventSender);
            void OnAxisSource(NWayland.Protocols.Wayland.WlPointer eventSender, AxisSourceEnum @axisSource);
            void OnAxisStop(NWayland.Protocols.Wayland.WlPointer eventSender, uint @time, AxisEnum @axis);
            void OnAxisDiscrete(NWayland.Protocols.Wayland.WlPointer eventSender, AxisEnum @axis, int @discrete);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnEnter(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr), arguments[2].Int32, arguments[3].Int32);
            if (opcode == 1)
                Events?.OnLeave(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr));
            if (opcode == 2)
                Events?.OnMotion(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32);
            if (opcode == 3)
                Events?.OnButton(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, (ButtonStateEnum)arguments[3].UInt32);
            if (opcode == 4)
                Events?.OnAxis(this, arguments[0].UInt32, (AxisEnum)arguments[1].UInt32, arguments[2].Int32);
            if (opcode == 5)
                Events?.OnFrame(this);
            if (opcode == 6)
                Events?.OnAxisSource(this, (AxisSourceEnum)arguments[0].UInt32);
            if (opcode == 7)
                Events?.OnAxisStop(this, arguments[0].UInt32, (AxisEnum)arguments[1].UInt32);
            if (opcode == 8)
                Events?.OnAxisDiscrete(this, (AxisEnum)arguments[0].UInt32, arguments[1].Int32);
        }

        public enum ErrorEnum
        {
            /// <summary>given wl_surface has another role</summary>
            Role = 0
        }

        /// <summary>
        /// Describes the physical state of a button that produced the button
        /// event.
        /// </summary>
        public enum ButtonStateEnum
        {
            /// <summary>the button is not pressed</summary>
            Released = 0,
            /// <summary>the button is pressed</summary>
            Pressed = 1
        }

        /// <summary>
        /// Describes the axis types of scroll events.
        /// </summary>
        public enum AxisEnum
        {
            /// <summary>vertical axis</summary>
            VerticalScroll = 0,
            /// <summary>horizontal axis</summary>
            HorizontalScroll = 1
        }

        /// <summary>
        /// Describes the source types for axis events. This indicates to the
        /// client how an axis event was physically generated; a client may
        /// adjust the user interface accordingly. For example, scroll events
        /// from a "finger" source may be in a smooth coordinate space with
        /// kinetic scrolling whereas a "wheel" source may be in discrete steps
        /// of a number of lines.
        /// 
        /// The "continuous" axis source is a device generating events in a
        /// continuous coordinate space, but using something other than a
        /// finger. One example for this source is button-based scrolling where
        /// the vertical motion of a device is converted to scroll events while
        /// a button is held down.
        /// 
        /// The "wheel tilt" axis source indicates that the actual device is a
        /// wheel but the scroll event is not caused by a rotation but a
        /// (usually sideways) tilt of the wheel.
        /// </summary>
        public enum AxisSourceEnum
        {
            /// <summary>a physical wheel rotation</summary>
            Wheel = 0,
            /// <summary>finger on a touch surface</summary>
            Finger = 1,
            /// <summary>continuous coordinate space</summary>
            Continuous = 2,
            /// <summary>a physical wheel tilt</summary>
            WheelTilt = 3
        }

        class ProxyFactory : IBindFactory<WlPointer>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface);
            }

            public WlPointer Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlPointer(handle, version, display);
            }
        }

        public static IBindFactory<WlPointer> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_pointer";
        public const int InterfaceVersion = 7;

        public WlPointer(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_keyboard interface represents one or more keyboards
    /// associated with a seat.
    /// </summary>
    public sealed unsafe partial class WlKeyboard : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlKeyboard()
        {
            WlInterface.Init("wl_keyboard", 7, new WlMessage[] {
                WlMessage.Create("release", "3", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("keymap", "uhu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("enter", "uoa", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null }),
                WlMessage.Create("leave", "uo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("key", "uuuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("modifiers", "uuuuu", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("repeat_info", "4ii", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 3)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnKeymap(NWayland.Protocols.Wayland.WlKeyboard eventSender, KeymapFormatEnum @format, int @fd, uint @size);
            void OnEnter(NWayland.Protocols.Wayland.WlKeyboard eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface, ReadOnlySpan<int> @keys);
            void OnLeave(NWayland.Protocols.Wayland.WlKeyboard eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnKey(NWayland.Protocols.Wayland.WlKeyboard eventSender, uint @serial, uint @time, uint @key, KeyStateEnum @state);
            void OnModifiers(NWayland.Protocols.Wayland.WlKeyboard eventSender, uint @serial, uint @modsDepressed, uint @modsLatched, uint @modsLocked, uint @group);
            void OnRepeatInfo(NWayland.Protocols.Wayland.WlKeyboard eventSender, int @rate, int @delay);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnKeymap(this, (KeymapFormatEnum)arguments[0].UInt32, arguments[1].Int32, arguments[2].UInt32);
            if (opcode == 1)
                Events?.OnEnter(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr), NWayland.Interop.WlArray.SpanFromWlArrayPtr<int>(arguments[2].IntPtr));
            if (opcode == 2)
                Events?.OnLeave(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr));
            if (opcode == 3)
                Events?.OnKey(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, (KeyStateEnum)arguments[3].UInt32);
            if (opcode == 4)
                Events?.OnModifiers(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32);
            if (opcode == 5)
                Events?.OnRepeatInfo(this, arguments[0].Int32, arguments[1].Int32);
        }

        /// <summary>
        /// This specifies the format of the keymap provided to the
        /// client with the wl_keyboard.keymap event.
        /// </summary>
        public enum KeymapFormatEnum
        {
            /// <summary>no keymap; client must understand how to interpret the raw keycode</summary>
            NoKeymap = 0,
            /// <summary>libxkbcommon compatible, null-terminated string; to determine the xkb keycode, clients must add 8 to the key event keycode</summary>
            XkbV1 = 1
        }

        /// <summary>
        /// Describes the physical state of a key that produced the key event.
        /// </summary>
        public enum KeyStateEnum
        {
            /// <summary>key is not pressed</summary>
            Released = 0,
            /// <summary>key is pressed</summary>
            Pressed = 1
        }

        class ProxyFactory : IBindFactory<WlKeyboard>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface);
            }

            public WlKeyboard Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlKeyboard(handle, version, display);
            }
        }

        public static IBindFactory<WlKeyboard> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_keyboard";
        public const int InterfaceVersion = 7;

        public WlKeyboard(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wl_touch interface represents a touchscreen
    /// associated with a seat.
    /// 
    /// Touch interactions can consist of one or more contacts.
    /// For each contact, a series of events is generated, starting
    /// with a down event, followed by zero or more motion events,
    /// and ending with an up event. Events relating to the same
    /// contact point can be identified by the ID of the sequence.
    /// </summary>
    public sealed unsafe partial class WlTouch : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlTouch()
        {
            WlInterface.Init("wl_touch", 7, new WlMessage[] {
                WlMessage.Create("release", "3", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("down", "uuoiff", new WlInterface*[] { null, null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null }),
                WlMessage.Create("up", "uui", new WlInterface*[] { null, null, null }),
                WlMessage.Create("motion", "uiff", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("frame", "", new WlInterface*[] { }),
                WlMessage.Create("cancel", "", new WlInterface*[] { }),
                WlMessage.Create("shape", "6iff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("orientation", "6if", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlTouch.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 3)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnDown(NWayland.Protocols.Wayland.WlTouch eventSender, uint @serial, uint @time, NWayland.Protocols.Wayland.WlSurface @surface, int @id, int @x, int @y);
            void OnUp(NWayland.Protocols.Wayland.WlTouch eventSender, uint @serial, uint @time, int @id);
            void OnMotion(NWayland.Protocols.Wayland.WlTouch eventSender, uint @time, int @id, int @x, int @y);
            void OnFrame(NWayland.Protocols.Wayland.WlTouch eventSender);
            void OnCancel(NWayland.Protocols.Wayland.WlTouch eventSender);
            void OnShape(NWayland.Protocols.Wayland.WlTouch eventSender, int @id, int @major, int @minor);
            void OnOrientation(NWayland.Protocols.Wayland.WlTouch eventSender, int @id, int @orientation);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDown(this, arguments[0].UInt32, arguments[1].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr), arguments[3].Int32, arguments[4].Int32, arguments[5].Int32);
            if (opcode == 1)
                Events?.OnUp(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].Int32);
            if (opcode == 2)
                Events?.OnMotion(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32);
            if (opcode == 3)
                Events?.OnFrame(this);
            if (opcode == 4)
                Events?.OnCancel(this);
            if (opcode == 5)
                Events?.OnShape(this, arguments[0].Int32, arguments[1].Int32, arguments[2].Int32);
            if (opcode == 6)
                Events?.OnOrientation(this, arguments[0].Int32, arguments[1].Int32);
        }

        class ProxyFactory : IBindFactory<WlTouch>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlTouch.WlInterface);
            }

            public WlTouch Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlTouch(handle, version, display);
            }
        }

        public static IBindFactory<WlTouch> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_touch";
        public const int InterfaceVersion = 7;

        public WlTouch(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An output describes part of the compositor geometry.  The
    /// compositor works in the 'compositor coordinate system' and an
    /// output corresponds to a rectangular area in that space that is
    /// actually visible.  This typically corresponds to a monitor that
    /// displays part of the compositor space.  This object is published
    /// as global during start up, or when a monitor is hotplugged.
    /// </summary>
    public sealed unsafe partial class WlOutput : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlOutput()
        {
            WlInterface.Init("wl_output", 3, new WlMessage[] {
                WlMessage.Create("release", "3", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("geometry", "iiiiissi", new WlInterface*[] { null, null, null, null, null, null, null, null }),
                WlMessage.Create("mode", "uiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("done", "2", new WlInterface*[] { }),
                WlMessage.Create("scale", "2i", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 3)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnGeometry(NWayland.Protocols.Wayland.WlOutput eventSender, int @x, int @y, int @physicalWidth, int @physicalHeight, SubpixelEnum @subpixel, System.String @make, System.String @model, TransformEnum @transform);
            void OnMode(NWayland.Protocols.Wayland.WlOutput eventSender, ModeEnum @flags, int @width, int @height, int @refresh);
            void OnDone(NWayland.Protocols.Wayland.WlOutput eventSender);
            void OnScale(NWayland.Protocols.Wayland.WlOutput eventSender, int @factor);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGeometry(this, arguments[0].Int32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32, (SubpixelEnum)arguments[4].Int32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[5].IntPtr), System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[6].IntPtr), (TransformEnum)arguments[7].Int32);
            if (opcode == 1)
                Events?.OnMode(this, (ModeEnum)arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32);
            if (opcode == 2)
                Events?.OnDone(this);
            if (opcode == 3)
                Events?.OnScale(this, arguments[0].Int32);
        }

        /// <summary>
        /// This enumeration describes how the physical
        /// pixels on an output are laid out.
        /// </summary>
        public enum SubpixelEnum
        {
            /// <summary>unknown geometry</summary>
            Unknown = 0,
            /// <summary>no geometry</summary>
            None = 1,
            /// <summary>horizontal RGB</summary>
            HorizontalRgb = 2,
            /// <summary>horizontal BGR</summary>
            HorizontalBgr = 3,
            /// <summary>vertical RGB</summary>
            VerticalRgb = 4,
            /// <summary>vertical BGR</summary>
            VerticalBgr = 5
        }

        /// <summary>
        /// This describes the transform that a compositor will apply to a
        /// surface to compensate for the rotation or mirroring of an
        /// output device.
        /// 
        /// The flipped values correspond to an initial flip around a
        /// vertical axis followed by rotation.
        /// 
        /// The purpose is mainly to allow clients to render accordingly and
        /// tell the compositor, so that for fullscreen surfaces, the
        /// compositor will still be able to scan out directly from client
        /// surfaces.
        /// </summary>
        public enum TransformEnum
        {
            /// <summary>no transform</summary>
            Normal = 0,
            /// <summary>90 degrees counter-clockwise</summary>
            k_90 = 1,
            /// <summary>180 degrees counter-clockwise</summary>
            k_180 = 2,
            /// <summary>270 degrees counter-clockwise</summary>
            k_270 = 3,
            /// <summary>180 degree flip around a vertical axis</summary>
            Flipped = 4,
            /// <summary>flip and rotate 90 degrees counter-clockwise</summary>
            Flipped90 = 5,
            /// <summary>flip and rotate 180 degrees counter-clockwise</summary>
            Flipped180 = 6,
            /// <summary>flip and rotate 270 degrees counter-clockwise</summary>
            Flipped270 = 7
        }

        [System.Flags]
        /// <summary>
        /// These flags describe properties of an output mode.
        /// They are used in the flags bitfield of the mode event.
        /// </summary>
        public enum ModeEnum
        {
            /// <summary>indicates this is the current mode</summary>
            Current = 0x1,
            /// <summary>indicates this is the preferred mode</summary>
            Preferred = 0x2
        }

        class ProxyFactory : IBindFactory<WlOutput>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface);
            }

            public WlOutput Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlOutput(handle, version, display);
            }
        }

        public static IBindFactory<WlOutput> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_output";
        public const int InterfaceVersion = 3;

        public WlOutput(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A region object describes an area.
    /// 
    /// Region objects are used to describe the opaque and input
    /// regions of a surface.
    /// </summary>
    public sealed unsafe partial class WlRegion : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlRegion()
        {
            WlInterface.Init("wl_region", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("add", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("subtract", "iiii", new WlInterface*[] { null, null, null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Add the specified rectangle to the region.
        /// </summary>
        public void Add(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Subtract the specified rectangle from the region.
        /// </summary>
        public void Subtract(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<WlRegion>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface);
            }

            public WlRegion Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlRegion(handle, version, display);
            }
        }

        public static IBindFactory<WlRegion> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_region";
        public const int InterfaceVersion = 1;

        public WlRegion(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The global interface exposing sub-surface compositing capabilities.
    /// A wl_surface, that has sub-surfaces associated, is called the
    /// parent surface. Sub-surfaces can be arbitrarily nested and create
    /// a tree of sub-surfaces.
    /// 
    /// The root surface in a tree of sub-surfaces is the main
    /// surface. The main surface cannot be a sub-surface, because
    /// sub-surfaces must always have a parent.
    /// 
    /// A main surface with its sub-surfaces forms a (compound) window.
    /// For window management purposes, this set of wl_surface objects is
    /// to be considered as a single window, and it should also behave as
    /// such.
    /// 
    /// The aim of sub-surfaces is to offload some of the compositing work
    /// within a window from clients to the compositor. A prime example is
    /// a video player with decorations and video in separate wl_surface
    /// objects. This should allow the compositor to pass YUV video buffer
    /// processing to dedicated overlay hardware when possible.
    /// </summary>
    public sealed unsafe partial class WlSubcompositor : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlSubcompositor()
        {
            WlInterface.Init("wl_subcompositor", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_subsurface", "noo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSubsurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSubcompositor.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a sub-surface interface for the given surface, and
        /// associate it with the given parent surface. This turns a
        /// plain wl_surface into a sub-surface.
        /// 
        /// The to-be sub-surface must not already have another role, and it
        /// must not have an existing wl_subsurface object. Otherwise a protocol
        /// error is raised.
        /// 
        /// Adding sub-surfaces to a parent is a double-buffered operation on the
        /// parent (see wl_surface.commit). The effect of adding a sub-surface
        /// becomes visible on the next time the state of the parent surface is
        /// applied.
        /// 
        /// This request modifies the behaviour of wl_surface.commit request on
        /// the sub-surface, see the documentation on wl_subsurface interface.
        /// </summary>
        public NWayland.Protocols.Wayland.WlSubsurface GetSubsurface(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlSurface @parent)
        {
            if (@parent == null)
                throw new System.ArgumentNullException("parent");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface,
                @parent
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wayland.WlSubsurface.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlSubsurface(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary>the to-be sub-surface is invalid</summary>
            BadSurface = 0
        }

        class ProxyFactory : IBindFactory<WlSubcompositor>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSubcompositor.WlInterface);
            }

            public WlSubcompositor Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlSubcompositor(handle, version, display);
            }
        }

        public static IBindFactory<WlSubcompositor> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_subcompositor";
        public const int InterfaceVersion = 1;

        public WlSubcompositor(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An additional interface to a wl_surface object, which has been
    /// made a sub-surface. A sub-surface has one parent surface. A
    /// sub-surface's size and position are not limited to that of the parent.
    /// Particularly, a sub-surface is not automatically clipped to its
    /// parent's area.
    /// 
    /// A sub-surface becomes mapped, when a non-NULL wl_buffer is applied
    /// and the parent surface is mapped. The order of which one happens
    /// first is irrelevant. A sub-surface is hidden if the parent becomes
    /// hidden, or if a NULL wl_buffer is applied. These rules apply
    /// recursively through the tree of surfaces.
    /// 
    /// The behaviour of a wl_surface.commit request on a sub-surface
    /// depends on the sub-surface's mode. The possible modes are
    /// synchronized and desynchronized, see methods
    /// wl_subsurface.set_sync and wl_subsurface.set_desync. Synchronized
    /// mode caches the wl_surface state to be applied when the parent's
    /// state gets applied, and desynchronized mode applies the pending
    /// wl_surface state directly. A sub-surface is initially in the
    /// synchronized mode.
    /// 
    /// Sub-surfaces also have another kind of state, which is managed by
    /// wl_subsurface requests, as opposed to wl_surface requests. This
    /// state includes the sub-surface position relative to the parent
    /// surface (wl_subsurface.set_position), and the stacking order of
    /// the parent and its sub-surfaces (wl_subsurface.place_above and
    /// .place_below). This state is applied when the parent surface's
    /// wl_surface state is applied, regardless of the sub-surface's mode.
    /// As the exception, set_sync and set_desync are effective immediately.
    /// 
    /// The main surface can be thought to be always in desynchronized mode,
    /// since it does not have a parent in the sub-surfaces sense.
    /// 
    /// Even if a sub-surface is in desynchronized mode, it will behave as
    /// in synchronized mode, if its parent surface behaves as in
    /// synchronized mode. This rule is applied recursively throughout the
    /// tree of surfaces. This means, that one can set a sub-surface into
    /// synchronized mode, and then assume that all its child and grand-child
    /// sub-surfaces are synchronized, too, without explicitly setting them.
    /// 
    /// If the wl_surface associated with the wl_subsurface is destroyed, the
    /// wl_subsurface object becomes inert. Note, that destroying either object
    /// takes effect immediately. If you need to synchronize the removal
    /// of a sub-surface to the parent surface update, unmap the sub-surface
    /// first by attaching a NULL wl_buffer, update parent, and then destroy
    /// the sub-surface.
    /// 
    /// If the parent wl_surface object is destroyed, the sub-surface is
    /// unmapped.
    /// </summary>
    public sealed unsafe partial class WlSubsurface : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlSubsurface()
        {
            WlInterface.Init("wl_subsurface", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("place_above", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("place_below", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("set_sync", "", new WlInterface*[] { }),
                WlMessage.Create("set_desync", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSubsurface.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This schedules a sub-surface position change.
        /// The sub-surface will be moved so that its origin (top left
        /// corner pixel) will be at the location x, y of the parent surface
        /// coordinate system. The coordinates are not restricted to the parent
        /// surface area. Negative values are allowed.
        /// 
        /// The scheduled coordinates will take effect whenever the state of the
        /// parent surface is applied. When this happens depends on whether the
        /// parent surface is in synchronized mode or not. See
        /// wl_subsurface.set_sync and wl_subsurface.set_desync for details.
        /// 
        /// If more than one set_position request is invoked by the client before
        /// the commit of the parent surface, the position of a new request always
        /// replaces the scheduled position from any previous request.
        /// 
        /// The initial position is 0, 0.
        /// </summary>
        public void SetPosition(int @x, int @y)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This sub-surface is taken from the stack, and put back just
        /// above the reference surface, changing the z-order of the sub-surfaces.
        /// The reference surface must be one of the sibling surfaces, or the
        /// parent surface. Using any other surface, including this sub-surface,
        /// will cause a protocol error.
        /// 
        /// The z-order is double-buffered. Requests are handled in order and
        /// applied immediately to a pending state. The final pending state is
        /// copied to the active state the next time the state of the parent
        /// surface is applied. When this happens depends on whether the parent
        /// surface is in synchronized mode or not. See wl_subsurface.set_sync and
        /// wl_subsurface.set_desync for details.
        /// 
        /// A new sub-surface is initially added as the top-most in the stack
        /// of its siblings and parent.
        /// </summary>
        public void PlaceAbove(NWayland.Protocols.Wayland.WlSurface @sibling)
        {
            if (@sibling == null)
                throw new System.ArgumentNullException("sibling");
            WlArgument* __args = stackalloc WlArgument[] {
                @sibling
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// The sub-surface is placed just below the reference surface.
        /// See wl_subsurface.place_above.
        /// </summary>
        public void PlaceBelow(NWayland.Protocols.Wayland.WlSurface @sibling)
        {
            if (@sibling == null)
                throw new System.ArgumentNullException("sibling");
            WlArgument* __args = stackalloc WlArgument[] {
                @sibling
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Change the commit behaviour of the sub-surface to synchronized
        /// mode, also described as the parent dependent mode.
        /// 
        /// In synchronized mode, wl_surface.commit on a sub-surface will
        /// accumulate the committed state in a cache, but the state will
        /// not be applied and hence will not change the compositor output.
        /// The cached state is applied to the sub-surface immediately after
        /// the parent surface's state is applied. This ensures atomic
        /// updates of the parent and all its synchronized sub-surfaces.
        /// Applying the cached state will invalidate the cache, so further
        /// parent surface commits do not (re-)apply old state.
        /// 
        /// See wl_subsurface for the recursive effect of this mode.
        /// </summary>
        public void SetSync()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Change the commit behaviour of the sub-surface to desynchronized
        /// mode, also described as independent or freely running mode.
        /// 
        /// In desynchronized mode, wl_surface.commit on a sub-surface will
        /// apply the pending state directly, without caching, as happens
        /// normally with a wl_surface. Calling wl_surface.commit on the
        /// parent surface has no effect on the sub-surface's wl_surface
        /// state. This mode allows a sub-surface to be updated on its own.
        /// 
        /// If cached state exists when wl_surface.commit is called in
        /// desynchronized mode, the pending state is added to the cached
        /// state, and applied as a whole. This invalidates the cache.
        /// 
        /// Note: even if a sub-surface is set to desynchronized, a parent
        /// sub-surface may override it to behave as synchronized. For details,
        /// see wl_subsurface.
        /// 
        /// If a surface's parent surface behaves as desynchronized, then
        /// the cached state is applied on set_desync.
        /// </summary>
        public void SetDesync()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary>wl_surface is not a sibling or the parent</summary>
            BadSurface = 0
        }

        class ProxyFactory : IBindFactory<WlSubsurface>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSubsurface.WlInterface);
            }

            public WlSubsurface Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlSubsurface(handle, version, display);
            }
        }

        public static IBindFactory<WlSubsurface> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_subsurface";
        public const int InterfaceVersion = 1;

        public WlSubsurface(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}