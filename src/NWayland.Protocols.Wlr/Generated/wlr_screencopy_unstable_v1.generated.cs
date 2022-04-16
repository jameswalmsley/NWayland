using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrScreencopyUnstableV1
{
    /// <summary>
    /// This object is a manager which offers requests to start capturing from a
    /// source.
    /// </summary>
    public sealed unsafe partial class ZwlrScreencopyManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrScreencopyManagerV1()
        {
            WlInterface.Init("zwlr_screencopy_manager_v1", 2, new WlMessage[] {
                WlMessage.Create("capture_output", "nio", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("capture_output_region", "nioiiii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface), null, null, null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyManagerV1.WlInterface);
        }

        /// <summary>
        /// Capture the next frame of an entire output.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 CaptureOutput(int @overlayCursor, NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @overlayCursor,
                @output
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1(__ret, Version, Display);
        }

        /// <summary>
        /// Capture the next frame of an output's region.
        /// 
        /// The region is given in output logical coordinates, see
        /// xdg_output.logical_size. The region will be clipped to the output's
        /// extents.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 CaptureOutputRegion(int @overlayCursor, NWayland.Protocols.Wayland.WlOutput @output, int @x, int @y, int @width, int @height)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @overlayCursor,
                @output,
                @x,
                @y,
                @width,
                @height
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
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

        class ProxyFactory : IBindFactory<ZwlrScreencopyManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyManagerV1.WlInterface);
            }

            public ZwlrScreencopyManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrScreencopyManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrScreencopyManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_screencopy_manager_v1";
        public const int InterfaceVersion = 2;

        public ZwlrScreencopyManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object represents a single frame.
    /// 
    /// When created, a "buffer" event will be sent. The client will then be able
    /// to send a "copy" request. If the capture is successful, the compositor
    /// will send a "flags" followed by a "ready" event.
    /// 
    /// If the capture failed, the "failed" event is sent. This can happen anytime
    /// before the "ready" event.
    /// 
    /// Once either a "ready" or a "failed" event is received, the client should
    /// destroy the frame.
    /// </summary>
    public sealed unsafe partial class ZwlrScreencopyFrameV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrScreencopyFrameV1()
        {
            WlInterface.Init("zwlr_screencopy_frame_v1", 2, new WlMessage[] {
                WlMessage.Create("copy", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("copy_with_damage", "2o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("buffer", "uuuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("flags", "u", new WlInterface*[] { null }),
                WlMessage.Create("ready", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("failed", "", new WlInterface*[] { }),
                WlMessage.Create("damage", "2uuuu", new WlInterface*[] { null, null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface);
        }

        /// <summary>
        /// Copy the frame to the supplied buffer. The buffer must have a the
        /// correct size, see zwlr_screencopy_frame_v1.buffer. The buffer needs to
        /// have a supported format.
        /// 
        /// If the frame is successfully copied, a "flags" and a "ready" events are
        /// sent. Otherwise, a "failed" event is sent.
        /// </summary>
        public void Copy(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Same as copy, except it waits until there is damage to copy.
        /// </summary>
        public void CopyWithDamage(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            if (Version < 2)
                throw new System.InvalidOperationException("Request copy_with_damage is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnBuffer(NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 eventSender, uint @format, uint @width, uint @height, uint @stride);
            void OnFlags(NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 eventSender, FlagsEnum @flags);
            void OnReady(NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 eventSender, uint @tvSecHi, uint @tvSecLo, uint @tvNsec);
            void OnFailed(NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 eventSender);
            void OnDamage(NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1 eventSender, uint @x, uint @y, uint @width, uint @height);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnBuffer(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32);
            if (opcode == 1)
                Events?.OnFlags(this, (FlagsEnum)arguments[0].UInt32);
            if (opcode == 2)
                Events?.OnReady(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
            if (opcode == 3)
                Events?.OnFailed(this);
            if (opcode == 4)
                Events?.OnDamage(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32);
        }

        public enum ErrorEnum
        {
            /// <summary>the object has already been used to copy a wl_buffer</summary>
            AlreadyUsed = 0,
            /// <summary>buffer attributes are invalid</summary>
            InvalidBuffer = 1
        }

        [System.Flags]
        public enum FlagsEnum
        {
            /// <summary>contents are y-inverted</summary>
            YInvert = 1
        }

        class ProxyFactory : IBindFactory<ZwlrScreencopyFrameV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrScreencopyUnstableV1.ZwlrScreencopyFrameV1.WlInterface);
            }

            public ZwlrScreencopyFrameV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrScreencopyFrameV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrScreencopyFrameV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_screencopy_frame_v1";
        public const int InterfaceVersion = 2;

        public ZwlrScreencopyFrameV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}