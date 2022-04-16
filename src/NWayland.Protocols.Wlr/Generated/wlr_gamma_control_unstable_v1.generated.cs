using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrGammaControlUnstableV1
{
    /// <summary>
    /// This interface is a manager that allows creating per-output gamma
    /// controls.
    /// </summary>
    public sealed unsafe partial class ZwlrGammaControlManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrGammaControlManagerV1()
        {
            WlInterface.Init("zwlr_gamma_control_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("get_gamma_control", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlManagerV1.WlInterface);
        }

        /// <summary>
        /// Create a gamma control that can be used to adjust gamma tables for the
        /// provided output.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1 GetGammaControl(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @output
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<ZwlrGammaControlManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlManagerV1.WlInterface);
            }

            public ZwlrGammaControlManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrGammaControlManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrGammaControlManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_gamma_control_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwlrGammaControlManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface allows a client to adjust gamma tables for a particular
    /// output.
    /// 
    /// The client will receive the gamma size, and will then be able to set gamma
    /// tables. At any time the compositor can send a failed event indicating that
    /// this object is no longer valid.
    /// 
    /// There can only be at most one gamma control object per output, which
    /// has exclusive access to this particular output. When the gamma control
    /// object is destroyed, the gamma table is restored to its original value.
    /// </summary>
    public sealed unsafe partial class ZwlrGammaControlV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrGammaControlV1()
        {
            WlInterface.Init("zwlr_gamma_control_v1", 1, new WlMessage[] {
                WlMessage.Create("set_gamma", "h", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("gamma_size", "u", new WlInterface*[] { null }),
                WlMessage.Create("failed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1.WlInterface);
        }

        /// <summary>
        /// Set the gamma table. The file descriptor can be memory-mapped to provide
        /// the raw gamma table, which contains successive gamma ramps for the red,
        /// green and blue channels. Each gamma ramp is an array of 16-byte unsigned
        /// integers which has the same length as the gamma size.
        /// 
        /// The file descriptor data must have the same length as three times the
        /// gamma size.
        /// </summary>
        public void SetGamma(int @fd)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @fd
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
            void OnGammaSize(NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1 eventSender, uint @size);
            void OnFailed(NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGammaSize(this, arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnFailed(this);
        }

        public enum ErrorEnum
        {
            /// <summary>invalid gamma tables</summary>
            InvalidGamma = 1
        }

        class ProxyFactory : IBindFactory<ZwlrGammaControlV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrGammaControlUnstableV1.ZwlrGammaControlV1.WlInterface);
            }

            public ZwlrGammaControlV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrGammaControlV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrGammaControlV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_gamma_control_v1";
        public const int InterfaceVersion = 1;

        public ZwlrGammaControlV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}