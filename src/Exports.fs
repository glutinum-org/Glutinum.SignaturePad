namespace rec Glutinum.SignaturePad

open Fable.Core
open Fable.Core.JsInterop
open System
open Browser.Types
open Glutinum.SignaturePad.Point
open Glutinum.SignaturePad.SignatureEventTarget

[<AbstractClass>]
[<Erase>]
type Exports =
    [<ImportDefault("signature_pad"); EmitConstructor>]
    static member SignaturePad(canvas: HTMLCanvasElement, ?options: Options) : SignaturePad =
        nativeOnly

[<AllowNullLiteral>]
[<Interface>]
type SignatureEvent =
    abstract member event: U3<MouseEvent, TouchEvent, PointerEvent> with get, set
    abstract member ``type``: string with get, set
    abstract member x: float with get, set
    abstract member y: float with get, set
    abstract member pressure: float with get, set

[<AllowNullLiteral>]
[<Interface>]
type FromDataOptions =
    abstract member clear: bool option with get, set

[<AllowNullLiteral>]
[<Interface>]
type ToSVGOptions =
    abstract member includeBackgroundColor: bool option with get, set

[<AllowNullLiteral>]
[<Interface>]
type PointGroupOptions =
    abstract member dotSize: float with get, set
    abstract member minWidth: float with get, set
    abstract member maxWidth: float with get, set
    abstract member penColor: string with get, set
    abstract member velocityFilterWeight: float with get, set
    /// <summary>
    /// This is the globalCompositeOperation for the line.
    /// *default: 'source-over'*
    /// </summary>
    abstract member compositeOperation: GlobalCompositeOperation with get, set

[<AllowNullLiteral>]
[<Interface>]
type Options =
    // inherit Partial<PointGroupOptions>
    abstract member minDistance: float option with get, set
    abstract member backgroundColor: string option with get, set
    abstract member throttle: float option with get, set
    abstract member canvasContextOptions: CanvasRenderingContext2DSettings option with get, set
    abstract member dotSize: float option with get, set
    abstract member minWidth: float option with get, set
    abstract member maxWidth: float option with get, set
    abstract member penColor: string option with get, set
    abstract member velocityFilterWeight: float option with get, set
    /// <summary>
    /// This is the globalCompositeOperation for the line.
    /// *default: 'source-over'*
    /// </summary>
    abstract member compositeOperation: GlobalCompositeOperation option with get, set

[<AllowNullLiteral>]
[<Interface>]
type PointGroup =
    inherit PointGroupOptions
    abstract member points: ResizeArray<BasicPoint> with get, set

[<AllowNullLiteral>]
[<Interface>]
type SignaturePad =
    inherit SignatureEventTarget
    abstract member dotSize: float with get, set
    abstract member minWidth: float with get, set
    abstract member maxWidth: float with get, set
    abstract member penColor: string with get, set
    abstract member minDistance: float with get, set
    abstract member velocityFilterWeight: float with get, set
    abstract member compositeOperation: GlobalCompositeOperation with get, set
    abstract member backgroundColor: string with get, set
    abstract member throttle: float with get, set
    abstract member canvasContextOptions: CanvasRenderingContext2DSettings with get, set
    abstract member clear: unit -> unit

    abstract member fromDataURL:
        dataUrl: string * ?options: SignaturePad.fromDataURL.options -> JS.Promise<unit>

    abstract member toDataURL: ``type``: string * ?encoderOptions: ToSVGOptions -> string
    abstract member toDataURL: ?``type``: string * ?encoderOptions: float -> string
    abstract member on: unit -> unit
    abstract member off: unit -> unit
    abstract member isEmpty: unit -> bool
    abstract member fromData: pointGroups: ResizeArray<PointGroup> * arg1: FromDataOptions -> unit
    abstract member toData: unit -> ResizeArray<PointGroup>
    abstract member _isLeftButtonPressed: event: MouseEvent * ?only: bool -> bool
    abstract member toSVG: arg1: ToSVGOptions -> string

module SignaturePad =

    module fromDataURL =

        [<Global>]
        [<AllowNullLiteral>]
        type options
            [<ParamObject; Emit("$0")>]
            (?ratio: float, ?width: float, ?height: float, ?xOffset: float, ?yOffset: float)
            =

            member val ratio: float option = nativeOnly with get, set
            member val width: float option = nativeOnly with get, set
            member val height: float option = nativeOnly with get, set
            member val xOffset: float option = nativeOnly with get, set
            member val yOffset: float option = nativeOnly with get, set

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type GlobalCompositeOperation =
    | color
    | ``color-burn``
    | ``color-dodge``
    | copy
    | darken
    | ``destination-atop``
    | ``destination-in``
    | ``destination-out``
    | ``destination-over``
    | difference
    | exclusion
    | ``hard-light``
    | hue
    | lighten
    | lighter
    | luminosity
    | multiply
    | overlay
    | saturation
    | screen
    | ``soft-light``
    | ``source-atop``
    | ``source-in``
    | ``source-out``
    | ``source-over``
    | xor

[<AllowNullLiteral>]
[<Interface>]
type CanvasRenderingContext2DSettings =
    abstract member alpha: bool option with get, set
    abstract member colorSpace: PredefinedColorSpace option with get, set
    abstract member desynchronized: bool option with get, set
    abstract member willReadFrequently: bool option with get, set

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type PredefinedColorSpace =
    | ``display-p3``
    | srgb
