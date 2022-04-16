using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.InputTimestampsUnstableV1
{
    /// <summary>
    /// A global interface used for requesting high-resolution timestamps
    /// for input events.
    /// </summary>
    public sealed unsafe partial class ZwpInputTimestampsManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputTimestampsManagerV1()
        {
            WlInterface.Init("zwp_input_timestamps_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_keyboard_timestamps", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface) }),
                WlMessage.Create("get_pointer_timestamps", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface) }),
                WlMessage.Create("get_touch_timestamps", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlTouch.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Creates a new input timestamps object that represents a subscription
        /// to high-resolution timestamp events for all wl_keyboard events that
        /// carry a timestamp.
        /// 
        /// If the associated wl_keyboard object is invalidated, either through
        /// client action (e.g. release) or server-side changes, the input
        /// timestamps object becomes inert and the client should destroy it
        /// by calling zwp_input_timestamps_v1.destroy.
        /// </summary>
        public NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1 GetKeyboardTimestamps(NWayland.Protocols.Wayland.WlKeyboard @keyboard)
        {
            if (@keyboard == null)
                throw new System.ArgumentNullException("keyboard");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @keyboard
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1(__ret, Version, Display);
        }

        /// <summary>
        /// Creates a new input timestamps object that represents a subscription
        /// to high-resolution timestamp events for all wl_pointer events that
        /// carry a timestamp.
        /// 
        /// If the associated wl_pointer object is invalidated, either through
        /// client action (e.g. release) or server-side changes, the input
        /// timestamps object becomes inert and the client should destroy it
        /// by calling zwp_input_timestamps_v1.destroy.
        /// </summary>
        public NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1 GetPointerTimestamps(NWayland.Protocols.Wayland.WlPointer @pointer)
        {
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @pointer
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1(__ret, Version, Display);
        }

        /// <summary>
        /// Creates a new input timestamps object that represents a subscription
        /// to high-resolution timestamp events for all wl_touch events that
        /// carry a timestamp.
        /// 
        /// If the associated wl_touch object becomes invalid, either through
        /// client action (e.g. release) or server-side changes, the input
        /// timestamps object becomes inert and the client should destroy it
        /// by calling zwp_input_timestamps_v1.destroy.
        /// </summary>
        public NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1 GetTouchTimestamps(NWayland.Protocols.Wayland.WlTouch @touch)
        {
            if (@touch == null)
                throw new System.ArgumentNullException("touch");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @touch
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 3, __args, ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpInputTimestampsManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsManagerV1.WlInterface);
            }

            public ZwpInputTimestampsManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputTimestampsManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputTimestampsManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_timestamps_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputTimestampsManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// Provides high-resolution timestamp events for a set of subscribed input
    /// events. The set of subscribed input events is determined by the
    /// zwp_input_timestamps_manager_v1 request used to create this object.
    /// </summary>
    public sealed unsafe partial class ZwpInputTimestampsV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputTimestampsV1()
        {
            WlInterface.Init("zwp_input_timestamps_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("timestamp", "uuu", new WlInterface*[] { null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnTimestamp(NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1 eventSender, uint @tvSecHi, uint @tvSecLo, uint @tvNsec);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTimestamp(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
        }

        class ProxyFactory : IBindFactory<ZwpInputTimestampsV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputTimestampsUnstableV1.ZwpInputTimestampsV1.WlInterface);
            }

            public ZwpInputTimestampsV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputTimestampsV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputTimestampsV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_timestamps_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputTimestampsV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}