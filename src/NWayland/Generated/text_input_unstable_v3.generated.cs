using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
using System.Threading.Tasks;

namespace NWayland.Protocols.TextInputUnstableV3
{
    /// <summary>
    /// The zwp_text_input_v3 interface represents text input and input methods
    /// associated with a seat. It provides enter/leave events to follow the
    /// text input focus for a seat.
    /// 
    /// Requests are used to enable/disable the text-input object and set
    /// state information like surrounding and selected text or the content type.
    /// The information about the entered text is sent to the text-input object
    /// via the preedit_string and commit_string events.
    /// 
    /// Text is valid UTF-8 encoded, indices and lengths are in bytes. Indices
    /// must not point to middle bytes inside a code point: they must either
    /// point to the first byte of a code point or to the end of the buffer.
    /// Lengths must be measured between two valid indices.
    /// 
    /// Focus moving throughout surfaces will result in the emission of
    /// zwp_text_input_v3.enter and zwp_text_input_v3.leave events. The focused
    /// surface must commit zwp_text_input_v3.enable and
    /// zwp_text_input_v3.disable requests as the keyboard focus moves across
    /// editable and non-editable elements of the UI. Those two requests are not
    /// expected to be paired with each other, the compositor must be able to
    /// handle consecutive series of the same request.
    /// 
    /// State is sent by the state requests (set_surrounding_text,
    /// set_content_type and set_cursor_rectangle) and a commit request. After an
    /// enter event or disable request all state information is invalidated and
    /// needs to be resent by the client.
    /// </summary>
    public sealed unsafe partial class ZwpTextInputV3 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTextInputV3()
        {
            WlInterface.Init("zwp_text_input_v3", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("enable", "", new WlInterface*[] { }),
                WlMessage.Create("disable", "", new WlInterface*[] { }),
                WlMessage.Create("set_surrounding_text", "sii", new WlInterface*[] { null, null, null }),
                WlMessage.Create("set_text_change_cause", "u", new WlInterface*[] { null }),
                WlMessage.Create("set_content_type", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("set_cursor_rectangle", "iiii", new WlInterface*[] { null, null, null, null }),
                WlMessage.Create("commit", "", new WlInterface*[] { })
            }, new WlMessage[] {
                WlMessage.Create("enter", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("leave", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) }),
                WlMessage.Create("preedit_string", "?sii", new WlInterface*[] { null, null, null }),
                WlMessage.Create("commit_string", "?s", new WlInterface*[] { null }),
                WlMessage.Create("delete_surrounding_text", "uu", new WlInterface*[] { null, null }),
                WlMessage.Create("done", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3.WlInterface);
        }

        protected sealed override void CallWaylandDestructor()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
        }

