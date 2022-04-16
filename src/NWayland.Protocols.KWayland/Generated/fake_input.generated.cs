using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.FakeInput
{
    /// <summary>
    /// This interface allows other processes to provide fake input events.
    /// Purpose is on the one hand side to provide testing facilities like XTest on X11.
    /// But also to support use case like kdeconnect's mouse pad interface.
    /// 
    /// A compositor should not trust the input received from this interface.
    /// Clients should not expect that the compositor honors the requests from this
    /// interface.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinFakeInput : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinFakeInput()
        {
            WlInterface.Init("org_kde_kwin_fake_input", 4, new WlMessage[] {
                WlMessage.Create("authenticate", "ss", new WlInterface*[] { null, null }),
                WlMessage.Create("pointer_motion", "ff", new WlInterface*[] { null, null }),
                WlMessage.Create("button", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("axis", "uf", new WlInterface*[] { null, null }),
                WlMessage.Create("touch_down", "2uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("touch_motion", "2uff", new WlInterface*[] { null, null, null }),
                WlMessage.Create("touch_up", "2u", new WlInterface*[] { null }),
                WlMessage.Create("touch_cancel", "2", new WlInterface*[] { }),
                WlMessage.Create("touch_frame", "2", new WlInterface*[] { }),
                WlMessage.Create("pointer_motion_absolute", "3ff", new WlInterface*[] { null, null }),
                WlMessage.Create("keyboard_key", "4uu", new WlInterface*[] { null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.FakeInput.OrgKdeKwinFakeInput.WlInterface);
        }

        /// <summary>
        /// A client should use this request to tell the compositor why it wants to
        /// use this interface. The compositor might use the information to decide
        /// whether it wants to grant the request. The data might also be passed to
        /// the user to decide whether the application should get granted access to
        /// this very privileged interface.
        /// </summary>
        public void Authenticate(System.String @application, System.String @reason)
        {
            if (@reason == null)
                throw new System.ArgumentNullException("reason");
            if (@application == null)
                throw new System.ArgumentNullException("application");
            using var __marshalled__application = new NWayland.Interop.NWaylandMarshalledString(@application);
            using var __marshalled__reason = new NWayland.Interop.NWaylandMarshalledString(@reason);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__application,
                __marshalled__reason
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void PointerMotion(int @deltaX, int @deltaY)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @deltaX,
                @deltaY
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public void Button(uint @button, uint @state)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @button,
                @state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public void Axis(uint @axis, int @value)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @axis,
                @value
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// A client should use this request to send touch down event at specific
        /// co-ordinates.
        /// </summary>
        public void TouchDown(uint @id, int @x, int @y)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request touch_down is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @id,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// A client should use this request to send touch motion to specific position.
        /// </summary>
        public void TouchMotion(uint @id, int @x, int @y)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request touch_motion is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @id,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// A client should use this request to send touch up event.
        /// </summary>
        public void TouchUp(uint @id)
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request touch_up is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @id
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// A client should use this request to cancel the current
        /// touch event.
        /// </summary>
        public void TouchCancel()
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request touch_cancel is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// A client should use this request to send touch frame event.
        /// </summary>
        public void TouchFrame()
        {
            if (Version < 2)
                throw new System.InvalidOperationException("Request touch_frame is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public void PointerMotionAbsolute(int @x, int @y)
        {
            if (Version < 3)
                throw new System.InvalidOperationException("Request pointer_motion_absolute is only supported since version 3");
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public void KeyboardKey(uint @button, uint @state)
        {
            if (Version < 4)
                throw new System.InvalidOperationException("Request keyboard_key is only supported since version 4");
            WlArgument* __args = stackalloc WlArgument[] {
                @button,
                @state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinFakeInput>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.FakeInput.OrgKdeKwinFakeInput.WlInterface);
            }

            public OrgKdeKwinFakeInput Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinFakeInput(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinFakeInput> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_fake_input";
        public const int InterfaceVersion = 4;

        public OrgKdeKwinFakeInput(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}