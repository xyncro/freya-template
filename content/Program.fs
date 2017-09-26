module Program

//#if (framework == "kestrel")
open KestrelInterop
//#elseif (framework == "suave")
open Freya.Core
open Suave
//#endif

[<EntryPoint>]
let main argv =
//#if (framework == "kestrel")
    let configureApp =
        ApplicationBuilder.useFreya Api.root

    WebHost.create ()
    |> WebHost.bindTo [|"http://localhost:5000"|]
    |> WebHost.configure configureApp
    |> WebHost.buildAndRun
//#elseif (framework == "suave")
    startWebServer
        defaultConfig
        (Owin.OwinApp.ofAppFunc "/" (OwinAppFunc.ofFreya Api.root))
//#endif

    0
