# Glutinum.SignaturePad

[![](https://img.shields.io/badge/Project_made_using_Glutinum.Template-7679db?style=for-the-badge)](https://github.com/glutinum-org/Glutinum.Template)

<!-- To learn how to use the template please refer to MANUAL.md -->

<!-- You can put the documentation for your binding below -->

[![NuGet](https://img.shields.io/nuget/v/Glutinum.SignaturePad.svg)](https://www.nuget.org/packages/Glutinum.SignaturePad)

Binding for [SignaturePad](https://www.npmjs.com/package/signature_pad).

## Usage

```fs
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
```
