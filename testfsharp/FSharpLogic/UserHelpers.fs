module UserHelpers

open Interfaces
open System


let MakeLI (id : IIdentity) =
    String.Format ("<li value=\"{0}\">{1}</li>", id.Id, id.Name)

type LinkedList<'a> =
  | Empty
  | Cons of 'a * LinkedList<'a>

let l1 = Cons(1, Cons(2, Cons(3, Empty)))

let rec filter (pred:'a->bool) (l:LinkedList<'a>) : LinkedList<'b> = 
  match l with 
  | Cons(a, next) -> if (pred a) then Cons(a, filter pred next) else filter pred next
  | Empty -> Empty


let rec map (f:'a->'b) (l:LinkedList<'a>) : LinkedList<'b> = 
    match l with 
    | Cons(a, next) -> Cons(f a, map f next)
    | Empty -> Empty

let rec fold (acc:'b -> 'a -> 'b) (init:'b) (l:LinkedList<'a>) : 'b =
    match l with
    | Cons(a, next) -> fold acc (acc init a) next
    | Empty -> init

let toString l = fold (fun ret next -> ret + next.ToString()) "" l 

System.Console.WriteLine("test" + toString l1)
