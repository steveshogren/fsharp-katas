module UserHelpers

open Interfaces
open System

let CapitalizeUser user = user

let MakeLI (id : IIdentity) =
    String.Format ("<li value=\"{0}\">{1}</li>", id.Id, id.Name)
