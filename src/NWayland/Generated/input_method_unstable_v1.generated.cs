using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.InputMethodUnstableV1
{
    /// <summary>
    /// Corresponds to a text input on the input method side. An input method context
    /// is created on text input activation on the input method side. It allows
    /// receiving information about the text input from the application via events.
    /// Input method contexts do not keep state after deactivation and should be
    /// destroyed after deactivation is handled.
    /// 
    /// Text is generally UTF-8 encoded, indices and lengths are in bytes.
    /// 
    /// Serials are used to synchronize the state between the text input and
    /// an input method. New serials are sent by the text input in the
    /// commit_state request and are used by the input method to indicate
    /// the known text input state in events like preedit_string, commit_string,
    /// and keysym. The text input can then ignore events from the input method
    /// which are based on an outdated state (for example after a reset).
    /// 
    /// Warning! The protocol described in this file is experimental and
    /// backward incompatible changes may be made. Backward compatible changes
    /// may be added together with the corresponding interface version bump.
    /// Backward incompatible changes are done by bumping the version number in
    /// the protocol and interface names and resetting the interface version.
    /// Once the protocol is to be declared stable, the 'z' prefix and the
    /// version number in the protocol and interface names are removed and the
    /// interface version number is reset.
    /// </summary>
    public sealed unsafe partial class ZwpInputMethodContextV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputMethodContextV1()
        {
            WlInterface.Init("zwp_input_method_context_v1", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("commit_string", "us", new WlInterface*[] { null, null }),
                WlMessage.Create("preedit_string", "uss", new WlInterface*[] { null, null, null }),
                WlMessage.Create("preedit_styling", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("preedit_cursor", "i", new WlInterface*[] { null }),
                WlMessage.Create("delete_surrounding_text", "iu", new WlInterface*[] { null, null }),
                WlMessage.Create("cursor_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("modifiers_map", "a", new WlInterface*[] { null }),
                WlMessage.Create("keysym", "uuuuu", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("grab_keyboard", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface) }),
                WlMessage.Create("key", "uuuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("modifiers", "uuuuu", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("language", "us", new WlInterface*[] { null, null }),
                WlMessage.Create("text_direction", "uu", new WlInterface*[] { null, null })
            }, new WlMessage[] {
                WlMessage.Create("surrounding_text", "suu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("reset", "", new WlInterface*[] { }),
                WlMessage.Create("content_type", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("invoke_action", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("commit_state", "u", new WlInterface*[] { null }),
                WlMessage.Create("preferred_language", "s", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Send the commit string text for insertion to the application.
        /// 
        /// The text to commit could be either just a single character after a key
        /// press or the result of some composing (pre-edit). It could be also an
        /// empty text when some text should be removed (see
        /// delete_surrounding_text) or when the input cursor should be moved (see
        /// cursor_position).
        /// 
        /// Any previously set composing text will be removed.
        /// </summary>
        public void CommitString(uint @serial, System.String @text)
        {
            if (@text == null)
                throw new System.ArgumentNullException("text");
            using var __marshalled__text = new NWayland.Interop.NWaylandMarshalledString(@text);
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                __marshalled__text
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Send the pre-edit string text to the application text input.
        /// 
        /// The commit text can be used to replace the pre-edit text on reset (for
        /// example on unfocus).
        /// 
        /// Previously sent preedit_style and preedit_cursor requests are also
        /// processed by the text_input.
        /// </summary>
        public void PreeditString(uint @serial, System.String @text, System.String @commit)
        {
            if (@commit == null)
                throw new System.ArgumentNullException("commit");
            if (@text == null)
                throw new System.ArgumentNullException("text");
            using var __marshalled__text = new NWayland.Interop.NWaylandMarshalledString(@text);
            using var __marshalled__commit = new NWayland.Interop.NWaylandMarshalledString(@commit);
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                __marshalled__text,
                __marshalled__commit
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Set the styling information on composing text. The style is applied for
        /// length in bytes from index relative to the beginning of
        /// the composing text (as byte offset). Multiple styles can
        /// be applied to a composing text.
        /// 
        /// This request should be sent before sending a preedit_string request.
        /// </summary>
        public void PreeditStyling(uint @index, uint @length, uint @style)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @index,
                @length,
                @style
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Set the cursor position inside the composing text (as byte offset)
        /// relative to the start of the composing text.
        /// 
        /// When index is negative no cursor should be displayed.
        /// 
        /// This request should be sent before sending a preedit_string request.
        /// </summary>
        public void PreeditCursor(int @index)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @index
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Remove the surrounding text.
        /// 
        /// This request will be handled on the text_input side directly following
        /// a commit_string request.
        /// </summary>
        public void DeleteSurroundingText(int @index, uint @length)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @index,
                @length
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Set the cursor and anchor to a new position. Index is the new cursor
        /// position in bytes (when &gt;= 0 this is relative to the end of the inserted text,
        /// otherwise it is relative to the beginning of the inserted text). Anchor is
        /// the new anchor position in bytes (when &gt;= 0 this is relative to the end of the
        /// inserted text, otherwise it is relative to the beginning of the inserted
        /// text). When there should be no selected text, anchor should be the same
        /// as index.
        /// 
        /// This request will be handled on the text_input side directly following
        /// a commit_string request.
        /// </summary>
        public void CursorPosition(int @index, int @anchor)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @index,
                @anchor
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        public void ModifiersMap(ReadOnlySpan<byte> @map)
        {
            fixed (byte* __pointer__map = @map)
            {
                var __marshalled__map = NWayland.Interop.WlArray.FromPointer(__pointer__map, @map.Length);
                WlArgument* __args = stackalloc WlArgument[] {
                    &__marshalled__map
                };
                LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
            }
        }

        /// <summary>
        /// Notify when a key event was sent. Key events should not be used for
        /// normal text input operations, which should be done with commit_string,
        /// delete_surrounding_text, etc. The key event follows the wl_keyboard key
        /// event convention. Sym is an XKB keysym, state is a wl_keyboard key_state.
        /// </summary>
        public void Keysym(uint @serial, uint @time, uint @sym, uint @state, uint @modifiers)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @time,
                @sym,
                @state,
                @modifiers
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        /// <summary>
        /// Allow an input method to receive hardware keyboard input and process
        /// key events to generate text events (with pre-edit) over the wire. This
        /// allows input methods which compose multiple key events for inputting
        /// text like it is done for CJK languages.
        /// </summary>
        public NWayland.Protocols.Wayland.WlKeyboard GrabKeyboard()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 9, __args, ref NWayland.Protocols.Wayland.WlKeyboard.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.Wayland.WlKeyboard(__ret, Version, Display);
        }

        /// <summary>
        /// Forward a wl_keyboard::key event to the client that was not processed
        /// by the input method itself. Should be used when filtering key events
        /// with grab_keyboard.  The arguments should be the ones from the
        /// wl_keyboard::key event.
        /// 
        /// For generating custom key events use the keysym request instead.
        /// </summary>
        public void Key(uint @serial, uint @time, uint @key, uint @state)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @time,
                @key,
                @state
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        /// <summary>
        /// Forward a wl_keyboard::modifiers event to the client that was not
        /// processed by the input method itself.  Should be used when filtering
        /// key events with grab_keyboard. The arguments should be the ones
        /// from the wl_keyboard::modifiers event.
        /// </summary>
        public void Modifiers(uint @serial, uint @modsDepressed, uint @modsLatched, uint @modsLocked, uint @group)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @modsDepressed,
                @modsLatched,
                @modsLocked,
                @group
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 11, __args);
        }

        public void Language(uint @serial, System.String @language)
        {
            if (@language == null)
                throw new System.ArgumentNullException("language");
            using var __marshalled__language = new NWayland.Interop.NWaylandMarshalledString(@language);
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                __marshalled__language
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 12, __args);
        }

        public void TextDirection(uint @serial, uint @direction)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                @direction
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 13, __args);
        }

        public interface IEvents
        {
            void OnSurroundingText(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender, System.String @text, uint @cursor, uint @anchor);
            void OnReset(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender);
            void OnContentType(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender, uint @hint, uint @purpose);
            void OnInvokeAction(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender, uint @button, uint @index);
            void OnCommitState(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender, uint @serial);
            void OnPreferredLanguage(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 eventSender, System.String @language);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnSurroundingText(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].UInt32, arguments[2].UInt32);
            if (opcode == 1)
                Events?.OnReset(this);
            if (opcode == 2)
                Events?.OnContentType(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 3)
                Events?.OnInvokeAction(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 4)
                Events?.OnCommitState(this, arguments[0].UInt32);
            if (opcode == 5)
                Events?.OnPreferredLanguage(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZwpInputMethodContextV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1.WlInterface);
            }

            public ZwpInputMethodContextV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputMethodContextV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputMethodContextV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_method_context_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputMethodContextV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// An input method object is responsible for composing text in response to
    /// input from hardware or virtual keyboards. There is one input method
    /// object per seat. On activate there is a new input method context object
    /// created which allows the input method to communicate with the text input.
    /// </summary>
    public sealed unsafe partial class ZwpInputMethodV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputMethodV1()
        {
            WlInterface.Init("zwp_input_method_v1", 1, new WlMessage[] { }, new WlMessage[] {
                WlMessage.Create("activate", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1.WlInterface) }),
                WlMessage.Create("deactivate", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1.WlInterface) })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodV1.WlInterface);
        }

        public interface IEvents
        {
            void OnActivate(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodV1 eventSender, ZwpInputMethodContextV1 @id);
            void OnDeactivate(NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodV1 eventSender, NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1 @context);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnActivate(this, new ZwpInputMethodContextV1(arguments[0].IntPtr, Version, Display));
            if (opcode == 1)
                Events?.OnDeactivate(this, WlProxy.FromNative<NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodContextV1>(arguments[0].IntPtr));
        }

        class ProxyFactory : IBindFactory<ZwpInputMethodV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputMethodV1.WlInterface);
            }

            public ZwpInputMethodV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputMethodV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputMethodV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_method_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputMethodV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// Only one client can bind this interface at a time.
    /// </summary>
    public sealed unsafe partial class ZwpInputPanelV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputPanelV1()
        {
            WlInterface.Init("zwp_input_panel_v1", 1, new WlMessage[] {
                WlMessage.Create("get_input_panel_surface", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelV1.WlInterface);
        }

        public NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1 GetInputPanelSurface(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpInputPanelV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelV1.WlInterface);
            }

            public ZwpInputPanelV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputPanelV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputPanelV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_panel_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputPanelV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    public sealed unsafe partial class ZwpInputPanelSurfaceV1 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpInputPanelSurfaceV1()
        {
            WlInterface.Init("zwp_input_panel_surface_v1", 1, new WlMessage[] {
                WlMessage.Create("set_toplevel", "ou", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface), null }),
                WlMessage.Create("set_overlay_panel", "", new WlInterface*[] { })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1.WlInterface);
        }

        /// <summary>
        /// Set the input_panel_surface type to keyboard.
        /// 
        /// A keyboard surface is only shown when a text input is active.
        /// </summary>
        public void SetToplevel(NWayland.Protocols.Wayland.WlOutput @output, uint @position)
        {
            if (@output == null)
                throw new System.ArgumentNullException("output");
            WlArgument* __args = stackalloc WlArgument[] {
                @output,
                @position
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Set the input_panel_surface to be an overlay panel.
        /// 
        /// This is shown near the input cursor above the application window when
        /// a text input is active.
        /// </summary>
        public void SetOverlayPanel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum PositionEnum
        {
            CenterBottom = 0
        }

        class ProxyFactory : IBindFactory<ZwpInputPanelSurfaceV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.InputMethodUnstableV1.ZwpInputPanelSurfaceV1.WlInterface);
            }

            public ZwpInputPanelSurfaceV1 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpInputPanelSurfaceV1(handle, version, display);
            }
        }

        public static IBindFactory<ZwpInputPanelSurfaceV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_input_panel_surface_v1";
        public const int InterfaceVersion = 1;

        public ZwpInputPanelSurfaceV1(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}