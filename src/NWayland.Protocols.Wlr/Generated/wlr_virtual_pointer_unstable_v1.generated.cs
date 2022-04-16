using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1
{
    /// <summary>
    /// This protocol allows clients to emulate a physical pointer device. The
    /// requests are mostly mirror opposites of those specified in wl_pointer.
    /// </summary>
    public sealed unsafe partial class ZwlrVirtualPointerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrVirtualPointerV1()
        {
            WlInterface.Init("zwlr_virtual_pointer_v1", 1, new WlMessage[] {
                WlMessage.Create("motion", "uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("motion_absolute", "uuuuu", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("button", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("axis", "uuf", new WlInterface*[] { null, null, null }),
                WlMessage.Create("frame", "", new WlInterface*[] { }),
                WlMessage.Create("axis_source", "u", new WlInterface*[] { null }),
                WlMessage.Create("axis_stop", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("axis_discrete", "uufi", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("destroy", "1", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1.WlInterface);
        }

        /// <summary>
        /// The pointer has moved by a relative amount to the previous request.
        /// 
        /// Values are in the global compositor space.
        /// </summary>
        public void Motion(uint @time, int @dx, int @dy)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                @dx,
                @dy
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The pointer has moved in an absolute coordinate frame.
        /// 
        /// Value of x can range from 0 to x_extent, value of y can range from 0
        /// to y_extent.
        /// </summary>
        public void MotionAbsolute(uint @time, uint @x, uint @y, uint @xExtent, uint @yExtent)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                @x,
                @y,
                @xExtent,
                @yExtent
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// A button was pressed or released.
        /// </summary>
        public void Button(uint @time, uint @button, NWayland.Protocols.Wayland.WlPointer.ButtonStateEnum @state)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                @button,
                (uint)@state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Scroll and other axis requests.
        /// </summary>
        public void Axis(uint @time, NWayland.Protocols.Wayland.WlPointer.AxisEnum @axis, int @value)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                (uint)@axis,
                @value
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Indicates the set of events that logically belong together.
        /// </summary>
        public void Frame()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Source information for scroll and other axis.
        /// </summary>
        public void AxisSource(NWayland.Protocols.Wayland.WlPointer.AxisSourceEnum @axisSource)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@axisSource
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Stop notification for scroll and other axes.
        /// </summary>
        public void AxisStop(uint @time, NWayland.Protocols.Wayland.WlPointer.AxisEnum @axis)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                (uint)@axis
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Discrete step information for scroll and other axes.
        /// 
        /// This event allows the client to extend data normally sent using the axis
        /// event with discrete value.
        /// </summary>
        public void AxisDiscrete(uint @time, NWayland.Protocols.Wayland.WlPointer.AxisEnum @axis, int @value, int @discrete)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @time,
                (uint)@axis,
                @value,
                @discrete
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 1)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwlrVirtualPointerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1.WlInterface);
            }

            public ZwlrVirtualPointerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrVirtualPointerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrVirtualPointerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_virtual_pointer_v1";
        public const int InterfaceVersion = 1;

        public ZwlrVirtualPointerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object allows clients to create individual virtual pointer objects.
    /// </summary>
    public sealed unsafe partial class ZwlrVirtualPointerManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrVirtualPointerManagerV1()
        {
            WlInterface.Init("zwlr_virtual_pointer_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("create_virtual_pointer", "?on", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerManagerV1.WlInterface);
        }

        /// <summary>
        /// Creates a new virtual pointer. The optional seat is a suggestion to the
        /// compositor.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1 CreateVirtualPointer(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwlrVirtualPointerManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrVirtualPointerUnstableV1.ZwlrVirtualPointerManagerV1.WlInterface);
            }

            public ZwlrVirtualPointerManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrVirtualPointerManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrVirtualPointerManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_virtual_pointer_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwlrVirtualPointerManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}