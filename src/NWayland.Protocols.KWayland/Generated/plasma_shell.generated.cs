using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.PlasmaShell
{
    /// <summary>
    /// This interface is used by KF5 powered Wayland shells to communicate with
    /// the compositor and can only be bound one time.
    /// </summary>
    public sealed unsafe partial class OrgKdePlasmaShell : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaShell()
        {
            WlInterface.Init("org_kde_plasma_shell", 6, new WlMessage[] {
                WlMessage.Create("get_surface", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaShell.WlInterface);
        }

        /// <summary>
        /// Create a shell surface for an existing surface.
        /// 
        /// Only one shell surface can be associated with a given
        /// surface.
        /// </summary>
        public NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface GetSurface(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaShell>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaShell.WlInterface);
            }

            public OrgKdePlasmaShell Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaShell(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaShell> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_shell";
        public const int InterfaceVersion = 6;

        public OrgKdePlasmaShell(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An interface that may be implemented by a wl_surface, for
    /// implementations that provide the shell user interface.
    /// 
    /// It provides requests to set surface roles, assign an output
    /// or set the position in output coordinates.
    /// 
    /// On the server side the object is automatically destroyed when
    /// the related wl_surface is destroyed.  On client side,
    /// org_kde_plasma_surface.destroy() must be called before
    /// destroying the wl_surface object.
    /// </summary>
    public sealed unsafe partial class OrgKdePlasmaSurface : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaSurface()
        {
            WlInterface.Init("org_kde_plasma_surface", 6, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_output", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("set_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("set_role", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_panel_behavior", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_skip_taskbar", "2u", new WlInterface*[] { null }),
                WlMessage.Create("panel_auto_hide_hide", "4", new WlInterface*[] { }),
                WlMessage.Create("panel_auto_hide_show", "4", new WlInterface*[] { }),
                WlMessage.Create("set_panel_takes_focus", "4u", new WlInterface*[] { null }),
                WlMessage.Create("set_skip_switcher", "5u", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("auto_hidden_panel_hidden", "4", new WlInterface*[] { }),
                WlMessage.Create("auto_hidden_panel_shown", "4", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Assign an output to this shell surface.
        /// The compositor will use this information to set the position
        /// when org_kde_plasma_surface.set_position request is
        /// called.
        /// </summary>
        public void SetOutput(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Move the surface to new coordinates.
        /// 
        /// Coordinates are global, for example 50,50 for a 1920,0+1920x1080 output
        /// is 1970,50 in global coordinates space.
        /// 
        /// Use org_kde_plasma_surface.set_output to assign an output
        /// to this surface.
        /// </summary>
        public void SetPosition(int @x, int @y)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Assign a role to a shell surface.
        /// 
        /// The compositor handles surfaces depending on their role.
        /// See the explanation below.
        /// 
        /// This request fails if the surface already has a role, this means
        /// the surface role may be assigned only once.
        /// 
        /// == Surfaces with splash role ==
        /// 
        /// Splash surfaces are placed above every other surface during the
        /// shell startup phase.
        /// 
        /// The surfaces are placed according to the output coordinates.
        /// No size is imposed to those surfaces, the shell has to resize
        /// them according to output size.
        /// 
        /// These surfaces are meant to hide the desktop during the startup
        /// phase so that the user will always see a ready to work desktop.
        /// 
        /// A shell might not create splash surfaces if the compositor reveals
        /// the desktop in an alternative fashion, for example with a fade
        /// in effect.
        /// 
        /// That depends on how much time the desktop usually need to prepare
        /// the workspace or specific design decisions.
        /// This specification doesn't impose any particular design.
        /// 
        /// When the startup phase is finished, the shell will send the
        /// org_kde_plasma.desktop_ready request to the compositor.
        /// 
        /// == Surfaces with desktop role ==
        /// 
        /// Desktop surfaces are placed below all other surfaces and are used
        /// to show the actual desktop view with icons, search results or
        /// controls the user will interact with. What to show depends on the
        /// shell implementation.
        /// 
        /// The surfaces are placed according to the output coordinates.
        /// No size is imposed to those surfaces, the shell has to resize
        /// them according to output size.
        /// 
        /// Only one surface per output can have the desktop role.
        /// 
        /// == Surfaces with dashboard role ==
        /// 
        /// Dashboard surfaces are placed above desktop surfaces and are used to
        /// show additional widgets and controls.
        /// 
        /// The surfaces are placed according to the output coordinates.
        /// No size is imposed to those surfaces, the shell has to resize
        /// them according to output size.
        /// 
        /// Only one surface per output can have the dashboard role.
        /// 
        /// == Surfaces with config role ==
        /// 
        /// A configuration surface is shown when the user wants to configure
        /// panel or desktop views.
        /// 
        /// Only one surface per output can have the config role.
        /// 
        /// TODO: This should grab the input like popup menus, right?
        /// 
        /// == Surfaces with overlay role ==
        /// 
        /// Overlays are special surfaces that shows for a limited amount
        /// of time.  Such surfaces are useful to display things like volume,
        /// brightness and status changes.
        /// 
        /// Compositors may decide to show those surfaces in a layer above
        /// all surfaces, even full screen ones if so is desired.
        /// 
        /// == Surfaces with notification role ==
        /// 
        /// Notification surfaces display informative content for a limited
        /// amount of time.  The compositor may decide to show them in a corner
        /// depending on the configuration.
        /// 
        /// These surfaces are shown in a layer above all other surfaces except
        /// for full screen ones.
        /// 
        /// == Surfaces with lock role ==
        /// 
        /// The lock surface is shown by the compositor when the session is
        /// locked, users interact with it to unlock the session.
        /// 
        /// Compositors should move lock surfaces to 0,0 in output
        /// coordinates space and hide all other surfaces for security sake.
        /// For the same reason it is recommended that clients make the
        /// lock surface as big as the screen.
        /// 
        /// Only one surface per output can have the lock role.
        /// </summary>
        public void SetRole(uint @role)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @role
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Set flags bitmask as described by the flag enum.
        /// Pass 0 to unset any flag, the surface will adjust its behavior to
        /// the default.
        /// </summary>
        public void SetPanelBehavior(uint @flag)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @flag
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Setting this bit to the window, will make it say it prefers to not be listed in the taskbar. Taskbar implementations may or may not follow this hint.
        /// </summary>
        public void SetSkipTaskbar(uint @skip)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request set_skip_taskbar is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @skip
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// A panel surface with panel_behavior auto_hide can perform this request to hide the panel
        /// on a screen edge without unmapping it. The compositor informs the client about the panel
        /// being hidden with the event auto_hidden_panel_hidden.
        /// 
        /// The compositor will restore the visibility state of the
        /// surface when the pointer touches the screen edge the panel borders. Once the compositor restores
        /// the visibility the event auto_hidden_panel_shown will be sent. This event will also be sent
        /// if the compositor is unable to hide the panel.
        /// 
        /// The client can also request to show the panel again with the request panel_auto_hide_show.
        /// </summary>
        public void PanelAutoHideHide()
        {
            if (Version < 4)
                throw new System.InvalidOperationException("Request panel_auto_hide_hide is only supported since version 4");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// A panel surface with panel_behavior auto_hide can perform this request to show the panel
        /// again which got hidden with panel_auto_hide_hide.
        /// </summary>
        public void PanelAutoHideShow()
        {
            if (Version < 4)
                throw new System.InvalidOperationException("Request panel_auto_hide_show is only supported since version 4");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// By default various org_kde_plasma_surface roles do not take focus and cannot be
        /// activated. With this request the compositor can be instructed to pass focus also to this
        /// org_kde_plasma_surface.
        /// </summary>
        public void SetPanelTakesFocus(uint @takesFocus)
        {
            if (Version < 4)
                throw new System.InvalidOperationException("Request set_panel_takes_focus is only supported since version 4");
            WlArgument* __args = stackalloc WlArgument[] {
                @takesFocus
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Setting this bit will indicate that the window prefers not to be listed in a switcher.
        /// </summary>
        public void SetSkipSwitcher(uint @skip)
        {
            if (Version < 5)
                throw new System.InvalidOperationException("Request set_skip_switcher is only supported since version 5");
            WlArgument* __args = stackalloc WlArgument[] {
                @skip
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public interface IEvents
        {
            void OnAutoHiddenPanelHidden(NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface eventSender);
            void OnAutoHiddenPanelShown(NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnAutoHiddenPanelHidden(this);
            if (opcode == 1)
                Events?.OnAutoHiddenPanelShown(this);
        }

        public enum RoleEnum
        {
            Normal = 0,
            Desktop = 1,
            Panel = 2,
            Onscreendisplay = 3,
            Notification = 4,
            Tooltip = 5,
            Criticalnotification = 6
        }

        public enum PanelBehaviorEnum
        {
            /// <summary>normal panel visibility</summary>
            AlwaysVisible = 1,
            /// <summary>hide automatically</summary>
            AutoHide = 2,
            /// <summary>windows can cover</summary>
            WindowsCanCover = 3,
            /// <summary>windows go below</summary>
            WindowsGoBelow = 4
        }

        public enum ErrorEnum
        {
            /// <summary>Request panel_auto_hide performed on a surface which does not correspond to an auto-hide panel.</summary>
            PanelNotAutoHide = 0
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaSurface>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaShell.OrgKdePlasmaSurface.WlInterface);
            }

            public OrgKdePlasmaSurface Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaSurface(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaSurface> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_surface";
        public const int InterfaceVersion = 6;

        public OrgKdePlasmaSurface(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}