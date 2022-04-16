using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Outputmanagement
{
    /// <summary>
    /// This interface enables clients to set properties of output devices for screen
    /// configuration purposes via the server. To this end output devices are referenced
    /// by global org_kde_kwin_outputdevice objects.
    /// 
    /// outputmanagement (wl_global)
    /// --------------------------
    /// request:
    /// * create_configuration -&gt; outputconfiguration (wl_resource)
    /// 
    /// outputconfiguration (wl_resource)
    /// --------------------------
    /// requests:
    /// * enable(outputdevice, bool)
    /// * mode(outputdevice, mode_id)
    /// * transformation(outputdevice, flag)
    /// * position(outputdevice, x, y)
    /// * apply
    /// 
    /// events:
    /// * applied
    /// * failed
    /// 
    /// The server registers one outputmanagement object as a global object. In order
    /// to configure outputs a client requests create_configuration, which provides a
    /// resource referencing an outputconfiguration for one-time configuration. That
    /// way the server knows which requests belong together and can group them by that.
    /// 
    /// On the outputconfiguration object the client calls for each output whether the
    /// output should be enabled, which mode should be set (by referencing the mode from
    /// the list of announced modes) and the output's global position. Once all outputs
    /// are configured that way, the client calls apply.
    /// At that point and not earlier the server should try to apply the configuration.
    /// If this succeeds the server emits the applied signal, otherwise the failed
    /// signal, such that the configuring client is noticed about the success of its
    /// configuration request.
    /// 
    /// Through this design the interface enables atomic output configuration changes if
    /// internally supported by the server.
    /// 
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinOutputmanagement : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinOutputmanagement()
        {
            WlInterface.Init("org_kde_kwin_outputmanagement", 2, new WlMessage[] {
                WlMessage.Create("create_configuration", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputmanagement.WlInterface);
        }

        /// <summary>
        /// Request an outputconfiguration object through which the client can configure
        /// output devices.
        /// </summary>
        public NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration CreateConfiguration()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinOutputmanagement>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputmanagement.WlInterface);
            }

            public OrgKdeKwinOutputmanagement Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinOutputmanagement(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinOutputmanagement> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_outputmanagement";
        public const int InterfaceVersion = 2;

        public OrgKdeKwinOutputmanagement(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// outputconfiguration is a client-specific resource that can be used to ask
    /// the server to apply changes to available output devices.
    /// 
    /// The client receives a list of output devices from the registry. When it wants
    /// to apply new settings, it creates a configuration object from the
    /// outputmanagement global, writes changes through this object's enable, scale,
    /// transform and mode calls. It then asks the server to apply these settings in
    /// an atomic fashion, for example through Linux' DRM interface.
    /// 
    /// The server signals back whether the new settings have applied successfully
    /// or failed to apply. outputdevice objects are updated after the changes have been
    /// applied to the hardware and before the server side sends the applied event.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinOutputconfiguration : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinOutputconfiguration()
        {
            WlInterface.Init("org_kde_kwin_outputconfiguration", 2, new WlMessage[] {
                WlMessage.Create("enable", "oi", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null }),
                WlMessage.Create("mode", "oi", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null }),
                WlMessage.Create("transform", "oi", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null }),
                WlMessage.Create("position", "oii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null, null }),
                WlMessage.Create("scale", "oi", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null }),
                WlMessage.Create("apply", "", new WlInterface*[] { }),
                WlMessage.Create("scalef", "2of", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null }),
                WlMessage.Create("colorcurves", "2oaaa", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface), null, null, null }),
                WlMessage.Create("destroy", "2", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("applied", "", new WlInterface*[] { }),
                WlMessage.Create("failed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration.WlInterface);
        }

        /// <summary>
        /// Mark the output as enabled or disabled.
        /// </summary>
        public void Enable(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @enable)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @enable
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Sets the mode for a given output by its mode size (width and height) and refresh rate.
        /// </summary>
        public void Mode(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @modeId)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @modeId
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Sets the transformation for a given output.
        /// </summary>
        public void Transform(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @transform)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @transform
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Sets the position for this output device. (x,y) describe the top-left corner
        /// of the output in global space, whereby the origin (0,0) of the global space
        /// has to be aligned with the top-left corner of the most left and in case this
        /// does not define a single one the top output.
        /// 
        /// There may be no gaps or overlaps between outputs, i.e. the outputs are
        /// stacked horizontally, vertically, or both on each other.
        /// </summary>
        public void Position(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @x, int @y)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Sets the scaling factor for this output device.
        /// </summary>
        public void Scale(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @scale)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @scale
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Asks the server to apply property changes requested through this outputconfiguration
        /// object to all outputs on the server side.
        /// </summary>
        public void Apply()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Sets the scaling factor for this output device.
        /// Sending both scale and scalef is undefined.
        /// </summary>
        public void Scalef(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, int @scale)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            if (Version < 2)
                throw new System.InvalidOperationException("Request scalef is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @outputdevice,
                @scale
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Set color curves of output devices through RGB color ramps. Allows color
        /// correction of output device from user space.
        /// 
        /// These are the raw values. A compositor might opt to adjust these values
        /// internally, for example to shift color temperature at night.
        /// </summary>
        public void Colorcurves(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice @outputdevice, ReadOnlySpan<byte> @red, ReadOnlySpan<byte> @green, ReadOnlySpan<byte> @blue)
        {
            if (@outputdevice == null)
                throw new System.ArgumentNullException("outputdevice");
            if (Version < 2)
                throw new System.InvalidOperationException("Request colorcurves is only supported since version 2");
            fixed (byte* __pointer__red = @red)
            fixed (byte* __pointer__green = @green)
            fixed (byte* __pointer__blue = @blue)
            {
                var __marshalled__red = NWayland.Interop.WlArray.FromPointer(__pointer__red, @red.Length);
                var __marshalled__green = NWayland.Interop.WlArray.FromPointer(__pointer__green, @green.Length);
                var __marshalled__blue = NWayland.Interop.WlArray.FromPointer(__pointer__blue, @blue.Length);
                WlArgument* __args = stackalloc WlArgument[] {
                    @outputdevice,
                    &__marshalled__red,
                    &__marshalled__green,
                    &__marshalled__blue
                };
                LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
            }
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 2)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public interface IEvents
        {
            void OnApplied(NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration eventSender);
            void OnFailed(NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnApplied(this);
            if (opcode == 1)
                Events?.OnFailed(this);
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinOutputconfiguration>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Outputmanagement.OrgKdeKwinOutputconfiguration.WlInterface);
            }

            public OrgKdeKwinOutputconfiguration Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinOutputconfiguration(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinOutputconfiguration> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_outputconfiguration";
        public const int InterfaceVersion = 2;

        public OrgKdeKwinOutputconfiguration(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}