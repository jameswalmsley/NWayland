using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XdgForeignUnstableV1
{
    /// <summary>
    /// A global interface used for exporting surfaces that can later be imported
    /// using xdg_importer.
    /// </summary>
    public sealed unsafe partial class ZxdgExporterV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgExporterV1()
        {
            WlInterface.Init("zxdg_exporter_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("export", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExporterV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The export request exports the passed surface so that it can later be
        /// imported via xdg_importer. When called, a new xdg_exported object will
        /// be created and xdg_exported.handle will be sent immediately. See the
        /// corresponding interface and event for details.
        /// 
        /// A surface may be exported multiple times, and each exported handle may
        /// be used to create a xdg_imported multiple times. Only xdg_surface
        /// surfaces may be exported.
        /// </summary>
        public NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1 Export(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgExporterV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExporterV1.WlInterface);
            }

            public ZxdgExporterV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgExporterV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgExporterV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_exporter_v1";
        public const int InterfaceVersion = 1;

        public ZxdgExporterV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A global interface used for importing surfaces exported by xdg_exporter.
    /// With this interface, a client can create a reference to a surface of
    /// another client.
    /// </summary>
    public sealed unsafe partial class ZxdgImporterV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgImporterV1()
        {
            WlInterface.Init("zxdg_importer_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("import", "ns", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1.WlInterface), null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImporterV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The import request imports a surface from any client given a handle
        /// retrieved by exporting said surface using xdg_exporter.export. When
        /// called, a new xdg_imported object will be created. This new object
        /// represents the imported surface, and the importing client can
        /// manipulate its relationship using it. See xdg_imported for details.
        /// </summary>
        public NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1 Import(System.String @handle)
        {
            if (@handle == null)
                throw new System.ArgumentNullException("handle");
            using var __marshalled__handle = new NWayland.Interop.NWaylandMarshalledString(@handle);
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                __marshalled__handle
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgImporterV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImporterV1.WlInterface);
            }

            public ZxdgImporterV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgImporterV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgImporterV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_importer_v1";
        public const int InterfaceVersion = 1;

        public ZxdgImporterV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A xdg_exported object represents an exported reference to a surface. The
    /// exported surface may be referenced as long as the xdg_exported object not
    /// destroyed. Destroying the xdg_exported invalidates any relationship the
    /// importer may have established using xdg_imported.
    /// </summary>
    public sealed unsafe partial class ZxdgExportedV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgExportedV1()
        {
            WlInterface.Init("zxdg_exported_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("handle", "s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnHandle(NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1 eventSender, System.String @handle);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnHandle(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZxdgExportedV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgExportedV1.WlInterface);
            }

            public ZxdgExportedV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgExportedV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgExportedV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_exported_v1";
        public const int InterfaceVersion = 1;

        public ZxdgExportedV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A xdg_imported object represents an imported reference to surface exported
    /// by some client. A client can use this interface to manipulate
    /// relationships between its own surfaces and the imported surface.
    /// </summary>
    public sealed unsafe partial class ZxdgImportedV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgImportedV1()
        {
            WlInterface.Init("zxdg_imported_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_parent_of", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("destroyed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the imported surface as the parent of some surface of the client.
        /// The passed surface must be a toplevel xdg_surface. Calling this function
        /// sets up a surface to surface relation with the same stacking and positioning
        /// semantics as xdg_surface.set_parent.
        /// </summary>
        public void SetParentOf(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
            void OnDestroyed(NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDestroyed(this);
        }

        class ProxyFactory : IBindFactory<ZxdgImportedV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV1.ZxdgImportedV1.WlInterface);
            }

            public ZxdgImportedV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgImportedV1(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgImportedV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_imported_v1";
        public const int InterfaceVersion = 1;

        public ZxdgImportedV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}