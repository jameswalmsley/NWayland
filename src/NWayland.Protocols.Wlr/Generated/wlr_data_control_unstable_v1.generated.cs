using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Wlr.WlrDataControlUnstableV1
{
    /// <summary>
    /// This interface is a manager that allows creating per-seat data device
    /// controls.
    /// </summary>
    public sealed unsafe partial class ZwlrDataControlManagerV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrDataControlManagerV1()
        {
            WlInterface.Init("zwlr_data_control_manager_v1", 2, new WlMessage[] {
                WlMessage.Create("create_data_source", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface) }),
                WlMessage.Create("get_data_device", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlManagerV1.WlInterface);
        }

        /// <summary>
        /// Create a new data source.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1 CreateDataSource()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1(__ret, Version, Display);
        }

        /// <summary>
        /// Create a data device that can be used to manage a seat's selection.
        /// </summary>
        public NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1 GetDataDevice(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1(__ret, Version, Display);
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

        class ProxyFactory : IBindFactory<ZwlrDataControlManagerV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlManagerV1.WlInterface);
            }

            public ZwlrDataControlManagerV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrDataControlManagerV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrDataControlManagerV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_data_control_manager_v1";
        public const int InterfaceVersion = 2;

        public ZwlrDataControlManagerV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// This interface allows a client to manage a seat's selection.
    /// 
    /// When the seat is destroyed, this object becomes inert.
    /// </summary>
    public sealed unsafe partial class ZwlrDataControlDeviceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrDataControlDeviceV1()
        {
            WlInterface.Init("zwlr_data_control_device_v1", 2, new WlMessage[] {
                WlMessage.Create("set_selection", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface) }),
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_primary_selection", "2?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("data_offer", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1.WlInterface) }),
                WlMessage.Create("selection", "?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1.WlInterface) }),
                WlMessage.Create("finished", "", new WlInterface*[] { }),
                WlMessage.Create("primary_selection", "2?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1.WlInterface);
        }

        /// <summary>
        /// This request asks the compositor to set the selection to the data from
        /// the source on behalf of the client.
        /// 
        /// The given source may not be used in any further set_selection or
        /// set_primary_selection requests. Attempting to use a previously used
        /// source is a protocol error.
        /// 
        /// To unset the selection, set the source to NULL.
        /// </summary>
        public void SetSelection(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1 @source)
        {
            if (@source == null)
                throw new System.ArgumentNullException("source");
            WlArgument* __args = stackalloc WlArgument[] {
                @source
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This request asks the compositor to set the primary selection to the
        /// data from the source on behalf of the client.
        /// 
        /// The given source may not be used in any further set_selection or
        /// set_primary_selection requests. Attempting to use a previously used
        /// source is a protocol error.
        /// 
        /// To unset the primary selection, set the source to NULL.
        /// 
        /// The compositor will ignore this request if it does not support primary
        /// selection.
        /// </summary>
        public void SetPrimarySelection(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1 @source)
        {
            if (@source == null)
                throw new System.ArgumentNullException("source");
            if (Version < 2)
                throw new System.InvalidOperationException("Request set_primary_selection is only supported since version 2");
            WlArgument* __args = stackalloc WlArgument[] {
                @source
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public interface IEvents
        {
            void OnDataOffer(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1 eventSender, ZwlrDataControlOfferV1 @id);
            void OnSelection(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1 eventSender, NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1 @id);
            void OnFinished(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1 eventSender);
            void OnPrimarySelection(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1 eventSender, NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1 @id);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDataOffer(this, new ZwlrDataControlOfferV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnSelection(this, WlProxy.FromNative<NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1>(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnFinished(this);
            if (opcode == 3)
                Events?.OnPrimarySelection(this, WlProxy.FromNative<NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1>(arguments[0].IntPtr));
        }

        public enum ErrorEnum
        {
            /// <summary>source given to set_selection or set_primary_selection was already used before</summary>
            UsedSource = 1
        }

        class ProxyFactory : IBindFactory<ZwlrDataControlDeviceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlDeviceV1.WlInterface);
            }

            public ZwlrDataControlDeviceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrDataControlDeviceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrDataControlDeviceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_data_control_device_v1";
        public const int InterfaceVersion = 2;

        public ZwlrDataControlDeviceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// The wlr_data_control_source object is the source side of a
    /// wlr_data_control_offer. It is created by the source client in a data
    /// transfer and provides a way to describe the offered data and a way to
    /// respond to requests to transfer the data.
    /// </summary>
    public sealed unsafe partial class ZwlrDataControlSourceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrDataControlSourceV1()
        {
            WlInterface.Init("zwlr_data_control_source_v1", 1, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("send", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("cancelled", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface);
        }

        /// <summary>
        /// This request adds a MIME type to the set of MIME types advertised to
        /// targets. Can be called several times to offer multiple types.
        /// 
        /// Calling this after wlr_data_control_device.set_selection is a protocol
        /// error.
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
            void OnSend(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1 eventSender, System.String @mimeType, int @fd);
            void OnCancelled(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSend(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].Int32);
            if (opcode == 1)
                Events?.OnCancelled(this);
        }

        public enum ErrorEnum
        {
            /// <summary>offer sent after wlr_data_control_device.set_selection</summary>
            InvalidOffer = 1
        }

        class ProxyFactory : IBindFactory<ZwlrDataControlSourceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlSourceV1.WlInterface);
            }

            public ZwlrDataControlSourceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrDataControlSourceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrDataControlSourceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_data_control_source_v1";
        public const int InterfaceVersion = 1;

        public ZwlrDataControlSourceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A wlr_data_control_offer represents a piece of data offered for transfer
    /// by another client (the source client). The offer describes the different
    /// MIME types that the data can be converted to and provides the mechanism
    /// for transferring the data directly from the source client.
    /// </summary>
    public sealed unsafe partial class ZwlrDataControlOfferV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwlrDataControlOfferV1()
        {
            WlInterface.Init("zwlr_data_control_offer_v1", 1, new WlMessage[] {
                WlMessage.Create("receive", "sh", new WlInterface*[] { null, null }),
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("offer", "s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1.WlInterface);
        }

        /// <summary>
        /// To transfer the offered data, the client issues this request and
        /// indicates the MIME type it wants to receive. The transfer happens
        /// through the passed file descriptor (typically created with the pipe
        /// system call). The source client writes the data in the MIME type
        /// representation requested and then closes the file descriptor.
        /// 
        /// The receiving client reads from the read end of the pipe until EOF and
        /// then closes its end, at which point the transfer is complete.
        /// 
        /// This request may happen multiple times for different MIME types.
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
            void OnOffer(NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1 eventSender, System.String @mimeType);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnOffer(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZwlrDataControlOfferV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wlr.WlrDataControlUnstableV1.ZwlrDataControlOfferV1.WlInterface);
            }

            public ZwlrDataControlOfferV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwlrDataControlOfferV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwlrDataControlOfferV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwlr_data_control_offer_v1";
        public const int InterfaceVersion = 1;

        public ZwlrDataControlOfferV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}