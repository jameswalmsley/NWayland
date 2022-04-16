using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.PlasmaWindowManagement
{
    /// <summary>
    /// This interface manages application windows.
    /// It provides requests to show and hide the desktop and emits
    /// an event every time a window is created so that the client can
    /// use it to manage the window.
    /// 
    /// Only one client can bind this interface at a time.
    /// </summary>
    public sealed unsafe partial class OrgKdePlasmaWindowManagement : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaWindowManagement()
        {
            WlInterface.Init("org_kde_plasma_window_management", 9, new WlMessage[] {
                WlMessage.Create("show_desktop", "u", new WlInterface*[] { null }),
                WlMessage.Create("get_window", "nu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow.WlInterface), null })
            }, new WlMessage[] {
                WlMessage.Create("show_desktop_changed", "u", new WlInterface*[] { null }),
                WlMessage.Create("window", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindowManagement.WlInterface);
        }

        /// <summary>
        /// Tell the compositor to show/hide the desktop.
        /// </summary>
        public void ShowDesktop(uint @state)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow GetWindow(uint @internalWindowId)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @internalWindowId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow(__ret, Version, Display);
        }

        public interface IEvents
        {
            void OnShowDesktopChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindowManagement eventSender, uint @state);
            void OnWindow(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindowManagement eventSender, uint @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnShowDesktopChanged(this, arguments[0].UInt32);
            if (opcode == 1)
                Events?.OnWindow(this, arguments[0].UInt32);
        }

        public enum StateEnum
        {
            Active = 1 << 0,
            Minimized = 1 << 1,
            Maximized = 1 << 2,
            Fullscreen = 1 << 3,
            KeepAbove = 1 << 4,
            KeepBelow = 1 << 5,
            OnAllDesktops = 1 << 6,
            DemandsAttention = 1 << 7,
            Closeable = 1 << 8,
            Minimizable = 1 << 9,
            Maximizable = 1 << 10,
            Fullscreenable = 1 << 11,
            Skiptaskbar = 1 << 12,
            Shadeable = 1 << 13,
            Shaded = 1 << 14,
            Movable = 1 << 15,
            Resizable = 1 << 16,
            VirtualDesktopChangeable = 1 << 17,
            Skipswitcher = 1 << 18
        }

        public enum ShowDesktopEnum
        {
            Disabled = 0,
            Enabled = 1
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaWindowManagement>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindowManagement.WlInterface);
            }

            public OrgKdePlasmaWindowManagement Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaWindowManagement(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaWindowManagement> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_window_management";
        public const int InterfaceVersion = 9;

        public OrgKdePlasmaWindowManagement(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// Manages and control an application window.
    /// 
    /// Only one client can bind this interface at a time.
    /// </summary>
    public sealed unsafe partial class OrgKdePlasmaWindow : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaWindow()
        {
            WlInterface.Init("org_kde_plasma_window", 8, new WlMessage[] {
                WlMessage.Create("set_state", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("set_virtual_desktop", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_minimized_geometry", "ouuuu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null, null }),
                WlMessage.Create("unset_minimized_geometry", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("close", "", new WlInterface*[] { }),
                WlMessage.Create("request_move", "3", new WlInterface*[] { }),
                WlMessage.Create("request_resize", "3", new WlInterface*[] { }),
                WlMessage.Create("destroy", "4", new WlInterface*[] { }),
                WlMessage.Create("get_icon", "7h", new WlInterface*[] { null }),
                WlMessage.Create("request_enter_virtual_desktop", "8s", new WlInterface*[] { null }),
                WlMessage.Create("request_enter_new_virtual_desktop", "8", new WlInterface*[] { }),
                WlMessage.Create("request_leave_virtual_desktop", "8s", new WlInterface*[] { null })
            }, new WlMessage[] {
                WlMessage.Create("title_changed", "s", new WlInterface*[] { null }),
                WlMessage.Create("app_id_changed", "s", new WlInterface*[] { null }),
                WlMessage.Create("state_changed", "u", new WlInterface*[] { null }),
                WlMessage.Create("virtual_desktop_changed", "i", new WlInterface*[] { null }),
                WlMessage.Create("themed_icon_name_changed", "s", new WlInterface*[] { null }),
                WlMessage.Create("unmapped", "", new WlInterface*[] { }),
                WlMessage.Create("initial_state", "4", new WlInterface*[] { }),
                WlMessage.Create("parent_window", "5?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow.WlInterface) }),
                WlMessage.Create("geometry", "6iiuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("icon_changed", "7", new WlInterface*[] { }),
                WlMessage.Create("pid_changed", "u", new WlInterface*[] { null }),
                WlMessage.Create("virtual_desktop_entered", "8s", new WlInterface*[] { null }),
                WlMessage.Create("virtual_desktop_left", "8s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow.WlInterface);
        }

        /// <summary>
        /// Set window state.
        /// 
        /// Values for state argument are described by org_kde_plasma_window_management.state
        /// and can be used together in a bitfield. The flags bitfield describes which flags are
        /// supposed to be set, the state bitfield the value for the set flags
        /// </summary>
        public void SetState(uint @flags, uint @state)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @flags,
                @state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Deprecated: use enter_virtual_desktop
        /// Maps the window to a different virtual desktop.
        /// 
        /// To show the window on all virtual desktops, call the
        /// org_kde_plasma_window.set_state request and specify a on_all_desktops
        /// state in the bitfield.
        /// </summary>
        public void SetVirtualDesktop(uint @number)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @number
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Sets the geometry of the taskbar entry for this window.
        /// The geometry is relative to a panel in particular.
        /// </summary>
        public void SetMinimizedGeometry(NWayland.Protocols.Wayland.WlSurface @panel, uint @x, uint @y, uint @width, uint @height)
        {
            if (@panel == null)
                throw new System.ArgumentNullException("panel");
            WlArgument* __args = stackalloc WlArgument[] {
                @panel,
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Remove the task geometry information for a particular panel.
        /// </summary>
        public void UnsetMinimizedGeometry(NWayland.Protocols.Wayland.WlSurface @panel)
        {
            if (@panel == null)
                throw new System.ArgumentNullException("panel");
            WlArgument* __args = stackalloc WlArgument[] {
                @panel
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Close this window.
        /// </summary>
        public void Close()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Request an interactive move for this window.
        /// </summary>
        public void RequestMove()
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request request_move is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Request an interactive resize for this window.
        /// </summary>
        public void RequestResize()
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request request_resize is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 4)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// The compositor will write the window icon into the provided file descriptor.
        /// The data is a serialized QIcon with QDataStream.
        /// </summary>
        public void GetIcon(int @fd)
        {
            if (Version < 7)
                throw new System.InvalidOperationException("Request get_icon is only supported since version 7");
            WlArgument* __args = stackalloc WlArgument[] {
                @fd
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Make the window enter a virtual desktop. A window can enter more
        /// than one virtual desktop. if the id is empty or invalid, no action will be performed.
        /// </summary>
        public void RequestEnterVirtualDesktop(System.String @id)
        {
            if (@id == null)
                throw new System.ArgumentNullException("id");
            if (Version < 8)
                throw new System.InvalidOperationException("Request request_enter_virtual_desktop is only supported since version 8");
            using var __marshalled__id = new NWayland.Interop.NWaylandMarshalledString(@id);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__id
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        /// <summary>RFC: do this with an empty id to request_enter_virtual_desktop?
        /// Make the window enter a new virtual desktop. If the server consents the request,
        /// it will create a new virtual desktop and assign the window to it.
        /// </summary>
        public void RequestEnterNewVirtualDesktop()
        {
            if (Version < 8)
                throw new System.InvalidOperationException("Request request_enter_new_virtual_desktop is only supported since version 8");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        /// <summary>
        /// Make the window exit a virtual desktop. If it exits all desktops it will be considered on all of them.
        /// </summary>
        public void RequestLeaveVirtualDesktop(System.String @id)
        {
            if (@id == null)
                throw new System.ArgumentNullException("id");
            if (Version < 8)
                throw new System.InvalidOperationException("Request request_leave_virtual_desktop is only supported since version 8");
            using var __marshalled__id = new NWayland.Interop.NWaylandMarshalledString(@id);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__id
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 11, __args);
        }

        public interface IEvents
        {
            void OnTitleChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, System.String @title);
            void OnAppIdChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, System.String @appId);
            void OnStateChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, uint @flags);
            void OnVirtualDesktopChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, int @number);
            void OnThemedIconNameChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, System.String @name);
            void OnUnmapped(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender);
            void OnInitialState(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender);
            void OnParentWindow(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow @parent);
            void OnGeometry(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, int @x, int @y, uint @width, uint @height);
            void OnIconChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender);
            void OnPidChanged(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, uint @pid);
            void OnVirtualDesktopEntered(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, System.String @id);
            void OnVirtualDesktopLeft(NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow eventSender, System.String @is);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTitleChanged(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnAppIdChanged(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnStateChanged(this, arguments[0].UInt32);
            if (opcode == 3)
                Events?.OnVirtualDesktopChanged(this, arguments[0].Int32);
            if (opcode == 4)
                Events?.OnThemedIconNameChanged(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 5)
                Events?.OnUnmapped(this);
            if (opcode == 6)
                Events?.OnInitialState(this);
            if (opcode == 7)
                Events?.OnParentWindow(this, WlProxy.FromNative<NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow>(arguments[0].IntPtr));
            if (opcode == 8)
                Events?.OnGeometry(this, arguments[0].Int32, arguments[1].Int32, arguments[2].UInt32, arguments[3].UInt32);
            if (opcode == 9)
                Events?.OnIconChanged(this);
            if (opcode == 10)
                Events?.OnPidChanged(this, arguments[0].UInt32);
            if (opcode == 11)
                Events?.OnVirtualDesktopEntered(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 12)
                Events?.OnVirtualDesktopLeft(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaWindow>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaWindowManagement.OrgKdePlasmaWindow.WlInterface);
            }

            public OrgKdePlasmaWindow Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaWindow(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaWindow> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_window";
        public const int InterfaceVersion = 8;

        public OrgKdePlasmaWindow(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}