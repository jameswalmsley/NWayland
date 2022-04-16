using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1
{
    /// <summary>
    /// This interface is a manager that allows reading and writing the current
    /// output device configuration.
    /// 
    /// Output devices that display pixels (e.g. a physical monitor or a virtual
    /// output in a window) are represented as heads. Heads cannot be created nor
    /// destroyed by the client, but they can be enabled or disabled and their
    /// properties can be changed. Each head may have one or more available modes.
    /// 
    /// Whenever a head appears (e.g. a monitor is plugged in), it will be
    /// advertised via the head event. Immediately after the output manager is
    /// bound, all current heads are advertised.
    /// 
    /// Whenever a head's properties change, the relevant wlr_output_head events
    /// will be sent. Not all head properties will be sent: only properties that
    /// have changed need to.
    /// 
    /// Whenever a head disappears (e.g. a monitor is unplugged), a
    /// wlr_output_head.finished event will be sent.
    /// 
    /// After one or more heads appear, change or disappear, the done event will
    /// be sent. It carries a serial which can be used in a create_configuration
    /// request to update heads properties.
    /// 
    /// The information obtained from this protocol should only be used for output
    /// configuration purposes. This protocol is not designed to be a generic
    /// output property advertisement protocol for regular clients. Instead,
    /// protocols such as xdg-output should be used.
    /// </summary>
    public sealed unsafe partial class ZwlrOutputManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrOutputManagerV1()
        {
            WlInterface.Init("zwlr_output_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("create_configuration", "nu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1.WlInterface), null }),
                WlMessage.Create("stop", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("head", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1.WlInterface) }),
                WlMessage.Create("done", "u", new WlInterface*[] { null }),
                WlMessage.Create("finished", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputManagerV1.WlInterface);
        }

        /// <summary>
        /// Create a new output configuration object. This allows to update head
        /// properties.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1 CreateConfiguration(uint @serial)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @serial
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1(__ret, Version, Display);
        }

        /// <summary>
        /// Indicates the client no longer wishes to receive events for output
        /// configuration changes. However the compositor may emit further events,
        /// until the finished event is emitted.
        /// 
        /// The client must not send any more requests after this one.
        /// </summary>
        public void Stop()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnHead(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputManagerV1 eventSender, ZwlrOutputHeadV1 @head);
            void OnDone(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputManagerV1 eventSender, uint @serial);
            void OnFinished(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputManagerV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnHead(this, new ZwlrOutputHeadV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnDone(this, arguments[0].UInt32);
            if (opcode == 2)
                Events?.OnFinished(this);
        }

        class ProxyFactory : IBindFactory<ZwlrOutputManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputManagerV1.WlInterface);
            }

            public ZwlrOutputManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrOutputManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrOutputManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_output_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwlrOutputManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A head is an output device. The difference between a wl_output object and
    /// a head is that heads are advertised even if they are turned off. A head
    /// object only advertises properties and cannot be used directly to change
    /// them.
    /// 
    /// A head has some read-only properties: modes, name, description and
    /// physical_size. These cannot be changed by clients.
    /// 
    /// Other properties can be updated via a wlr_output_configuration object.
    /// 
    /// Properties sent via this interface are applied atomically via the
    /// wlr_output_manager.done event. No guarantees are made regarding the order
    /// in which properties are sent.
    /// </summary>
    public sealed unsafe partial class ZwlrOutputHeadV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrOutputHeadV1()
        {
            WlInterface.Init("zwlr_output_head_v1", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("name", "s", new WlInterface*[] { null }),
                WlMessage.Create("description", "s", new WlInterface*[] { null }),
                WlMessage.Create("physical_size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("mode", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1.WlInterface) }),
                WlMessage.Create("enabled", "i", new WlInterface*[] { null }),
                WlMessage.Create("current_mode", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1.WlInterface) }),
                WlMessage.Create("position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("transform", "i", new WlInterface*[] { null }),
                WlMessage.Create("scale", "f", new WlInterface*[] { null }),
                WlMessage.Create("finished", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1.WlInterface);
        }

        public interface IEvents
        {
            void OnName(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, System.String @name);
            void OnDescription(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, System.String @description);
            void OnPhysicalSize(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, int @width, int @height);
            void OnMode(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, ZwlrOutputModeV1 @mode);
            void OnEnabled(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, int @enabled);
            void OnCurrentMode(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 @mode);
            void OnPosition(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, int @x, int @y);
            void OnTransform(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, NWayland.Protocols.Wayland.WlOutput.TransformEnum @transform);
            void OnScale(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender, int @scale);
            void OnFinished(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnName(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnDescription(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnPhysicalSize(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 3)
                Events?.OnMode(this, new ZwlrOutputModeV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 4)
                Events?.OnEnabled(this, arguments[0].Int32);
            if (opcode == 5)
                Events?.OnCurrentMode(this, WlProxy.FromNative<NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1>(arguments[0].IntPtr));
            if (opcode == 6)
                Events?.OnPosition(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 7)
                Events?.OnTransform(this, (NWayland.Protocols.Wayland.WlOutput.TransformEnum)arguments[0].Int32);
            if (opcode == 8)
                Events?.OnScale(this, arguments[0].Int32);
            if (opcode == 9)
                Events?.OnFinished(this);
        }

        class ProxyFactory : IBindFactory<ZwlrOutputHeadV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1.WlInterface);
            }

            public ZwlrOutputHeadV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrOutputHeadV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrOutputHeadV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_output_head_v1";
        public const int InterfaceVersion = 1;

        public ZwlrOutputHeadV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object describes an output mode.
    /// 
    /// Some heads don't support output modes, in which case modes won't be
    /// advertised.
    /// 
    /// Properties sent via this interface are applied atomically via the
    /// wlr_output_manager.done event. No guarantees are made regarding the order
    /// in which properties are sent.
    /// </summary>
    public sealed unsafe partial class ZwlrOutputModeV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrOutputModeV1()
        {
            WlInterface.Init("zwlr_output_mode_v1", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("size", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("refresh", "i", new WlInterface*[] { null }),
                WlMessage.Create("preferred", "", new WlInterface*[] { }),
                WlMessage.Create("finished", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1.WlInterface);
        }

        public interface IEvents
        {
            void OnSize(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 eventSender, int @width, int @height);
            void OnRefresh(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 eventSender, int @refresh);
            void OnPreferred(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 eventSender);
            void OnFinished(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSize(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 1)
                Events?.OnRefresh(this, arguments[0].Int32);
            if (opcode == 2)
                Events?.OnPreferred(this);
            if (opcode == 3)
                Events?.OnFinished(this);
        }

        class ProxyFactory : IBindFactory<ZwlrOutputModeV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1.WlInterface);
            }

            public ZwlrOutputModeV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrOutputModeV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrOutputModeV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_output_mode_v1";
        public const int InterfaceVersion = 1;

        public ZwlrOutputModeV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object is used by the client to describe a full output configuration.
    /// 
    /// First, the client needs to setup the output configuration. Each head can
    /// be either enabled (and configured) or disabled. It is a protocol error to
    /// send two enable_head or disable_head requests with the same head. It is a
    /// protocol error to omit a head in a configuration.
    /// 
    /// Then, the client can apply or test the configuration. The compositor will
    /// then reply with a succeeded, failed or cancelled event. Finally the client
    /// should destroy the configuration object.
    /// </summary>
    public sealed unsafe partial class ZwlrOutputConfigurationV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrOutputConfigurationV1()
        {
            WlInterface.Init("zwlr_output_configuration_v1", 1, new WlMessage[] {
                WlMessage.Create("enable_head", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1.WlInterface) }),
                WlMessage.Create("disable_head", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1.WlInterface) }),
                WlMessage.Create("apply", "", new WlInterface*[] { }),
                WlMessage.Create("test", "", new WlInterface*[] { }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("succeeded", "", new WlInterface*[] { }),
                WlMessage.Create("failed", "", new WlInterface*[] { }),
                WlMessage.Create("cancelled", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1.WlInterface);
        }

        /// <summary>
        /// Enable a head. This request creates a head configuration object that can
        /// be used to change the head's properties.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1 EnableHead(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 @head)
        {
            if (@head == null)
                throw new System.ArgumentNullException("head");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @head
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1(__ret, Version, Display);
        }

        /// <summary>
        /// Disable a head.
        /// </summary>
        public void DisableHead(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputHeadV1 @head)
        {
            if (@head == null)
                throw new System.ArgumentNullException("head");
            WlArgument* __args = stackalloc WlArgument[] {
                @head
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Apply the new output configuration.
        /// 
        /// In case the configuration is successfully applied, there is no guarantee
        /// that the new output state matches completely the requested
        /// configuration. For instance, a compositor might round the scale if it
        /// doesn't support fractional scaling.
        /// 
        /// After this request has been sent, the compositor must respond with an
        /// succeeded, failed or cancelled event. Sending a request that isn't the
        /// destructor is a protocol error.
        /// </summary>
        public void Apply()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Test the new output configuration. The configuration won't be applied,
        /// but will only be validated.
        /// 
        /// Even if the compositor succeeds to test a configuration, applying it may
        /// fail.
        /// 
        /// After this request has been sent, the compositor must respond with an
        /// succeeded, failed or cancelled event. Sending a request that isn't the
        /// destructor is a protocol error.
        /// </summary>
        public void Test()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        public interface IEvents
        {
            void OnSucceeded(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1 eventSender);
            void OnFailed(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1 eventSender);
            void OnCancelled(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSucceeded(this);
            if (opcode == 1)
                Events?.OnFailed(this);
            if (opcode == 2)
                Events?.OnCancelled(this);
        }

        public enum ErrorEnum
        {
            /// <summary>head has been configured twice</summary>
            AlreadyConfiguredHead = 1,
            /// <summary>head has not been configured</summary>
            UnconfiguredHead = 2,
            /// <summary>request sent after configuration has been applied or tested</summary>
            AlreadyUsed = 3
        }

        class ProxyFactory : IBindFactory<ZwlrOutputConfigurationV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationV1.WlInterface);
            }

            public ZwlrOutputConfigurationV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrOutputConfigurationV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrOutputConfigurationV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_output_configuration_v1";
        public const int InterfaceVersion = 1;

        public ZwlrOutputConfigurationV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This object is used by the client to update a single head's configuration.
    /// 
    /// It is a protocol error to set the same property twice.
    /// </summary>
    public sealed unsafe partial class ZwlrOutputConfigurationHeadV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrOutputConfigurationHeadV1()
        {
            WlInterface.Init("zwlr_output_configuration_head_v1", 1, new WlMessage[] {
                WlMessage.Create("set_mode", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1.WlInterface) }),
                WlMessage.Create("set_custom_mode", "iii", new WlInterface*[] { null, null, null }),
                WlMessage.Create("set_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("set_transform", "i", new WlInterface*[] { null }),
                WlMessage.Create("set_scale", "f", new WlInterface*[] { null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1.WlInterface);
        }

        /// <summary>
        /// This request sets the head's mode.
        /// </summary>
        public void SetMode(NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputModeV1 @mode)
        {
            if (@mode == null)
                throw new System.ArgumentNullException("mode");
            WlArgument* __args = stackalloc WlArgument[] {
                @mode
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This request assigns a custom mode to the head. The size is given in
        /// physical hardware units of the output device. If set to zero, the
        /// refresh rate is unspecified.
        /// 
        /// It is a protocol error to set both a mode and a custom mode.
        /// </summary>
        public void SetCustomMode(int @width, int @height, int @refresh)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height,
                @refresh
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This request sets the head's position in the global compositor space.
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
        /// This request sets the head's transform.
        /// </summary>
        public void SetTransform(NWayland.Protocols.Wayland.WlOutput.TransformEnum @transform)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (int)@transform
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// This request sets the head's scale.
        /// </summary>
        public void SetScale(int @scale)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @scale
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
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
            /// <summary>property has already been set</summary>
            AlreadySet = 1,
            /// <summary>mode doesn't belong to head</summary>
            InvalidMode = 2,
            /// <summary>mode is invalid</summary>
            InvalidCustomMode = 3,
            /// <summary>transform value outside enum</summary>
            InvalidTransform = 4,
            /// <summary>scale negative or zero</summary>
            InvalidScale = 5
        }

        class ProxyFactory : IBindFactory<ZwlrOutputConfigurationHeadV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrOutputManagementUnstableV1.ZwlrOutputConfigurationHeadV1.WlInterface);
            }

            public ZwlrOutputConfigurationHeadV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrOutputConfigurationHeadV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrOutputConfigurationHeadV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_output_configuration_head_v1";
        public const int InterfaceVersion = 1;

        public ZwlrOutputConfigurationHeadV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}