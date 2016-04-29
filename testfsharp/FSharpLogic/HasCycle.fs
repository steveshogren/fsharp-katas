namespace FSharpLogic
open System
open UserHelpers

type Node<'a> (v:'a, next:Node<'a> option) =
    member val value = v with get, set
    member val next = next with get, set

type HasCycle () = 

    let hasCycle (l:Node<'a>) = 
        let rec iHasCycle (f:Node<'a> option) (s:Node<'a> option) =
            match (f,s) with
            | None, next -> false
            | Some fast, Some slow -> 
                if fast = slow then true
                else match fast.next with 
                     | None -> false
                     | Some next -> iHasCycle next.next slow.next
            | _, _ -> false
           
        iHasCycle l.next (Some l)

    member t.runTests () = 
        let l1 = Node(1, Some (Node(2, None)))
        System.Console.WriteLine((hasCycle l1) = false)
        let n1 = Node(1, None)
        let n2 = Node(2, Some(Node(3, None)))
        n1.next <- Some n1
        n2.next <- Some n2

        System.Console.WriteLine((hasCycle(n1)) = true)
