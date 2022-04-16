using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1
{
    /// <summary>
    /// Clients can use this interface to prevent input events from being sent to
    /// any surfaces but its own, which is useful for example in lock screen
    /// software. It is assumed that access to this interface will be locked down
    /// to whitelisted clients by the compositor.
    /// </summary>
    public sealed unsafe partial class ZwlrInputInhibitManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrInputInhibitManagerV1()
        {
            WlInterface.Init("zwlr_input_inhibit_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("get_inhibitor", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitManagerV1.WlInterface);
        }

        /// <summary>
        /// Activates the input inhibitor. As long as the inhibitor is active, the
        /// compositor will not send input events to other clients.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1 GetInhibitor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1(__ret, Version, Display);
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
            /// <summary>an input inhibitor is already in use on the compositor</summary>
            AlreadyInhibited = 0
        }

        class ProxyFactory : IBindFactory<ZwlrInputInhibitManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitManagerV1.WlInterface);
            }

            public ZwlrInputInhibitManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrInputInhibitManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrInputInhibitManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_input_inhibit_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwlrInputInhibitManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// While this resource exists, input to clients other than the owner of the
    /// inhibitor resource will not receive input events. Any client which
    /// previously had focus will receive a leave event and will not be given
    /// focus again. The client that owns this resource will receive all input
    /// events normally. The compositor will also disable all of its own input
    /// processing (such as keyboard shortcuts) while the inhibitor is active.
    /// 
    /// The compositor may continue to send input events to selected clients,
    /// such as an on-screen keyboard (via the input-method protocol).
    /// </summary>
    public sealed unsafe partial class ZwlrInputInhibitorV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrInputInhibitorV1()
        {
            WlInterface.Init("zwlr_input_inhibitor_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwlrInputInhibitorV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrInputInhibitUnstableV1.ZwlrInputInhibitorV1.WlInterface);
            }

            public ZwlrInputInhibitorV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrInputInhibitorV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrInputInhibitorV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_input_inhibitor_v1";
        public const int InterfaceVersion = 1;

        public ZwlrInputInhibitorV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}