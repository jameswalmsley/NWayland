using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.Viewporter
{
    /// <summary>
    /// The global interface exposing surface cropping and scaling
    /// capabilities is used to instantiate an interface extension for a
    /// wl_surface object. This extended interface will then allow
    /// cropping and scaling the surface contents, effectively
    /// disconnecting the direct relationship between the buffer and the
    /// surface size.
    /// </summary>
    public sealed unsafe partial class WpViewporter : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WpViewporter()
        {
            WlInterface.Init("wp_viewporter", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_viewport", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Viewporter.WpViewport.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Viewporter.WpViewporter.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Instantiate an interface extension for the given wl_surface to
        /// crop and scale its content. If the given wl_surface already has
        /// a wp_viewport object associated, the viewport_exists
        /// protocol error is raised.
        /// </summary>
        public NWayland.Protocols.Viewporter.WpViewport GetViewport(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.Viewporter.WpViewport.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Viewporter.WpViewport(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary>the surface already has a viewport object associated</summary>
            ViewportExists = 0
        }

        class ProxyFactory : IBindFactory<WpViewporter>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Viewporter.WpViewporter.WlInterface);
            }

            public WpViewporter Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WpViewporter(handle, version, display);
            }
        }

        public static IBindFactory<WpViewporter> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_viewporter";
        public const int InterfaceVersion = 1;

        public WpViewporter(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An additional interface to a wl_surface object, which allows the
    /// client to specify the cropping and scaling of the surface
    /// contents.
    /// 
    /// This interface works with two concepts: the source rectangle (src_x,
    /// src_y, src_width, src_height), and the destination size (dst_width,
    /// dst_height). The contents of the source rectangle are scaled to the
    /// destination size, and content outside the source rectangle is ignored.
    /// This state is double-buffered, and is applied on the next
    /// wl_surface.commit.
    /// 
    /// The two parts of crop and scale state are independent: the source
    /// rectangle, and the destination size. Initially both are unset, that
    /// is, no scaling is applied. The whole of the current wl_buffer is
    /// used as the source, and the surface size is as defined in
    /// wl_surface.attach.
    /// 
    /// If the destination size is set, it causes the surface size to become
    /// dst_width, dst_height. The source (rectangle) is scaled to exactly
    /// this size. This overrides whatever the attached wl_buffer size is,
    /// unless the wl_buffer is NULL. If the wl_buffer is NULL, the surface
    /// has no content and therefore no size. Otherwise, the size is always
    /// at least 1x1 in surface local coordinates.
    /// 
    /// If the source rectangle is set, it defines what area of the wl_buffer is
    /// taken as the source. If the source rectangle is set and the destination
    /// size is not set, then src_width and src_height must be integers, and the
    /// surface size becomes the source rectangle size. This results in cropping
    /// without scaling. If src_width or src_height are not integers and
    /// destination size is not set, the bad_size protocol error is raised when
    /// the surface state is applied.
    /// 
    /// The coordinate transformations from buffer pixel coordinates up to
    /// the surface-local coordinates happen in the following order:
    /// 1. buffer_transform (wl_surface.set_buffer_transform)
    /// 2. buffer_scale (wl_surface.set_buffer_scale)
    /// 3. crop and scale (wp_viewport.set*)
    /// This means, that the source rectangle coordinates of crop and scale
    /// are given in the coordinates after the buffer transform and scale,
    /// i.e. in the coordinates that would be the surface-local coordinates
    /// if the crop and scale was not applied.
    /// 
    /// If src_x or src_y are negative, the bad_value protocol error is raised.
    /// Otherwise, if the source rectangle is partially or completely outside of
    /// the non-NULL wl_buffer, then the out_of_buffer protocol error is raised
    /// when the surface state is applied. A NULL wl_buffer does not raise the
    /// out_of_buffer error.
    /// 
    /// The x, y arguments of wl_surface.attach are applied as normal to
    /// the surface. They indicate how many pixels to remove from the
    /// surface size from the left and the top. In other words, they are
    /// still in the surface-local coordinate system, just like dst_width
    /// and dst_height are.
    /// 
    /// If the wl_surface associated with the wp_viewport is destroyed,
    /// all wp_viewport requests except 'destroy' raise the protocol error
    /// no_surface.
    /// 
    /// If the wp_viewport object is destroyed, the crop and scale
    /// state is removed from the wl_surface. The change will be applied
    /// on the next wl_surface.commit.
    /// </summary>
    public sealed unsafe partial class WpViewport : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WpViewport()
        {
            WlInterface.Init("wp_viewport", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("set_source", "ffff", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("set_destination", "ii", new WlInterface*[] { null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Viewporter.WpViewport.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the source rectangle of the associated wl_surface. See
        /// wp_viewport for the description, and relation to the wl_buffer
        /// size.
        /// 
        /// If all of x, y, width and height are -1.0, the source rectangle is
        /// unset instead. Any other set of values where width or height are zero
        /// or negative, or x or y are negative, raise the bad_value protocol
        /// error.
        /// 
        /// The crop and scale state is double-buffered state, and will be
        /// applied on the next wl_surface.commit.
        /// </summary>
        public void SetSource(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Set the destination size of the associated wl_surface. See
        /// wp_viewport for the description, and relation to the wl_buffer
        /// size.
        /// 
        /// If width is -1 and height is -1, the destination size is unset
        /// instead. Any other pair of values for width and height that
        /// contains zero or negative values raises the bad_value protocol
        /// error.
        /// 
        /// The crop and scale state is double-buffered state, and will be
        /// applied on the next wl_surface.commit.
        /// </summary>
        public void SetDestination(int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @width,
                @height
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

        public enum ErrorEnum
        {
            /// <summary>negative or zero values in width or height</summary>
            BadValue = 0,
            /// <summary>destination size is not integer</summary>
            BadSize = 1,
            /// <summary>source rectangle extends outside of the content area</summary>
            OutOfBuffer = 2,
            /// <summary>the wl_surface was destroyed</summary>
            NoSurface = 3
        }

        class ProxyFactory : IBindFactory<WpViewport>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Viewporter.WpViewport.WlInterface);
            }

            public WpViewport Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WpViewport(handle, version, display);
            }
        }

        public static IBindFactory<WpViewport> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_viewport";
        public const int InterfaceVersion = 1;

        public WpViewport(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}