module UserHelpers

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

let append v l = Cons(v, l) 

let tail = function
    | Cons(a, next) -> next
    | Empty -> Empty

let head = function
    | Cons(a, next) -> Some a
    | Empty -> None

let toString l = fold (fun ret next -> ret + next.ToString()) "" l 

type Stack<'a>() =
    member val first = Empty with get, set
    member this.Push (v:'a) =
        this.first <- append v this.first  
        this
    member this.Pop () = 
        let v = head this.first
        this.first <- tail this.first
        v

let rec foldStack (acc:'b->'a->'b) (init:'b) (l:Stack<'a>) : 'b =
  match l.Pop() with
  | None -> init
  | Some v -> foldStack acc (acc init v) l

type Node<'a> (v:'a) =
    member val value = v with get, set
    member val next:Node<'a> option = None with get, set

type Queue<'a>() =
    member val first = None with get, set
    member val last = None with get, set
    member this.Enqueue (v:'a) =
        System.Console.WriteLine("Enqueuing:"+v.ToString())
        match this.last with
        | None ->
            let n = Node(v)
            this.first <- Some n
            this.last <- Some n
            this
        | Some lastVal ->
            lastVal.next <- Some(Node(v))
            this
    member this.Dequeue () : 'a option = 
        System.Console.WriteLine("Dequeue:"+this.first.ToString())
        match this.first with
        | None -> None
        | Some firstVal -> 
            this.first <- firstVal.next
            let v = firstVal.value 
            System.Console.WriteLine("Dequeuing:"+v.ToString())
            Some v

let rec foldQ (acc:'b->'a->'b) (init:'b) (l:Queue<'a>) : 'b =
  match l.Dequeue() with
  | None -> init
  | Some v -> foldQ acc (acc init v) l

let reverse (l:LinkedList<'a>) =
    fold (fun ret n -> append n ret) Empty l

let testReverse () =         
   System.Console.WriteLine(reverse l1 |> toString )
   System.Console.WriteLine(reverse l1 |> toString |> ((=) "54321"))