        /// <summary>
        /// Requests text input on the surface previously obtained from the enter
        /// event.
        /// 
        /// This request must be issued every time the active text input changes
        /// to a new one, including within the current surface. Use
        /// zwp_text_input_v3.disable when there is no longer any input focus on
        /// the current surface.
        /// 
        /// This request resets all state associated with previous enable, disable,
        /// set_surrounding_text, set_text_change_cause, set_content_type, and
        /// set_cursor_rectangle requests, as well as the state associated with
        /// preedit_string, commit_string, and delete_surrounding_text events.
        /// 
        /// The set_surrounding_text, set_content_type and set_cursor_rectangle
        /// requests must follow if the text input supports the necessary
        /// functionality.
        /// 
        /// State set with this request is double-buffered. It will get applied on
        /// the next zwp_text_input_v3.commit request, and stay valid until the
        /// next committed enable or disable request.
        /// 
        /// The changes must be applied by the compositor after issuing a
        /// zwp_text_input_v3.commit request.
        /// </summary>
        public void Enable()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Explicitly disable text input on the current surface (typically when
        /// there is no focus on any text entry inside the surface).
        /// 
        /// State set with this request is double-buffered. It will get applied on
        /// the next zwp_text_input_v3.commit request.
        /// </summary>
        public void Disable()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 2, __args);
        }

        /// <summary>
        /// Sets the surrounding plain text around the input, excluding the preedit
        /// text.
        /// 
        /// The client should notify the compositor of any changes in any of the
        /// values carried with this request, including changes caused by handling
        /// incoming text-input events as well as changes caused by other
        /// mechanisms like keyboard typing.
        /// 
        /// If the client is unaware of the text around the cursor, it should not
        /// issue this request, to signify lack of support to the compositor.
        /// 
        /// Text is UTF-8 encoded, and should include the cursor position, the
        /// complete selection and additional characters before and after them.
        /// There is a maximum length of wayland messages, so text can not be
        /// longer than 4000 bytes.
        /// 
        /// Cursor is the byte offset of the cursor within text buffer.
        /// 
        /// Anchor is the byte offset of the selection anchor within text buffer.
        /// If there is no selected text, anchor is the same as cursor.
        /// 
        /// If any preedit text is present, it is replaced with a cursor for the
        /// purpose of this event.
        /// 
        /// Values set with this request are double-buffered. They will get applied
        /// on the next zwp_text_input_v3.commit request, and stay valid until the
        /// next committed enable or disable request.
        /// 
        /// The initial state for affected fields is empty, meaning that the text
        /// input does not support sending surrounding text. If the empty values
        /// get applied, subsequent attempts to change them may have no effect.
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
            LibWayland.wl_proxy_marshal_array(this.Handle, 3, __args);
        }

        /// <summary>
        /// Tells the compositor why the text surrounding the cursor changed.
        /// 
        /// Whenever the client detects an external change in text, cursor, or
        /// anchor posision, it must issue this request to the compositor. This
        /// request is intended to give the input method a chance to update the
        /// preedit text in an appropriate way, e.g. by removing it when the user
        /// starts typing with a keyboard.
        /// 
        /// cause describes the source of the change.
        /// 
        /// The value set with this request is double-buffered. It must be applied
        /// and reset to initial at the next zwp_text_input_v3.commit request.
        /// 
        /// The initial value of cause is input_method.
        /// </summary>
        public void SetTextChangeCause(ChangeCauseEnum @cause)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@cause
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 4, __args);
        }

        /// <summary>
        /// Sets the content purpose and content hint. While the purpose is the
        /// basic purpose of an input field, the hint flags allow to modify some of
        /// the behavior.
        /// 
        /// Values set with this request are double-buffered. They will get applied
        /// on the next zwp_text_input_v3.commit request.
        /// Subsequent attempts to update them may have no effect. The values
        /// remain valid until the next committed enable or disable request.
        /// 
        /// The initial value for hint is none, and the initial value for purpose
        /// is normal.
        /// </summary>
        public void SetContentType(ContentHintEnum @hint, ContentPurposeEnum @purpose)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                (uint)@hint,
                (uint)@purpose
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 5, __args);
        }

        /// <summary>
        /// Marks an area around the cursor as a x, y, width, height rectangle in
        /// surface local coordinates.
        /// 
        /// Allows the compositor to put a window with word suggestions near the
        /// cursor, without obstructing the text being input.
        /// 
        /// If the client is unaware of the position of edited text, it should not
        /// issue this request, to signify lack of support to the compositor.
        /// 
        /// Values set with this request are double-buffered. They will get applied
        /// on the next zwp_text_input_v3.commit request, and stay valid until the
        /// next committed enable or disable request.
        /// 
        /// The initial values describing a cursor rectangle are empty. That means
        /// the text input does not support describing the cursor area. If the
        /// empty values get applied, subsequent attempts to change them may have
        /// no effect.
        /// </summary>
        public void SetCursorRectangle(int @x, int @y, int @width, int @height)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @x,
                @y,
                @width,
                @height
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 6, __args);
        }

        /// <summary>
        /// Atomically applies state changes recently sent to the compositor.
        /// 
        /// The commit request establishes and updates the state of the client, and
        /// must be issued after any changes to apply them.
        /// 
        /// Text input state (enabled status, content purpose, content hint,
        /// surrounding text and change cause, cursor rectangle) is conceptually
        /// double-buffered within the context of a text input, i.e. between a
        /// committed enable request and the following committed enable or disable
        /// request.
        /// 
        /// Protocol requests modify the pending state, as opposed to the current
        /// state in use by the input method. A commit request atomically applies
        /// all pending state, replacing the current state. After commit, the new
        /// pending state is as documented for each related request.
        /// 
        /// Requests are applied in the order of arrival.
        /// 
        /// Neither current nor pending state are modified unless noted otherwise.
        /// 
        /// The compositor must count the number of commit requests coming from
        /// each zwp_text_input_v3 object and use the count as the serial in done
        /// events.
        /// </summary>
        public void Commit()
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 7, __args);
        }

        public interface IEvents
        {
            void OnEnter(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnLeave(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, NWayland.Protocols.Wayland.WlSurface @surface);
            void OnPreeditString(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, System.String @text, int @cursorBegin, int @cursorEnd);
            void OnCommitString(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, System.String @text);
            void OnDeleteSurroundingText(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, uint @beforeLength, uint @afterLength);
            void OnDone(NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 eventSender, uint @serial);
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            if (opcode == 0)
                Events?.OnEnter(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[0].IntPtr));
            if (opcode == 1)
                Events?.OnLeave(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlSurface>(arguments[0].IntPtr));
            if (opcode == 2)
                Events?.OnPreeditString(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr), arguments[1].Int32, arguments[2].Int32);
            if (opcode == 3)
                Events?.OnCommitString(this, System.Runtime.InteropServices.Marshal.PtrToStringAnsi(arguments[0].IntPtr));
            if (opcode == 4)
                Events?.OnDeleteSurroundingText(this, arguments[0].UInt32, arguments[1].UInt32);
            if (opcode == 5)
                Events?.OnDone(this, arguments[0].UInt32);
        }

        /// <summary>
        /// Reason for the change of surrounding text or cursor posision.
        /// </summary>
        public enum ChangeCauseEnum
        {
            /// <summary>input method caused the change</summary>
            InputMethod = 0,
            /// <summary>something else than the input method caused the change</summary>
            Other = 1
        }

        [System.Flags]
        /// <summary>
        /// Content hint is a bitmask to allow to modify the behavior of the text
        /// input.
        /// </summary>
        public enum ContentHintEnum
        {
            /// <summary>no special behavior</summary>
            None = 0x0,
            /// <summary>suggest word completions</summary>
            Completion = 0x1,
            /// <summary>suggest word corrections</summary>
            Spellcheck = 0x2,
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
            /// <summary>just Latin characters should be entered</summary>
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
            /// <summary>input a password (combine with sensitive_data hint)</summary>
            Password = 8,
            /// <summary>input is a numeric password (combine with sensitive_data hint)</summary>
            Pin = 9,
            /// <summary>input a date</summary>
            Date = 10,
            /// <summary>input a time</summary>
            Time = 11,
            /// <summary>input a date and time</summary>
            Datetime = 12,
            /// <summary>input for a terminal</summary>
            Terminal = 13
        }

        class ProxyFactory : IBindFactory<ZwpTextInputV3>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3.WlInterface);
            }

            public ZwpTextInputV3 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTextInputV3(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTextInputV3> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_text_input_v3";
        public const int InterfaceVersion = 1;

        public ZwpTextInputV3(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }

    /// <summary>
    /// A factory for text-input objects. This object is a global singleton.
    /// </summary>
    public sealed unsafe partial class ZwpTextInputManagerV3 : NWayland.Protocols.Wayland.WlProxy
    {
        [System.Runtime.CompilerServices.FixedAddressValueType]
        public static NWayland.Interop.WlInterface WlInterface;

        static ZwpTextInputManagerV3()
        {
            WlInterface.Init("zwp_text_input_manager_v3", 1, new WlMessage[] {
                WlMessage.Create("destroy", "", new WlInterface*[] { }),
                WlMessage.Create("get_text_input", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSeat.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputManagerV3.WlInterface);
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
        public NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3 GetTextInput(NWayland.Protocols.Wayland.WlSeat @seat)
        {
            if (@seat == null)
                throw new System.ArgumentNullException("seat");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @seat
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor(this.Handle, 1, __args, ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3.WlInterface);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.TextInputUnstableV3.ZwpTextInputV3(__ret, Version, Display);
        }

        public interface IEvents
        {
        }

        public IEvents Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        class ProxyFactory : IBindFactory<ZwpTextInputManagerV3>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.TextInputUnstableV3.ZwpTextInputManagerV3.WlInterface);
            }

            public ZwpTextInputManagerV3 Create(IntPtr handle, int version, WlDisplay display)
            {
                return new ZwpTextInputManagerV3(handle, version, display);
            }
        }

        public static IBindFactory<ZwpTextInputManagerV3> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_text_input_manager_v3";
        public const int InterfaceVersion = 1;

        public ZwpTextInputManagerV3(IntPtr handle, int version, NWayland.Protocols.Wayland.WlDisplay display) : base(handle, version, display)
        {
        }
    }
}