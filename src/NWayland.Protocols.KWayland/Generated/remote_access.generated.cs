using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.RemoteAccess
{
    public sealed unsafe partial class OrgKdeKwinRemoteAccessManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinRemoteAccessManager()
        {
            WlInterface.Init("org_kde_kwin_remote_access_manager", 1, new WlMessage[] {
                WlMessage.Create("get_buffer", "1ni", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer.WlInterface), null }),
                WlMessage.Create("release", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("buffer_ready", "1io", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteAccessManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer GetBuffer(int @internalBufferId)
        {
            if (Version < 1)
                throw new System.InvalidOperationException("Request get_buffer is only supported since version 1");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @internalBufferId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer(__ret, Version, Display);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnBufferReady(NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteAccessManager eventSender, int @id, NWayland.Protocols.Wayland.WlOutput @output);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnBufferReady(this, arguments[0].Int32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[1].IntPtr));
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinRemoteAccessManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteAccessManager.WlInterface);
            }

            public OrgKdeKwinRemoteAccessManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinRemoteAccessManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinRemoteAccessManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_remote_access_manager";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinRemoteAccessManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinRemoteBuffer : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinRemoteBuffer()
        {
            WlInterface.Init("org_kde_kwin_remote_buffer", 1, new WlMessage[] {
                WlMessage.Create("release", "1", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("gbm_handle", "1huuuu", new WlInterface*[] { null, null, null, null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 1)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnGbmHandle(NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer eventSender, int @fd, uint @width, uint @height, uint @stride, uint @format);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnGbmHandle(this, arguments[0].Int32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32);
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinRemoteBuffer>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.RemoteAccess.OrgKdeKwinRemoteBuffer.WlInterface);
            }

            public OrgKdeKwinRemoteBuffer Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinRemoteBuffer(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinRemoteBuffer> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_remote_buffer";
        public const int InterfaceVersion = 1;

        public OrgKdeKwinRemoteBuffer(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}