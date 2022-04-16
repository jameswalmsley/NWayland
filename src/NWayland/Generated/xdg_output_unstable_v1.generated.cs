using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XdgOutputUnstableV1
{
    /// <summary>
    /// A global factory interface for xdg_output objects.
    /// </summary>
    public sealed unsafe partial class ZxdgOutputManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgOutputManagerV1()
        {
            WlInterface.Init("zxdg_output_manager_v1", 3, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_xdg_output", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This creates a new xdg_output object for the given wl_output.
        /// </summary>
        public NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 GetXdgOutput(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @output
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgOutputManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputManagerV1.WlInterface);
            }

            public ZxdgOutputManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgOutputManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgOutputManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_output_manager_v1";
        public const int InterfaceVersion = 3;

        public ZxdgOutputManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An xdg_output describes part of the compositor geometry.
    /// 
    /// This typically corresponds to a monitor that displays part of the
    /// compositor space.
    /// 
    /// For objects version 3 onwards, after all xdg_output properties have been
    /// sent (when the object is created and when properties are updated), a
    /// wl_output.done event is sent. This allows changes to the output
    /// properties to be seen as atomic, even if they happen via multiple events.
    /// </summary>
    public sealed unsafe partial class ZxdgOutputV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgOutputV1()
        {
            WlInterface.Init("zxdg_output_v1", 3, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("logical_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("logical_size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("name", "2s", new WlInterface*[] { null }),
                WlMessage.Create("description", "2s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnLogicalPosition(NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 eventSender, int @x, int @y);
            void OnLogicalSize(NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 eventSender, int @width, int @height);
            void OnDone(NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 eventSender);
            void OnName(NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 eventSender, System.String @name);
            void OnDescription(NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1 eventSender, System.String @description);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnLogicalPosition(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 1)
                Events?.OnLogicalSize(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 2)
                Events?.OnDone(this);
            if (opcode == 3)
                Events?.OnName(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 4)
                Events?.OnDescription(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZxdgOutputV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgOutputUnstableV1.ZxdgOutputV1.WlInterface);
            }

            public ZxdgOutputV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgOutputV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgOutputV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_output_v1";
        public const int InterfaceVersion = 3;

        public ZxdgOutputV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}