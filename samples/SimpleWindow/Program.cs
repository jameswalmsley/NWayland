using System;
using System.Collections.Generic;
using System.Linq;
using NWayland.Interop;
using NWayland.Protocols.Wayland;
using NWayland.Protocols.XdgShell;
using static SimpleWindow.LinuxUnsafeMethods;

using System.IO;
using System.IO.MemoryMappedFiles;

namespace SimpleWindow
{
    unsafe class Program
    {
        static WlBuffer create_buffer(WlShm shm, int width, int height) {
            int stride = width * 4;
            int size = stride*height;

            string name = "my_shared_mem";
            int fd = shm_open(name, FdFlags.O_RDWR | FdFlags.O_CREAT | FdFlags.O_EXCL, 0600);
            if(fd < 0) {
                Console.WriteLine("Bas shm_opem()");
            }
            shm_unlink(name);
            ftruncate(fd, (uint) size);


            var pool = shm.CreatePool((int) fd, (int) size);
            return pool.CreateBuffer(0, width, height, stride, WlShm.FormatEnum.Xrgb8888);
        }

        static void Main(string[] args)
        {
            var display = WlDisplay.Connect(null);
            var registry = display.GetRegistry();
            var registryHandler = new RegistryHandler(registry);
            registry.Events = registryHandler;
            display.Dispatch();
            display.Roundtrip();
            var globals = registryHandler.GetGlobals();


            var shm = registryHandler.Bind(WlShm.BindFactory, WlShm.InterfaceName, WlShm.InterfaceVersion);

            var buffer = create_buffer(shm, 640, 480);

            var compositor = registryHandler.Bind(WlCompositor.BindFactory, WlCompositor.InterfaceName, 4);
            
            display.Roundtrip();
            var shell = registryHandler.Bind(XdgWmBase.BindFactory, XdgWmBase.InterfaceName, 2);
            
            display.Roundtrip();
            var surface = compositor.CreateSurface();
            var shellSurface = shell.GetXdgSurface(surface);
            var toplevel = shellSurface.GetToplevel();

            var _region = compositor.CreateRegion(); 
            _region.Add(0, 0, 640, 480);

            surface.SetOpaqueRegion(_region);

            var xdgSurfaceHandler = new XdgSurfaceHandler(shellSurface);
            shellSurface.Events = xdgSurfaceHandler;

            var xdgTopLevelHandler = new XdgTopLevelHandler(toplevel);
            toplevel.Events = xdgTopLevelHandler;

            surface.Commit();
            display.Roundtrip();

            toplevel.SetTitle("Test");
            shellSurface.SetWindowGeometry(0, 0, 640, 480);
            surface.Attach(buffer, 0, 0);
            surface.Commit();
            while(true) {
                display.Dispatch();
                display.Roundtrip();
            }
        }
    }

    public class GlobalInfo
    {
        public uint Name { get; }
        public string Interface { get; }
        public uint Version { get; }

        public GlobalInfo(uint name, string @interface, uint version)
        {
            Name = name;
            Interface = @interface;
            Version = version;
        }

        public override string ToString() => $"{Interface} version {Version} at {Name}";
    }

    internal class XdgSurfaceHandler : XdgSurface.IEvents
    {
        private XdgSurface _xdg_surface;

        public XdgSurfaceHandler(XdgSurface xdg_surface)
        {
            _xdg_surface = xdg_surface;
        }

        public void OnConfigure(NWayland.Protocols.XdgShell.XdgSurface eventSender, uint @serial) {
            _xdg_surface.AckConfigure(serial);
            Console.WriteLine("Hello from AckConfiure");
        }
    }

    internal class XdgTopLevelHandler : XdgToplevel.IEvents
    {
        private XdgToplevel _top_level;

        public XdgTopLevelHandler(XdgToplevel top_level)
        {
            _top_level = top_level;
        }

        public void OnClose(XdgToplevel eventSender)
        {
            throw new NotImplementedException();
        }

        public void OnConfigure(XdgToplevel eventSender, int width, int height, ReadOnlySpan<byte> states)
        {
            throw new NotImplementedException();
        }
    }


    internal class RegistryHandler : WlRegistry.IEvents
    {
        private readonly WlRegistry _registry;

        public RegistryHandler(WlRegistry registry)
        {
            _registry = registry;
        }
        private Dictionary<uint, GlobalInfo> _globals { get; } = new Dictionary<uint, GlobalInfo>();
        public List<GlobalInfo> GetGlobals() => _globals.Values.ToList();
        public void OnGlobal(WlRegistry eventSender, uint name, string @interface, uint version)
        {
            _globals[name] = new GlobalInfo(name, @interface, version);
        }

        public void OnGlobalRemove(WlRegistry eventSender, uint name)
        {
            _globals.Remove(name);
        }

        public unsafe T Bind<T>(IBindFactory<T> factory, string iface, int? version) where T : WlProxy
        {
            var glob = GetGlobals().FirstOrDefault(g => g.Interface == iface);
            if (glob == null)
                throw new NotSupportedException($"Unable to find {iface} in the registry");

            version ??= factory.GetInterface()->Version;
            if (version > factory.GetInterface()->Version)
                throw new ArgumentException($"Version {version} is not supported");
            
            if (glob.Version < version)
                throw new NotSupportedException(
                    $"Compositor doesn't support {version} of {iface}, only {glob.Version} is supported");
            
            return _registry.Bind(glob.Name, factory, version.Value);
        }
    }
}
