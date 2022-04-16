using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Slide
{
    public sealed unsafe partial class OrgKdeKwinSlideManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinSlideManager()
        {
            WlInterface.Init("org_kde_kwin_slide_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("unset", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlideManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide(__ret, Version, Display);
        }

        public void Unset(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinSlideManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlideManager.WlInterface);
            }

            public OrgKdeKwinSlideManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinSlideManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinSlideManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_slide_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinSlideManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// Ask the compositor to move the surface from a location to another
    /// with a slide animation.
    /// 
    /// The from argument provides a clue about where the slide animation
    /// begins, offset is the distance from screen edge to begin the animation.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinSlide : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinSlide()
        {
            WlInterface.Init("org_kde_kwin_slide", 1, new WlMessage[] {
                WlMessage.Create("commit", "", new WlInterface*[] { }),
                WlMessage.Create("set_location", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_offset", "i", new WlInterface*[] { null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide.WlInterface);
        }

        public void Commit()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void SetLocation(uint @location)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @location
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public void SetOffset(int @offset)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @offset
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum LocationEnum
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinSlide>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Slide.OrgKdeKwinSlide.WlInterface);
            }

            public OrgKdeKwinSlide Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinSlide(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinSlide> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_slide";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinSlide(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}