namespace rec Glutinum.SignaturePad.Point

open Fable.Core

// [<AbstractClass>]
// [<Erase>]
// type Exports =
//     [<Import("Point", "REPLACE_ME_WITH_MODULE_NAME"); EmitConstructor>]
//     static member Point (x: float, y: float, ?pressure: float, ?time: float) : Point = nativeOnly

[<AllowNullLiteral>]
[<Interface>]
type BasicPoint =
    abstract member x: float with get, set
    abstract member y: float with get, set
    abstract member pressure: float with get, set
    abstract member time: float with get, set

[<AllowNullLiteral>]
[<Interface>]
type Point =
    inherit BasicPoint
    abstract member x: float with get, set
    abstract member y: float with get, set
    abstract member pressure: float with get, set
    abstract member time: float with get, set
    abstract member distanceTo: start: BasicPoint -> float
    abstract member equals: other: BasicPoint -> bool
    abstract member velocityFrom: start: BasicPoint -> float
