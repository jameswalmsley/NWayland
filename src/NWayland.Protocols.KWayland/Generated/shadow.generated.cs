using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Shadow
{
    public sealed unsafe partial class OrgKdeKwinShadowManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinShadowManager()
        {
            WlInterface.Init("org_kde_kwin_shadow_manager", 2, new WlMessage[] {
                WlMessage.Create("create", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("unset", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("destroy", "2", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadowManager.WlInterface);
        }

        public NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow Create(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow(__ret, Version, Display);
        }

        public void Unset(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 2)
                return;
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

        class ProxyFactory : IBindFactory<OrgKdeKwinShadowManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadowManager.WlInterface);
            }

            public OrgKdeKwinShadowManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinShadowManager(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinShadowManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_shadow_manager";
        public const int InterfaceVersion = 2;

        public OrgKdeKwinShadowManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class OrgKdeKwinShadow : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdeKwinShadow()
        {
            WlInterface.Init("org_kde_kwin_shadow", 2, new WlMessage[] {
                WlMessage.Create("commit", "", new WlInterface*[] { }),
                WlMessage.Create("attach_left", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_top_left", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_top", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_top_right", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_right", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_bottom_right", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_bottom", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("attach_bottom_left", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlBuffer.WlInterface) }),
                WlMessage.Create("set_left_offset", "f", new WlInterface*[] { null }),
                WlMessage.Create("set_top_offset", "f", new WlInterface*[] { null }),
                WlMessage.Create("set_right_offset", "f", new WlInterface*[] { null }),
                WlMessage.Create("set_bottom_offset", "f", new WlInterface*[] { null }),
                WlMessage.Create("destroy", "2", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow.WlInterface);
        }

        public void Commit()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public void AttachLeft(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public void AttachTopLeft(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        public void AttachTop(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        public void AttachTopRight(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        public void AttachRight(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        public void AttachBottomRight(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        public void AttachBottom(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        public void AttachBottomLeft(NWayland.Protocols.Wayland.WlBuffer @buffer)
        {
            if (@buffer == null)
                throw new System.ArgumentNullException("buffer");
            WlArgument* __args = stackalloc WlArgument[] {
                @buffer
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public void SetLeftOffset(int @offset)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @offset
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public void SetTopOffset(int @offset)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @offset
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        public void SetRightOffset(int @offset)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @offset
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 11, __args);
        }

        public void SetBottomOffset(int @offset)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @offset
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 12, __args);
        }

        protected sealed override void CallWaylandDestructor()
        {
            if (Version < 2)
                return;
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 13, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<OrgKdeKwinShadow>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Shadow.OrgKdeKwinShadow.WlInterface);
            }

            public OrgKdeKwinShadow Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdeKwinShadow(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdeKwinShadow> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_kwin_shadow";
        public const int InterfaceVersion = 2;

        public OrgKdeKwinShadow(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}