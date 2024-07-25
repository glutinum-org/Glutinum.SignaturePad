namespace rec Glutinum.SignaturePad.SignatureEventTarget

open Fable.Core
open Fable.Core.JsInterop
open System
open Browser.Types

[<AbstractClass>]
[<Erase>]
type Exports =
    [<Import("SignatureEventTarget", "REPLACE_ME_WITH_MODULE_NAME"); EmitConstructor>]
    static member SignatureEventTarget() : SignatureEventTarget = nativeOnly

[<AllowNullLiteral>]
[<Interface>]
type SignatureEventTarget =
    abstract member addEventListener:
        ``type``: string *
        listener: EventListenerOrEventListenerObject option *
        ?options: U2<bool, AddEventListenerOptions> ->
            unit

    abstract member dispatchEvent: event: Event -> bool

    abstract member removeEventListener:
        ``type``: string *
        callback: EventListenerOrEventListenerObject option *
        ?options: U2<bool, EventListenerOptions> ->
            unit

[<AllowNullLiteral>]
[<Interface>]
type EventListener =
    [<Emit("$0($1...)")>]
    abstract member Invoke: evt: Event -> unit

[<AllowNullLiteral>]
[<Interface>]
type EventListenerObject =
    abstract member handleEvent: ``object``: Event -> unit

type EventListenerOrEventListenerObject = U2<EventListener, EventListenerObject>

[<AllowNullLiteral>]
[<Interface>]
type EventListenerOptions =
    abstract member capture: bool option with get, set
