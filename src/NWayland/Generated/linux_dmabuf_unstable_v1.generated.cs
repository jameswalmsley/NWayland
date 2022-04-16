using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.LinuxDmabufUnstableV1
{
    /// <summary>
    /// Following the interfaces from:
    /// https://www.khronos.org/registry/egl/extensions/EXT/EGL_EXT_image_dma_buf_import.txt
    /// https://www.khronos.org/registry/EGL/extensions/EXT/EGL_EXT_image_dma_buf_import_modifiers.txt
    /// and the Linux DRM sub-system's AddFb2 ioctl.
    /// 
    /// This interface offers ways to create generic dmabuf-based
    /// wl_buffers. Immediately after a client binds to this interface,
    /// the set of supported formats and format modifiers is sent with
    /// 'format' and 'modifier' events.
    /// 
    /// The following are required from clients:
    /// 
    /// - Clients must ensure that either all data in the dma-buf is
    /// coherent for all subsequent read access or that coherency is
    /// correctly handled by the underlying kernel-side dma-buf
    /// implementation.
    /// 
    /// - Don't make any more attachments after sending the buffer to the
    /// compositor. Making more attachments later increases the risk of
    /// the compositor not being able to use (re-import) an existing
    /// dmabuf-based wl_buffer.
    /// 
    /// The underlying graphics stack must ensure the following:
    /// 
    /// - The dmabuf file descriptors relayed to the server will stay valid
    /// for the whole lifetime of the wl_buffer. This means the server may
    /// at any time use those fds to import the dmabuf into any kernel
    /// sub-system that might accept it.
    /// 
    /// To create a wl_buffer from one or more dmabufs, a client creates a
    /// zwp_linux_dmabuf_params_v1 object with a zwp_linux_dmabuf_v1.create_params
    /// request. All planes required by the intended format are added with
    /// the 'add' request. Finally, a 'create' or 'create_immed' request is
    /// issued, which has the following outcome depending on the import success.
    /// 
    /// The 'create' request,
    /// - on success, triggers a 'created' event which provides the final
    /// wl_buffer to the client.
    /// - on failure, triggers a 'failed' event to convey that the server
    /// cannot use the dmabufs received from the client.
    /// 
    /// For the 'create_immed' request,
    /// - on success, the server immediately imports the added dmabufs to
    /// create a wl_buffer. No event is sent from the server in this case.
    /// - on failure, the server can choose to either:
    /// - terminate the client by raising a fatal error.
    /// - mark the wl_buffer as failed, and send a 'failed' event to the
    /// client. If the client uses a failed wl_buffer as an argument to any
    /// request, the behaviour is compositor implementation-defined.
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
    public sealed unsafe partial class ZwpLinuxDmabufV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpLinuxDmabufV1()
        {
            WlInterface.Init("zwp_linux_dmabuf_v1", 3, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("create_params", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("format", "u", new WlInterface*[] { null }),
                WlMessage.Create("modifier", "3uuu", new WlInterface*[] { null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxDmabufV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This temporary object is used to collect multiple dmabuf handles into
        /// a single batch to create a wl_buffer. It can only be used once and
        /// should be destroyed after a 'created' or 'failed' event has been
        /// received.
        /// </summary>
        public NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1 CreateParams()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnFormat(NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxDmabufV1 eventSender, uint @format);
            void OnModifier(NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxDmabufV1 eventSender, uint @format, uint @modifierHi, uint @modifierLo);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnFormat(this, arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnModifier(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
        }

        class ProxyFactory : IBindFactory<ZwpLinuxDmabufV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxDmabufV1.WlInterface);
            }

            public ZwpLinuxDmabufV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpLinuxDmabufV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpLinuxDmabufV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_linux_dmabuf_v1";
        public const int InterfaceVersion = 3;

        public ZwpLinuxDmabufV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This temporary object is a collection of dmabufs and other
    /// parameters that together form a single logical buffer. The temporary
    /// object may eventually create one wl_buffer unless cancelled by
    /// destroying it before requesting 'create'.
    /// 
    /// Single-planar formats only require one dmabuf, however
    /// multi-planar formats may require more than one dmabuf. For all
    /// formats, an 'add' request must be called once per plane (even if the
    /// underlying dmabuf fd is identical).
    /// 
    /// You must use consecutive plane indices ('plane_idx' argument for 'add')
    /// from zero to the number of planes used by the drm_fourcc format code.
    /// All planes required by the format must be given exactly once, but can
    /// be given in any order. Each plane index can be set only once.
    /// </summary>
    public sealed unsafe partial class ZwpLinuxBufferParamsV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpLinuxBufferParamsV1()
        {
            WlInterface.Init("zwp_linux_buffer_params_v1", 3, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("add", "huuuuu", new WlInterface*[] { null, null, null, null, null, null }),
                WlMessage.Create("create", "iiuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("create_immed", "2niiuu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface), null, null, null, null })
            }, new WlMessage[] {
                WlMessage.Create("created", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("failed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This request adds one dmabuf to the set in this
        /// zwp_linux_buffer_params_v1.
        /// 
        /// The 64-bit unsigned value combined from modifier_hi and modifier_lo
        /// is the dmabuf layout modifier. DRM AddFB2 ioctl calls this the
        /// fb modifier, which is defined in drm_mode.h of Linux UAPI.
        /// This is an opaque token. Drivers use this token to express tiling,
        /// compression, etc. driver-specific modifications to the base format
        /// defined by the DRM fourcc code.
        /// 
        /// Warning: It should be an error if the format/modifier pair was not
        /// advertised with the modifier event. This is not enforced yet because
        /// some implementations always accept DRM_FORMAT_MOD_INVALID. Also
        /// version 2 of this protocol does not have the modifier event.
        /// 
        /// This request raises the PLANE_IDX error if plane_idx is too large.
        /// The error PLANE_SET is raised if attempting to set a plane that
        /// was already set.
        /// </summary>
        public void Add(int @fd, uint @planeIdx, uint @offset, uint @stride, uint @modifierHi, uint @modifierLo)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @fd,
                @planeIdx,
                @offset,
                @stride,
                @modifierHi,
                @modifierLo
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This asks for creation of a wl_buffer from the added dmabuf
        /// buffers. The wl_buffer is not created immediately but returned via
        /// the 'created' event if the dmabuf sharing succeeds. The sharing
        /// may fail at runtime for reasons a client cannot predict, in
        /// which case the 'failed' event is triggered.
        /// 
        /// The 'format' argument is a DRM_FORMAT code, as defined by the
        /// libdrm's drm_fourcc.h. The Linux kernel's DRM sub-system is the
        /// authoritative source on how the format codes should work.
        /// 
        /// The 'flags' is a bitfield of the flags defined in enum "flags".
        /// 'y_invert' means the that the image needs to be y-flipped.
        /// 
        /// Flag 'interlaced' means that the frame in the buffer is not
        /// progressive as usual, but interlaced. An interlaced buffer as
        /// supported here must always contain both top and bottom fields.
        /// The top field always begins on the first pixel row. The temporal
        /// ordering between the two fields is top field first, unless
        /// 'bottom_first' is specified. It is undefined whether 'bottom_first'
        /// is ignored if 'interlaced' is not set.
        /// 
        /// This protocol does not convey any information about field rate,
        /// duration, or timing, other than the relative ordering between the
        /// two fields in one buffer. A compositor may have to estimate the
        /// intended field rate from the incoming buffer rate. It is undefined
        /// whether the time of receiving wl_surface.commit with a new buffer
        /// attached, applying the wl_surface state, wl_surface.frame callback
        /// trigger, presentation, or any other point in the compositor cycle
        /// is used to measure the frame or field times. There is no support
        /// for detecting missed or late frames/fields/buffers either, and
        /// there is no support whatsoever for cooperating with interlaced
        /// compositor output.
        /// 
        /// The composited image quality resulting from the use of interlaced
        /// buffers is explicitly undefined. A compositor may use elaborate
        /// hardware features or software to deinterlace and create progressive
        /// output frames from a sequence of interlaced input buffers, or it
        /// may produce substandard image quality. However, compositors that
        /// cannot guarantee reasonable image quality in all cases are recommended
        /// to just reject all interlaced buffers.
        /// 
        /// Any argument errors, including non-positive width or height,
        /// mismatch between the number of planes and the format, bad
        /// format, bad offset or stride, may be indicated by fatal protocol
        /// errors: INCOMPLETE, INVALID_FORMAT, INVALID_DIMENSIONS,
        /// OUT_OF_BOUNDS.
        /// 
        /// Dmabuf import errors in the server that are not obvious client
        /// bugs are returned via the 'failed' event as non-fatal. This
        /// allows attempting dmabuf sharing and falling back in the client
        /// if it fails.
        /// 
        /// This request can be sent only once in the object's lifetime, after
        /// which the only legal request is destroy. This object should be
        /// destroyed after issuing a 'create' request. Attempting to use this
        /// object after issuing 'create' raises ALREADY_USED protocol error.
        /// 
        /// It is not mandatory to issue 'create'. If a client wants to
        /// cancel the buffer creation, it can just destroy this object.
        /// </summary>
        public void Create(int @width, int @height, uint @format, uint @flags)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height,
                @format,
                @flags
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// This asks for immediate creation of a wl_buffer by importing the
        /// added dmabufs.
        /// 
        /// In case of import success, no event is sent from the server, and the
        /// wl_buffer is ready to be used by the client.
        /// 
        /// Upon import failure, either of the following may happen, as seen fit
        /// by the implementation:
        /// - the client is terminated with one of the following fatal protocol
        /// errors:
        /// - INCOMPLETE, INVALID_FORMAT, INVALID_DIMENSIONS, OUT_OF_BOUNDS,
        /// in case of argument errors such as mismatch between the number
        /// of planes and the format, bad format, non-positive width or
        /// height, or bad offset or stride.
        /// - INVALID_WL_BUFFER, in case the cause for failure is unknown or
        /// plaform specific.
        /// - the server creates an invalid wl_buffer, marks it as failed and
        /// sends a 'failed' event to the client. The result of using this
        /// invalid wl_buffer as an argument in any request by the client is
        /// defined by the compositor implementation.
        /// 
        /// This takes the same arguments as a 'create' request, and obeys the
        /// same restrictions.
        /// </summary>
        public NWayland.Protocols.Wayland.WlBuffer CreateImmed(int @width, int @height, uint @format, uint @flags)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request create_immed is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @width,
                @height,
                @format,
                @flags
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 3, __args, ref NWayland.Protocols.Wayland.WlBuffer.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlBuffer(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnCreated(NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1 eventSender, WlBuffer @buffer);
            void OnFailed(NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnCreated(this, new WlBuffer(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnFailed(this);
        }

        public enum ErrorEnum
        {
            /// <summary>the dmabuf_batch object has already been used to create a wl_buffer</summary>
            AlreadyUsed = 0,
            /// <summary>plane index out of bounds</summary>
            PlaneIdx = 1,
            /// <summary>the plane index was already set</summary>
            PlaneSet = 2,
            /// <summary>missing or too many planes to create a buffer</summary>
            Incomplete = 3,
            /// <summary>format not supported</summary>
            InvalidFormat = 4,
            /// <summary>invalid width or height</summary>
            InvalidDimensions = 5,
            /// <summary>offset + stride * height goes out of dmabuf bounds</summary>
            OutOfBounds = 6,
            /// <summary>invalid wl_buffer resulted from importing dmabufs via                the create_immed request on given buffer_params</summary>
            InvalidWlBuffer = 7
        }

        public enum FlagsEnum
        {
            /// <summary>contents are y-inverted</summary>
            YInvert = 1,
            /// <summary>content is interlaced</summary>
            Interlaced = 2,
            /// <summary>bottom field first</summary>
            BottomFirst = 4
        }

        class ProxyFactory : IBindFactory<ZwpLinuxBufferParamsV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.LinuxDmabufUnstableV1.ZwpLinuxBufferParamsV1.WlInterface);
            }

            public ZwpLinuxBufferParamsV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpLinuxBufferParamsV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpLinuxBufferParamsV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_linux_buffer_params_v1";
        public const int InterfaceVersion = 3;

        public ZwpLinuxBufferParamsV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}