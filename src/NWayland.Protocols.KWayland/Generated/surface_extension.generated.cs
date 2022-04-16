using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.SurfaceExtension
{
    public sealed unsafe partial class QtSurfaceExtension : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static QtSurfaceExtension()
        {
            WlInterface.Init("qt_surface_extension", 1, new WlMessage[] {
                WlMessage.Create("get_extended_surface", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.SurfaceExtension.QtSurfaceExtension.WlInterface);
        }

        public NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface GetExtendedSurface(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<QtSurfaceExtension>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.SurfaceExtension.QtSurfaceExtension.WlInterface);
            }

            public QtSurfaceExtension Create(IntPtr handle, int version, WlDisplay display)
            {
                return new QtSurfaceExtension(handle, version, display);
            }
        }

        public static IBindFactory<QtSurfaceExtension> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "qt_surface_extension";
        public const int InterfaceVersion = 1;

        public QtSurfaceExtension(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class QtExtendedSurface : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static QtExtendedSurface()
        {
            WlInterface.Init("qt_extended_surface", 1, new WlMessage[] {
                WlMessage.Create("update_generic_property", "sa", new WlInterface*[] { null, null }),
                WlMessage.Create("set_content_orientation_mask", "i", new WlInterface*[] { null }),
                WlMessage.Create("set_window_flags", "i", new WlInterface*[] { null }),
                WlMessage.Create("raise", "", new WlInterface*[] { }),
                WlMessage.Create("lower", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("onscreen_visibility", "i", new WlInterface*[] { null }),
                WlMessage.Create("set_generic_property", "sa", new WlInterface*[] { null, null }),
                WlMessage.Create("close", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface.WlInterface);
        }

        public void UpdateGenericProperty(System.String @name, ReadOnlySpan<byte> @value)
        {
            if (@name == null)
                throw new System.ArgumentNullException("name");
            using var __marshalled__name = new NWayland.Interop.NWaylandMarshalledString(@name);
            fixed (byte* __pointer__value = @value)
            {
                var __marshalled__value = NWayland.Interop.WlArray.FromPointer(__pointer__value, @value.Length);
                WlArgument* __args = stackalloc WlArgument[] {
                    __marshalled__name,
                    &__marshalled__value
                };
                LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
            }
        }

        public void SetContentOrientationMask(int @orientation)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @orientation
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public void SetWindowFlags(int @flags)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @flags
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public void Raise()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public void Lower()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        public interface IEvents
        {
            void OnOnscreenVisibility(NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface eventSender, int @visible);
            void OnSetGenericProperty(NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface eventSender, System.String @name, ReadOnlySpan<byte> @value);
            void OnClose(NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnOnscreenVisibility(this, arguments[0].Int32);
            if (opcode == 1)
                Events?.OnSetGenericProperty(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[1].IntPtr));
            if (opcode == 2)
                Events?.OnClose(this);
        }

        public enum OrientationEnum
        {
            PrimaryOrientation = 0,
            PortraitOrientation = 1,
            LandscapeOrientation = 2,
            InvertedPortraitOrientation = 4,
            InvertedLandscapeOrientation = 8
        }

        public enum WindowflagEnum
        {
            OverridesSystemGestures = 1,
            StaysOnTop = 2,
            BypassWindowManager = 4
        }

        class ProxyFactory : IBindFactory<QtExtendedSurface>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.SurfaceExtension.QtExtendedSurface.WlInterface);
            }

            public QtExtendedSurface Create(IntPtr handle, int version, WlDisplay display)
            {
                return new QtExtendedSurface(handle, version, display);
            }
        }

        public static IBindFactory<QtExtendedSurface> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "qt_extended_surface";
        public const int InterfaceVersion = 1;

        public QtExtendedSurface(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}