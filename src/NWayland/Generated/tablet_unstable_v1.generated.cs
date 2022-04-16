using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.TabletUnstableV1
{
    /// <summary>
    /// An object that provides access to the graphics tablets available on this
    /// system. All tablets are associated with a seat, to get access to the
    /// actual tablets, use wp_tablet_manager.get_tablet_seat.
    /// </summary>
    public sealed unsafe partial class ZwpTabletManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletManagerV1()
        {
            WlInterface.Init("zwp_tablet_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("get_tablet_seat", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletManagerV1.WlInterface);
        }

        /// <summary>
        /// Get the wp_tablet_seat object for the given seat. This object
        /// provides access to all graphics tablets in this seat.
        /// </summary>
        public NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1 GetTabletSeat(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<ZwpTabletManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletManagerV1.WlInterface);
            }

            public ZwpTabletManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpTabletManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An object that provides access to the graphics tablets available on this
    /// seat. After binding to this interface, the compositor sends a set of
    /// wp_tablet_seat.tablet_added and wp_tablet_seat.tool_added events.
    /// </summary>
    public sealed unsafe partial class ZwpTabletSeatV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletSeatV1()
        {
            WlInterface.Init("zwp_tablet_seat_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("tablet_added", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletV1.WlInterface) }),
                WlMessage.Create("tool_added", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnTabletAdded(NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1 eventSender, ZwpTabletV1 @id);
            void OnToolAdded(NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1 eventSender, ZwpTabletToolV1 @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTabletAdded(this, new ZwpTabletV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnToolAdded(this, new ZwpTabletToolV1(arguments[0].IntPtr, Version, Display));
        }

        class ProxyFactory : IBindFactory<ZwpTabletSeatV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletSeatV1.WlInterface);
            }

            public ZwpTabletSeatV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletSeatV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletSeatV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_seat_v1";
        public const int InterfaceVersion = 1;

        public ZwpTabletSeatV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An object that represents a physical tool that has been, or is
    /// currently in use with a tablet in this seat. Each wp_tablet_tool
    /// object stays valid until the client destroys it; the compositor
    /// reuses the wp_tablet_tool object to indicate that the object's
    /// respective physical tool has come into proximity of a tablet again.
    /// 
    /// A wp_tablet_tool object's relation to a physical tool depends on the
    /// tablet's ability to report serial numbers. If the tablet supports
    /// this capability, then the object represents a specific physical tool
    /// and can be identified even when used on multiple tablets.
    /// 
    /// A tablet tool has a number of static characteristics, e.g. tool type,
    /// hardware_serial and capabilities. These capabilities are sent in an
    /// event sequence after the wp_tablet_seat.tool_added event before any
    /// actual events from this tool. This initial event sequence is
    /// terminated by a wp_tablet_tool.done event.
    /// 
    /// Tablet tool events are grouped by wp_tablet_tool.frame events.
    /// Any events received before a wp_tablet_tool.frame event should be
    /// considered part of the same hardware state change.
    /// </summary>
    public sealed unsafe partial class ZwpTabletToolV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletToolV1()
        {
            WlInterface.Init("zwp_tablet_tool_v1", 1, new WlMessage[] {
                WlMessage.Create("set_cursor", "u?oii", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("type", "u", new WlInterface*[] { null }),
                WlMessage.Create("hardware_serial", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("hardware_id_wacom", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("capability", "u", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("removed", "", new WlInterface*[] { }),
                WlMessage.Create("proximity_in", "uoo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("proximity_out", "", new WlInterface*[] { }),
                WlMessage.Create("down", "u", new WlInterface*[] { null }),
                WlMessage.Create("up", "", new WlInterface*[] { }),
                WlMessage.Create("motion", "ff", new WlInterface*[] { null, null }),
                WlMessage.Create("pressure", "u", new WlInterface*[] { null }),
                WlMessage.Create("distance", "u", new WlInterface*[] { null }),
                WlMessage.Create("tilt", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("rotation", "i", new WlInterface*[] { null }),
                WlMessage.Create("slider", "i", new WlInterface*[] { null }),
                WlMessage.Create("wheel", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("button", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("frame", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1.WlInterface);
        }

        /// <summary>
        /// Sets the surface of the cursor used for this tool on the given
        /// tablet. This request only takes effect if the tool is in proximity
        /// of one of the requesting client's surfaces or the surface parameter
        /// is the current pointer surface. If there was a previous surface set
        /// with this request it is replaced. If surface is NULL, the cursor
        /// image is hidden.
        /// 
        /// The parameters hotspot_x and hotspot_y define the position of the
        /// pointer surface relative to the pointer location. Its top-left corner
        /// is always at (x, y) - (hotspot_x, hotspot_y), where (x, y) are the
        /// coordinates of the pointer location, in surface-local coordinates.
        /// 
        /// On surface.attach requests to the pointer surface, hotspot_x and
        /// hotspot_y are decremented by the x and y parameters passed to the
        /// request. Attach must be confirmed by wl_surface.commit as usual.
        /// 
        /// The hotspot can also be updated by passing the currently set pointer
        /// surface to this request with new values for hotspot_x and hotspot_y.
        /// 
        /// The current and pending input regions of the wl_surface are cleared,
        /// and wl_surface.set_input_region is ignored until the wl_surface is no
        /// longer used as the cursor. When the use as a cursor ends, the current
        /// and pending input regions become undefined, and the wl_surface is
        /// unmapped.
        /// 
        /// This request gives the surface the role of a cursor. The role
        /// assigned by this request is the same as assigned by
        /// wl_pointer.set_cursor meaning the same surface can be
        /// used both as a wl_pointer cursor and a wp_tablet cursor. If the
        /// surface already has another role, it raises a protocol error.
        /// The surface may be used on multiple tablets and across multiple
        /// seats.
        /// </summary>
        public void SetCursor(uint @serial, NWayland.Protocols.Wayland.WlSurface @surface, int @hotspotX, int @hotspotY)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @surface,
                @hotspotX,
                @hotspotY
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
            void OnType(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, TypeEnum @toolType);
            void OnHardwareSerial(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @hardwareSerialHi, uint @hardwareSerialLo);
            void OnHardwareIdWacom(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @hardwareIdHi, uint @hardwareIdLo);
            void OnCapability(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, CapabilityEnum @capability);
            void OnDone(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender);
            void OnRemoved(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender);
            void OnProximityIn(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @serial, NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 @tablet, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnProximityOut(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender);
            void OnDown(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @serial);
            void OnUp(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender);
            void OnMotion(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, int @x, int @y);
            void OnPressure(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @pressure);
            void OnDistance(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @distance);
            void OnTilt(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, int @tiltX, int @tiltY);
            void OnRotation(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, int @degrees);
            void OnSlider(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, int @position);
            void OnWheel(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, int @degrees, int @clicks);
            void OnButton(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @serial, uint @button, ButtonStateEnum @state);
            void OnFrame(NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1 eventSender, uint @time);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnType(this, (TypeEnum)arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnHardwareSerial(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 2)
                Events?.OnHardwareIdWacom(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 3)
                Events?.OnCapability(this, (CapabilityEnum)arguments[0].UInt32);
            if (opcode == 4)
                Events?.OnDone(this);
            if (opcode == 5)
                Events?.OnRemoved(this);
            if (opcode == 6)
                Events?.OnProximityIn(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.TabletUnstableV1.ZwpTabletV1>(arguments[1].IntPtr), WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr));
            if (opcode == 7)
                Events?.OnProximityOut(this);
            if (opcode == 8)
                Events?.OnDown(this, arguments[0].UInt32);
            if (opcode == 9)
                Events?.OnUp(this);
            if (opcode == 10)
                Events?.OnMotion(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 11)
                Events?.OnPressure(this, arguments[0].UInt32);
            if (opcode == 12)
                Events?.OnDistance(this, arguments[0].UInt32);
            if (opcode == 13)
                Events?.OnTilt(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 14)
                Events?.OnRotation(this, arguments[0].Int32);
            if (opcode == 15)
                Events?.OnSlider(this, arguments[0].Int32);
            if (opcode == 16)
                Events?.OnWheel(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 17)
                Events?.OnButton(this, arguments[0].UInt32, arguments[1].UInt32, (ButtonStateEnum)arguments[2].UInt32);
            if (opcode == 18)
                Events?.OnFrame(this, arguments[0].UInt32);
        }

        /// <summary>
        /// Describes the physical type of a tool. The physical type of a tool
        /// generally defines its base usage.
        /// 
        /// The mouse tool represents a mouse-shaped tool that is not a relative
        /// device but bound to the tablet's surface, providing absolute
        /// coordinates.
        /// 
        /// The lens tool is a mouse-shaped tool with an attached lens to
        /// provide precision focus.
        /// </summary>
        public enum TypeEnum
        {
            /// <summary>Pen</summary>
            Pen = 0x140,
            /// <summary>Eraser</summary>
            Eraser = 0x141,
            /// <summary>Brush</summary>
            Brush = 0x142,
            /// <summary>Pencil</summary>
            Pencil = 0x143,
            /// <summary>Airbrush</summary>
            Airbrush = 0x144,
            /// <summary>Finger</summary>
            Finger = 0x145,
            /// <summary>Mouse</summary>
            Mouse = 0x146,
            /// <summary>Lens</summary>
            Lens = 0x147
        }

        /// <summary>
        /// Describes extra capabilities on a tablet.
        /// 
        /// Any tool must provide x and y values, extra axes are
        /// device-specific.
        /// </summary>
        public enum CapabilityEnum
        {
            /// <summary>Tilt axes</summary>
            Tilt = 1,
            /// <summary>Pressure axis</summary>
            Pressure = 2,
            /// <summary>Distance axis</summary>
            Distance = 3,
            /// <summary>Z-rotation axis</summary>
            Rotation = 4,
            /// <summary>Slider axis</summary>
            Slider = 5,
            /// <summary>Wheel axis</summary>
            Wheel = 6
        }

        /// <summary>
        /// Describes the physical state of a button that produced the button event.
        /// </summary>
        public enum ButtonStateEnum
        {
            /// <summary>button is not pressed</summary>
            Released = 0,
            /// <summary>button is pressed</summary>
            Pressed = 1
        }

        public enum ErrorEnum
        {
            /// <summary>given wl_surface has another role</summary>
            Role = 0
        }

        class ProxyFactory : IBindFactory<ZwpTabletToolV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletToolV1.WlInterface);
            }

            public ZwpTabletToolV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletToolV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletToolV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_tool_v1";
        public const int InterfaceVersion = 1;

        public ZwpTabletToolV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wp_tablet interface represents one graphics tablet device. The
    /// tablet interface itself does not generate events; all events are
    /// generated by wp_tablet_tool objects when in proximity above a tablet.
    /// 
    /// A tablet has a number of static characteristics, e.g. device name and
    /// pid/vid. These capabilities are sent in an event sequence after the
    /// wp_tablet_seat.tablet_added event. This initial event sequence is
    /// terminated by a wp_tablet.done event.
    /// </summary>
    public sealed unsafe partial class ZwpTabletV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletV1()
        {
            WlInterface.Init("zwp_tablet_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("name", "s", new WlInterface*[] { null }),
                WlMessage.Create("id", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("path", "s", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("removed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnName(NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 eventSender, System.String @name);
            void OnId(NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 eventSender, uint @vid, uint @pid);
            void OnPath(NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 eventSender, System.String @path);
            void OnDone(NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 eventSender);
            void OnRemoved(NWayland.Protocols.TabletUnstableV1.ZwpTabletV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnName(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnId(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 2)
                Events?.OnPath(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 3)
                Events?.OnDone(this);
            if (opcode == 4)
                Events?.OnRemoved(this);
        }

        class ProxyFactory : IBindFactory<ZwpTabletV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV1.ZwpTabletV1.WlInterface);
            }

            public ZwpTabletV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_v1";
        public const int InterfaceVersion = 1;

        public ZwpTabletV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}