using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Idle
{
    /// <summary>
    /// This interface allows to monitor user idle time on a given seat. The interface
    /// allows to register timers which trigger after no user activity was registered
    /// on the seat for a given interval. It notifies when user activity resumes.
    /// 
    /// This is useful for applications wanting to perform actions when the user is not
    /// interacting with the system, e.g. chat applications setting the user as away, power
    /// management features to dim screen, etc..
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinIdle : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinIdle()
        {
            WlInterface.Init("org_kde_kwin_idle", 1, new WlMessage[] {
                WlMessage.Create("get_idle_timeout", "nou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdle.WlInterface);
        }

        public NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout GetIdleTimeout(NWayland.Protocols.Wayland.WlSeat @seat, uint @timeout)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat,
                @timeout
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinIdle>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdle.WlInterface);
            }

            public OrgKdeKwinIdle Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinIdle(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinIdle> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_idle";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinIdle(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinIdleTimeout : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinIdleTimeout()
        {
            WlInterface.Init("org_kde_kwin_idle_timeout", 1, new WlMessage[] {
                WlMessage.Create("release", "", new WlInterface*[] { }),
                WlMessage.Create("simulate_user_activity", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("idle", "", new WlInterface*[] { }),
                WlMessage.Create("resumed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void SimulateUserActivity()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnIdle(NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout eventSender);
            void OnResumed(NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnIdle(this);
            if (opcode == 1)
                Events?.OnResumed(this);
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinIdleTimeout>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Idle.OrgKdeKwinIdleTimeout.WlInterface);
            }

            public OrgKdeKwinIdleTimeout Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinIdleTimeout(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinIdleTimeout> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_idle_timeout";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinIdleTimeout(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}