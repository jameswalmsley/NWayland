using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1
{
    /// <summary>
    /// The purpose of this protocol is to enable the creation of taskbars
    /// and docks by providing them with a list of opened applications and
    /// letting them request certain actions on them, like maximizing, etc.
    /// 
    /// After a client binds the zwlr_foreign_toplevel_manager_v1, each opened
    /// toplevel window will be sent via the toplevel event
    /// </summary>
    public sealed unsafe partial class ZwlrForeignToplevelManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrForeignToplevelManagerV1()
        {
            WlInterface.Init("zwlr_foreign_toplevel_manager_v1", 2, new WlMessage[] {
                WlMessage.Create("stop", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("toplevel", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1.WlInterface) }),
                WlMessage.Create("finished", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelManagerV1.WlInterface);
        }

        /// <summary>
        /// Indicates the client no longer wishes to receive events for new toplevels.
        /// However the compositor may emit further toplevel_created events, until
        /// the finished event is emitted.
        /// 
        /// The client must not send any more requests after this one.
        /// </summary>
        public void Stop()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnToplevel(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelManagerV1 eventSender, ZwlrForeignToplevelHandleV1 @toplevel);
            void OnFinished(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelManagerV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnToplevel(this, new ZwlrForeignToplevelHandleV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnFinished(this);
        }

        class ProxyFactory : IBindFactory<ZwlrForeignToplevelManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelManagerV1.WlInterface);
            }

            public ZwlrForeignToplevelManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrForeignToplevelManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrForeignToplevelManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_foreign_toplevel_manager_v1";
        public const int InterfaceVersion = 2;

        public ZwlrForeignToplevelManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A zwlr_foreign_toplevel_handle_v1 object represents an opened toplevel
    /// window. Each app may have multiple opened toplevels.
    /// 
    /// Each toplevel has a list of outputs it is visible on, conveyed to the
    /// client with the output_enter and output_leave events.
    /// </summary>
    public sealed unsafe partial class ZwlrForeignToplevelHandleV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrForeignToplevelHandleV1()
        {
            WlInterface.Init("zwlr_foreign_toplevel_handle_v1", 2, new WlMessage[] {
                WlMessage.Create("set_maximized", "", new WlInterface*[] { }),
                WlMessage.Create("unset_maximized", "", new WlInterface*[] { }),
                WlMessage.Create("set_minimized", "", new WlInterface*[] { }),
                WlMessage.Create("unset_minimized", "", new WlInterface*[] { }),
                WlMessage.Create("activate", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("close", "", new WlInterface*[] { }),
                WlMessage.Create("set_rectangle", "oiiii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_fullscreen", "2?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("unset_fullscreen", "2", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("title", "s", new WlInterface*[] { null }),
                WlMessage.Create("app_id", "s", new WlInterface*[] { null }),
                WlMessage.Create("output_enter", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("output_leave", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                WlMessage.Create("state", "a", new WlInterface*[] { null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("closed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1.WlInterface);
        }

        /// <summary>
        /// Requests that the toplevel be maximized. If the maximized state actually
        /// changes, this will be indicated by the state event.
        /// </summary>
        public void SetMaximized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Requests that the toplevel be unmaximized. If the maximized state actually
        /// changes, this will be indicated by the state event.
        /// </summary>
        public void UnsetMaximized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Requests that the toplevel be minimized. If the minimized state actually
        /// changes, this will be indicated by the state event.
        /// </summary>
        public void SetMinimized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Requests that the toplevel be unminimized. If the minimized state actually
        /// changes, this will be indicated by the state event.
        /// </summary>
        public void UnsetMinimized()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Request that this toplevel be activated on the given seat.
        /// There is no guarantee the toplevel will be actually activated.
        /// </summary>
        public void Activate(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Send a request to the toplevel to close itself. The compositor would
        /// typically use a shell-specific method to carry out this request, for
        /// example by sending the xdg_toplevel.close event. However, this gives
        /// no guarantees the toplevel will actually be destroyed. If and when
        /// this happens, the zwlr_foreign_toplevel_handle_v1.closed event will
        /// be emitted.
        /// </summary>
        public void Close()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// The rectangle of the surface specified in this request corresponds to
        /// the place where the app using this protocol represents the given toplevel.
        /// It can be used by the compositor as a hint for some operations, e.g
        /// minimizing. The client is however not required to set this, in which
        /// case the compositor is free to decide some default value.
        /// 
        /// If the client specifies more than one rectangle, only the last one is
        /// considered.
        /// 
        /// The dimensions are given in surface-local coordinates.
        /// Setting width=height=0 removes the already-set rectangle.
        /// </summary>
        public void SetRectangle(NWayland.Protocols.Wayland.WlSurface @surface, int @x, int @y, int @width, int @height)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                @x,
                @y,
                @width,
                @height
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
        /// Requests that the toplevel be fullscreened on the given output. If the
        /// fullscreen state and/or the outputs the toplevel is visible on actually
        /// change, this will be indicated by the state and output_enter/leave
        /// events.
        /// 
        /// The output parameter is only a hint to the compositor. Also, if output
        /// is NULL, the compositor should decide which output the toplevel will be
        /// fullscreened on, if at all.
        /// </summary>
        public void SetFullscreen(NWayland.Protocols.Wayland.WlOutput @output)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            if (Version < 2)
                throw new System.InvalidOperationException("Request set_fullscreen is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @output
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Requests that the toplevel be unfullscreened. If the fullscreen state
        /// actually changes, this will be indicated by the state event.
        /// </summary>
        public void UnsetFullscreen()
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request unset_fullscreen is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public interface IEvents
        {
            void OnTitle(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender, System.String @title);
            void OnAppId(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender, System.String @appId);
            void OnOutputEnter(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender, NWayland.Protocols.Wayland.WlOutput @output);
            void OnOutputLeave(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender, NWayland.Protocols.Wayland.WlOutput @output);
            void OnState(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender, ReadOnlySpan<byte> @state);
            void OnDone(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender);
            void OnClosed(NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnTitle(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnAppId(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnOutputEnter(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
            if (opcode == 3)
                Events?.OnOutputLeave(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
            if (opcode == 4)
                Events?.OnState(this, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[0].IntPtr));
            if (opcode == 5)
                Events?.OnDone(this);
            if (opcode == 6)
                Events?.OnClosed(this);
        }

        /// <summary>
        /// The different states that a toplevel can have. These have the same meaning
        /// as the states with the same names defined in xdg-toplevel
        /// </summary>
        public enum StateEnum
        {
            /// <summary>the toplevel is maximized</summary>
            Maximized = 0,
            /// <summary>the toplevel is minimized</summary>
            Minimized = 1,
            /// <summary>the toplevel is active</summary>
            Activated = 2,
            /// <summary>the toplevel is fullscreen</summary>
            Fullscreen = 3
        }

        public enum ErrorEnum
        {
            /// <summary>the provided rectangle is invalid</summary>
            InvalidRectangle = 0
        }

        class ProxyFactory : IBindFactory<ZwlrForeignToplevelHandleV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrForeignToplevelManagementUnstableV1.ZwlrForeignToplevelHandleV1.WlInterface);
            }

            public ZwlrForeignToplevelHandleV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrForeignToplevelHandleV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrForeignToplevelHandleV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_foreign_toplevel_handle_v1";
        public const int InterfaceVersion = 2;

        public ZwlrForeignToplevelHandleV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}