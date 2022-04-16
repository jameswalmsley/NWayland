using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.PointerGesturesUnstableV1
{
    /// <summary>
    /// A global interface to provide semantic touchpad gestures for a given
    /// pointer.
    /// 
    /// Two gestures are currently supported: swipe and zoom/rotate.
    /// All gestures follow a three-stage cycle: begin, update, end and
    /// are identified by a unique id.
    /// 
    /// Warning! The protocol described in this file is experimental and
    /// backward incompatible changes may be made. Backward compatible changes
    /// may be added together with the corresponding interface version bump.
    /// Backward incompatible changes are done by bumping the version number in
    /// the protocol and interface names and resetting the interface version.
    /// Once the protocol is to be declared stable, the 'z' prefix and the
    /// version number in the protocol and interface names are removed and the
    /// interface version number is reset.
    /// </summary>
    public sealed unsafe partial class ZwpPointerGesturesV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPointerGesturesV1()
        {
            WlInterface.Init("zwp_pointer_gestures_v1", 2, new WlMessage[] {
                WlMessage.Create("get_swipe_gesture", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface) }),
                WlMessage.Create("get_pinch_gesture", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface) }),
                WlMessage.Create("release", "2", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturesV1.WlInterface);
        }

        /// <summary>
        /// Create a swipe gesture object. See the
        /// wl_pointer_gesture_swipe interface for details.
        /// </summary>
        public NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1 GetSwipeGesture(NWayland.Protocols.Wayland.WlPointer @pointer)
        {
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @pointer
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1(__ret, Version, Display);
        }

        /// <summary>
        /// Create a pinch gesture object. See the
        /// wl_pointer_gesture_pinch interface for details.
        /// </summary>
        public NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1 GetPinchGesture(NWayland.Protocols.Wayland.WlPointer @pointer)
        {
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @pointer
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 2)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpPointerGesturesV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturesV1.WlInterface);
            }

            public ZwpPointerGesturesV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPointerGesturesV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPointerGesturesV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_pointer_gestures_v1";
        public const int InterfaceVersion = 2;

        public ZwpPointerGesturesV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A swipe gesture object notifies a client about a multi-finger swipe
    /// gesture detected on an indirect input device such as a touchpad.
    /// The gesture is usually initiated by multiple fingers moving in the
    /// same direction but once initiated the direction may change.
    /// The precise conditions of when such a gesture is detected are
    /// implementation-dependent.
    /// 
    /// A gesture consists of three stages: begin, update (optional) and end.
    /// There cannot be multiple simultaneous pinch or swipe gestures on a
    /// same pointer/seat, how compositors prevent these situations is
    /// implementation-dependent.
    /// 
    /// A gesture may be cancelled by the compositor or the hardware.
    /// Clients should not consider performing permanent or irreversible
    /// actions until the end of a gesture has been received.
    /// </summary>
    public sealed unsafe partial class ZwpPointerGestureSwipeV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPointerGestureSwipeV1()
        {
            WlInterface.Init("zwp_pointer_gesture_swipe_v1", 2, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("begin", "uuou", new WlInterface*[] { null, null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null }),
                WlMessage.Create("update", "uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("end", "uui", new WlInterface*[] { null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnBegin(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1 eventSender, uint @serial, uint @time, NWayland.Protocols.Wayland.WlSurface @surface, uint @fingers);
            void OnUpdate(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1 eventSender, uint @time, int @dx, int @dy);
            void OnEnd(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1 eventSender, uint @serial, uint @time, int @cancelled);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnBegin(this, arguments[0].UInt32, arguments[1].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr), arguments[3].UInt32);
            if (opcode == 1)
                Events?.OnUpdate(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32);
            if (opcode == 2)
                Events?.OnEnd(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].Int32);
        }

        class ProxyFactory : IBindFactory<ZwpPointerGestureSwipeV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGestureSwipeV1.WlInterface);
            }

            public ZwpPointerGestureSwipeV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPointerGestureSwipeV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPointerGestureSwipeV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_pointer_gesture_swipe_v1";
        public const int InterfaceVersion = 2;

        public ZwpPointerGestureSwipeV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A pinch gesture object notifies a client about a multi-finger pinch
    /// gesture detected on an indirect input device such as a touchpad.
    /// The gesture is usually initiated by multiple fingers moving towards
    /// each other or away from each other, or by two or more fingers rotating
    /// around a logical center of gravity. The precise conditions of when
    /// such a gesture is detected are implementation-dependent.
    /// 
    /// A gesture consists of three stages: begin, update (optional) and end.
    /// There cannot be multiple simultaneous pinch or swipe gestures on a
    /// same pointer/seat, how compositors prevent these situations is
    /// implementation-dependent.
    /// 
    /// A gesture may be cancelled by the compositor or the hardware.
    /// Clients should not consider performing permanent or irreversible
    /// actions until the end of a gesture has been received.
    /// </summary>
    public sealed unsafe partial class ZwpPointerGesturePinchV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPointerGesturePinchV1()
        {
            WlInterface.Init("zwp_pointer_gesture_pinch_v1", 2, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("begin", "uuou", new WlInterface*[] { null, null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null }),
                WlMessage.Create("update", "uffff", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("end", "uui", new WlInterface*[] { null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnBegin(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1 eventSender, uint @serial, uint @time, NWayland.Protocols.Wayland.WlSurface @surface, uint @fingers);
            void OnUpdate(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1 eventSender, uint @time, int @dx, int @dy, int @scale, int @rotation);
            void OnEnd(NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1 eventSender, uint @serial, uint @time, int @cancelled);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnBegin(this, arguments[0].UInt32, arguments[1].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr), arguments[3].UInt32);
            if (opcode == 1)
                Events?.OnUpdate(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32, arguments[4].Int32);
            if (opcode == 2)
                Events?.OnEnd(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].Int32);
        }

        class ProxyFactory : IBindFactory<ZwpPointerGesturePinchV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerGesturesUnstableV1.ZwpPointerGesturePinchV1.WlInterface);
            }

            public ZwpPointerGesturePinchV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPointerGesturePinchV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPointerGesturePinchV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_pointer_gesture_pinch_v1";
        public const int InterfaceVersion = 2;

        public ZwpPointerGesturePinchV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}