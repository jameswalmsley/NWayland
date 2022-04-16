using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Appmenu
{
    /// <summary>
    /// This interface allows a client to link a window (or wl_surface) to an com.canonical.dbusmenu
    /// interface registered on DBus.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinAppmenuManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinAppmenuManager()
        {
            WlInterface.Init("org_kde_kwin_appmenu_manager", 1, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenuManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinAppmenuManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenuManager.WlInterface);
            }

            public OrgKdeKwinAppmenuManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinAppmenuManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinAppmenuManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_appmenu_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinAppmenuManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The DBus service name and object path where the appmenu interface is present
    /// The object should be registered on the session bus before sending this request.
    /// If not applicable, clients should remove this object.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinAppmenu : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinAppmenu()
        {
            WlInterface.Init("org_kde_kwin_appmenu", 1, new WlMessage[] {
                WlMessage.Create("set_address", "ss", new WlInterface*[] { null, null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu.WlInterface);
        }

        /// <summary>
        /// Set or update the service name and object path.
        /// Strings should be formatted in Latin-1 matching the relevant DBus specifications.
        /// </summary>
        public void SetAddress(System.String @serviceName, System.String @objectPath)
        {
            if (@objectPath == null)
                throw new System.ArgumentNullException("objectPath");
            if (@serviceName == null)
                throw new System.ArgumentNullException("serviceName");
            using var __marshalled__serviceName = new NWayland.Interop.NWaylandMarshalledString(@serviceName);
            using var __marshalled__objectPath = new NWayland.Interop.NWaylandMarshalledString(@objectPath);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__serviceName,
                __marshalled__objectPath
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

        class ProxyFactory : IBindFactory<OrgKdeKwinAppmenu>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Appmenu.OrgKdeKwinAppmenu.WlInterface);
            }

            public OrgKdeKwinAppmenu Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinAppmenu(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinAppmenu> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_appmenu";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinAppmenu(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}