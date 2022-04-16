using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.ServerDecoration
{
    /// <summary>
    /// This interface allows to coordinate whether the server should create
    /// a server-side window decoration around a wl_surface representing a
    /// shell surface (wl_shell_surface or similar). By announcing support
    /// for this interface the server indicates that it supports server
    /// side decorations.
    /// 
    /// Use in conjunction with zxdg_decoration_manager_v1 is undefined.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinServerDecorationManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinServerDecorationManager()
        {
            WlInterface.Init("org_kde_kwin_server_decoration_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("default_mode", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecorationManager.WlInterface);
        }

        /// <summary>
        /// When a client creates a server-side decoration object it indicates
        /// that it supports the protocol. The client is supposed to tell the
        /// server whether it wants server-side decorations or will provide
        /// client-side decorations.
        /// 
        /// If the client does not create a server-side decoration object for
        /// a surface the server interprets this as lack of support for this
        /// protocol and considers it as client-side decorated. Nevertheless a
        /// client-side decorated surface should use this protocol to indicate
        /// to the server that it does not want a server-side deco.
        /// </summary>
        public NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnDefaultMode(NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecorationManager eventSender, uint @mode);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDefaultMode(this, arguments[0].UInt32);
        }

        public enum ModeEnum
        {
            /// <summary>Undecorated: The surface is not decorated at all, neither server nor client-side. An example is a popup surface which should not be decorated.</summary>
            None = 0,
            /// <summary>Client-side decoration: The decoration is part of the surface and the client.</summary>
            Client = 1,
            /// <summary>Server-side decoration: The server embeds the surface into a decoration frame.</summary>
            Server = 2
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinServerDecorationManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecorationManager.WlInterface);
            }

            public OrgKdeKwinServerDecorationManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinServerDecorationManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinServerDecorationManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_server_decoration_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinServerDecorationManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinServerDecoration : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinServerDecoration()
        {
            WlInterface.Init("org_kde_kwin_server_decoration", 1, new WlMessage[] {
                WlMessage.Create("release", "", new WlInterface*[] { }),
                WlMessage.Create("request_mode", "u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("mode", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void RequestMode(uint @mode)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @mode
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnMode(NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration eventSender, uint @mode);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnMode(this, arguments[0].UInt32);
        }

        public enum ModeEnum
        {
            /// <summary>Undecorated: The surface is not decorated at all, neither server nor client-side. An example is a popup surface which should not be decorated.</summary>
            None = 0,
            /// <summary>Client-side decoration: The decoration is part of the surface and the client.</summary>
            Client = 1,
            /// <summary>Server-side decoration: The server embeds the surface into a decoration frame.</summary>
            Server = 2
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinServerDecoration>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.ServerDecoration.OrgKdeKwinServerDecoration.WlInterface);
            }

            public OrgKdeKwinServerDecoration Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinServerDecoration(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinServerDecoration> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_server_decoration";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinServerDecoration(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}