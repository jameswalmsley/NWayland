using System;
using System.Runtime.InteropServices;

namespace NWayland.OpenGL.EGL
{
    unsafe public class OpenGLMethods
    {
        // ReSharper disable UnassignedGetOnlyAutoProperty
        [DllImport("libEGL", EntryPoint = "eglGetError")]
        public static extern int eglGetError();

        [DllImport("libEGL", EntryPoint = "eglGetDisplay")]
        public static extern IntPtr eglGetDisplay(IntPtr nativeDisplay);

        [DllImport("libEGL", EntryPoint = "eglGetPlatformDisplayEXT")]
        public static extern IntPtr eglGetPlatformDisplayEXT(int platform, IntPtr nativeDisplay, int[] attrs);

        [DllImport("libEGL", EntryPoint = "eglInitialize")]
        public static extern bool eglInitialize(IntPtr display, out int major, out int minor);

        [DllImport("libEGL", EntryPoint = "eglGetProcAddress")]
        public static extern IntPtr eglGetProcAddress(string proc);

        [DllImport("libEGL", EntryPoint = "eglBindAPI")]
        public static extern bool eglBindApi(int api);

        [DllImport("libEGL", EntryPoint = "eglChooseConfig")]
        public static extern bool eglChooseConfig(IntPtr display, int[] attribs, out IntPtr surfaceConfig, int numConfigs, out int choosenConfig);

        [DllImport("libEGL", EntryPoint = "eglCreateContext")]
        public static extern IntPtr eglCreateContext(IntPtr display, IntPtr config, int share, int[] attrs);

        [DllImport("libEGL", EntryPoint = "eglDestroyContext")]
        public static extern bool eglDestroyContext(IntPtr display, IntPtr context);

        [DllImport("libEGL", EntryPoint = "eglCreatePbufferSurface")]
        public static extern IntPtr eglCreatePBufferSurface(IntPtr display, IntPtr config, int[] attrs);

        [DllImport("libEGL", EntryPoint = "eglMakeCurrent")]
        public static extern bool eglMakeCurrent(IntPtr display, IntPtr draw, IntPtr read, IntPtr context);

        [DllImport("libEGL", EntryPoint = "eglGetCurrentContext")]
        public static extern IntPtr eglGetCurrentContext();

        [DllImport("libEGL", EntryPoint = "eglGetCurrentDisplay")]
        public static extern IntPtr eglGetCurrentDisplay();

        [DllImport("libEGL", EntryPoint = "eglGetCurrentSurface")]
        public static extern IntPtr eglGetCurrentSurface(int readDraw);

        [DllImport("libEGL", EntryPoint = "eglDestroySurface")]
        public static extern void eglDisplaySurfaceVoidDelegate(IntPtr display, IntPtr surface);

        [DllImport("libEGL", EntryPoint = "eglSwapBuffers")]
        public static extern void eglSwapBuffers(IntPtr display, IntPtr surface);

        [DllImport("libEGL", EntryPoint = "eglCreateWindowSurface")]
        public static extern IntPtr eglCreateWindowSurface(IntPtr display, IntPtr config, IntPtr window, int[]? attrs);

        [DllImport("libEGL", EntryPoint = "eglGetConfigAttrib")]
        public static extern bool eglGetConfigAttrib(IntPtr display, IntPtr config, int attr, out int rv);

        [DllImport("libEGL", EntryPoint = "eglWaitGL")]
        public static extern bool eglWaitGL();

        [DllImport("libEGL", EntryPoint = "eglWaitClient")]
        public static extern bool eglWaitClient();

        [DllImport("libEGL", EntryPoint = "eglWaitNative")]
        public static extern bool eglWaitNative(int engine);

        [DllImport("libEGL", EntryPoint = "eglCreatePbufferFromClientBuffer")]
        public static extern IntPtr eglCreatePbufferFromClientBuffer(IntPtr display, int buftype, IntPtr buffer, IntPtr config, int[] attrib_list);

        [DllImport("libGL", EntryPoint = "glClearColor")]
        public static extern void glClearColor(float red, float green, float blue, float alpha);

        [DllImport("libGL", EntryPoint = "glClear")]
        public static extern void glClear(int mask);
    }
}

