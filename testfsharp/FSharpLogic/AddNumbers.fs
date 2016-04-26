namespace FSharpLogic
open System
open UserHelpers

type AddNumbers () = 
    let l1 = Cons(2, Cons(4, Cons(3, Empty)))
    let l2 = Cons(5, Cons(6, Cons(4, Empty)))

    let add l1 l2 = 
        let rec addi = function
            | Cons(v1, n1), Cons(v2,n2), carry -> 
                let sum = v1+v2+carry
                if sum > 9 then 
                    Cons(sum%10, addi(n1, n2, 1))
                else 
                    Cons(v1+v2+carry, addi(n1, n2,0))
            | Cons(v1, n1), Empty, carry 
            | Empty, Cons(v1, n1), carry -> Cons(v1+carry, addi(n1, Empty, 0))
            | Empty, Empty, carry -> 
                if carry > 0 then Cons(carry, Empty) else Empty
        addi(l1, l2, 0)

    member t.runTests () = 
        System.Console.WriteLine(add l1 l2 |> toString )
        System.Console.WriteLine(add l1 l2 |> toString |> ((=) "708"))
        let l1 = Cons(6, Empty)
        let l2 = Cons(5, Empty)
        System.Console.WriteLine(add l1 l2 |> toString )
        System.Console.WriteLine(add l1 l2 |> toString |> ((=) "11"))
        let l1 = Cons(6, Empty)
        let l2 = Cons(5, Cons(1,Empty))
        System.Console.WriteLine(add l1 l2 |> toString )
        System.Console.WriteLine(add l1 l2 |> toString |> ((=) "12"))
