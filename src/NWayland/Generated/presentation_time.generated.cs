using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.PresentationTime
{
    /// <summary>
    /// 
    /// When the final realized presentation time is available, e.g.
    /// after a framebuffer flip completes, the requested
    /// presentation_feedback.presented events are sent. The final
    /// presentation time can differ from the compositor's predicted
    /// display update time and the update's target time, especially
    /// when the compositor misses its target vertical blanking period.
    /// </summary>
    public sealed unsafe partial class WpPresentation : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WpPresentation()
        {
            WlInterface.Init("wp_presentation", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("feedback", "on", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("clock_id", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentation.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Request presentation feedback for the current content submission
        /// on the given surface. This creates a new presentation_feedback
        /// object, which will deliver the feedback information once. If
        /// multiple presentation_feedback objects are created for the same
        /// submission, they will all deliver the same information.
        /// 
        /// For details on what information is returned, see the
        /// presentation_feedback interface.
        /// </summary>
        public NWayland.Protocols.PresentationTime.WpPresentationFeedback Feedback(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PresentationTime.WpPresentationFeedback(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnClockId(NWayland.Protocols.PresentationTime.WpPresentation eventSender, uint @clkId);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnClockId(this, arguments[0].UInt32);
        }

        /// <summary>
        /// These fatal protocol errors may be emitted in response to
        /// illegal presentation requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>invalid value in tv_nsec</summary>
            InvalidTimestamp = 0,
            /// <summary>invalid flag</summary>
            InvalidFlag = 1
        }

        class ProxyFactory : IBindFactory<WpPresentation>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentation.WlInterface);
            }

            public WpPresentation Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WpPresentation(handle, version, display);
            }
        }

        public static IBindFactory<WpPresentation> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_presentation";
        public const int InterfaceVersion = 1;

        public WpPresentation(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A presentation_feedback object returns an indication that a
    /// wl_surface content update has become visible to the user.
    /// One object corresponds to one content update submission
    /// (wl_surface.commit). There are two possible outcomes: the
    /// content update is presented to the user, and a presentation
    /// timestamp delivered; or, the user did not see the content
    /// update because it was superseded or its surface destroyed,
    /// and the content update is discarded.
    /// 
    /// Once a presentation_feedback object has delivered a 'presented'
    /// or 'discarded' event it is automatically destroyed.
    /// </summary>
    public sealed unsafe partial class WpPresentationFeedback : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WpPresentationFeedback()
        {
            WlInterface.Init("wp_presentation_feedback", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("sync_output", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("presented", "uuuuuuu", new WlInterface*[] { null, null, null, null, null, null, null }),
                WlMessage.Create("discarded", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface);
        }

        public interface IEvents
        {
            void OnSyncOutput(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender, NWayland.Protocols.Wayland.WlOutput @output);
            void OnPresented(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender, uint @tvSecHi, uint @tvSecLo, uint @tvNsec, uint @refresh, uint @seqHi, uint @seqLo, uint @flags);
            void OnDiscarded(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSyncOutput(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnPresented(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32, arguments[5].UInt32, arguments[6].UInt32);
            if (opcode == 2)
                Events?.OnDiscarded(this);
        }

        [System.Flags]
        /// <summary>
        /// These flags provide information about how the presentation of
        /// the related content update was done. The intent is to help
        /// clients assess the reliability of the feedback and the visual
        /// quality with respect to possible tearing and timings. The
        /// flags are:
        /// 
        /// VSYNC:
        /// The presentation was synchronized to the "vertical retrace" by
        /// the display hardware such that tearing does not happen.
        /// Relying on user space scheduling is not acceptable for this
        /// flag. If presentation is done by a copy to the active
        /// frontbuffer, then it must guarantee that tearing cannot
        /// happen.
        /// 
        /// HW_CLOCK:
        /// The display hardware provided measurements that the hardware
        /// driver converted into a presentation timestamp. Sampling a
        /// clock in user space is not acceptable for this flag.
        /// 
        /// HW_COMPLETION:
        /// The display hardware signalled that it started using the new
        /// image content. The opposite of this is e.g. a timer being used
        /// to guess when the display hardware has switched to the new
        /// image content.
        /// 
        /// ZERO_COPY:
        /// The presentation of this update was done zero-copy. This means
        /// the buffer from the client was given to display hardware as
        /// is, without copying it. Compositing with OpenGL counts as
        /// copying, even if textured directly from the client buffer.
        /// Possible zero-copy cases include direct scanout of a
        /// fullscreen surface and a surface on a hardware overlay.
        /// </summary>
        public enum KindEnum
        {
            /// <summary>presentation was vsync'd</summary>
            Vsync = 0x1,
            /// <summary>hardware provided the presentation timestamp</summary>
            HwClock = 0x2,
            /// <summary>hardware signalled the start of the presentation</summary>
            HwCompletion = 0x4,
            /// <summary>presentation was done zero-copy</summary>
            ZeroCopy = 0x8
        }

        class ProxyFactory : IBindFactory<WpPresentationFeedback>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface);
            }

            public WpPresentationFeedback Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WpPresentationFeedback(handle, version, display);
            }
        }

        public static IBindFactory<WpPresentationFeedback> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_presentation_feedback";
        public const int InterfaceVersion = 1;

        public WpPresentationFeedback(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}