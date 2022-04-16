using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1
{
    /// <summary>
    /// A global interface used for inhibiting the compositor keyboard shortcuts.
    /// </summary>
    public sealed unsafe partial class ZwpKeyboardShortcutsInhibitManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpKeyboardShortcutsInhibitManagerV1()
        {
            WlInterface.Init("zwp_keyboard_shortcuts_inhibit_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("inhibit_shortcuts", "noo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a new keyboard shortcuts inhibitor object associated with
        /// the given surface for the given seat.
        /// 
        /// If shortcuts are already inhibited for the specified seat and surface,
        /// a protocol error "already_inhibited" is raised by the compositor.
        /// </summary>
        public NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1 InhibitShortcuts(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1(__ret, Version, Display);
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
            /// <summary>the shortcuts are already inhibited for this surface</summary>
            AlreadyInhibited = 0
        }

        class ProxyFactory : IBindFactory<ZwpKeyboardShortcutsInhibitManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitManagerV1.WlInterface);
            }

            public ZwpKeyboardShortcutsInhibitManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpKeyboardShortcutsInhibitManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpKeyboardShortcutsInhibitManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_keyboard_shortcuts_inhibit_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpKeyboardShortcutsInhibitManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A keyboard shortcuts inhibitor instructs the compositor to ignore
    /// its own keyboard shortcuts when the associated surface has keyboard
    /// focus. As a result, when the surface has keyboard focus on the given
    /// seat, it will receive all key events originating from the specified
    /// seat, even those which would normally be caught by the compositor for
    /// its own shortcuts.
    /// 
    /// The Wayland compositor is however under no obligation to disable
    /// all of its shortcuts, and may keep some special key combo for its own
    /// use, including but not limited to one allowing the user to forcibly
    /// restore normal keyboard events routing in the case of an unwilling
    /// client. The compositor may also use the same key combo to reactivate
    /// an existing shortcut inhibitor that was previously deactivated on
    /// user request.
    /// 
    /// When the compositor restores its own keyboard shortcuts, an
    /// "inactive" event is emitted to notify the client that the keyboard
    /// shortcuts inhibitor is not effectively active for the surface and
    /// seat any more, and the client should not expect to receive all
    /// keyboard events.
    /// 
    /// When the keyboard shortcuts inhibitor is inactive, the client has
    /// no way to forcibly reactivate the keyboard shortcuts inhibitor.
    /// 
    /// The user can chose to re-enable a previously deactivated keyboard
    /// shortcuts inhibitor using any mechanism the compositor may offer,
    /// in which case the compositor will send an "active" event to notify
    /// the client.
    /// 
    /// If the surface is destroyed, unmapped, or loses the seat's keyboard
    /// focus, the keyboard shortcuts inhibitor becomes irrelevant and the
    /// compositor will restore its own keyboard shortcuts but no "inactive"
    /// event is emitted in this case.
    /// </summary>
    public sealed unsafe partial class ZwpKeyboardShortcutsInhibitorV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpKeyboardShortcutsInhibitorV1()
        {
            WlInterface.Init("zwp_keyboard_shortcuts_inhibitor_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("active", "", new WlInterface*[] { }),
                WlMessage.Create("inactive", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnActive(NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1 eventSender);
            void OnInactive(NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnActive(this);
            if (opcode == 1)
                Events?.OnInactive(this);
        }

        class ProxyFactory : IBindFactory<ZwpKeyboardShortcutsInhibitorV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KeyboardShortcutsInhibitUnstableV1.ZwpKeyboardShortcutsInhibitorV1.WlInterface);
            }

            public ZwpKeyboardShortcutsInhibitorV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpKeyboardShortcutsInhibitorV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpKeyboardShortcutsInhibitorV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_keyboard_shortcuts_inhibitor_v1";
        public const int InterfaceVersion = 1;

        public ZwpKeyboardShortcutsInhibitorV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}