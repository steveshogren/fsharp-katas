type LinkedList<'a> =
  | Empty
  | Cons of 'a * LinkedList<'a>

let l1 = Cons(1, Cons(2, Cons(3, Cons(4, Cons(5, Empty)))))

let rec map (f:'a->'b) (l:LinkedList<'a>) : LinkedList<'b> = 
  match l with 
  | Cons(a, next) -> Cons(f a, map f next)
  | Empty -> Empty

let rec filter (pred:'a->bool) (l:LinkedList<'a>) : LinkedList<'a> = 
  match l with 
  | Cons(a, next) -> if (pred a) then Cons(a, filter pred next) else filter pred next
  | Empty -> Empty

let rec fold (acc:'b -> 'a -> 'b) (init:'b) (l:LinkedList<'a>) : 'b =
  match l with
  | Cons(a, next) -> fold acc (acc init a) next
  | Empty -> init

let toString l = fold (fun ret next -> ret + next.ToString()) "" l 

System.Console.WriteLine(toString (map (fun a -> 1 + a) l1))
System.Console.WriteLine(toString (filter (fun a -> a = 2 || a = 4) l1))

type AddNumbers () = 
    let l1 = Cons(2, Cons(4, Cons(3, Empty)))
    let l2 = Cons(5, Cons(6, Cons(4, Empty)))

    let add l1 l2 = l1
    member t.runTests () = 
        System.Console.WriteLine(add l1 l2 |> toString |> ((=) "708"))
   
AddNumbers().runTests()

