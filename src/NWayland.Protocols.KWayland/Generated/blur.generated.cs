using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Blur
{
    public sealed unsafe partial class OrgKdeKwinBlurManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinBlurManager()
        {
            WlInterface.Init("org_kde_kwin_blur_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("unset", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlurManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<OrgKdeKwinBlurManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlurManager.WlInterface);
            }

            public OrgKdeKwinBlurManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinBlurManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinBlurManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_blur_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinBlurManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinBlur : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinBlur()
        {
            WlInterface.Init("org_kde_kwin_blur", 1, new WlMessage[] {
                WlMessage.Create("commit", "", new WlInterface*[] { }),
                WlMessage.Create("set_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur.WlInterface);
        }

        public void Commit()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void SetRegion(NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            WlArgument* __args = stackalloc WlArgument[] {
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
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

        class ProxyFactory : IBindFactory<OrgKdeKwinBlur>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Blur.OrgKdeKwinBlur.WlInterface);
            }

            public OrgKdeKwinBlur Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinBlur(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinBlur> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_blur";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinBlur(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}