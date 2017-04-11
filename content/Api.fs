module Api

open Freya.Core
open Freya.Optics.Http
open Freya.Types.Http
open Freya.Machines
open Freya.Machines.Http
open Freya.Routers.Uri.Template

let routeName = Freya.Optic.get (Route.atom_ "name")

let sayHello = freya {
  let! nameO = routeName
  let helloStr =
    match nameO with
    | Some name -> sprintf "Hello, %s!" name
    | None -> "Hello, World!"
  return Represent.text helloStr
}

let helloMachine = freyaMachine {
  methods [GET; HEAD; OPTIONS]

  handleOk sayHello
}

let root = freyaRouter {
  resource "/hello{/name}" helloMachine
}
