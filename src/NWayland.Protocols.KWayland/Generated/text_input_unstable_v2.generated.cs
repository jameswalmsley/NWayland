using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.KWayland.TextInputUnstableV2
{
    /// <summary>
    /// The zwp_text_input_v2 interface represents text input and input methods
    /// associated with a seat. It provides enter/leave events to follow the
    /// text input focus for a seat.
    /// 
    /// Requests are used to enable/disable the text-input object and set
    /// state information like surrounding and selected text or the content type.
    /// The information about the entered text is sent to the text-input object
    /// via the pre-edit and commit events. Using this interface removes the need
    /// for applications to directly process hardware key events and compose text
    /// out of them.
    /// 
    /// Text is valid UTF-8 encoded, indices and lengths are in bytes. Indices
    /// have to always point to the first byte of an UTF-8 encoded code point.
    /// Lengths are not allowed to contain just a part of an UTF-8 encoded code
    /// point.
    /// 
    /// State is sent by the state requests (set_surrounding_text,
    /// set_content_type, set_cursor_rectangle and set_preferred_language) and
    /// an update_state request. After an enter or an input_method_change event
    /// all state information is invalidated and needs to be resent from the
    /// client. A reset or entering a new widget on client side also
    /// invalidates all current state information.
    /// </summary>
    public sealed unsafe partial class ZwpTextInputV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTextInputV2()
        {
            WlInterface.Init("zwp_text_input_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("enable", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("disable", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("show_input_panel", "", new WlInterface*[] { }),
                WlMessage.Create("hide_input_panel", "", new WlInterface*[] { }),
                WlMessage.Create("set_surrounding_text", "sii", new WlInterface*[] { null, null, null }),
                WlMessage.Create("set_content_type", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("set_cursor_rectangle", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("set_preferred_language", "s", new WlInterface*[] { null }),
                WlMessage.Create("update_state", "uu", new WlInterface*[] { null, null })
            }, new WlMessage[] {
                WlMessage.Create("enter", "uo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("leave", "uo", new WlInterface*[] { null, WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("input_panel_state", "uiiii", new WlInterface*[] { null, null, null, null, null }),
                WlMessage.Create("preedit_string", "ss", new WlInterface*[] { null, null }),
                WlMessage.Create("preedit_styling", "uuu", new WlInterface*[] { null, null, null }),
                WlMessage.Create("preedit_cursor", "i", new WlInterface*[] { null }),
                WlMessage.Create("commit_string", "s", new WlInterface*[] { null }),
                WlMessage.Create("cursor_position", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("delete_surrounding_text", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("modifiers_map", "a", new WlInterface*[] { null }),
                WlMessage.Create("keysym", "uuuu", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("language", "s", new WlInterface*[] { null }),
                WlMessage.Create("text_direction", "u", new WlInterface*[] { null }),
                WlMessage.Create("configure_surrounding_text", "ii", new WlInterface*[] { null, null }),
                WlMessage.Create("input_method_changed", "uu", new WlInterface*[] { null, null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Enable text input in a surface (usually when a text entry inside of it
        /// has focus).
        /// 
        /// This can be called before or after a surface gets text (or keyboard)
        /// focus via the enter event. Text input to a surface is only active
        /// when it has the current text (or keyboard) focus and is enabled.
        /// </summary>
        public void Enable(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Disable text input in a surface (typically when there is no focus on any
        /// text entry inside the surface).
        /// </summary>
        public void Disable(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new System.ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Requests input panels (virtual keyboard) to show.
        /// 
        /// This should be used for example to show a virtual keyboard again
        /// (with a tap) after it was closed by pressing on a close button on the
        /// keyboard.
        /// </summary>
        public void ShowInputPanel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Requests input panels (virtual keyboard) to hide.
        /// </summary>
        public void HideInputPanel()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Sets the plain surrounding text around the input position. Text is
        /// UTF-8 encoded. Cursor is the byte offset within the surrounding text.
        /// Anchor is the byte offset of the selection anchor within the
        /// surrounding text. If there is no selected text, anchor is the same as
        /// cursor.
        /// 
        /// Make sure to always send some text before and after the cursor
        /// except when the cursor is at the beginning or end of text.
        /// 
        /// When there was a configure_surrounding_text event take the
        /// before_cursor and after_cursor arguments into account for picking how
        /// much surrounding text to send.
        /// 
        /// There is a maximum length of wayland messages so text can not be
        /// longer than 4000 bytes.
        /// </summary>
        public void SetSurroundingText(System.String @text, int @cursor, int @anchor)
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
        /// none hint should be assumed.
        /// </summary>
        public void SetContentType(ContentHintEnum @hint, ContentPurposeEnum @purpose)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@hint,
                (uint)@purpose
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Sets the cursor outline as a x, y, width, height rectangle in surface
        /// local coordinates.
        /// 
        /// Allows the compositor to put a window with word suggestions near the
        /// cursor.
        /// </summary>
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
        /// currently edited document or in an instant message application which
        /// tracks languages of contacts.
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

        /// <summary>
        /// Allows to atomically send state updates from client.
        /// 
        /// This request should follow after a batch of state updating requests
        /// like set_surrounding_text, set_content_type, set_cursor_rectangle and
        /// set_preferred_language.
        /// 
        /// The flags field indicates why an updated state is sent to the input
        /// method.
        /// 
        /// Reset should be used by an editor widget after the text was changed
        /// outside of the normal input method flow.
        /// 
        /// For "change" it is enough to send the changed state, else the full
        /// state should be send.
        /// 
        /// Serial should be set to the serial from the last enter or
        /// input_method_changed event.
        /// 
        /// To make sure to not receive outdated input method events after a
        /// reset or switching to a new widget wl_display_sync() should be used
        /// after update_state in these cases.
        /// </summary>
        public void UpdateState(uint @serial, UpdateStateEnum @reason)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @serial,
                (uint)@reason
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 9, __args);
        }

        public interface IEvents
        {
            void OnEnter(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnLeave(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @serial, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnInputPanelState(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, InputPanelVisibilityEnum @state, int @x, int @y, int @width, int @height);
            void OnPreeditString(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, System.String @text, System.String @commit);
            void OnPreeditStyling(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @index, uint @length, PreeditStyleEnum @style);
            void OnPreeditCursor(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, int @index);
            void OnCommitString(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, System.String @text);
            void OnCursorPosition(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, int @index, int @anchor);
            void OnDeleteSurroundingText(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @beforeLength, uint @afterLength);
            void OnModifiersMap(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, ReadOnlySpan<byte> @map);
            void OnKeysym(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @time, uint @sym, uint @state, uint @modifiers);
            void OnLanguage(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, System.String @language);
            void OnTextDirection(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, TextDirectionEnum @direction);
            void OnConfigureSurroundingText(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, int @beforeCursor, int @afterCursor);
            void OnInputMethodChanged(NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 eventSender, uint @serial, uint @flags);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnEnter(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr));
            if (opcode == 1)
                Events?.OnLeave(this, arguments[0].UInt32, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[1].IntPtr));
            if (opcode == 2)
                Events?.OnInputPanelState(this, (InputPanelVisibilityEnum)arguments[0].UInt32, arguments[1].Int32, arguments[2].Int32, arguments[3].Int32, arguments[4].Int32);
            if (opcode == 3)
                Events?.OnPreeditString(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[1].IntPtr));
            if (opcode == 4)
                Events?.OnPreeditStyling(this, arguments[0].UInt32, arguments[1].UInt32, (PreeditStyleEnum)arguments[2].UInt32);
            if (opcode == 5)
                Events?.OnPreeditCursor(this, arguments[0].Int32);
            if (opcode == 6)
                Events?.OnCommitString(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 7)
                Events?.OnCursorPosition(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 8)
                Events?.OnDeleteSurroundingText(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 9)
                Events?.OnModifiersMap(this, NWayland.Interop.WlArray.SpanFromWlArrayPtr<byte>(arguments[0].IntPtr));
            if (opcode == 10)
                Events?.OnKeysym(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32);
            if (opcode == 11)
                Events?.OnLanguage(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 12)
                Events?.OnTextDirection(this, (TextDirectionEnum)arguments[0].UInt32);
            if (opcode == 13)
                Events?.OnConfigureSurroundingText(this, arguments[0].Int32, arguments[1].Int32);
            if (opcode == 14)
                Events?.OnInputMethodChanged(this, arguments[0].UInt32, arguments[1].UInt32);
        }

        [System.Flags]
        /// <summary>
        /// Content hint is a bitmask to allow to modify the behavior of the text
        /// input.
        /// </summary>
        public enum ContentHintEnum
        {
            /// <summary>no special behaviour</summary>
            None = 0x0,
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

        /// <summary>
        /// Defines the reason for sending an updated state.
        /// </summary>
        public enum UpdateStateEnum
        {
            /// <summary>updated state because it changed</summary>
            Change = 0,
            /// <summary>full state after enter or input_method_changed event</summary>
            Full = 1,
            /// <summary>full state after reset</summary>
            Reset = 2,
            /// <summary>full state after switching focus to a different widget on client side</summary>
            Enter = 3
        }

        public enum InputPanelVisibilityEnum
        {
            /// <summary>the input panel (virtual keyboard) is hidden</summary>
            Hidden = 0,
            /// <summary>the input panel (virtual keyboard) is visible</summary>
            Visible = 1
        }

        public enum PreeditStyleEnum
        {
            /// <summary>default style for composing text</summary>
            Default = 0,
            /// <summary>composing text should be shown the same as non-composing text</summary>
            None = 1,
            /// <summary>composing text might be bold</summary>
            Active = 2,
            /// <summary>composing text might be cursive</summary>
            Inactive = 3,
            /// <summary>composing text might have a different background color</summary>
            Highlight = 4,
            /// <summary>composing text might be underlined</summary>
            Underline = 5,
            /// <summary>composing text should be shown the same as selected text</summary>
            Selection = 6,
            /// <summary>composing text might be underlined with a red wavy line</summary>
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

        class ProxyFactory : IBindFactory<ZwpTextInputV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2.WlInterface);
            }

            public ZwpTextInputV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTextInputV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTextInputV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_text_input_v2";
        public const int InterfaceVersion = 1;

        public ZwpTextInputV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A factory for text-input objects. This object is a global singleton.
    /// </summary>
    public sealed unsafe partial class ZwpTextInputManagerV2 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTextInputManagerV2()
        {
            WlInterface.Init("zwp_text_input_manager_v2", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_text_input", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputManagerV2.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Creates a new text-input object for a given seat.
        /// </summary>
        public NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2 GetTextInput(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputV2(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpTextInputManagerV2>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.KWayland.TextInputUnstableV2.ZwpTextInputManagerV2.WlInterface);
            }

            public ZwpTextInputManagerV2 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTextInputManagerV2(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTextInputManagerV2> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_text_input_manager_v2";
        public const int InterfaceVersion = 1;

        public ZwpTextInputManagerV2(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}