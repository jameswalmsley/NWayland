using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Dpms
{
    /// <summary>
    /// The Dpms manager allows to get a org_kde_kwin_dpms for a given wl_output.
    /// The org_kde_kwin_dpms provides the currently used VESA Display Power Management
    /// Signaling state (see https://en.wikipedia.org/wiki/VESA_Display_Power_Management_Signaling ).
    /// In addition it allows to request a state change. A compositor is not obliged to honor it
    /// and will normally automatically switch back to on state.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinDpmsManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinDpmsManager()
        {
            WlInterface.Init("org_kde_kwin_dpms_manager", 1, new WlMessage[] {
                WlMessage.Create("get", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpmsManager.WlInterface);
        }

        /// <summary>
        /// Factory request to get the org_kde_kwin_dpms for a given wl_output.
        /// </summary>
        public NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms Get(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @output
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinDpmsManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpmsManager.WlInterface);
            }

            public OrgKdeKwinDpmsManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinDpmsManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinDpmsManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_dpms_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinDpmsManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface provides information about the VESA DPMS state for a wl_output.
    /// It gets created through the request get on the org_kde_kwin_dpms_manager interface.
    /// 
    /// On creating the resource the server will push whether DPSM is supported for the output,
    /// the currently used DPMS state and notifies the client through the done event once all
    /// states are pushed. Whenever a state changes the set of changes is committed with the
    /// done event.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinDpms : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinDpms()
        {
            WlInterface.Init("org_kde_kwin_dpms", 1, new WlMessage[] {
                WlMessage.Create("set", "u", new WlInterface*[] { null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("supported", "u", new WlInterface*[] { null }),
                WlMessage.Create("mode", "u", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms.WlInterface);
        }

        /// <summary>
        /// Requests that the compositor puts the wl_output into the passed mode. The compositor
        /// is not obliged to change the state. In addition the compositor might leave the mode
        /// whenever it seems suitable. E.g. the compositor might return to On state on user input.
        /// 
        /// The client should not assume that the mode changed after requesting a new mode.
        /// Instead the client should listen for the mode event.
        /// </summary>
        public void Set(uint @mode)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @mode
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
            void OnSupported(NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms eventSender, uint @supported);
            void OnMode(NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms eventSender, uint @mode);
            void OnDone(NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSupported(this, arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnMode(this, arguments[0].UInt32);
            if (opcode == 2)
                Events?.OnDone(this);
        }

        public enum ModeEnum
        {
            On = 0,
            Standby = 1,
            Suspend = 2,
            Off = 3
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinDpms>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Dpms.OrgKdeKwinDpms.WlInterface);
            }

            public OrgKdeKwinDpms Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinDpms(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinDpms> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_dpms";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinDpms(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}