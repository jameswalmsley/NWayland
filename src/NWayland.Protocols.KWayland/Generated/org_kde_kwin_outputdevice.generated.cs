using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice
{
    /// <summary>
    /// An outputdevice describes a display device available to the compositor.
    /// outputdevice is similar to wl_output, but focuses on output
    /// configuration management.
    /// 
    /// A client can query all global outputdevice objects to enlist all
    /// available display devices, even those that may currently not be
    /// represented by the compositor as a wl_output.
    /// 
    /// The client sends configuration changes to the server through the
    /// outputconfiguration interface, and the server applies the configuration
    /// changes to the hardware and signals changes to the outputdevices
    /// accordingly.
    /// 
    /// This object is published as global during start up for every available
    /// display devices, or when one later becomes available, for example by
    /// being hotplugged via a physical connector.
    /// </summary>
    public sealed unsafe partial class OrgKdeKwinOutputdevice : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinOutputdevice()
        {
            WlInterface.Init("org_kde_kwin_outputdevice", 2, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("geometry", "iiiiissi", new WlInterface*[] { null, null, null, null, null, null, null, null }),
                WlMessage.Create("mode", "uiiii", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("done", "", new WlInterface*[] { }),
                WlMessage.Create("scale", "i", new WlInterface*[] { null }),
                WlMessage.Create("edid", "s", new WlInterface*[] { null }),
                WlMessage.Create("enabled", "i", new WlInterface*[] { null }),
                WlMessage.Create("uuid", "s", new WlInterface*[] { null }),
                WlMessage.Create("scalef", "2f", new WlInterface*[] { null }),
                WlMessage.Create("colorcurves", "2aaa", new WlInterface*[] { null, null, null }),
                WlMessage.Create("serial_number", "2s", new WlInterface*[] { null }),
                WlMessage.Create("eisa_id", "2s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface);
        }

        public interface IEvents
        {
            void OnGeometry(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, int @x, int @y, int @physicalWidth, int @physicalHeight, int @subpixel, System.String @make, System.String @model, int @transform);
            void OnMode(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, uint @flags, int @width, int @height, int @refresh, int @modeId);
            void OnDone(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender);
            void OnScale(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, int @factor);
            void OnEdid(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, System.String @raw);
            void OnEnabled(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, int @enabled);
            void OnUuid(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, System.String @uuid);
            void OnScalef(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, int @factor);
            void OnColorcurves(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, ReadOnlySpan<byte> @red, ReadOnlySpan<byte> @green, ReadOnlySpan<byte> @blue);
            void OnSerialNumber(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, System.String @serialNumber);
            void OnEisaId(NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice eventSender, System.String @eisaId);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGeometry(this, arguments[0].Int32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32, arguments[4].Int32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[5].IntPtr), System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[6].IntPtr), arguments[7].Int32);
            if (opcode == 1)
                Events?.OnMode(this, arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32, arguments[4].Int32);
            if (opcode == 2)
                Events?.OnDone(this);
            if (opcode == 3)
                Events?.OnScale(this, arguments[0].Int32);
            if (opcode == 4)
                Events?.OnEdid(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 5)
                Events?.OnEnabled(this, arguments[0].Int32);
            if (opcode == 6)
                Events?.OnUuid(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 7)
                Events?.OnScalef(this, arguments[0].Int32);
            if (opcode == 8)
                Events?.OnColorcurves(this, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[0].IntPtr), NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[1].IntPtr), NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[2].IntPtr));
            if (opcode == 9)
                Events?.OnSerialNumber(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 10)
                Events?.OnEisaId(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        /// <summary>
        /// This enumeration describes how the physical pixels on an output are
        /// laid out.
        /// </summary>
        public enum SubpixelEnum
        {
            Unknown = 0,
            None = 1,
            HorizontalRgb = 2,
            HorizontalBgr = 3,
            VerticalRgb = 4,
            VerticalBgr = 5
        }

        /// <summary>
        /// This describes the transform, that a compositor will apply to a
        /// surface to compensate for the rotation or mirroring of an
        /// output device.
        /// 
        /// The flipped values correspond to an initial flip around a
        /// vertical axis followed by rotation.
        /// 
        /// The purpose is mainly to allow clients to render accordingly and
        /// tell the compositor, so that for fullscreen surfaces, the
        /// compositor is still able to scan out directly client surfaces.
        /// </summary>
        public enum TransformEnum
        {
            Normal = 0,
            k_90 = 1,
            k_180 = 2,
            k_270 = 3,
            Flipped = 4,
            Flipped90 = 5,
            Flipped180 = 6,
            Flipped270 = 7
        }

        /// <summary>
        /// These flags describe properties of an output mode. They are
        /// used in the flags bitfield of the mode event.
        /// </summary>
        public enum ModeEnum
        {
            /// <summary>indicates this is the current mode</summary>
            Current = 0x1,
            /// <summary>indicates this is the preferred mode</summary>
            Preferred = 0x2
        }

        /// <summary>
        /// Describes whether a device is enabled, i.e. device is used to
        /// display content by the compositor. This wraps a boolean around
        /// an int to avoid a boolean trap.
        /// </summary>
        public enum EnablementEnum
        {
            Disabled = 0,
            Enabled = 1
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinOutputdevice>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.OrgKdeKwinOutputdevice.OrgKdeKwinOutputdevice.WlInterface);
            }

            public OrgKdeKwinOutputdevice Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinOutputdevice(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinOutputdevice> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_outputdevice";
        public const int InterfaceVersion = 2;

        public OrgKdeKwinOutputdevice(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}