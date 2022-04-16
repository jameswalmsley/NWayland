using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XdgDecorationUnstableV1
{
    /// <summary>
    /// This interface allows a compositor to announce support for server-side
    /// decorations.
    /// 
    /// A window decoration is a set of window controls as deemed appropriate by
    /// the party managing them, such as user interface components used to move,
    /// resize and change a window's state.
    /// 
    /// A client can use this protocol to request being decorated by a supporting
    /// compositor.
    /// 
    /// If compositor and client do not negotiate the use of a server-side
    /// decoration using this protocol, clients continue to self-decorate as they
    /// see fit.
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
    public sealed unsafe partial class ZxdgDecorationManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgDecorationManagerV1()
        {
            WlInterface.Init("zxdg_decoration_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_toplevel_decoration", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgShell.XdgToplevel.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgDecorationManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a new decoration object associated with the given toplevel.
        /// 
        /// Creating an xdg_toplevel_decoration from an xdg_toplevel which has a
        /// buffer attached or committed is a client error, and any attempts by a
        /// client to attach or manipulate a buffer prior to the first
        /// xdg_toplevel_decoration.configure event must also be treated as
        /// errors.
        /// </summary>
        public NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1 GetToplevelDecoration(NWayland.Protocols.XdgShell.XdgToplevel @toplevel)
        {
            if (@toplevel == null)
                throw new System.ArgumentNullException("toplevel");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @toplevel
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgDecorationManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgDecorationManagerV1.WlInterface);
            }

            public ZxdgDecorationManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgDecorationManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgDecorationManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_decoration_manager_v1";
        public const int InterfaceVersion = 1;

        public ZxdgDecorationManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The decoration object allows the compositor to toggle server-side window
    /// decorations for a toplevel surface. The client can request to switch to
    /// another mode.
    /// 
    /// The xdg_toplevel_decoration object must be destroyed before its
    /// xdg_toplevel.
    /// </summary>
    public sealed unsafe partial class ZxdgToplevelDecorationV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgToplevelDecorationV1()
        {
            WlInterface.Init("zxdg_toplevel_decoration_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_mode", "u", new WlInterface*[] { null }),
                WlMessage.Create("unset_mode", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("configure", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the toplevel surface decoration mode. This informs the compositor
        /// that the client prefers the provided decoration mode.
        /// 
        /// After requesting a decoration mode, the compositor will respond by
        /// emitting a xdg_surface.configure event. The client should then update
        /// its content, drawing it without decorations if the received mode is
        /// server-side decorations. The client must also acknowledge the configure
        /// when committing the new content (see xdg_surface.ack_configure).
        /// 
        /// The compositor can decide not to use the client's mode and enforce a
        /// different mode instead.
        /// 
        /// Clients whose decoration mode depend on the xdg_toplevel state may send
        /// a set_mode request in response to a xdg_surface.configure event and wait
        /// for the next xdg_surface.configure event to prevent unwanted state.
        /// Such clients are responsible for preventing configure loops and must
        /// make sure not to send multiple successive set_mode requests with the
        /// same decoration mode.
        /// </summary>
        public void SetMode(ModeEnum @mode)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@mode
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Unset the toplevel surface decoration mode. This informs the compositor
        /// that the client doesn't prefer a particular decoration mode.
        /// 
        /// This request has the same semantics as set_mode.
        /// </summary>
        public void UnsetMode()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnConfigure(NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1 eventSender, ModeEnum @mode);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfigure(this, (ModeEnum)arguments[0].UInt32);
        }

        public enum ErrorEnum
        {
            /// <summary>xdg_toplevel has a buffer attached before configure</summary>
            UnconfiguredBuffer = 0,
            /// <summary>xdg_toplevel already has a decoration object</summary>
            AlreadyConstructed = 1,
            /// <summary>xdg_toplevel destroyed before the decoration object</summary>
            Orphaned = 2
        }

        /// <summary>
        /// These values describe window decoration modes.
        /// </summary>
        public enum ModeEnum
        {
            /// <summary>no server-side window decoration</summary>
            ClientSide = 1,
            /// <summary>server-side window decoration</summary>
            ServerSide = 2
        }

        class ProxyFactory : IBindFactory<ZxdgToplevelDecorationV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgDecorationUnstableV1.ZxdgToplevelDecorationV1.WlInterface);
            }

            public ZxdgToplevelDecorationV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgToplevelDecorationV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgToplevelDecorationV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_toplevel_decoration_v1";
        public const int InterfaceVersion = 1;

        public ZxdgToplevelDecorationV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}