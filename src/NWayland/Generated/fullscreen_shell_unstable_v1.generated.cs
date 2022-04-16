using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.FullscreenShellUnstableV1
{
    /// <summary>
    /// Displays a single surface per output.
    /// 
    /// This interface provides a mechanism for a single client to display
    /// simple full-screen surfaces.  While there technically may be multiple
    /// clients bound to this interface, only one of those clients should be
    /// shown at a time.
    /// 
    /// To present a surface, the client uses either the present_surface or
    /// present_surface_for_mode requests.  Presenting a surface takes effect
    /// on the next wl_surface.commit.  See the individual requests for
    /// details about scaling and mode switches.
    /// 
    /// The client can have at most one surface per output at any time.
    /// Requesting a surface to be presented on an output that already has a
    /// surface replaces the previously presented surface.  Presenting a null
    /// surface removes its content and effectively disables the output.
    /// Exactly what happens when an output is "disabled" is
    /// compositor-specific.  The same surface may be presented on multiple
    /// outputs simultaneously.
    /// 
    /// Once a surface is presented on an output, it stays on that output
    /// until either the client removes it or the compositor destroys the
    /// output.  This way, the client can update the output's contents by
    /// simply attaching a new buffer.
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
    public sealed unsafe partial class ZwpFullscreenShellV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpFullscreenShellV1()
        {
            WlInterface.Init("zwp_fullscreen_shell_v1", 1, new WlMessage[] {
                WlMessage.Create("release", "", new WlInterface*[] { }),
                WlMessage.Create("present_surface", "?ou?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("present_surface_for_mode", "ooin", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface), null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("capability", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Present a surface on the given output.
        /// 
        /// If the output is null, the compositor will present the surface on
        /// whatever display (or displays) it thinks best.  In particular, this
        /// may replace any or all surfaces currently presented so it should
        /// not be used in combination with placing surfaces on specific
        /// outputs.
        /// 
        /// The method parameter is a hint to the compositor for how the surface
        /// is to be presented.  In particular, it tells the compositor how to
        /// handle a size mismatch between the presented surface and the
        /// output.  The compositor is free to ignore this parameter.
        /// 
        /// The "zoom", "zoom_crop", and "stretch" methods imply a scaling
        /// operation on the surface.  This will override any kind of output
        /// scaling, so the buffer_scale property of the surface is effectively
        /// ignored.
        /// </summary>
        public void PresentSurface(NWayland.Protocols.Wayland.WlSurface @surface, uint @method, NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                @method,
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Presents a surface on the given output for a particular mode.
        /// 
        /// If the current size of the output differs from that of the surface,
        /// the compositor will attempt to change the size of the output to
        /// match the surface.  The result of the mode-switch operation will be
        /// returned via the provided wl_fullscreen_shell_mode_feedback object.
        /// 
        /// If the current output mode matches the one requested or if the
        /// compositor successfully switches the mode to match the surface,
        /// then the mode_successful event will be sent and the output will
        /// contain the contents of the given surface.  If the compositor
        /// cannot match the output size to the surface size, the mode_failed
        /// will be sent and the output will contain the contents of the
        /// previously presented surface (if any).  If another surface is
        /// presented on the given output before either of these has a chance
        /// to happen, the present_cancelled event will be sent.
        /// 
        /// Due to race conditions and other issues unknown to the client, no
        /// mode-switch operation is guaranteed to succeed.  However, if the
        /// mode is one advertised by wl_output.mode or if the compositor
        /// advertises the ARBITRARY_MODES capability, then the client should
        /// expect that the mode-switch operation will usually succeed.
        /// 
        /// If the size of the presented surface changes, the resulting output
        /// is undefined.  The compositor may attempt to change the output mode
        /// to compensate.  However, there is no guarantee that a suitable mode
        /// will be found and the client has no way to be notified of success
        /// or failure.
        /// 
        /// The framerate parameter specifies the desired framerate for the
        /// output in mHz.  The compositor is free to ignore this parameter.  A
        /// value of 0 indicates that the client has no preference.
        /// 
        /// If the value of wl_output.scale differs from wl_surface.buffer_scale,
        /// then the compositor may choose a mode that matches either the buffer
        /// size or the surface size.  In either case, the surface will fill the
        /// output.
        /// </summary>
        public NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1 PresentSurfaceForMode(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlOutput @output, int @framerate)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                @output,
                @framerate,
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnCapability(NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellV1 eventSender, uint @capability);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnCapability(this, arguments[0].UInt32);
        }

        /// <summary>
        /// Various capabilities that can be advertised by the compositor.  They
        /// are advertised one-at-a-time when the wl_fullscreen_shell interface is
        /// bound.  See the wl_fullscreen_shell.capability event for more details.
        /// 
        /// ARBITRARY_MODES:
        /// This is a hint to the client that indicates that the compositor is
        /// capable of setting practically any mode on its outputs.  If this
        /// capability is provided, wl_fullscreen_shell.present_surface_for_mode
        /// will almost never fail and clients should feel free to set whatever
        /// mode they like.  If the compositor does not advertise this, it may
        /// still support some modes that are not advertised through wl_global.mode
        /// but it is less likely.
        /// 
        /// CURSOR_PLANE:
        /// This is a hint to the client that indicates that the compositor can
        /// handle a cursor surface from the client without actually compositing.
        /// This may be because of a hardware cursor plane or some other mechanism.
        /// If the compositor does not advertise this capability then setting
        /// wl_pointer.cursor may degrade performance or be ignored entirely.  If
        /// CURSOR_PLANE is not advertised, it is recommended that the client draw
        /// its own cursor and set wl_pointer.cursor(NULL).
        /// </summary>
        public enum CapabilityEnum
        {
            /// <summary>compositor is capable of almost any output mode</summary>
            ArbitraryModes = 1,
            /// <summary>compositor has a separate cursor plane</summary>
            CursorPlane = 2
        }

        /// <summary>
        /// Hints to indicate to the compositor how to deal with a conflict
        /// between the dimensions of the surface and the dimensions of the
        /// output. The compositor is free to ignore this parameter.
        /// </summary>
        public enum PresentMethodEnum
        {
            /// <summary>no preference, apply default policy</summary>
            Default = 0,
            /// <summary>center the surface on the output</summary>
            Center = 1,
            /// <summary>scale the surface, preserving aspect ratio, to the largest size that will fit on the output</summary>
            Zoom = 2,
            /// <summary>scale the surface, preserving aspect ratio, to fully fill the output cropping if needed</summary>
            ZoomCrop = 3,
            /// <summary>scale the surface to the size of the output ignoring aspect ratio</summary>
            Stretch = 4
        }

        /// <summary>
        /// These errors can be emitted in response to wl_fullscreen_shell requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>present_method is not known</summary>
            InvalidMethod = 0
        }

        class ProxyFactory : IBindFactory<ZwpFullscreenShellV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellV1.WlInterface);
            }

            public ZwpFullscreenShellV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpFullscreenShellV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpFullscreenShellV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_fullscreen_shell_v1";
        public const int InterfaceVersion = 1;

        public ZwpFullscreenShellV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class ZwpFullscreenShellModeFeedbackV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpFullscreenShellModeFeedbackV1()
        {
            WlInterface.Init("zwp_fullscreen_shell_mode_feedback_v1", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("mode_successful", "", new WlInterface*[] { }),
                WlMessage.Create("mode_failed", "", new WlInterface*[] { }),
                WlMessage.Create("present_cancelled", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1.WlInterface);
        }

        public interface IEvents
        {
            void OnModeSuccessful(NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1 eventSender);
            void OnModeFailed(NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1 eventSender);
            void OnPresentCancelled(NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnModeSuccessful(this);
            if (opcode == 1)
                Events?.OnModeFailed(this);
            if (opcode == 2)
                Events?.OnPresentCancelled(this);
        }

        class ProxyFactory : IBindFactory<ZwpFullscreenShellModeFeedbackV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.FullscreenShellUnstableV1.ZwpFullscreenShellModeFeedbackV1.WlInterface);
            }

            public ZwpFullscreenShellModeFeedbackV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpFullscreenShellModeFeedbackV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpFullscreenShellModeFeedbackV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_fullscreen_shell_mode_feedback_v1";
        public const int InterfaceVersion = 1;

        public ZwpFullscreenShellModeFeedbackV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}