using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.WlEglstreamController
{
    public sealed unsafe partial class WlEglstreamController : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlEglstreamController()
        {
            WlInterface.Init("wl_eglstream_controller", 2, new WlMessage[] {
                WlMessage.Create("attach_eglstream_consumer", "1oo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_eglstream_consumer_attribs", "2ooa", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface), null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.WlEglstreamController.WlEglstreamController.WlInterface);
        }

        /// <summary>
        /// Creates the corresponding server side EGLStream from the given wl_buffer
        /// and attaches a consumer to it.
        /// </summary>
        public void AttachEglstreamConsumer(NWayland.Protocols.Wayland.WlSurface @wlSurface, NWayland.Protocols.Wayland.WlBuffer @wlResource)
        {
            if (@wlResource == null)
                throw new System.ArgumentNullException("wlResource");
            if (@wlSurface == null)
                throw new System.ArgumentNullException("wlSurface");
            if (Version < 1)
                throw new System.InvalidOperationException("Request attach_eglstream_consumer is only supported since version 1");
            WlArgument* __args = stackalloc WlArgument[] {
                @wlSurface,
                @wlResource
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Creates the corresponding server side EGLStream from the given wl_buffer
        /// and attaches a consumer to it using the given attributes.
        /// </summary>
        public void AttachEglstreamConsumerAttribs(NWayland.Protocols.Wayland.WlSurface @wlSurface, NWayland.Protocols.Wayland.WlBuffer @wlResource, ReadOnlySpan<byte> @attribs)
        {
            if (@wlResource == null)
                throw new System.ArgumentNullException("wlResource");
            if (@wlSurface == null)
                throw new System.ArgumentNullException("wlSurface");
            if (Version < 2)
                throw new System.InvalidOperationException("Request attach_eglstream_consumer_attribs is only supported since version 2");
            fixed (byte* __pointer__attribs = @attribs)
            {
                var __marshalled__attribs = NWayland.Interop.WlArray.FromPointer(__pointer__attribs, @attribs.Length);
                WlArgument* __args = stackalloc WlArgument[] {
                    @wlSurface,
                    @wlResource,
                    &__marshalled__attribs
                };
                LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
            }
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        /// <summary>
        /// - dont_care: Using this enum will tell the server to make its own
        /// decisions regarding present mode.
        /// 
        /// - fifo:      Tells the server to use a fifo present mode. The decision to
        /// use fifo synchronous is left up to the server.
        /// 
        /// - mailbox:   Tells the server to use a mailbox present mode.
        /// </summary>
        public enum PresentModeEnum
        {
            /// <summary>Let the Server decide present mode</summary>
            DontCare = 0,
            /// <summary>Use a fifo present mode</summary>
            Fifo = 1,
            /// <summary>Use a mailbox mode</summary>
            Mailbox = 2
        }

        /// <summary>
        /// - present_mode: Must be one of wl_eglstream_controller_present_mode. Tells the
        /// server the desired present mode that should be used.
        /// 
        /// - fifo_length:  Only valid when the present_mode attrib is provided and its
        /// value is specified as fifo. Tells the server the desired fifo
        /// length to be used when the desired present_mode is fifo.
        /// </summary>
        public enum AttribEnum
        {
            /// <summary>Tells the server the desired present mode</summary>
            PresentMode = 0,
            /// <summary>Tells the server the desired fifo length when the desired presenation_mode is fifo.</summary>
            FifoLength = 1
        }

        class ProxyFactory : IBindFactory<WlEglstreamController>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.WlEglstreamController.WlEglstreamController.WlInterface);
            }

            public WlEglstreamController Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlEglstreamController(handle, version, display);
            }
        }

        public static IBindFactory<WlEglstreamController> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_eglstream_controller";
        public const int InterfaceVersion = 2;

        public WlEglstreamController(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}