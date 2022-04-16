using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.ServerDecorationPalette
{
    /// <summary>
    /// This interface allows a client to alter the palette of a server side decoration.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinServerDecorationPaletteManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinServerDecorationPaletteManager()
        {
            WlInterface.Init("org_kde_kwin_server_decoration_palette_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPaletteManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinServerDecorationPaletteManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPaletteManager.WlInterface);
            }

            public OrgKdeKwinServerDecorationPaletteManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinServerDecorationPaletteManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinServerDecorationPaletteManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_server_decoration_palette_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinServerDecorationPaletteManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface allows a client to alter the palette of a server side decoration.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinServerDecorationPalette : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinServerDecorationPalette()
        {
            WlInterface.Init("org_kde_kwin_server_decoration_palette", 1, new WlMessage[] {
                WlMessage.Create("set_palette", "s", new WlInterface*[] { null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette.WlInterface);
        }

        /// <summary>
        /// Color scheme that should be applied to the window decoration.
        /// Absolute file path, or name of palette in the user's config directory.
        /// The server may choose not to follow the requested style.
        /// </summary>
        public void SetPalette(System.String @palette)
        {
            if (@palette == null)
                throw new System.ArgumentNullException("palette");
            using var __marshalled__palette = new NWayland.Interop.NWaylandMarshalledString(@palette);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__palette
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
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

        class ProxyFactory : IBindFactory<OrgKdeKwinServerDecorationPalette>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecorationPalette.OrgKdeKwinServerDecorationPalette.WlInterface);
            }

            public OrgKdeKwinServerDecorationPalette Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinServerDecorationPalette(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinServerDecorationPalette> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_server_decoration_palette";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinServerDecorationPalette(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}