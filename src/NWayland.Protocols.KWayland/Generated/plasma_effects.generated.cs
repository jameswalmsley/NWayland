using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.PlasmaEffects
{
    public sealed unsafe partial class OrgKdePlasmaEffects : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static OrgKdePlasmaEffects()
        {
            WlInterface.Init("org_kde_plasma_effects", 1, new WlMessage[] {
                WlMessage.Create("slide", "oouii", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), null, null, null }),
                WlMessage.Create("set_blur_behind_region", "o?o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface) }),
                WlMessage.Create("set_contrast_region", "o?ouuu", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlRegion.WlInterface), null, null, null })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaEffects.OrgKdePlasmaEffects.WlInterface);
        }

        /// <summary>
        /// Ask the compositor to move the surface from a location to another
        /// with a slide animation.
        /// 
        /// The from argument provides a clue about where the slide animation
        /// begins, destination coordinates are specified with x and y.
        /// </summary>
        public void Slide(NWayland.Protocols.Wayland.WlOutput @output, NWayland.Protocols.Wayland.WlSurface @surface, uint @from, int @x, int @y)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                @output,
                @surface,
                @from,
                @x,
                @y
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// This request sets the region of the surface that will allow to see
        /// through with a blur effect.
        /// 
        /// Pass a null region to disable blur behind.
        /// </summary>
        public void SetBlurBehindRegion(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlRegion @region)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                @region
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// This request sets the region of the surface with a different
        /// contrast.
        /// 
        /// Pass a null region to disable this effect.
        /// 
        /// When a null region is passed the contrast, intensity and saturation
        /// arguments are not taken into account.
        /// 
        /// The contrast, intensity and saturation parameters are in
        /// the 0-255 range.
        /// </summary>
        public void SetContrastRegion(NWayland.Protocols.Wayland.WlSurface @surface, NWayland.Protocols.Wayland.WlRegion @region, uint @contrast, uint @intensity, uint @saturation)
        {
            if (@region == null)
                throw new System.ArgumentNullException("region");
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                @region,
                @contrast,
                @intensity,
                @saturation
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

        public enum LocationEnum
        {
            None = 0,
            Left = 1,
            Top = 2,
            Right = 3,
            Bottom = 4
        }

        class ProxyFactory : IBindFactory<OrgKdePlasmaEffects>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.PlasmaEffects.OrgKdePlasmaEffects.WlInterface);
            }

            public OrgKdePlasmaEffects Create(IntPtr handle, int version, WlDisplay display)
            {
                return new OrgKdePlasmaEffects(handle, version, display);
            }
        }

        public static IBindFactory<OrgKdePlasmaEffects> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "org_kde_plasma_effects";
        public const int InterfaceVersion = 1;

        public OrgKdePlasmaEffects(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}