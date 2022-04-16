using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1
{
    /// <summary>
    /// This object is a manager with which to start capturing from sources.
    /// </summary>
    public sealed unsafe partial class ZwlrExportDmabufManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrExportDmabufManagerV1()
        {
            WlInterface.Init("zwlr_export_dmabuf_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("capture_output", "nio", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufManagerV1.WlInterface);
        }

        /// <summary>
        /// Capture the next frame of a an entire output.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1 CaptureOutput(int @overlayCursor, NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @overlayCursor,
                @output
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<ZwlrExportDmabufManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufManagerV1.WlInterface);
            }

            public ZwlrExportDmabufManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrExportDmabufManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrExportDmabufManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_export_dmabuf_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwlrExportDmabufManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object represents a single DMA-BUF frame.
    /// 
    /// If the capture is successful, the compositor will first send a "frame"
    /// event, followed by one or several "object". When the frame is available
    /// for readout, the "ready" event is sent.
    /// 
    /// If the capture failed, the "cancel" event is sent. This can happen anytime
    /// before the "ready" event.
    /// 
    /// Once either a "ready" or a "cancel" event is received, the client should
    /// destroy the frame. Once an "object" event is received, the client is
    /// responsible for closing the associated file descriptor.
    /// 
    /// All frames are read-only and may not be written into or altered.
    /// </summary>
    public sealed unsafe partial class ZwlrExportDmabufFrameV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrExportDmabufFrameV1()
        {
            WlInterface.Init("zwlr_export_dmabuf_frame_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("frame", "uuuuuuuuuu", new WlInterface*[] { null, null, null, null, null, null, null, null, null, null }),
                WlMessage.Create("object", "uhuuuu", new WlInterface*[] { null, null, null, null, null, null }),
                WlMessage.Create("ready", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("cancel", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnFrame(NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1 eventSender, uint @width, uint @height, uint @offsetX, uint @offsetY, uint @bufferFlags, FlagsEnum @flags, uint @format, uint @modHigh, uint @modLow, uint @numObjects);
            void OnObject(NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1 eventSender, uint @index, int @fd, uint @size, uint @offset, uint @stride, uint @planeIndex);
            void OnReady(NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1 eventSender, uint @tvSecHi, uint @tvSecLo, uint @tvNsec);
            void OnCancel(NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1 eventSender, CancelReasonEnum @reason);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnFrame(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32, (FlagsEnum)arguments[5].UInt32, arguments[6].UInt32, arguments[7].UInt32, arguments[8].UInt32, arguments[9].UInt32);
            if (opcode == 1)
                Events?.OnObject(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32, arguments[5].UInt32);
            if (opcode == 2)
                Events?.OnReady(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
            if (opcode == 3)
                Events?.OnCancel(this, (CancelReasonEnum)arguments[0].UInt32);
        }

        /// <summary>
        /// Special flags that should be respected by the client.
        /// </summary>
        public enum FlagsEnum
        {
            /// <summary>clients should copy frame before processing</summary>
            Transient = 0x1
        }

        /// <summary>
        /// Indicates reason for cancelling the frame.
        /// </summary>
        public enum CancelReasonEnum
        {
            /// <summary>temporary error, source will produce more frames</summary>
            Temporary = 0,
            /// <summary>fatal error, source will not produce frames</summary>
            Permanent = 1,
            /// <summary>temporary error, source will produce more frames</summary>
            Resizing = 2
        }

        class ProxyFactory : IBindFactory<ZwlrExportDmabufFrameV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrExportDmabufUnstableV1.ZwlrExportDmabufFrameV1.WlInterface);
            }

            public ZwlrExportDmabufFrameV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrExportDmabufFrameV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrExportDmabufFrameV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_export_dmabuf_frame_v1";
        public const int InterfaceVersion = 1;

        public ZwlrExportDmabufFrameV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}