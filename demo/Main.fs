module Demo

open Browser
open Glutinum.SignaturePad

open type Glutinum.SignaturePad.Exports

let canvas = document.getElementById("canvas") :?> Types.HTMLCanvasElement
let clearButton = document.getElementById("clear") :?> Types.HTMLButtonElement
let generateDateUrlButton = document.getElementById("generate") :?> Types.HTMLButtonElement

let signaturePad = SignaturePad(canvas)

clearButton.addEventListener("click", fun _ -> signaturePad.clear())

generateDateUrlButton.addEventListener("click", fun _ ->
    let dataUrl = signaturePad.toDataURL()
    printfn "%s" dataUrl
    window.alert(dataUrl)
)
