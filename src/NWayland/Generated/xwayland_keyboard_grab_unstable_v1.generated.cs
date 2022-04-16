using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XwaylandKeyboardGrabUnstableV1
{
    /// <summary>
    /// A global interface used for grabbing the keyboard.
    /// </summary>
    public sealed unsafe partial class ZwpXwaylandKeyboardGrabManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpXwaylandKeyboardGrabManagerV1()
        {
            WlInterface.Init("zwp_xwayland_keyboard_grab_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("grab_keyboard", "noo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The grab_keyboard request asks for a grab of the keyboard, forcing
        /// the keyboard focus for the given seat upon the given surface.
        /// 
        /// The protocol provides no guarantee that the grab is ever satisfied,
        /// and does not require the compositor to send an error if the grab
        /// cannot ever be satisfied. It is thus possible to request a keyboard
        /// grab that will never be effective.
        /// 
        /// The protocol:
        /// 
        /// * does not guarantee that the grab itself is applied for a surface,
        /// the grab request may be silently ignored by the compositor,
        /// * does not guarantee that any events are sent to this client even
        /// if the grab is applied to a surface,
        /// * does not guarantee that events sent to this client are exhaustive,
        /// a compositor may filter some events for its own consumption,
        /// * does not guarantee that events sent to this client are continuous,
        /// a compositor may change and reroute keyboard events while the grab
        /// is nominally active.
        /// </summary>
        public NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1 GrabKeyboard(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlSeat @seat)
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
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpXwaylandKeyboardGrabManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabManagerV1.WlInterface);
            }

            public ZwpXwaylandKeyboardGrabManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpXwaylandKeyboardGrabManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpXwaylandKeyboardGrabManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_xwayland_keyboard_grab_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpXwaylandKeyboardGrabManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A global interface used for grabbing the keyboard.
    /// </summary>
    public sealed unsafe partial class ZwpXwaylandKeyboardGrabV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpXwaylandKeyboardGrabV1()
        {
            WlInterface.Init("zwp_xwayland_keyboard_grab_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1.WlInterface);
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

        class ProxyFactory : IBindFactory<ZwpXwaylandKeyboardGrabV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XwaylandKeyboardGrabUnstableV1.ZwpXwaylandKeyboardGrabV1.WlInterface);
            }

            public ZwpXwaylandKeyboardGrabV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpXwaylandKeyboardGrabV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpXwaylandKeyboardGrabV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_xwayland_keyboard_grab_v1";
        public const int InterfaceVersion = 1;

        public ZwpXwaylandKeyboardGrabV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}