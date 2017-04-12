module Api

open Freya.Core
open Freya.Machines.Http
open Freya.Routers.Uri.Template

let routeName = Freya.Optic.get (Route.atom_ "name")

let name = freya {
  let! nameO = routeName

  match nameO with
  | Some name -> return name
  | None -> return "World"
}

let sayHello = freya {
  let! name = name

  return Represent.text (sprintf "Hello, %s!" name)
}

let helloMachine = freyaMachine {
  methods [GET; HEAD; OPTIONS]

  handleOk sayHello
}

let root = freyaRouter {
  resource "/hello{/name}" helloMachine
}
