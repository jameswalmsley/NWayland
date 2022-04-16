using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.TabletUnstableV2
{
    /// <summary>
    /// An object that provides access to the graphics tablets available on this
    /// system. All tablets are associated with a seat, to get access to the
    /// actual tablets, use wp_tablet_manager.get_tablet_seat.
    /// </summary>
    public sealed unsafe partial class ZwpTabletManagerV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletManagerV2()
        {
            WlInterface.Init("zwp_tablet_manager_v2", 1, new WlMessage[] {
                WlMessage.Create("get_tablet_seat", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletManagerV2.WlInterface);
        }

        /// <summary>
        /// Get the wp_tablet_seat object for the given seat. This object
        /// provides access to all graphics tablets in this seat.
        /// </summary>
        public NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2 GetTabletSeat(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<ZwpTabletManagerV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletManagerV2.WlInterface);
            }

            public ZwpTabletManagerV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletManagerV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletManagerV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_manager_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletManagerV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An object that provides access to the graphics tablets available on this
    /// seat. After binding to this interface, the compositor sends a set of
    /// wp_tablet_seat.tablet_added and wp_tablet_seat.tool_added events.
    /// </summary>
    public sealed unsafe partial class ZwpTabletSeatV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletSeatV2()
        {
            WlInterface.Init("zwp_tablet_seat_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("tablet_added", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletV2.WlInterface) }),
                WlMessage.Create("tool_added", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2.WlInterface) }),
                WlMessage.Create("pad_added", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnTabletAdded(NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2 eventSender, ZwpTabletV2 @id);
            void OnToolAdded(NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2 eventSender, ZwpTabletToolV2 @id);
            void OnPadAdded(NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2 eventSender, ZwpTabletPadV2 @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTabletAdded(this, new ZwpTabletV2(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnToolAdded(this, new ZwpTabletToolV2(arguments[0].IntPtr, Version, Display));
            if (opcode == 2)
                Events?.OnPadAdded(this, new ZwpTabletPadV2(arguments[0].IntPtr, Version, Display));
        }

        class ProxyFactory : IBindFactory<ZwpTabletSeatV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletSeatV2.WlInterface);
            }

            public ZwpTabletSeatV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletSeatV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletSeatV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_seat_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletSeatV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
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
    public sealed unsafe partial class ZwpTabletToolV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletToolV2()
        {
            WlInterface.Init("zwp_tablet_tool_v2", 1, new WlMessage[] {
                WlMessage.Create("set_cursor", "u?oii", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("type", "u", new WlInterface*[] { null }),
                WlMessage.Create("hardware_serial", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("hardware_id_wacom", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("capability", "u", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("removed", "", new WlInterface*[] { }),
                WlMessage.Create("proximity_in", "uoo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletV2.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("proximity_out", "", new WlInterface*[] { }),
                WlMessage.Create("down", "u", new WlInterface*[] { null }),
                WlMessage.Create("up", "", new WlInterface*[] { }),
                WlMessage.Create("motion", "ff", new WlInterface*[] { null, null }),
                WlMessage.Create("pressure", "u", new WlInterface*[] { null }),
                WlMessage.Create("distance", "u", new WlInterface*[] { null }),
                WlMessage.Create("tilt", "ff", new WlInterface*[] { null, null }),
                WlMessage.Create("rotation", "f", new WlInterface*[] { null }),
                WlMessage.Create("slider", "i", new WlInterface*[] { null }),
                WlMessage.Create("wheel", "fi", new WlInterface*[] { null, null }),
                WlMessage.Create("button", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("frame", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2.WlInterface);
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
        /// This request gives the surface the role of a wp_tablet_tool cursor. A
        /// surface may only ever be used as the cursor surface for one
        /// wp_tablet_tool. If the surface already has another role or has
        /// previously been used as cursor surface for a different tool, a
        /// protocol error is raised.
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
            void OnType(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, TypeEnum @toolType);
            void OnHardwareSerial(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @hardwareSerialHi, uint @hardwareSerialLo);
            void OnHardwareIdWacom(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @hardwareIdHi, uint @hardwareIdLo);
            void OnCapability(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, CapabilityEnum @capability);
            void OnDone(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender);
            void OnRemoved(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender);
            void OnProximityIn(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @serial, NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 @tablet, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnProximityOut(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender);
            void OnDown(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @serial);
            void OnUp(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender);
            void OnMotion(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, int @x, int @y);
            void OnPressure(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @pressure);
            void OnDistance(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @distance);
            void OnTilt(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, int @tiltX, int @tiltY);
            void OnRotation(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, int @degrees);
            void OnSlider(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, int @position);
            void OnWheel(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, int @degrees, int @clicks);
            void OnButton(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @serial, uint @button, ButtonStateEnum @state);
            void OnFrame(NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2 eventSender, uint @time);
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
                Events?.OnProximityIn(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.TabletUnstableV2.ZwpTabletV2>(arguments[1].IntPtr), WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr));
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

        class ProxyFactory : IBindFactory<ZwpTabletToolV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletToolV2.WlInterface);
            }

            public ZwpTabletToolV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletToolV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletToolV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_tool_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletToolV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
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
    public sealed unsafe partial class ZwpTabletV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletV2()
        {
            WlInterface.Init("zwp_tablet_v2", 1, new WlMessage[] {
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
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnName(NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 eventSender, System.String @name);
            void OnId(NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 eventSender, uint @vid, uint @pid);
            void OnPath(NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 eventSender, System.String @path);
            void OnDone(NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 eventSender);
            void OnRemoved(NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 eventSender);
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

        class ProxyFactory : IBindFactory<ZwpTabletV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletV2.WlInterface);
            }

            public ZwpTabletV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A circular interaction area, such as the touch ring on the Wacom Intuos
    /// Pro series tablets.
    /// 
    /// Events on a ring are logically grouped by the wl_tablet_pad_ring.frame
    /// event.
    /// </summary>
    public sealed unsafe partial class ZwpTabletPadRingV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletPadRingV2()
        {
            WlInterface.Init("zwp_tablet_pad_ring_v2", 1, new WlMessage[] {
                WlMessage.Create("set_feedback", "su", new WlInterface*[] { null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("source", "u", new WlInterface*[] { null }),
                WlMessage.Create("angle", "f", new WlInterface*[] { null }),
                WlMessage.Create("stop", "", new WlInterface*[] { }),
                WlMessage.Create("frame", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2.WlInterface);
        }

        /// <summary>
        /// Request that the compositor use the provided feedback string
        /// associated with this ring. This request should be issued immediately
        /// after a wp_tablet_pad_group.mode_switch event from the corresponding
        /// group is received, or whenever the ring is mapped to a different
        /// action. See wp_tablet_pad_group.mode_switch for more details.
        /// 
        /// Clients are encouraged to provide context-aware descriptions for
        /// the actions associated with the ring; compositors may use this
        /// information to offer visual feedback about the button layout
        /// (eg. on-screen displays).
        /// 
        /// The provided string 'description' is a UTF-8 encoded string to be
        /// associated with this ring, and is considered user-visible; general
        /// internationalization rules apply.
        /// 
        /// The serial argument will be that of the last
        /// wp_tablet_pad_group.mode_switch event received for the group of this
        /// ring. Requests providing other serials than the most recent one will be
        /// ignored.
        /// </summary>
        public void SetFeedback(System.String @description, uint @serial)
        {
            if (@description == null)
                throw new System.ArgumentNullException("description");
            using var __marshalled__description = new NWayland.Interop.NWaylandMarshalledString(@description);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__description,
                @serial
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
            void OnSource(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2 eventSender, SourceEnum @source);
            void OnAngle(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2 eventSender, int @degrees);
            void OnStop(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2 eventSender);
            void OnFrame(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2 eventSender, uint @time);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSource(this, (SourceEnum)arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnAngle(this, arguments[0].Int32);
            if (opcode == 2)
                Events?.OnStop(this);
            if (opcode == 3)
                Events?.OnFrame(this, arguments[0].UInt32);
        }

        /// <summary>
        /// Describes the source types for ring events. This indicates to the
        /// client how a ring event was physically generated; a client may
        /// adjust the user interface accordingly. For example, events
        /// from a "finger" source may trigger kinetic scrolling.
        /// </summary>
        public enum SourceEnum
        {
            /// <summary>finger</summary>
            Finger = 1
        }

        class ProxyFactory : IBindFactory<ZwpTabletPadRingV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2.WlInterface);
            }

            public ZwpTabletPadRingV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletPadRingV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletPadRingV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_pad_ring_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletPadRingV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A linear interaction area, such as the strips found in Wacom Cintiq
    /// models.
    /// 
    /// Events on a strip are logically grouped by the wl_tablet_pad_strip.frame
    /// event.
    /// </summary>
    public sealed unsafe partial class ZwpTabletPadStripV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletPadStripV2()
        {
            WlInterface.Init("zwp_tablet_pad_strip_v2", 1, new WlMessage[] {
                WlMessage.Create("set_feedback", "su", new WlInterface*[] { null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("source", "u", new WlInterface*[] { null }),
                WlMessage.Create("position", "u", new WlInterface*[] { null }),
                WlMessage.Create("stop", "", new WlInterface*[] { }),
                WlMessage.Create("frame", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2.WlInterface);
        }

        /// <summary>
        /// Requests the compositor to use the provided feedback string
        /// associated with this strip. This request should be issued immediately
        /// after a wp_tablet_pad_group.mode_switch event from the corresponding
        /// group is received, or whenever the strip is mapped to a different
        /// action. See wp_tablet_pad_group.mode_switch for more details.
        /// 
        /// Clients are encouraged to provide context-aware descriptions for
        /// the actions associated with the strip, and compositors may use this
        /// information to offer visual feedback about the button layout
        /// (eg. on-screen displays).
        /// 
        /// The provided string 'description' is a UTF-8 encoded string to be
        /// associated with this ring, and is considered user-visible; general
        /// internationalization rules apply.
        /// 
        /// The serial argument will be that of the last
        /// wp_tablet_pad_group.mode_switch event received for the group of this
        /// strip. Requests providing other serials than the most recent one will be
        /// ignored.
        /// </summary>
        public void SetFeedback(System.String @description, uint @serial)
        {
            if (@description == null)
                throw new System.ArgumentNullException("description");
            using var __marshalled__description = new NWayland.Interop.NWaylandMarshalledString(@description);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__description,
                @serial
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
            void OnSource(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2 eventSender, SourceEnum @source);
            void OnPosition(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2 eventSender, uint @position);
            void OnStop(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2 eventSender);
            void OnFrame(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2 eventSender, uint @time);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSource(this, (SourceEnum)arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnPosition(this, arguments[0].UInt32);
            if (opcode == 2)
                Events?.OnStop(this);
            if (opcode == 3)
                Events?.OnFrame(this, arguments[0].UInt32);
        }

        /// <summary>
        /// Describes the source types for strip events. This indicates to the
        /// client how a strip event was physically generated; a client may
        /// adjust the user interface accordingly. For example, events
        /// from a "finger" source may trigger kinetic scrolling.
        /// </summary>
        public enum SourceEnum
        {
            /// <summary>finger</summary>
            Finger = 1
        }

        class ProxyFactory : IBindFactory<ZwpTabletPadStripV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2.WlInterface);
            }

            public ZwpTabletPadStripV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletPadStripV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletPadStripV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_pad_strip_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletPadStripV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A pad group describes a distinct (sub)set of buttons, rings and strips
    /// present in the tablet. The criteria of this grouping is usually positional,
    /// eg. if a tablet has buttons on the left and right side, 2 groups will be
    /// presented. The physical arrangement of groups is undisclosed and may
    /// change on the fly.
    /// 
    /// Pad groups will announce their features during pad initialization. Between
    /// the corresponding wp_tablet_pad.group event and wp_tablet_pad_group.done, the
    /// pad group will announce the buttons, rings and strips contained in it,
    /// plus the number of supported modes.
    /// 
    /// Modes are a mechanism to allow multiple groups of actions for every element
    /// in the pad group. The number of groups and available modes in each is
    /// persistent across device plugs. The current mode is user-switchable, it
    /// will be announced through the wp_tablet_pad_group.mode_switch event both
    /// whenever it is switched, and after wp_tablet_pad.enter.
    /// 
    /// The current mode logically applies to all elements in the pad group,
    /// although it is at clients' discretion whether to actually perform different
    /// actions, and/or issue the respective .set_feedback requests to notify the
    /// compositor. See the wp_tablet_pad_group.mode_switch event for more details.
    /// </summary>
    public sealed unsafe partial class ZwpTabletPadGroupV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletPadGroupV2()
        {
            WlInterface.Init("zwp_tablet_pad_group_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("buttons", "a", new WlInterface*[] { null }),
                WlMessage.Create("ring", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadRingV2.WlInterface) }),
                WlMessage.Create("strip", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadStripV2.WlInterface) }),
                WlMessage.Create("modes", "u", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("mode_switch", "uuu", new WlInterface*[] { null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnButtons(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender, ReadOnlySpan<byte> @buttons);
            void OnRing(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender, ZwpTabletPadRingV2 @ring);
            void OnStrip(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender, ZwpTabletPadStripV2 @strip);
            void OnModes(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender, uint @modes);
            void OnDone(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender);
            void OnModeSwitch(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2 eventSender, uint @time, uint @serial, uint @mode);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnButtons(this, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnRing(this, new ZwpTabletPadRingV2(arguments[0].IntPtr, Version, Display));
            if (opcode == 2)
                Events?.OnStrip(this, new ZwpTabletPadStripV2(arguments[0].IntPtr, Version, Display));
            if (opcode == 3)
                Events?.OnModes(this, arguments[0].UInt32);
            if (opcode == 4)
                Events?.OnDone(this);
            if (opcode == 5)
                Events?.OnModeSwitch(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
        }

        class ProxyFactory : IBindFactory<ZwpTabletPadGroupV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2.WlInterface);
            }

            public ZwpTabletPadGroupV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletPadGroupV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletPadGroupV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_pad_group_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletPadGroupV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A pad device is a set of buttons, rings and strips
    /// usually physically present on the tablet device itself. Some
    /// exceptions exist where the pad device is physically detached, e.g. the
    /// Wacom ExpressKey Remote.
    /// 
    /// Pad devices have no axes that control the cursor and are generally
    /// auxiliary devices to the tool devices used on the tablet surface.
    /// 
    /// A pad device has a number of static characteristics, e.g. the number
    /// of rings. These capabilities are sent in an event sequence after the
    /// wp_tablet_seat.pad_added event before any actual events from this pad.
    /// This initial event sequence is terminated by a wp_tablet_pad.done
    /// event.
    /// 
    /// All pad features (buttons, rings and strips) are logically divided into
    /// groups and all pads have at least one group. The available groups are
    /// notified through the wp_tablet_pad.group event; the compositor will
    /// emit one event per group before emitting wp_tablet_pad.done.
    /// 
    /// Groups may have multiple modes. Modes allow clients to map multiple
    /// actions to a single pad feature. Only one mode can be active per group,
    /// although different groups may have different active modes.
    /// </summary>
    public sealed unsafe partial class ZwpTabletPadV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTabletPadV2()
        {
            WlInterface.Init("zwp_tablet_pad_v2", 1, new WlMessage[] {
                WlMessage.Create("set_feedback", "usu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("group", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadGroupV2.WlInterface) }),
                WlMessage.Create("path", "s", new WlInterface*[] { null }),
                WlMessage.Create("buttons", "u", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("button", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("enter", "uoo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletV2.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("leave", "uo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("removed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2.WlInterface);
        }

        /// <summary>
        /// Requests the compositor to use the provided feedback string
        /// associated with this button. This request should be issued immediately
        /// after a wp_tablet_pad_group.mode_switch event from the corresponding
        /// group is received, or whenever a button is mapped to a different
        /// action. See wp_tablet_pad_group.mode_switch for more details.
        /// 
        /// Clients are encouraged to provide context-aware descriptions for
        /// the actions associated with each button, and compositors may use
        /// this information to offer visual feedback on the button layout
        /// (e.g. on-screen displays).
        /// 
        /// Button indices start at 0. Setting the feedback string on a button
        /// that is reserved by the compositor (i.e. not belonging to any
        /// wp_tablet_pad_group) does not generate an error but the compositor
        /// is free to ignore the request.
        /// 
        /// The provided string 'description' is a UTF-8 encoded string to be
        /// associated with this ring, and is considered user-visible; general
        /// internationalization rules apply.
        /// 
        /// The serial argument will be that of the last
        /// wp_tablet_pad_group.mode_switch event received for the group of this
        /// button. Requests providing other serials than the most recent one will
        /// be ignored.
        /// </summary>
        public void SetFeedback(uint @button, System.String @description, uint @serial)
        {
            if (@description == null)
                throw new System.ArgumentNullException("description");
            using var __marshalled__description = new NWayland.Interop.NWaylandMarshalledString(@description);
            WlArgument* __args = stackalloc WlArgument[] {
                @button,
                __marshalled__description,
                @serial
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
            void OnGroup(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, ZwpTabletPadGroupV2 @padGroup);
            void OnPath(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, System.String @path);
            void OnButtons(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, uint @buttons);
            void OnDone(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender);
            void OnButton(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, uint @time, uint @button, ButtonStateEnum @state);
            void OnEnter(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, uint @serial, NWayland.Protocols.TabletUnstableV2.ZwpTabletV2 @tablet, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnLeave(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnRemoved(NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGroup(this, new ZwpTabletPadGroupV2(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnPath(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnButtons(this, arguments[0].UInt32);
            if (opcode == 3)
                Events?.OnDone(this);
            if (opcode == 4)
                Events?.OnButton(this, arguments[0].UInt32, arguments[1].UInt32, (ButtonStateEnum)arguments[2].UInt32);
            if (opcode == 5)
                Events?.OnEnter(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.TabletUnstableV2.ZwpTabletV2>(arguments[1].IntPtr), WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[2].IntPtr));
            if (opcode == 6)
                Events?.OnLeave(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr));
            if (opcode == 7)
                Events?.OnRemoved(this);
        }

        /// <summary>
        /// Describes the physical state of a button that caused the button
        /// event.
        /// </summary>
        public enum ButtonStateEnum
        {
            /// <summary>the button is not pressed</summary>
            Released = 0,
            /// <summary>the button is pressed</summary>
            Pressed = 1
        }

        class ProxyFactory : IBindFactory<ZwpTabletPadV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TabletUnstableV2.ZwpTabletPadV2.WlInterface);
            }

            public ZwpTabletPadV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTabletPadV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTabletPadV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_tablet_pad_v2";
        public const int InterfaceVersion = 1;

        public ZwpTabletPadV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}