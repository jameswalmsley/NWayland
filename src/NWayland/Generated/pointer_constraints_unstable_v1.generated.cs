using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.PointerConstraintsUnstableV1
{
    /// <summary>
    /// The global interface exposing pointer constraining functionality. It
    /// exposes two requests: lock_pointer for locking the pointer to its
    /// position, and confine_pointer for locking the pointer to a region.
    /// 
    /// The lock_pointer and confine_pointer requests create the objects
    /// wp_locked_pointer and wp_confined_pointer respectively, and the client can
    /// use these objects to interact with the lock.
    /// 
    /// For any surface, only one lock or confinement may be active across all
    /// wl_pointer objects of the same seat. If a lock or confinement is requested
    /// when another lock or confinement is active or requested on the same surface
    /// and with any of the wl_pointer objects of the same seat, an
    /// 'already_constrained' error will be raised.
    /// </summary>
    public sealed unsafe partial class ZwpPointerConstraintsV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPointerConstraintsV1()
        {
            WlInterface.Init("zwp_pointer_constraints_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("lock_pointer", "noo?ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface), null }),
                WlMessage.Create("confine_pointer", "noo?ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlPointer.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface), null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpPointerConstraintsV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The lock_pointer request lets the client request to disable movements of
        /// the virtual pointer (i.e. the cursor), effectively locking the pointer
        /// to a position. This request may not take effect immediately; in the
        /// future, when the compositor deems implementation-specific constraints
        /// are satisfied, the pointer lock will be activated and the compositor
        /// sends a locked event.
        /// 
        /// The protocol provides no guarantee that the constraints are ever
        /// satisfied, and does not require the compositor to send an error if the
        /// constraints cannot ever be satisfied. It is thus possible to request a
        /// lock that will never activate.
        /// 
        /// There may not be another pointer constraint of any kind requested or
        /// active on the surface for any of the wl_pointer objects of the seat of
        /// the passed pointer when requesting a lock. If there is, an error will be
        /// raised. See general pointer lock documentation for more details.
        /// 
        /// The intersection of the region passed with this request and the input
        /// region of the surface is used to determine where the pointer must be
        /// in order for the lock to activate. It is up to the compositor whether to
        /// warp the pointer or require some kind of user interaction for the lock
        /// to activate. If the region is null the surface input region is used.
        /// 
        /// A surface may receive pointer focus without the lock being activated.
        /// 
        /// The request creates a new object wp_locked_pointer which is used to
        /// interact with the lock as well as receive updates about its state. See
        /// the the description of wp_locked_pointer for further information.
        /// 
        /// Note that while a pointer is locked, the wl_pointer objects of the
        /// corresponding seat will not emit any wl_pointer.motion events, but
        /// relative motion events will still be emitted via wp_relative_pointer
        /// objects of the same seat. wl_pointer.axis and wl_pointer.button events
        /// are unaffected.
        /// </summary>
        public NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1 LockPointer(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlPointer @pointer, NWayland.Protocols.Wayland.WlRegion @region, uint @lifetime)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface,
                @pointer,
                @region,
                @lifetime
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1(__ret, Version, Display);
        }

        /// <summary>
        /// The confine_pointer request lets the client request to confine the
        /// pointer cursor to a given region. This request may not take effect
        /// immediately; in the future, when the compositor deems implementation-
        /// specific constraints are satisfied, the pointer confinement will be
        /// activated and the compositor sends a confined event.
        /// 
        /// The intersection of the region passed with this request and the input
        /// region of the surface is used to determine where the pointer must be
        /// in order for the confinement to activate. It is up to the compositor
        /// whether to warp the pointer or require some kind of user interaction for
        /// the confinement to activate. If the region is null the surface input
        /// region is used.
        /// 
        /// The request will create a new object wp_confined_pointer which is used
        /// to interact with the confinement as well as receive updates about its
        /// state. See the the description of wp_confined_pointer for further
        /// information.
        /// </summary>
        public NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1 ConfinePointer(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlPointer @pointer, NWayland.Protocols.Wayland.WlRegion @region, uint @lifetime)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            if (@pointer == null)
                throw new System.ArgumentNullException("pointer");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface,
                @pointer,
                @region,
                @lifetime
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 2, __args, ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        /// <summary>
        /// These errors can be emitted in response to wp_pointer_constraints
        /// requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary>pointer constraint already requested on that surface</summary>
            AlreadyConstrained = 1
        }

        /// <summary>
        /// These values represent different lifetime semantics. They are passed
        /// as arguments to the factory requests to specify how the constraint
        /// lifetimes should be managed.
        /// </summary>
        public enum LifetimeEnum
        {
            Oneshot = 1,
            Persistent = 2
        }

        class ProxyFactory : IBindFactory<ZwpPointerConstraintsV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpPointerConstraintsV1.WlInterface);
            }

            public ZwpPointerConstraintsV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPointerConstraintsV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPointerConstraintsV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_pointer_constraints_v1";
        public const int InterfaceVersion = 1;

        public ZwpPointerConstraintsV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wp_locked_pointer interface represents a locked pointer state.
    /// 
    /// While the lock of this object is active, the wl_pointer objects of the
    /// associated seat will not emit any wl_pointer.motion events.
    /// 
    /// This object will send the event 'locked' when the lock is activated.
    /// Whenever the lock is activated, it is guaranteed that the locked surface
    /// will already have received pointer focus and that the pointer will be
    /// within the region passed to the request creating this object.
    /// 
    /// To unlock the pointer, send the destroy request. This will also destroy
    /// the wp_locked_pointer object.
    /// 
    /// If the compositor decides to unlock the pointer the unlocked event is
    /// sent. See wp_locked_pointer.unlock for details.
    /// 
    /// When unlocking, the compositor may warp the cursor position to the set
    /// cursor position hint. If it does, it will not result in any relative
    /// motion events emitted via wp_relative_pointer.
    /// 
    /// If the surface the lock was requested on is destroyed and the lock is not
    /// yet activated, the wp_locked_pointer object is now defunct and must be
    /// destroyed.
    /// </summary>
    public sealed unsafe partial class ZwpLockedPointerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpLockedPointerV1()
        {
            WlInterface.Init("zwp_locked_pointer_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_cursor_position_hint", "ff", new WlInterface*[] { null, null }),
                WlMessage.Create("set_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("locked", "", new WlInterface*[] { }),
                WlMessage.Create("unlocked", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the cursor position hint relative to the top left corner of the
        /// surface.
        /// 
        /// If the client is drawing its own cursor, it should update the position
        /// hint to the position of its own cursor. A compositor may use this
        /// information to warp the pointer upon unlock in order to avoid pointer
        /// jumps.
        /// 
        /// The cursor position hint is double buffered. The new hint will only take
        /// effect when the associated surface gets it pending state applied. See
        /// wl_surface.commit for details.
        /// </summary>
        public void SetCursorPositionHint(int @surfaceX, int @surfaceY)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @surfaceX,
                @surfaceY
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Set a new region used to lock the pointer.
        /// 
        /// The new lock region is double-buffered. The new lock region will
        /// only take effect when the associated surface gets its pending state
        /// applied. See wl_surface.commit for details.
        /// 
        /// For details about the lock region, see wp_locked_pointer.
        /// </summary>
        public void SetRegion(NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            WlArgument* __args = stackalloc WlArgument[] {
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnLocked(NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1 eventSender);
            void OnUnlocked(NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnLocked(this);
            if (opcode == 1)
                Events?.OnUnlocked(this);
        }

        class ProxyFactory : IBindFactory<ZwpLockedPointerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpLockedPointerV1.WlInterface);
            }

            public ZwpLockedPointerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpLockedPointerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpLockedPointerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_locked_pointer_v1";
        public const int InterfaceVersion = 1;

        public ZwpLockedPointerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wp_confined_pointer interface represents a confined pointer state.
    /// 
    /// This object will send the event 'confined' when the confinement is
    /// activated. Whenever the confinement is activated, it is guaranteed that
    /// the surface the pointer is confined to will already have received pointer
    /// focus and that the pointer will be within the region passed to the request
    /// creating this object. It is up to the compositor to decide whether this
    /// requires some user interaction and if the pointer will warp to within the
    /// passed region if outside.
    /// 
    /// To unconfine the pointer, send the destroy request. This will also destroy
    /// the wp_confined_pointer object.
    /// 
    /// If the compositor decides to unconfine the pointer the unconfined event is
    /// sent. The wp_confined_pointer object is at this point defunct and should
    /// be destroyed.
    /// </summary>
    public sealed unsafe partial class ZwpConfinedPointerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpConfinedPointerV1()
        {
            WlInterface.Init("zwp_confined_pointer_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_region", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("confined", "", new WlInterface*[] { }),
                WlMessage.Create("unconfined", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set a new region used to confine the pointer.
        /// 
        /// The new confine region is double-buffered. The new confine region will
        /// only take effect when the associated surface gets its pending state
        /// applied. See wl_surface.commit for details.
        /// 
        /// If the confinement is active when the new confinement region is applied
        /// and the pointer ends up outside of newly applied region, the pointer may
        /// warped to a position within the new confinement region. If warped, a
        /// wl_pointer.motion event will be emitted, but no
        /// wp_relative_pointer.relative_motion event.
        /// 
        /// The compositor may also, instead of using the new region, unconfine the
        /// pointer.
        /// 
        /// For details about the confine region, see wp_confined_pointer.
        /// </summary>
        public void SetRegion(NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            WlArgument* __args = stackalloc WlArgument[] {
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnConfined(NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1 eventSender);
            void OnUnconfined(NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnConfined(this);
            if (opcode == 1)
                Events?.OnUnconfined(this);
        }

        class ProxyFactory : IBindFactory<ZwpConfinedPointerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PointerConstraintsUnstableV1.ZwpConfinedPointerV1.WlInterface);
            }

            public ZwpConfinedPointerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpConfinedPointerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpConfinedPointerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_confined_pointer_v1";
        public const int InterfaceVersion = 1;

        public ZwpConfinedPointerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}