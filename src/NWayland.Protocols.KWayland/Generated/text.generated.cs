using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.Text
{
    /// <summary>
    /// An object used for text input. Adds support for text input and input 
    /// methods to applications. A text-input object is created from a
    /// wl_text_input_manager and corresponds typically to a text entry in an
    /// application.
    /// Requests are used to activate/deactivate the text-input object and set
    /// state information like surrounding and selected text or the content type.
    /// The information about entered text is sent to the text-input object via
    /// the pre-edit and commit events. Using this interface removes the need
    /// for applications to directly process hardware key events and compose text
    /// out of them.
    /// 
    /// Text is generally UTF-8 encoded, indices and lengths are in bytes.
    /// 
    /// Serials are used to synchronize the state between the text input and
    /// an input method. New serials are sent by the text input in the
    /// commit_state request and are used by the input method to indicate
    /// the known text input state in events like preedit_string, commit_string,
    /// and keysym. The text input can then ignore events from the input method
    /// which are based on an outdated state (for example after a reset).
    /// </summary>
    public sealed unsafe partial class WlTextInput : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlTextInput()
        {
            WlInterface.Init("wl_text_input", 1, new WlMessage[] {
                WlMessage.Create("activate", "oo", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("deactivate", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) }),
                WlMessage.Create("show_input_panel", "", new WlInterface*[] { }),
                WlMessage.Create("hide_input_panel", "", new WlInterface*[] { }),
                WlMessage.Create("reset", "", new WlInterface*[] { }),
                WlMessage.Create("set_surrounding_text", "suu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("set_content_type", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("set_cursor_rectangle", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("set_preferred_language", "s", new WlInterface*[] { null }),
                WlMessage.Create("commit_state", "u", new WlInterface*[] { null }),
                WlMessage.Create("invoke_action", "uu", new WlInterface*[] { null, null })
            }, new WlMessage[] {
                WlMessage.Create("enter", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("leave", "", new WlInterface*[] { }),
                WlMessage.Create("modifiers_map", "a", new WlInterface*[] { null }),
                WlMessage.Create("input_panel_state", "u", new WlInterface*[] { null }),
                WlMessage.Create("preedit_string", "uss", new WlInterface*[] { null, null, null }),
                WlMessage.Create("preedit_styling", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("preedit_cursor", "i", new WlInterface*[] { null }),
                WlMessage.Create("commit_string", "us", new WlInterface*[] { null, null }),
                WlMessage.Create("cursor_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("delete_surrounding_text", "iu", new WlInterface*[] { null, null }),
                WlMessage.Create("keysym", "uuuuu", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("language", "us", new WlInterface*[] { null, null }),
                WlMessage.Create("text_direction", "uu", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Text.WlTextInput.WlInterface);
        }

        /// <summary>
        /// Requests the text-input object to be activated (typically when the 
        /// text entry gets focus).
        /// The seat argument is a wl_seat which maintains the focus for this
        /// activation. The surface argument is a wl_surface assigned to the
        /// text-input object and tracked for focus lost. The enter event
        /// is emitted on successful activation.
        /// </summary>
        public void Activate(NWayland.Protocols.Wayland.WlSeat @seat, NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat,
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Requests the text-input object to be deactivated (typically when the
        /// text entry lost focus). The seat argument is a wl_seat which was used
        /// for activation.
        /// </summary>
        public void Deactivate(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                @seat
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Requests input panels (virtual keyboard) to show.
        /// </summary>
        public void ShowInputPanel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Requests input panels (virtual keyboard) to hide.
        /// </summary>
        public void HideInputPanel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Should be called by an editor widget when the input state should be
        /// reset, for example after the text was changed outside of the normal
        /// input method flow.
        /// </summary>
        public void Reset()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Sets the plain surrounding text around the input position. Text is
        /// UTF-8 encoded. Cursor is the byte offset within the
        /// surrounding text. Anchor is the byte offset of the
        /// selection anchor within the surrounding text. If there is no selected
        /// text anchor is the same as cursor.
        /// </summary>
        public void SetSurroundingText(System.String @text, uint @cursor, uint @anchor)
        {
            if (@text == null)
                throw new System.ArgumentNullException("text");
            using var __marshalled__text = new NWayland.Interop.NWaylandMarshalledString(@text);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__text,
                @cursor,
                @anchor
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Sets the content purpose and content hint. While the purpose is the
        /// basic purpose of an input field, the hint flags allow to modify some
        /// of the behavior.
        /// 
        /// When no content type is explicitly set, a normal content purpose with
        /// default hints (auto completion, auto correction, auto capitalization)
        /// should be assumed.
        /// </summary>
        public void SetContentType(uint @hint, uint @purpose)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @hint,
                @purpose
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        public void SetCursorRectangle(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        /// <summary>
        /// Sets a specific language. This allows for example a virtual keyboard to
        /// show a language specific layout. The "language" argument is a RFC-3066 
        /// format language tag.
        /// 
        /// It could be used for example in a word processor to indicate language of
        /// currently edited document or in an instant message application which tracks
        /// languages of contacts.
        /// </summary>
        public void SetPreferredLanguage(System.String @language)
        {
            if (@language == null)
                throw new System.ArgumentNullException("language");
            using var __marshalled__language = new NWayland.Interop.NWaylandMarshalledString(@language);
            WlArgument* __args = stackalloc WlArgument[] {
                __marshalled__language
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 8, __args);
        }

        public void CommitState(uint @serial)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public void InvokeAction(uint @button, uint @index)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @button,
                @index
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 10, __args);
        }

        public interface IEvents
        {
            void OnEnter(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnLeave(NWayland.Protocols.KWayland.Text.WlTextInput eventSender);
            void OnModifiersMap(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, ReadOnlySpan<byte> @map);
            void OnInputPanelState(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @state);
            void OnPreeditString(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @serial, System.String @text, System.String @commit);
            void OnPreeditStyling(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @index, uint @length, uint @style);
            void OnPreeditCursor(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, int @index);
            void OnCommitString(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @serial, System.String @text);
            void OnCursorPosition(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, int @index, int @anchor);
            void OnDeleteSurroundingText(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, int @index, uint @length);
            void OnKeysym(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @serial, uint @time, uint @sym, uint @state, uint @modifiers);
            void OnLanguage(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @serial, System.String @language);
            void OnTextDirection(NWayland.Protocols.KWayland.Text.WlTextInput eventSender, uint @serial, uint @direction);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnEnter(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnLeave(this);
            if (opcode == 2)
                Events?.OnModifiersMap(this, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[0].IntPtr));
            if (opcode == 3)
                Events?.OnInputPanelState(this, arguments[0].UInt32);
            if (opcode == 4)
                Events?.OnPreeditString(this, arguments[0].UInt32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[1].IntPtr), System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[2].IntPtr));
            if (opcode == 5)
                Events?.OnPreeditStyling(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32);
            if (opcode == 6)
                Events?.OnPreeditCursor(this, arguments[0].Int32);
            if (opcode == 7)
                Events?.OnCommitString(this, arguments[0].UInt32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[1].IntPtr));
            if (opcode == 8)
                Events?.OnCursorPosition(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 9)
                Events?.OnDeleteSurroundingText(this, arguments[0].Int32, arguments[1].UInt32);
            if (opcode == 10)
                Events?.OnKeysym(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32);
            if (opcode == 11)
                Events?.OnLanguage(this, arguments[0].UInt32, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[1].IntPtr));
            if (opcode == 12)
                Events?.OnTextDirection(this, arguments[0].UInt32, arguments[1].UInt32);
        }

        /// <summary>
        /// Content hint is a bitmask to allow to modify the behavior of the text
        /// input.
        /// </summary>
        public enum ContentHintEnum
        {
            /// <summary>no special behaviour</summary>
            None = 0x0,
            /// <summary>auto completion, correction and capitalization</summary>
            Default = 0x7,
            /// <summary>hidden and sensitive text</summary>
            Password = 0xc0,
            /// <summary>suggest word completions</summary>
            AutoCompletion = 0x1,
            /// <summary>suggest word corrections</summary>
            AutoCorrection = 0x2,
            /// <summary>switch to uppercase letters at the start of a sentence</summary>
            AutoCapitalization = 0x4,
            /// <summary>prefer lowercase letters</summary>
            Lowercase = 0x8,
            /// <summary>prefer uppercase letters</summary>
            Uppercase = 0x10,
            /// <summary>prefer casing for titles and headings (can be language dependent)</summary>
            Titlecase = 0x20,
            /// <summary>characters should be hidden</summary>
            HiddenText = 0x40,
            /// <summary>typed text should not be stored</summary>
            SensitiveData = 0x80,
            /// <summary>just latin characters should be entered</summary>
            Latin = 0x100,
            /// <summary>the text input is multiline</summary>
            Multiline = 0x200
        }

        /// <summary>
        /// The content purpose allows to specify the primary purpose of a text
        /// input.
        /// 
        /// This allows an input method to show special purpose input panels with
        /// extra characters or to disallow some characters.
        /// </summary>
        public enum ContentPurposeEnum
        {
            /// <summary>default input, allowing all characters</summary>
            Normal = 0,
            /// <summary>allow only alphabetic characters</summary>
            Alpha = 1,
            /// <summary>allow only digits</summary>
            Digits = 2,
            /// <summary>input a number (including decimal separator and sign)</summary>
            Number = 3,
            /// <summary>input a phone number</summary>
            Phone = 4,
            /// <summary>input an URL</summary>
            Url = 5,
            /// <summary>input an email address</summary>
            Email = 6,
            /// <summary>input a name of a person</summary>
            Name = 7,
            /// <summary>input a password (combine with password or sensitive_data hint)</summary>
            Password = 8,
            /// <summary>input a date</summary>
            Date = 9,
            /// <summary>input a time</summary>
            Time = 10,
            /// <summary>input a date and time</summary>
            Datetime = 11,
            /// <summary>input for a terminal</summary>
            Terminal = 12
        }

        public enum PreeditStyleEnum
        {
            /// <summary>default style for composing text</summary>
            Default = 0,
            /// <summary>style should be the same as in non-composing text</summary>
            None = 1,
            Active = 2,
            Inactive = 3,
            Highlight = 4,
            Underline = 5,
            Selection = 6,
            Incorrect = 7
        }

        public enum TextDirectionEnum
        {
            /// <summary>automatic text direction based on text and language</summary>
            Auto = 0,
            /// <summary>left-to-right</summary>
            Ltr = 1,
            /// <summary>right-to-left</summary>
            Rtl = 2
        }

        class ProxyFactory : IBindFactory<WlTextInput>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Text.WlTextInput.WlInterface);
            }

            public WlTextInput Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlTextInput(handle, version, display);
            }
        }

        public static IBindFactory<WlTextInput> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_text_input";
        public const int InterfaceVersion = 1;

        public WlTextInput(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A factory for text-input objects. This object is a global singleton.
    /// </summary>
    public sealed unsafe partial class WlTextInputManager : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static WlTextInputManager()
        {
            WlInterface.Init("wl_text_input_manager", 1, new WlMessage[] {
                WlMessage.Create("create_text_input", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Text.WlTextInput.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Text.WlTextInputManager.WlInterface);
        }

        /// <summary>
        /// Creates a new text-input object.
        /// </summary>
        public NWayland.Protocols.KWayland.Text.WlTextInput CreateTextInput()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 0, __args, ref NWayland.Protocols.KWayland.Text.WlTextInput.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.Text.WlTextInput(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<WlTextInputManager>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.Text.WlTextInputManager.WlInterface);
            }

            public WlTextInputManager Create(IntPtr handle, int version, WlDisplay display)
            {
                return new WlTextInputManager(handle, version, display);
            }
        }

        public static IBindFactory<WlTextInputManager> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wl_text_input_manager";
        public const int InterfaceVersion = 1;

        public WlTextInputManager(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}