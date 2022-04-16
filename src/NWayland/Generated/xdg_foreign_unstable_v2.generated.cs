using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.XdgForeignUnstableV2
{
    /// <summary>
    /// A global interface used for exporting surfaces that can later be imported
    /// using xdg_importer.
    /// </summary>
    public sealed unsafe partial class ZxdgExporterV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgExporterV2()
        {
            WlInterface.Init("zxdg_exporter_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("export_toplevel", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExporterV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The export_toplevel request exports the passed surface so that it can later be
        /// imported via xdg_importer. When called, a new xdg_exported object will
        /// be created and xdg_exported.handle will be sent immediately. See the
        /// corresponding interface and event for details.
        /// 
        /// A surface may be exported multiple times, and each exported handle may
        /// be used to create a xdg_imported multiple times. Only xdg_toplevel
        /// equivalent surfaces may be exported.
        /// </summary>
        public NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2 ExportToplevel(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgExporterV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExporterV2.WlInterface);
            }

            public ZxdgExporterV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgExporterV2(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgExporterV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_exporter_v2";
        public const int InterfaceVersion = 1;

        public ZxdgExporterV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A global interface used for importing surfaces exported by xdg_exporter.
    /// With this interface, a client can create a reference to a surface of
    /// another client.
    /// </summary>
    public sealed unsafe partial class ZxdgImporterV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgImporterV2()
        {
            WlInterface.Init("zxdg_importer_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("import_toplevel", "ns", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2.WlInterface), null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImporterV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// The import_toplevel request imports a surface from any client given a handle
        /// retrieved by exporting said surface using xdg_exporter.export_toplevel.
        /// When called, a new xdg_imported object will be created. This new object
        /// represents the imported surface, and the importing client can
        /// manipulate its relationship using it. See xdg_imported for details.
        /// </summary>
        public NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2 ImportToplevel(System.String @handle)
        {
            if (@handle == null)
                throw new System.ArgumentNullException("handle");
            using var __marshalled__handle = new NWayland.Interop.NWaylandMarshalledString(@handle);
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                __marshalled__handle
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZxdgImporterV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImporterV2.WlInterface);
            }

            public ZxdgImporterV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgImporterV2(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgImporterV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_importer_v2";
        public const int InterfaceVersion = 1;

        public ZxdgImporterV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A xdg_exported object represents an exported reference to a surface. The
    /// exported surface may be referenced as long as the xdg_exported object not
    /// destroyed. Destroying the xdg_exported invalidates any relationship the
    /// importer may have established using xdg_imported.
    /// </summary>
    public sealed unsafe partial class ZxdgExportedV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgExportedV2()
        {
            WlInterface.Init("zxdg_exported_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("handle", "s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        public interface IEvents
        {
            void OnHandle(NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2 eventSender, System.String @handle);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnHandle(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZxdgExportedV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgExportedV2.WlInterface);
            }

            public ZxdgExportedV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgExportedV2(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgExportedV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_exported_v2";
        public const int InterfaceVersion = 1;

        public ZxdgExportedV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A xdg_imported object represents an imported reference to surface exported
    /// by some client. A client can use this interface to manipulate
    /// relationships between its own surfaces and the imported surface.
    /// </summary>
    public sealed unsafe partial class ZxdgImportedV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZxdgImportedV2()
        {
            WlInterface.Init("zxdg_imported_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_parent_of", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] {
                WlMessage.Create("destroyed", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the imported surface as the parent of some surface of the client.
        /// The passed surface must be a xdg_toplevel equivalent. Calling this
        /// function sets up a surface to surface relation with the same stacking
        /// and positioning semantics as xdg_toplevel.set_parent.
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
            void OnDestroyed(NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2 eventSender);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnDestroyed(this);
        }

        class ProxyFactory : IBindFactory<ZxdgImportedV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.XdgForeignUnstableV2.ZxdgImportedV2.WlInterface);
            }

            public ZxdgImportedV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZxdgImportedV2(handle, version, display);
            }
        }

        public static IBindFactory<ZxdgImportedV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zxdg_imported_v2";
        public const int InterfaceVersion = 1;

        public ZxdgImportedV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}