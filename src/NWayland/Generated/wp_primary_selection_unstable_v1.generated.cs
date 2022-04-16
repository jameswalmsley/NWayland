using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.WpPrimarySelectionUnstableV1
{
    /// <summary>
    /// The primary selection device manager is a singleton global object that
    /// provides access to the primary selection. It allows to create
    /// wp_primary_selection_source objects, as well as retrieving the per-seat
    /// wp_primary_selection_device objects.
    /// </summary>
    public sealed unsafe partial class ZwpPrimarySelectionDeviceManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPrimarySelectionDeviceManagerV1()
        {
            WlInterface.Init("zwp_primary_selection_device_manager_v1", 1, new WlMessage[] {
                WlMessage.Create("create_source", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1.WlInterface) }),
                WlMessage.Create("get_device", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceManagerV1.WlInterface);
        }

        /// <summary>
        /// Create a new primary selection source.
        /// </summary>
        public NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1 CreateSource()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1(__ret, Version, Display);
        }

        /// <summary>
        /// Create a new data device for a given seat.
        /// </summary>
        public NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1 GetDevice(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpPrimarySelectionDeviceManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceManagerV1.WlInterface);
            }

            public ZwpPrimarySelectionDeviceManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPrimarySelectionDeviceManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPrimarySelectionDeviceManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_primary_selection_device_manager_v1";
        public const int InterfaceVersion = 1;

        public ZwpPrimarySelectionDeviceManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class ZwpPrimarySelectionDeviceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPrimarySelectionDeviceV1()
        {
            WlInterface.Init("zwp_primary_selection_device_v1", 1, new WlMessage[] {
                WlMessage.Create("set_selection", "?ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1.WlInterface), null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("data_offer", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1.WlInterface) }),
                WlMessage.Create("selection", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1.WlInterface);
        }

        /// <summary>
        /// Replaces the current selection. The previous owner of the primary
        /// selection will receive a wp_primary_selection_source.cancelled event.
        /// 
        /// To unset the selection, set the source to NULL.
        /// </summary>
        public void SetSelection(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1 @source, uint @serial)
        {
            if (@source == null)
                throw new System.ArgumentNullException("source");
            WlArgument* __args = stackalloc WlArgument[] {
                @source,
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnDataOffer(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1 eventSender, ZwpPrimarySelectionOfferV1 @offer);
            void OnSelection(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1 eventSender, NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1 @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDataOffer(this, new ZwpPrimarySelectionOfferV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnSelection(this, WlProxy.FromNative<NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1>(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZwpPrimarySelectionDeviceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionDeviceV1.WlInterface);
            }

            public ZwpPrimarySelectionDeviceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPrimarySelectionDeviceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPrimarySelectionDeviceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_primary_selection_device_v1";
        public const int InterfaceVersion = 1;

        public ZwpPrimarySelectionDeviceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A wp_primary_selection_offer represents an offer to transfer the contents
    /// of the primary selection clipboard to the client. Similar to
    /// wl_data_offer, the offer also describes the mime types that the data can
    /// be converted to and provides the mechanisms for transferring the data
    /// directly to the client.
    /// </summary>
    public sealed unsafe partial class ZwpPrimarySelectionOfferV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPrimarySelectionOfferV1()
        {
            WlInterface.Init("zwp_primary_selection_offer_v1", 1, new WlMessage[] {
                WlMessage.Create("receive", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1.WlInterface);
        }

        /// <summary>
        /// To transfer the contents of the primary selection clipboard, the client
        /// issues this request and indicates the mime type that it wants to
        /// receive. The transfer happens through the passed file descriptor
        /// (typically created with the pipe system call). The source client writes
        /// the data in the mime type representation requested and then closes the
        /// file descriptor.
        /// 
        /// The receiving client reads from the read end of the pipe until EOF and
        /// closes its end, at which point the transfer is complete.
        /// </summary>
        public void Receive(System.String @mimeType, int @fd)
        {
            if (@mimeType == null)
                throw new System.ArgumentNullException("mimeType");
            using var __marshalled__mimeType = new NWayland.Interop.NWaylandMarshalledString(@mimeType);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__mimeType,
                @fd
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnOffer(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1 eventSender, System.String @mimeType);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnOffer(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZwpPrimarySelectionOfferV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionOfferV1.WlInterface);
            }

            public ZwpPrimarySelectionOfferV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPrimarySelectionOfferV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPrimarySelectionOfferV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_primary_selection_offer_v1";
        public const int InterfaceVersion = 1;

        public ZwpPrimarySelectionOfferV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The source side of a wp_primary_selection_offer, it provides a way to
    /// describe the offered data and respond to requests to transfer the
    /// requested contents of the primary selection clipboard.
    /// </summary>
    public sealed unsafe partial class ZwpPrimarySelectionSourceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpPrimarySelectionSourceV1()
        {
            WlInterface.Init("zwp_primary_selection_source_v1", 1, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("send", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("cancelled", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1.WlInterface);
        }

        /// <summary>
        /// This request adds a mime type to the set of mime types advertised to
        /// targets. Can be called several times to offer multiple types.
        /// </summary>
        public void Offer(System.String @mimeType)
        {
            if (@mimeType == null)
                throw new System.ArgumentNullException("mimeType");
            using var __marshalled__mimeType = new NWayland.Interop.NWaylandMarshalledString(@mimeType);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__mimeType
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnSend(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1 eventSender, System.String @mimeType, int @fd);
            void OnCancelled(NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSend(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].Int32);
            if (opcode == 1)
                Events?.OnCancelled(this);
        }

        class ProxyFactory : IBindFactory<ZwpPrimarySelectionSourceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.WpPrimarySelectionUnstableV1.ZwpPrimarySelectionSourceV1.WlInterface);
            }

            public ZwpPrimarySelectionSourceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpPrimarySelectionSourceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpPrimarySelectionSourceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_primary_selection_source_v1";
        public const int InterfaceVersion = 1;

        public ZwpPrimarySelectionSourceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}