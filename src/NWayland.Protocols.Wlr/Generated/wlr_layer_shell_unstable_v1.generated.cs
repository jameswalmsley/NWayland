using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrLayerShellUnstableV1
{
    /// <summary>
    /// Clients can use this interface to assign the surface_layer role to
    /// wl_surfaces. Such surfaces are assigned to a "layer" of the output and
    /// rendered with a defined z-depth respective to each other. They may also be
    /// anchored to the edges and corners of a screen and specify input handling
    /// semantics. This interface should be suitable for the implementation of
    /// many desktop shell components, and a broad number of other applications
    /// that interact with the desktop.
    /// </summary>
    public sealed unsafe partial class ZwlrLayerShellV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrLayerShellV1()
        {
            WlInterface.Init("zwlr_layer_shell_v1", 2, new WlMessage[] {
                WlMessage.Create("get_layer_surface", "no?ous", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface), null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerShellV1.WlInterface);
        }

        /// <summary>
        /// Create a layer surface for an existing surface. This assigns the role of
        /// layer_surface, or raises a protocol error if another role is already
        /// assigned.
        /// 
        /// Creating a layer surface from a wl_surface which has a buffer attached
        /// or committed is a client error, and any attempts by a client to attach
        /// or manipulate a buffer prior to the first layer_surface.configure call
        /// must also be treated as errors.
        /// 
        /// You may pass NULL for output to allow the compositor to decide which
        /// output to use. Generally this will be the one that the user most
        /// recently interacted with.
        /// 
        /// Clients can specify a namespace that defines the purpose of the layer
        /// surface.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1 GetLayerSurface(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlOutput @output, LayerEnum @layer, System.String @namespace)
        {
            if (@namespace == null)
                throw new System.ArgumentNullException("namespace");
            if (@output == null)
                throw new System.ArgumentNullException("output");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            using var __marshalled__namespace = new NWayland.Interop.NWaylandMarshalledString(@namespace);
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface,
                @output,
                (uint)@layer,
                __marshalled__namespace
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary>wl_surface has another role</summary>
            Role = 0,
            /// <summary>layer value is invalid</summary>
            InvalidLayer = 1,
            /// <summary>wl_surface has a buffer attached or committed</summary>
            AlreadyConstructed = 2
        }

        /// <summary>
        /// These values indicate which layers a surface can be rendered in. They
        /// are ordered by z depth, bottom-most first. Traditional shell surfaces
        /// will typically be rendered between the bottom and top layers.
        /// Fullscreen shell surfaces are typically rendered at the top layer.
        /// Multiple surfaces can share a single layer, and ordering within a
        /// single layer is undefined.
        /// </summary>
        public enum LayerEnum
        {
            Background = 0,
            Bottom = 1,
            Top = 2,
            Overlay = 3
        }

        class ProxyFactory : IBindFactory<ZwlrLayerShellV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerShellV1.WlInterface);
            }

            public ZwlrLayerShellV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrLayerShellV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrLayerShellV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_layer_shell_v1";
        public const int InterfaceVersion = 2;

        public ZwlrLayerShellV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An interface that may be implemented by a wl_surface, for surfaces that
    /// are designed to be rendered as a layer of a stacked desktop-like
    /// environment.
    /// 
    /// Layer surface state (layer, size, anchor, exclusive zone,
    /// margin, interactivity) is double-buffered, and will be applied at the
    /// time wl_surface.commit of the corresponding wl_surface is called.
    /// </summary>
    public sealed unsafe partial class ZwlrLayerSurfaceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrLayerSurfaceV1()
        {
            WlInterface.Init("zwlr_layer_surface_v1", 2, new WlMessage[] {
                WlMessage.Create("set_size", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("set_anchor", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_exclusive_zone", "i", new WlInterface*[] { null }),
                WlMessage.Create("set_margin", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("set_keyboard_interactivity", "u", new WlInterface*[] { null }),
                WlMessage.Create("get_popup", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShell.XdgPopup.WlInterface) }),
                WlMessage.Create("ack_configure", "u", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_layer", "2u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("configure", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("closed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1.WlInterface);
        }

        /// <summary>
        /// Sets the size of the surface in surface-local coordinates. The
        /// compositor will display the surface centered with respect to its
        /// anchors.
        /// 
        /// If you pass 0 for either value, the compositor will assign it and
        /// inform you of the assignment in the configure event. You must set your
        /// anchor to opposite edges in the dimensions you omit; not doing so is a
        /// protocol error. Both values are 0 by default.
        /// 
        /// Size is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetSize(uint @width, uint @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Requests that the compositor anchor the surface to the specified edges
        /// and corners. If two orthogonal edges are specified (e.g. 'top' and
        /// 'left'), then the anchor point will be the intersection of the edges
        /// (e.g. the top left corner of the output); otherwise the anchor point
        /// will be centered on that edge, or in the center if none is specified.
        /// 
        /// Anchor is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetAnchor(AnchorEnum @anchor)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@anchor
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Requests that the compositor avoids occluding an area with other
        /// surfaces. The compositor's use of this information is
        /// implementation-dependent - do not assume that this region will not
        /// actually be occluded.
        /// 
        /// A positive value is only meaningful if the surface is anchored to one
        /// edge or an edge and both perpendicular edges. If the surface is not
        /// anchored, anchored to only two perpendicular edges (a corner), anchored
        /// to only two parallel edges or anchored to all edges, a positive value
        /// will be treated the same as zero.
        /// 
        /// A positive zone is the distance from the edge in surface-local
        /// coordinates to consider exclusive.
        /// 
        /// Surfaces that do not wish to have an exclusive zone may instead specify
        /// how they should interact with surfaces that do. If set to zero, the
        /// surface indicates that it would like to be moved to avoid occluding
        /// surfaces with a positive exclusive zone. If set to -1, the surface
        /// indicates that it would not like to be moved to accommodate for other
        /// surfaces, and the compositor should extend it all the way to the edges
        /// it is anchored to.
        /// 
        /// For example, a panel might set its exclusive zone to 10, so that
        /// maximized shell surfaces are not shown on top of it. A notification
        /// might set its exclusive zone to 0, so that it is moved to avoid
        /// occluding the panel, but shell surfaces are shown underneath it. A
        /// wallpaper or lock screen might set their exclusive zone to -1, so that
        /// they stretch below or over the panel.
        /// 
        /// The default value is 0.
        /// 
        /// Exclusive zone is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetExclusiveZone(int @zone)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @zone
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Requests that the surface be placed some distance away from the anchor
        /// point on the output, in surface-local coordinates. Setting this value
        /// for edges you are not anchored to has no effect.
        /// 
        /// The exclusive zone includes the margin.
        /// 
        /// Margin is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetMargin(int @top, int @right, int @bottom, int @left)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @top,
                @right,
                @bottom,
                @left
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Set to 1 to request that the seat send keyboard events to this layer
        /// surface. For layers below the shell surface layer, the seat will use
        /// normal focus semantics. For layers above the shell surface layers, the
        /// seat will always give exclusive keyboard focus to the top-most layer
        /// which has keyboard interactivity set to true.
        /// 
        /// Layer surfaces receive pointer, touch, and tablet events normally. If
        /// you do not want to receive them, set the input region on your surface
        /// to an empty region.
        /// 
        /// Events is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetKeyboardInteractivity(uint @keyboardInteractivity)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @keyboardInteractivity
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// This assigns an xdg_popup's parent to this layer_surface.  This popup
        /// should have been created via xdg_surface::get_popup with the parent set
        /// to NULL, and this request must be invoked before committing the popup's
        /// initial state.
        /// 
        /// See the documentation of xdg_popup for more details about what an
        /// xdg_popup is and how it is used.
        /// </summary>
        public void GetPopup(NWayland.Protocols.XdgShell.XdgPopup @popup)
        {
            if (@popup == null)
                throw new System.ArgumentNullException("popup");
            WlArgument* __args = stackalloc WlArgument[] {
                @popup
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// When a configure event is received, if a client commits the
        /// surface in response to the configure event, then the client
        /// must make an ack_configure request sometime before the commit
        /// request, passing along the serial of the configure event.
        /// 
        /// If the client receives multiple configure events before it
        /// can respond to one, it only has to ack the last configure event.
        /// 
        /// A client is not required to commit immediately after sending
        /// an ack_configure request - it may even ack_configure several times
        /// before its next surface commit.
        /// 
        /// A client may send multiple ack_configure requests before committing, but
        /// only the last request sent before a commit indicates which configure
        /// event the client really is responding to.
        /// </summary>
        public void AckConfigure(uint @serial)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// Change the layer that the surface is rendered on.
        /// 
        /// Layer is double-buffered, see wl_surface.commit.
        /// </summary>
        public void SetLayer(NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerShellV1.LayerEnum @layer)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request set_layer is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@layer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public interface IEvents
        {
            void OnConfigure(NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1 eventSender, uint @serial, uint @width, uint @height);
            void OnClosed(NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfigure(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
            if (opcode == 1)
                Events?.OnClosed(this);
        }

        public enum ErrorEnum
        {
            /// <summary>provided surface state is invalid</summary>
            InvalidSurfaceState = 0,
            /// <summary>size is invalid</summary>
            InvalidSize = 1,
            /// <summary>anchor bitfield is invalid</summary>
            InvalidAnchor = 2
        }

        [System.Flags]
        public enum AnchorEnum
        {
            /// <summary>the top edge of the anchor rectangle</summary>
            Top = 1,
            /// <summary>the bottom edge of the anchor rectangle</summary>
            Bottom = 2,
            /// <summary>the left edge of the anchor rectangle</summary>
            Left = 4,
            /// <summary>the right edge of the anchor rectangle</summary>
            Right = 8
        }

        class ProxyFactory : IBindFactory<ZwlrLayerSurfaceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrLayerShellUnstableV1.ZwlrLayerSurfaceV1.WlInterface);
            }

            public ZwlrLayerSurfaceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrLayerSurfaceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrLayerSurfaceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_layer_surface_v1";
        public const int InterfaceVersion = 2;

        public ZwlrLayerSurfaceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}