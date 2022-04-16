using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.IdleInhibitUnstableV1
{
    /// <summary>
    /// This interface permits inhibiting the idle behavior such as screen
    /// blanking, locking, and screensaving.  The client binds the idle manager
    /// globally, then creates idle-inhibitor objects for each surface.
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
    public sealed unsafe partial class ZwpIdleInhibitManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpIdleInhibitManagerV1()
        {
            WlInterface.Init("zwp_idle_inhibit_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("create_inhibitor", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitManagerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Create a new inhibitor object associated with the given surface.
        /// </summary>
        public NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1 CreateInhibitor(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpIdleInhibitManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitManagerV1.WlInterface);
            }

            public ZwpIdleInhibitManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpIdleInhibitManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpIdleInhibitManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_idle_inhibit_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpIdleInhibitManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An idle inhibitor prevents the output that the associated surface is
    /// visible on from being set to a state where it is not visually usable due
    /// to lack of user interaction (e.g. blanked, dimmed, locked, set to power
    /// save, etc.)  Any screensaver processes are also blocked from displaying.
    /// 
    /// If the surface is destroyed, unmapped, becomes occluded, loses
    /// visibility, or otherwise becomes not visually relevant for the user, the
    /// idle inhibitor will not be honored by the compositor; if the surface
    /// subsequently regains visibility the inhibitor takes effect once again.
    /// Likewise, the inhibitor isn't honored if the system was already idled at
    /// the time the inhibitor was established, although if the system later
    /// de-idles and re-idles the inhibitor will take effect.
    /// </summary>
    public sealed unsafe partial class ZwpIdleInhibitorV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpIdleInhibitorV1()
        {
            WlInterface.Init("zwp_idle_inhibitor_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpIdleInhibitorV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.IdleInhibitUnstableV1.ZwpIdleInhibitorV1.WlInterface);
            }

            public ZwpIdleInhibitorV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpIdleInhibitorV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpIdleInhibitorV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_idle_inhibitor_v1";
        public const int InterfaceVersion = 1;

        public ZwpIdleInhibitorV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}