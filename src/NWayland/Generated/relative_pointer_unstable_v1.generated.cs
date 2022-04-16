using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.RelativePointerUnstableV1
{
    /// <summary>
    /// A global interface used for getting the relative pointer object for a
    /// given pointer.
    /// </summary>
    public sealed unsafe partial class ZwpRelativePointerManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpRelativePointerManagerV1()
        {
            WlInterface.Init("zwp_relative_pointer_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_relative_pointer", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a relative pointer interface given a wl_pointer object. See the
        /// wp_relative_pointer interface for more details.
        /// </summary>
        public NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1 GetRelativePointer(NWayland.Protocols.Wayland.WlPointer @pointer)
        {
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @pointer
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpRelativePointerManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerManagerV1.WlInterface);
            }

            public ZwpRelativePointerManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpRelativePointerManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpRelativePointerManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_relative_pointer_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpRelativePointerManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A wp_relative_pointer object is an extension to the wl_pointer interface
    /// used for emitting relative pointer events. It shares the same focus as
    /// wl_pointer objects of the same seat and will only emit events when it has
    /// focus.
    /// </summary>
    public sealed unsafe partial class ZwpRelativePointerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpRelativePointerV1()
        {
            WlInterface.Init("zwp_relative_pointer_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("relative_motion", "uuffff", new WlInterface*[] { null, null, null, null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnRelativeMotion(NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1 eventSender, uint @utimeHi, uint @utimeLo, int @dx, int @dy, int @dxUnaccel, int @dyUnaccel);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnRelativeMotion(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].Int32, arguments[3].Int32, arguments[4].Int32, arguments[5].Int32);
        }

        class ProxyFactory : IBindFactory<ZwpRelativePointerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.RelativePointerUnstableV1.ZwpRelativePointerV1.WlInterface);
            }

            public ZwpRelativePointerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpRelativePointerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpRelativePointerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_relative_pointer_v1";
        public const int InterfaceVersion = 1;

        public ZwpRelativePointerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}