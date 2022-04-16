using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop
{
    public sealed unsafe partial class OrgKdePlasmaVirtualDesktopManagement : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaVirtualDesktopManagement()
        {
            WlInterface.Init("org_kde_plasma_virtual_desktop_management", 2, new WlMessage[] {
                WlMessage.Create("get_virtual_desktop", "ns", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop.WlInterface), null }),
                WlMessage.Create("request_create_virtual_desktop", "su", new WlInterface*[] { null, null }),
                WlMessage.Create("request_remove_virtual_desktop", "s", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("desktop_created", "su", new WlInterface*[] { null, null }),
                WlMessage.Create("desktop_removed", "s", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("rows", "2u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement.WlInterface);
        }

        /// <summary>
        /// Given the id of a particular virtual desktop, get the corresponding org_kde_plasma_virtual_desktop which represents only the desktop with that id;
        /// </summary>
        public NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop GetVirtualDesktop(System.String @desktopId)
        {
            if (@desktopId == null)
                throw new System.ArgumentNullException("desktopId");
            using var __marshalled__desktopId = new NWayland.Interop.NWaylandMarshalledString(@desktopId);
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                __marshalled__desktopId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop(__ret, Version, Display);
        }

        /// <summary>
        /// Ask the server to create a new virtual desktop, and position it at a specified position. If the position is zero or less, it will be positioned at the beginning, if the cosition is the count or more, it will be positioned at the end.
        /// </summary>
        public void RequestCreateVirtualDesktop(System.String @name, uint @position)
        {
            if (@name == null)
                throw new System.ArgumentNullException("name");
            using var __marshalled__name = new NWayland.Interop.NWaylandMarshalledString(@name);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__name,
                @position
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Ask the server to get rid of a virtual desktop, the server may or may not acconsent to the request.
        /// </summary>
        public void RequestRemoveVirtualDesktop(System.String @desktopId)
        {
            if (@desktopId == null)
                throw new System.ArgumentNullException("desktopId");
            using var __marshalled__desktopId = new NWayland.Interop.NWaylandMarshalledString(@desktopId);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__desktopId
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnDesktopCreated(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement eventSender, System.String @desktopId, uint @position);
            void OnDesktopRemoved(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement eventSender, System.String @desktopId);
            void OnDone(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement eventSender);
            void OnRows(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement eventSender, uint @rows);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDesktopCreated(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].UInt32);
            if (opcode == 1)
                Events?.OnDesktopRemoved(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnDone(this);
            if (opcode == 3)
                Events?.OnRows(this, arguments[0].UInt32);
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaVirtualDesktopManagement>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktopManagement.WlInterface);
            }

            public OrgKdePlasmaVirtualDesktopManagement Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaVirtualDesktopManagement(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaVirtualDesktopManagement> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_virtual_desktop_management";
        public const int InterfaceVersion = 2;

        public OrgKdePlasmaVirtualDesktopManagement(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdePlasmaVirtualDesktop : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaVirtualDesktop()
        {
            WlInterface.Init("org_kde_plasma_virtual_desktop", 1, new WlMessage[] {
                WlMessage.Create("request_activate", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("desktop_id", "s", new WlInterface*[] { null }),
                WlMessage.Create("name", "s", new WlInterface*[] { null }),
                WlMessage.Create("activated", "", new WlInterface*[] { }),
                WlMessage.Create("deactivated", "", new WlInterface*[] { }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("removed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop.WlInterface);
        }

        /// <summary>
        /// Request the server to set the status of this desktop to active: The server is free to consent or deny the request. This will be the new "current" virtual desktop of the system.
        /// </summary>
        public void RequestActivate()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnDesktopId(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender, System.String @desktopId);
            void OnName(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender, System.String @name);
            void OnActivated(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender);
            void OnDeactivated(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender);
            void OnDone(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender);
            void OnRemoved(NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDesktopId(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnName(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnActivated(this);
            if (opcode == 3)
                Events?.OnDeactivated(this);
            if (opcode == 4)
                Events?.OnDone(this);
            if (opcode == 5)
                Events?.OnRemoved(this);
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaVirtualDesktop>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdePlasmaVirtualDesktop.OrgKdePlasmaVirtualDesktop.WlInterface);
            }

            public OrgKdePlasmaVirtualDesktop Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaVirtualDesktop(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaVirtualDesktop> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_virtual_desktop";
        public const int InterfaceVersion = 1;

        public OrgKdePlasmaVirtualDesktop(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}