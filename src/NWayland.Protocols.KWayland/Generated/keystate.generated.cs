using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Keystate
{
    /// <summary>
    /// Keeps track of the states of the different keys that have a state attached to it.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinKeystate : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinKeystate()
        {
            WlInterface.Init("org_kde_kwin_keystate", 3, new WlMessage[] {
                WlMessage.Create("fetchStates", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("stateChanged", "uu", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Keystate.OrgKdeKwinKeystate.WlInterface);
        }

        public void FetchStates()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnStateChanged(NWayland.Protocols.KWayland.Keystate.OrgKdeKwinKeystate eventSender, uint @key, uint @state);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnStateChanged(this, arguments[0].UInt32, arguments[1].UInt32);
        }

        public enum KeyEnum
        {
            Capslock = 0,
            Numlock = 1,
            Scrolllock = 2
        }

        public enum StateEnum
        {
            Unlocked = 0,
            Latched = 1,
            Locked = 2
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinKeystate>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Keystate.OrgKdeKwinKeystate.WlInterface);
            }

            public OrgKdeKwinKeystate Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinKeystate(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinKeystate> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_keystate";
        public const int InterfaceVersion = 3;

        public OrgKdeKwinKeystate(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}