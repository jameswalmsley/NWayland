using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XdgShellUnstableV6
{
    /// <summary>
    /// xdg_shell allows clients to turn a wl_surface into a "real window"
    /// which can be dragged, resized, stacked, and moved around by the
    /// user. Everything about this interface is suited towards traditional
    /// desktop environments.
    /// </summary>
    public sealed unsafe partial class ZxdgShellV6 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgShellV6()
        {
            WlInterface.Init("zxdg_shell_v6", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("create_positioner", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6.WlInterface) }),
                WlMessage.Create("get_xdg_surface", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("pong", "u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("ping", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgShellV6.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a positioner object. A positioner object is used to position
        /// surfaces relative to some parent surface. See the interface description
        /// and xdg_surface.get_popup for details.
        /// </summary>
        public NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6 CreatePositioner()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6(__ret, Version, Display);
        }

        /// <summary>
        /// This creates an xdg_surface for the given surface. While xdg_surface
        /// itself is not a role, the corresponding surface may only be assigned
        /// a role extending xdg_surface, such as xdg_toplevel or xdg_popup.
        /// 
        /// This creates an xdg_surface for the given surface. An xdg_surface is
        /// used as basis to define a role to a given surface, such as xdg_toplevel
        /// or xdg_popup. It also manages functionality shared between xdg_surface
        /// based surface roles.
        /// 
        /// See the documentation of xdg_surface for more details about what an
        /// xdg_surface is and how it is used.
        /// </summary>
        public NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6 GetXdgSurface(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6(__ret, Version, Display);
        }

        /// <summary>
        /// A client must respond to a ping event with a pong request or
        /// the client may be deemed unresponsive. See xdg_shell.ping.
        /// </summary>
        public void Pong(uint @serial)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public interface IEvents
        {
            void OnPing(NWayland.Protocols.XdgShellUnstableV6.ZxdgShellV6 eventSender, uint @serial);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnPing(this, arguments[0].UInt32);
        }

        public enum ErrorEnum
        {
            /// <summary>given wl_surface has another role</summary>
            Role = 0,
            /// <summary>xdg_shell was destroyed before children</summary>
            DefunctSurfaces = 1,
            /// <summary>the client tried to map or destroy a non-topmost popup</summary>
            NotTheTopmostPopup = 2,
            /// <summary>the client specified an invalid popup parent surface</summary>
            InvalidPopupParent = 3,
            /// <summary>the client provided an invalid surface state</summary>
            InvalidSurfaceState = 4,
            /// <summary>the client provided an invalid positioner</summary>
            InvalidPositioner = 5
        }

        class ProxyFactory : IBindFactory<ZxdgShellV6>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgShellV6.WlInterface);
            }

            public ZxdgShellV6 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgShellV6(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgShellV6> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_shell_v6";
        public const int InterfaceVersion = 1;

        public ZxdgShellV6(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The xdg_positioner provides a collection of rules for the placement of a
    /// child surface relative to a parent surface. Rules can be defined to ensure
    /// the child surface remains within the visible area's borders, and to
    /// specify how the child surface changes its position, such as sliding along
    /// an axis, or flipping around a rectangle. These positioner-created rules are
    /// constrained by the requirement that a child surface must intersect with or
    /// be at least partially adjacent to its parent surface.
    /// 
    /// See the various requests for details about possible rules.
    /// 
    /// At the time of the request, the compositor makes a copy of the rules
    /// specified by the xdg_positioner. Thus, after the request is complete the
    /// xdg_positioner object can be destroyed or reused; further changes to the
    /// object will have no effect on previous usages.
    /// 
    /// For an xdg_positioner object to be considered complete, it must have a
    /// non-zero size set by set_size, and a non-zero anchor rectangle set by
    /// set_anchor_rect. Passing an incomplete xdg_positioner object when
    /// positioning a surface raises an error.
    /// </summary>
    public sealed unsafe partial class ZxdgPositionerV6 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgPositionerV6()
        {
            WlInterface.Init("zxdg_positioner_v6", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("set_anchor_rect", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("set_anchor", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_gravity", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_constraint_adjustment", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_offset", "ii", new WlInterface*[] { null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the size of the surface that is to be positioned with the positioner
        /// object. The size is in surface-local coordinates and corresponds to the
        /// window geometry. See xdg_surface.set_window_geometry.
        /// 
        /// If a zero or negative size is set the invalid_input error is raised.
        /// </summary>
        public void SetSize(int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Specify the anchor rectangle within the parent surface that the child
        /// surface will be placed relative to. The rectangle is relative to the
        /// window geometry as defined by xdg_surface.set_window_geometry of the
        /// parent surface. The rectangle must be at least 1x1 large.
        /// 
        /// When the xdg_positioner object is used to position a child surface, the
        /// anchor rectangle may not extend outside the window geometry of the
        /// positioned child's parent surface.
        /// 
        /// If a zero or negative size is set the invalid_input error is raised.
        /// </summary>
        public void SetAnchorRect(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Defines a set of edges for the anchor rectangle. These are used to
        /// derive an anchor point that the child surface will be positioned
        /// relative to. If two orthogonal edges are specified (e.g. 'top' and
        /// 'left'), then the anchor point will be the intersection of the edges
        /// (e.g. the top left position of the rectangle); otherwise, the derived
        /// anchor point will be centered on the specified edge, or in the center of
        /// the anchor rectangle if no edge is specified.
        /// 
        /// If two parallel anchor edges are specified (e.g. 'left' and 'right'),
        /// the invalid_input error is raised.
        /// </summary>
        public void SetAnchor(AnchorEnum @anchor)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@anchor
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Defines in what direction a surface should be positioned, relative to
        /// the anchor point of the parent surface. If two orthogonal gravities are
        /// specified (e.g. 'bottom' and 'right'), then the child surface will be
        /// placed in the specified direction; otherwise, the child surface will be
        /// centered over the anchor point on any axis that had no gravity
        /// specified.
        /// 
        /// If two parallel gravities are specified (e.g. 'left' and 'right'), the
        /// invalid_input error is raised.
        /// </summary>
        public void SetGravity(GravityEnum @gravity)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@gravity
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Specify how the window should be positioned if the originally intended
        /// position caused the surface to be constrained, meaning at least
        /// partially outside positioning boundaries set by the compositor. The
        /// adjustment is set by constructing a bitmask describing the adjustment to
        /// be made when the surface is constrained on that axis.
        /// 
        /// If no bit for one axis is set, the compositor will assume that the child
        /// surface should not change its position on that axis when constrained.
        /// 
        /// If more than one bit for one axis is set, the order of how adjustments
        /// are applied is specified in the corresponding adjustment descriptions.
        /// 
        /// The default adjustment is none.
        /// </summary>
        public void SetConstraintAdjustment(uint @constraintAdjustment)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @constraintAdjustment
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Specify the surface position offset relative to the position of the
        /// anchor on the anchor rectangle and the anchor on the surface. For
        /// example if the anchor of the anchor rectangle is at (x, y), the surface
        /// has the gravity bottom|right, and the offset is (ox, oy), the calculated
        /// surface position will be (x + ox, y + oy). The offset position of the
        /// surface is the one used for constraint testing. See
        /// set_constraint_adjustment.
        /// 
        /// An example use case is placing a popup menu on top of a user interface
        /// element, while aligning the user interface element of the parent surface
        /// with some user interface element placed somewhere in the popup surface.
        /// </summary>
        public void SetOffset(int @x, int @y)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
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
            /// <summary>invalid input provided</summary>
            InvalidInput = 0
        }

        [System.Flags]
        public enum AnchorEnum
        {
            /// <summary>the center of the anchor rectangle</summary>
            None = 0,
            /// <summary>the top edge of the anchor rectangle</summary>
            Top = 1,
            /// <summary>the bottom edge of the anchor rectangle</summary>
            Bottom = 2,
            /// <summary>the left edge of the anchor rectangle</summary>
            Left = 4,
            /// <summary>the right edge of the anchor rectangle</summary>
            Right = 8
        }

        [System.Flags]
        public enum GravityEnum
        {
            /// <summary>center over the anchor edge</summary>
            None = 0,
            /// <summary>position above the anchor edge</summary>
            Top = 1,
            /// <summary>position below the anchor edge</summary>
            Bottom = 2,
            /// <summary>position to the left of the anchor edge</summary>
            Left = 4,
            /// <summary>position to the right of the anchor edge</summary>
            Right = 8
        }

        [System.Flags]
        /// <summary>
        /// The constraint adjustment value define ways the compositor will adjust
        /// the position of the surface, if the unadjusted position would result
        /// in the surface being partly constrained.
        /// 
        /// Whether a surface is considered 'constrained' is left to the compositor
        /// to determine. For example, the surface may be partly outside the
        /// compositor's defined 'work area', thus necessitating the child surface's
        /// position be adjusted until it is entirely inside the work area.
        /// 
        /// The adjustments can be combined, according to a defined precedence: 1)
        /// Flip, 2) Slide, 3) Resize.
        /// </summary>
        public enum ConstraintAdjustmentEnum
        {
            None = 0,
            SlideX = 1,
            SlideY = 2,
            FlipX = 4,
            FlipY = 8,
            ResizeX = 16,
            ResizeY = 32
        }

        class ProxyFactory : IBindFactory<ZxdgPositionerV6>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6.WlInterface);
            }

            public ZxdgPositionerV6 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgPositionerV6(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgPositionerV6> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_positioner_v6";
        public const int InterfaceVersion = 1;

        public ZxdgPositionerV6(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An interface that may be implemented by a wl_surface, for
    /// implementations that provide a desktop-style user interface.
    /// 
    /// It provides a base set of functionality required to construct user
    /// interface elements requiring management by the compositor, such as
    /// toplevel windows, menus, etc. The types of functionality are split into
    /// xdg_surface roles.
    /// 
    /// Creating an xdg_surface does not set the role for a wl_surface. In order
    /// to map an xdg_surface, the client must create a role-specific object
    /// using, e.g., get_toplevel, get_popup. The wl_surface for any given
    /// xdg_surface can have at most one role, and may not be assigned any role
    /// not based on xdg_surface.
    /// 
    /// A role must be assigned before any other requests are made to the
    /// xdg_surface object.
    /// 
    /// The client must call wl_surface.commit on the corresponding wl_surface
    /// for the xdg_surface state to take effect.
    /// 
    /// Creating an xdg_surface from a wl_surface which has a buffer attached or
    /// committed is a client error, and any attempts by a client to attach or
    /// manipulate a buffer prior to the first xdg_surface.configure call must
    /// also be treated as errors.
    /// 
    /// For a surface to be mapped by the compositor, the following conditions
    /// must be met: (1) the client has assigned a xdg_surface based role to the
    /// surface, (2) the client has set and committed the xdg_surface state and
    /// the role dependent state to the surface and (3) the client has committed a
    /// buffer to the surface.
    /// </summary>
    public sealed unsafe partial class ZxdgSurfaceV6 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgSurfaceV6()
        {
            WlInterface.Init("zxdg_surface_v6", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_toplevel", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6.WlInterface) }),
                WlMessage.Create("get_popup", "noo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6.WlInterface) }),
                WlMessage.Create("set_window_geometry", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("ack_configure", "u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("configure", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This creates an xdg_toplevel object for the given xdg_surface and gives
        /// the associated wl_surface the xdg_toplevel role.
        /// 
        /// See the documentation of xdg_toplevel for more details about what an
        /// xdg_toplevel is and how it is used.
        /// </summary>
        public NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6 GetToplevel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6(__ret, Version, Display);
        }

        /// <summary>
        /// This creates an xdg_popup object for the given xdg_surface and gives the
        /// associated wl_surface the xdg_popup role.
        /// 
        /// See the documentation of xdg_popup for more details about what an
        /// xdg_popup is and how it is used.
        /// </summary>
        public NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6 GetPopup(NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6 @parent, NWayland.Protocols.XdgShellUnstableV6.ZxdgPositionerV6 @positioner)
        {
            if (@positioner == null)
                throw new System.ArgumentNullException("positioner");
            if (@parent == null)
                throw new System.ArgumentNullException("parent");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @parent,
                @positioner
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6(__ret, Version, Display);
        }

        /// <summary>
        /// The window geometry of a surface is its "visible bounds" from the
        /// user's perspective. Client-side decorations often have invisible
        /// portions like drop-shadows which should be ignored for the
        /// purposes of aligning, placing and constraining windows.
        /// 
        /// The window geometry is double buffered, and will be applied at the
        /// time wl_surface.commit of the corresponding wl_surface is called.
        /// 
        /// Once the window geometry of the surface is set, it is not possible to
        /// unset it, and it will remain the same until set_window_geometry is
        /// called again, even if a new subsurface or buffer is attached.
        /// 
        /// If never set, the value is the full bounds of the surface,
        /// including any subsurfaces. This updates dynamically on every
        /// commit. This unset is meant for extremely simple clients.
        /// 
        /// The arguments are given in the surface-local coordinate space of
        /// the wl_surface associated with this xdg_surface.
        /// 
        /// The width and height must be greater than zero. Setting an invalid size
        /// will raise an error. When applied, the effective window geometry will be
        /// the set window geometry clamped to the bounding rectangle of the
        /// combined geometry of the surface of the xdg_surface and the associated
        /// subsurfaces.
        /// </summary>
        public void SetWindowGeometry(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// When a configure event is received, if a client commits the
        /// surface in response to the configure event, then the client
        /// must make an ack_configure request sometime before the commit
        /// request, passing along the serial of the configure event.
        /// 
        /// For instance, for toplevel surfaces the compositor might use this
        /// information to move a surface to the top left only when the client has
        /// drawn itself for the maximized or fullscreen state.
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
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        public interface IEvents
        {
            void OnConfigure(NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6 eventSender, uint @serial);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfigure(this, arguments[0].UInt32);
        }

        public enum ErrorEnum
        {
            NotConstructed = 1,
            AlreadyConstructed = 2,
            UnconfiguredBuffer = 3
        }

        class ProxyFactory : IBindFactory<ZxdgSurfaceV6>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgSurfaceV6.WlInterface);
            }

            public ZxdgSurfaceV6 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgSurfaceV6(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgSurfaceV6> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_surface_v6";
        public const int InterfaceVersion = 1;

        public ZxdgSurfaceV6(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface defines an xdg_surface role which allows a surface to,
    /// among other things, set window-like properties such as maximize,
    /// fullscreen, and minimize, set application-specific metadata like title and
    /// id, and well as trigger user interactive operations such as interactive
    /// resize and move.
    /// </summary>
    public sealed unsafe partial class ZxdgToplevelV6 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgToplevelV6()
        {
            WlInterface.Init("zxdg_toplevel_v6", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_parent", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6.WlInterface) }),
                WlMessage.Create("set_title", "s", new WlInterface*[] { null }),
                WlMessage.Create("set_app_id", "s", new WlInterface*[] { null }),
                WlMessage.Create("show_window_menu", "ouii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null, null, null }),
                WlMessage.Create("move", "ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null }),
                WlMessage.Create("resize", "ouu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null, null }),
                WlMessage.Create("set_max_size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("set_min_size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("set_maximized", "", new WlInterface*[] { }),
                WlMessage.Create("unset_maximized", "", new WlInterface*[] { }),
                WlMessage.Create("set_fullscreen", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("unset_fullscreen", "", new WlInterface*[] { }),
                WlMessage.Create("set_minimized", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("configure", "iia", new WlInterface*[] { null, null, null }),
                WlMessage.Create("close", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the "parent" of this surface. This window should be stacked
        /// above a parent. The parent surface must be mapped as long as this
        /// surface is mapped.
        /// 
        /// Parent windows should be set on dialogs, toolboxes, or other
        /// "auxiliary" surfaces, so that the parent is raised when the dialog
        /// is raised.
        /// </summary>
        public void SetParent(NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6 @parent)
        {
            if (@parent == null)
                throw new System.ArgumentNullException("parent");
            WlArgument* __args = stackalloc WlArgument[] {
                @parent
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Set a short title for the surface.
        /// 
        /// This string may be used to identify the surface in a task bar,
        /// window list, or other user interface elements provided by the
        /// compositor.
        /// 
        /// The string must be encoded in UTF-8.
        /// </summary>
        public void SetTitle(System.String @title)
        {
            if (@title == null)
                throw new System.ArgumentNullException("title");
            using var __marshalled__title = new NWayland.Interop.NWaylandMarshalledString(@title);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__title
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Set an application identifier for the surface.
        /// 
        /// The app ID identifies the general class of applications to which
        /// the surface belongs. The compositor can use this to group multiple
        /// surfaces together, or to determine how to launch a new application.
        /// 
        /// For D-Bus activatable applications, the app ID is used as the D-Bus
        /// service name.
        /// 
        /// The compositor shell will try to group application surfaces together
        /// by their app ID. As a best practice, it is suggested to select app
        /// ID's that match the basename of the application's .desktop file.
        /// For example, "org.freedesktop.FooViewer" where the .desktop file is
        /// "org.freedesktop.FooViewer.desktop".
        /// 
        /// See the desktop-entry specification [0] for more details on
        /// application identifiers and how they relate to well-known D-Bus
        /// names and .desktop files.
        /// 
        /// [0] http://standards.freedesktop.org/desktop-entry-spec/
        /// </summary>
        public void SetAppId(System.String @appId)
        {
            if (@appId == null)
                throw new System.ArgumentNullException("appId");
            using var __marshalled__appId = new NWayland.Interop.NWaylandMarshalledString(@appId);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__appId
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Clients implementing client-side decorations might want to show
        /// a context menu when right-clicking on the decorations, giving the
        /// user a menu that they can use to maximize or minimize the window.
        /// 
        /// This request asks the compositor to pop up such a window menu at
        /// the given position, relative to the local surface coordinates of
        /// the parent surface. There are no guarantees as to what menu items
        /// the window menu contains.
        /// 
        /// This request must be used in response to some sort of user action
        /// like a button press, key press, or touch down event.
        /// </summary>
        public void ShowWindowMenu(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial, int @x, int @y)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Start an interactive, user-driven move of the surface.
        /// 
        /// This request must be used in response to some sort of user action
        /// like a button press, key press, or touch down event. The passed
        /// serial is used to determine the type of interactive move (touch,
        /// pointer, etc).
        /// 
        /// The server may ignore move requests depending on the state of
        /// the surface (e.g. fullscreen or maximized), or if the passed serial
        /// is no longer valid.
        /// 
        /// If triggered, the surface will lose the focus of the device
        /// (wl_pointer, wl_touch, etc) used for the move. It is up to the
        /// compositor to visually indicate that the move is taking place, such as
        /// updating a pointer cursor, during the move. There is no guarantee
        /// that the device focus will return when the move is completed.
        /// </summary>
        public void Move(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Start a user-driven, interactive resize of the surface.
        /// 
        /// This request must be used in response to some sort of user action
        /// like a button press, key press, or touch down event. The passed
        /// serial is used to determine the type of interactive resize (touch,
        /// pointer, etc).
        /// 
        /// The server may ignore resize requests depending on the state of
        /// the surface (e.g. fullscreen or maximized).
        /// 
        /// If triggered, the client will receive configure events with the
        /// "resize" state enum value and the expected sizes. See the "resize"
        /// enum value for more details about what is required. The client
        /// must also acknowledge configure events using "ack_configure". After
        /// the resize is completed, the client will receive another "configure"
        /// event without the resize state.
        /// 
        /// If triggered, the surface also will lose the focus of the device
        /// (wl_pointer, wl_touch, etc) used for the resize. It is up to the
        /// compositor to visually indicate that the resize is taking place,
        /// such as updating a pointer cursor, during the resize. There is no
        /// guarantee that the device focus will return when the resize is
        /// completed.
        /// 
        /// The edges parameter specifies how the surface should be resized,
        /// and is one of the values of the resize_edge enum. The compositor
        /// may use this information to update the surface position for
        /// example when dragging the top left corner. The compositor may also
        /// use this information to adapt its behavior, e.g. choose an
        /// appropriate cursor image.
        /// </summary>
        public void Resize(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial, uint @edges)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial,
                @edges
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Set a maximum size for the window.
        /// 
        /// The client can specify a maximum size so that the compositor does
        /// not try to configure the window beyond this size.
        /// 
        /// The width and height arguments are in window geometry coordinates.
        /// See xdg_surface.set_window_geometry.
        /// 
        /// Values set in this way are double-buffered. They will get applied
        /// on the next commit.
        /// 
        /// The compositor can use this information to allow or disallow
        /// different states like maximize or fullscreen and draw accurate
        /// animations.
        /// 
        /// Similarly, a tiling window manager may use this information to
        /// place and resize client windows in a more effective way.
        /// 
        /// The client should not rely on the compositor to obey the maximum
        /// size. The compositor may decide to ignore the values set by the
        /// client and request a larger size.
        /// 
        /// If never set, or a value of zero in the request, means that the
        /// client has no expected maximum size in the given dimension.
        /// As a result, a client wishing to reset the maximum size
        /// to an unspecified state can use zero for width and height in the
        /// request.
        /// 
        /// Requesting a maximum size to be smaller than the minimum size of
        /// a surface is illegal and will result in a protocol error.
        /// 
        /// The width and height must be greater than or equal to zero. Using
        /// strictly negative values for width and height will result in a
        /// protocol error.
        /// </summary>
        public void SetMaxSize(int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// Set a minimum size for the window.
        /// 
        /// The client can specify a minimum size so that the compositor does
        /// not try to configure the window below this size.
        /// 
        /// The width and height arguments are in window geometry coordinates.
        /// See xdg_surface.set_window_geometry.
        /// 
        /// Values set in this way are double-buffered. They will get applied
        /// on the next commit.
        /// 
        /// The compositor can use this information to allow or disallow
        /// different states like maximize or fullscreen and draw accurate
        /// animations.
        /// 
        /// Similarly, a tiling window manager may use this information to
        /// place and resize client windows in a more effective way.
        /// 
        /// The client should not rely on the compositor to obey the minimum
        /// size. The compositor may decide to ignore the values set by the
        /// client and request a smaller size.
        /// 
        /// If never set, or a value of zero in the request, means that the
        /// client has no expected minimum size in the given dimension.
        /// As a result, a client wishing to reset the minimum size
        /// to an unspecified state can use zero for width and height in the
        /// request.
        /// 
        /// Requesting a minimum size to be larger than the maximum size of
        /// a surface is illegal and will result in a protocol error.
        /// 
        /// The width and height must be greater than or equal to zero. Using
        /// strictly negative values for width and height will result in a
        /// protocol error.
        /// </summary>
        public void SetMinSize(int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Maximize the surface.
        /// 
        /// After requesting that the surface should be maximized, the compositor
        /// will respond by emitting a configure event with the "maximized" state
        /// and the required window geometry. The client should then update its
        /// content, drawing it in a maximized state, i.e. without shadow or other
        /// decoration outside of the window geometry. The client must also
        /// acknowledge the configure when committing the new content (see
        /// ack_configure).
        /// 
        /// It is up to the compositor to decide how and where to maximize the
        /// surface, for example which output and what region of the screen should
        /// be used.
        /// 
        /// If the surface was already maximized, the compositor will still emit
        /// a configure event with the "maximized" state.
        /// </summary>
        public void SetMaximized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        /// <summary>
        /// Unmaximize the surface.
        /// 
        /// After requesting that the surface should be unmaximized, the compositor
        /// will respond by emitting a configure event without the "maximized"
        /// state. If available, the compositor will include the window geometry
        /// dimensions the window had prior to being maximized in the configure
        /// request. The client must then update its content, drawing it in a
        /// regular state, i.e. potentially with shadow, etc. The client must also
        /// acknowledge the configure when committing the new content (see
        /// ack_configure).
        /// 
        /// It is up to the compositor to position the surface after it was
        /// unmaximized; usually the position the surface had before maximizing, if
        /// applicable.
        /// 
        /// If the surface was already not maximized, the compositor will still
        /// emit a configure event without the "maximized" state.
        /// </summary>
        public void UnsetMaximized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        /// <summary>
        /// Make the surface fullscreen.
        /// 
        /// You can specify an output that you would prefer to be fullscreen.
        /// If this value is NULL, it's up to the compositor to choose which
        /// display will be used to map this surface.
        /// 
        /// If the surface doesn't cover the whole output, the compositor will
        /// position the surface in the center of the output and compensate with
        /// black borders filling the rest of the output.
        /// </summary>
        public void SetFullscreen(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 11, __args);
        }

        public void UnsetFullscreen()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 12, __args);
        }

        /// <summary>
        /// Request that the compositor minimize your surface. There is no
        /// way to know if the surface is currently minimized, nor is there
        /// any way to unset minimization on this surface.
        /// 
        /// If you are looking to throttle redrawing when minimized, please
        /// instead use the wl_surface.frame event for this, as this will
        /// also work with live previews on windows in Alt-Tab, Expose or
        /// similar compositor features.
        /// </summary>
        public void SetMinimized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 13, __args);
        }

        public interface IEvents
        {
            void OnConfigure(NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6 eventSender, int @width, int @height, ReadOnlySpan<byte> @states);
            void OnClose(NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfigure(this, arguments[0].Int32, arguments[1].Int32, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[2].IntPtr));
            if (opcode == 1)
                Events?.OnClose(this);
        }

        /// <summary>
        /// These values are used to indicate which edge of a surface
        /// is being dragged in a resize operation.
        /// </summary>
        public enum ResizeEdgeEnum
        {
            None = 0,
            Top = 1,
            Bottom = 2,
            Left = 4,
            TopLeft = 5,
            BottomLeft = 6,
            Right = 8,
            TopRight = 9,
            BottomRight = 10
        }

        /// <summary>
        /// The different state values used on the surface. This is designed for
        /// state values like maximized, fullscreen. It is paired with the
        /// configure event to ensure that both the client and the compositor
        /// setting the state can be synchronized.
        /// 
        /// States set in this way are double-buffered. They will get applied on
        /// the next commit.
        /// </summary>
        public enum StateEnum
        {
            /// <summary>the surface is maximized</summary>
            Maximized = 1,
            /// <summary>the surface is fullscreen</summary>
            Fullscreen = 2,
            /// <summary>the surface is being resized</summary>
            Resizing = 3,
            /// <summary>the surface is now activated</summary>
            Activated = 4
        }

        class ProxyFactory : IBindFactory<ZxdgToplevelV6>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgToplevelV6.WlInterface);
            }

            public ZxdgToplevelV6 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgToplevelV6(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgToplevelV6> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_toplevel_v6";
        public const int InterfaceVersion = 1;

        public ZxdgToplevelV6(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A popup surface is a short-lived, temporary surface. It can be used to
    /// implement for example menus, popovers, tooltips and other similar user
    /// interface concepts.
    /// 
    /// A popup can be made to take an explicit grab. See xdg_popup.grab for
    /// details.
    /// 
    /// When the popup is dismissed, a popup_done event will be sent out, and at
    /// the same time the surface will be unmapped. See the xdg_popup.popup_done
    /// event for details.
    /// 
    /// Explicitly destroying the xdg_popup object will also dismiss the popup and
    /// unmap the surface. Clients that want to dismiss the popup when another
    /// surface of their own is clicked should dismiss the popup using the destroy
    /// request.
    /// 
    /// The parent surface must have either the xdg_toplevel or xdg_popup surface
    /// role.
    /// 
    /// A newly created xdg_popup will be stacked on top of all previously created
    /// xdg_popup surfaces associated with the same xdg_toplevel.
    /// 
    /// The parent of an xdg_popup must be mapped (see the xdg_surface
    /// description) before the xdg_popup itself.
    /// 
    /// The x and y arguments passed when creating the popup object specify
    /// where the top left of the popup should be placed, relative to the
    /// local surface coordinates of the parent surface. See
    /// xdg_surface.get_popup. An xdg_popup must intersect with or be at least
    /// partially adjacent to its parent surface.
    /// 
    /// The client must call wl_surface.commit on the corresponding wl_surface
    /// for the xdg_popup state to take effect.
    /// </summary>
    public sealed unsafe partial class ZxdgPopupV6 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgPopupV6()
        {
            WlInterface.Init("zxdg_popup_v6", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("grab", "ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), null })
            }, new WlMessage[] {
                WlMessage.Create("configure", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("popup_done", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This request makes the created popup take an explicit grab. An explicit
        /// grab will be dismissed when the user dismisses the popup, or when the
        /// client destroys the xdg_popup. This can be done by the user clicking
        /// outside the surface, using the keyboard, or even locking the screen
        /// through closing the lid or a timeout.
        /// 
        /// If the compositor denies the grab, the popup will be immediately
        /// dismissed.
        /// 
        /// This request must be used in response to some sort of user action like a
        /// button press, key press, or touch down event. The serial number of the
        /// event should be passed as 'serial'.
        /// 
        /// The parent of a grabbing popup must either be an xdg_toplevel surface or
        /// another xdg_popup with an explicit grab. If the parent is another
        /// xdg_popup it means that the popups are nested, with this popup now being
        /// the topmost popup.
        /// 
        /// Nested popups must be destroyed in the reverse order they were created
        /// in, e.g. the only popup you are allowed to destroy at all times is the
        /// topmost one.
        /// 
        /// When compositors choose to dismiss a popup, they may dismiss every
        /// nested grabbing popup as well. When a compositor dismisses popups, it
        /// will follow the same dismissing order as required from the client.
        /// 
        /// The parent of a grabbing popup must either be another xdg_popup with an
        /// active explicit grab, or an xdg_popup or xdg_toplevel, if there are no
        /// explicit grabs already taken.
        /// 
        /// If the topmost grabbing popup is destroyed, the grab will be returned to
        /// the parent of the popup, if that parent previously had an explicit grab.
        /// 
        /// If the parent is a grabbing popup which has already been dismissed, this
        /// popup will be immediately dismissed. If the parent is a popup that did
        /// not take an explicit grab, an error will be raised.
        /// 
        /// During a popup grab, the client owning the grab will receive pointer
        /// and touch events for all their surfaces as normal (similar to an
        /// "owner-events" grab in X11 parlance), while the top most grabbing popup
        /// will always have keyboard focus.
        /// </summary>
        public void Grab(NWayland.Protocols.Wayland.WlSeat @seat, uint @serial)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnConfigure(NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6 eventSender, int @x, int @y, int @width, int @height);
            void OnPopupDone(NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfigure(this, arguments[0].Int32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32);
            if (opcode == 1)
                Events?.OnPopupDone(this);
        }

        public enum ErrorEnum
        {
            /// <summary>tried to grab after being mapped</summary>
            InvalidGrab = 0
        }

        class ProxyFactory : IBindFactory<ZxdgPopupV6>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShellUnstableV6.ZxdgPopupV6.WlInterface);
            }

            public ZxdgPopupV6 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgPopupV6(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgPopupV6> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_popup_v6";
        public const int InterfaceVersion = 1;

        public ZxdgPopupV6(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}