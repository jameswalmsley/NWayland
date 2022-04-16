using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Contrast
{
    public sealed unsafe partial class OrgKdeKwinContrastManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinContrastManager()
        {
            WlInterface.Init("org_kde_kwin_contrast_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("unset", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrastManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<OrgKdeKwinContrastManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrastManager.WlInterface);
            }

            public OrgKdeKwinContrastManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinContrastManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinContrastManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_contrast_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinContrastManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinContrast : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinContrast()
        {
            WlInterface.Init("org_kde_kwin_contrast", 1, new WlMessage[] {
                WlMessage.Create("commit", "", new WlInterface*[] { }),
                WlMessage.Create("set_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) }),
                WlMessage.Create("set_contrast", "f", new WlInterface*[] { null }),
                WlMessage.Create("set_intensity", "f", new WlInterface*[] { null }),
                WlMessage.Create("set_saturation", "f", new WlInterface*[] { null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast.WlInterface);
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

        public void SetContrast(int @contrast)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @contrast
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public void SetIntensity(int @intensity)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @intensity
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public void SetSaturation(int @saturation)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @saturation
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        protected sealed override void CallWaylandDestructor()
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

        class ProxyFactory : IBindFactory<OrgKdeKwinContrast>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Contrast.OrgKdeKwinContrast.WlInterface);
            }

            public OrgKdeKwinContrast Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinContrast(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinContrast> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_contrast";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinContrast(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}