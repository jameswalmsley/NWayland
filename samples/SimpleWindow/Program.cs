using System;
using System.Collections.Generic;
using System.Linq;
using NWayland.Interop;
using NWayland.Protocols.Wayland;
using NWayland.Protocols.XdgShell;
using NWayland.OpenGL;
using NWayland.OpenGL.EGL;
using static NWayland.OpenGL.GlConsts;
using static NWayland.OpenGL.EGL.EglConsts;
using static NWayland.OpenGL.EGL.OpenGLMethods;
using static SimpleWindow.LinuxUnsafeMethods;

namespace SimpleWindow
{
    unsafe class Program
    {
        static WlBuffer create_buffer(WlShm shm, int width, int height)
        {
            int stride = width * 4;
            int size = stride * height;

            string name = "my_shared_mem";
            int fd = shm_open(name, FdFlags.O_RDWR | FdFlags.O_CREAT | FdFlags.O_EXCL, 0600);
            if (fd < 0)
            {
                Console.WriteLine("Bas shm_opem()");
            }
            shm_unlink(name);
            ftruncate(fd, (uint)size);


            var pool = shm.CreatePool((int)fd, (int)size);
            return pool.CreateBuffer(0, width, height, stride, WlShm.FormatEnum.Xrgb8888);
        }

        static void Main(string[] args)
        {
            var display = WlDisplay.Connect();
            var registry = display.GetRegistry();
            var registryHandler = new RegistryHandler(registry);
            registry.Events = registryHandler;
            display.Dispatch();
            display.Roundtrip();


            var compositor = registryHandler.Bind(WlCompositor.BindFactory, WlCompositor.InterfaceName, WlCompositor.InterfaceVersion);
            var shell = registryHandler.Bind(XdgWmBase.BindFactory, XdgWmBase.InterfaceName, XdgWmBase.InterfaceVersion);
            display.Roundtrip();

            shell.Events = new XdgWmBaseHandler();

            var wl_surface = compositor.CreateSurface();

            var xdgSurface = shell.GetXdgSurface(wl_surface);
            xdgSurface.Events = new XdgSurfaceHandler(xdgSurface);

            var xdgToplevel = xdgSurface.GetToplevel();
            xdgToplevel.Events = new XdgTopLevelHandler(xdgToplevel);

            xdgToplevel.SetTitle("Test");

            // xdgSurface.SetWindowGeometry(0, 0, 640, 480);

            var _region = compositor.CreateRegion();
            _region.Add(0, 0, 640, 480);

            wl_surface.SetOpaqueRegion(_region);

            wl_surface.Commit();
            display.Roundtrip();



            IntPtr egl_context = IntPtr.Zero;
            IntPtr egl_surface = IntPtr.Zero;

#if true
            bool use_egl = true;
            var wl_egl_window = LibWayland.wl_egl_window_create(wl_surface.Handle, 640, 480);
            Console.WriteLine($"wl_egl_window_create() -> {wl_egl_window}");



            var egl_display = eglGetDisplay(display.Handle);

            int major, minor;

            var ret = eglInitialize(egl_display, out major, out minor);
            Console.WriteLine($"eglInitialize returned: {ret}");
            Console.WriteLine($"Initialized eGL with: v{major}.{minor}");

            var attribs = new[]
            {
                EGL_SURFACE_TYPE, EGL_WINDOW_BIT,
                EGL_RENDERABLE_TYPE, EGL_OPENGL_ES2_BIT,
                EGL_RED_SIZE, 8,
                EGL_GREEN_SIZE, 8,
                EGL_BLUE_SIZE, 8,
                // EGL_ALPHA_SIZE, 8,
                EGL_NONE, EGL_NONE
            };

            IntPtr _egl_config;
            int chosen_config;
            ret = eglChooseConfig(egl_display, attribs, out _egl_config, 1, out chosen_config);
            Console.WriteLine($"ChosenConfig: {ret} : {chosen_config} : {_egl_config}");

            egl_surface = eglCreateWindowSurface(egl_display, _egl_config, wl_egl_window, null);//new[] { EGL_NONE, EGL_NONE });
            Console.WriteLine($"Got an egl_surface: {egl_surface}");

            var contextAttribs = new[]
            {
                EGL_CONTEXT_CLIENT_VERSION, 2, EGL_NONE, EGL_NONE
            };

            egl_context = eglCreateContext(egl_display, _egl_config, EGL_NO_CONTEXT, contextAttribs);
            Console.WriteLine($"Got an egl_context: {egl_context}");

            ret = eglMakeCurrent(egl_display, egl_surface, egl_surface, egl_context);
            Console.WriteLine($"eglMakeCurrent()  returned: {ret}");

#else 
            bool use_egl = false;
            var shm = registryHandler.Bind(WlShm.BindFactory, WlShm.InterfaceName, WlShm.InterfaceVersion);
            var buffer = create_buffer(shm, 640, 480);
            Console.WriteLine($"wl_buffer  version {buffer.Version}");
            wl_surface.Attach(buffer, 640, 480);
#endif 
            wl_surface.Commit();
            display.Roundtrip();
            while(true)
            {
                display.DispatchPending();
                if(use_egl)
                {
                    glClearColor(0.5f, 0.3f, 0.0f, 0.9f); 
                    glClear(GL_COLOR_BUFFER_BIT);
                    eglSwapBuffers(egl_display, egl_surface);
                }
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

    internal class XdgWmBaseHandler : XdgWmBase.IEvents
    {
        public void OnPing(XdgWmBase eventSender, uint serial)
        {
            throw new NotImplementedException();
        }
    }

    internal class XdgSurfaceHandler : XdgSurface.IEvents
    {
        private XdgSurface _xdg_surface;

        public XdgSurfaceHandler(XdgSurface xdg_surface)
        {
            _xdg_surface = xdg_surface;
        }

        public void OnConfigure(NWayland.Protocols.XdgShell.XdgSurface eventSender, uint @serial)
        {
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
