namespace FSharpLogic
open System
open UserHelpers
open NUnit.Framework

type TNode<'a> (v:'a, left:TNode<'a> option, right:TNode<'a> option) =
    member val value = v with get, set
    member val left = left with get, set
    member val right = right with get, set

module Tree =
    let makeNode = function
    | "#" -> None
    | v -> Some (TNode(Int32.Parse(v), None, None))

    let makeTree = function
    | next::left::right::rest -> 
        match makeNode next with
        | Some n ->
            n.left <- makeNode left
            n.right <- makeNode right
            Some n
        | None -> None
     | _ -> None

    let group (node:TNode<'a>) =
        let rec iPrint ret (current:TNode<'a> list) (next:TNode<'a> list) = 
            match current, next with
            | [], [] -> ret
            | [], next -> iPrint ret next []
            | node::rest, next -> 
                let ret = ret @ [node.value.ToString()]
                match node.left, node.right with
                | Some l, Some r -> 
                    iPrint ret rest (l::r::next)
                | Some n, None 
                | None, Some n -> 
                    iPrint ret rest (n::next)
                | None, None ->
                    iPrint ret rest next
        iPrint [] [node] []

    let levelFold (f:'a->'b->'b) (init:'b) (node:TNode<'a>) =
        let rec iPrint ret (current:TNode<'a> list) (next:TNode<'a> list) = 
            match current, next with
            | [], [] -> ret
            | [], next -> iPrint ret next []
            | node::rest, next -> 
                let ret = f node.value ret
                match node.left, node.right with
                | Some l, Some r -> 
                    iPrint ret rest (l::r::next)
                | Some n, None 
                | None, Some n -> 
                    iPrint ret rest (n::next)
                | None, None ->
                    iPrint ret rest next
        iPrint init [node] []

    let levelFoldOpt (f:'a option->'b->'b) (init:'b) (node:TNode<'a>) =
        let rec iPrint ret (current:(TNode<'a> option) list) (next:(TNode<'a> option) list) = 
            match current, next with
            | [], [] -> ret
            | [], next -> iPrint ret next []
            | (Some node)::rest, next ->
                let ret = f (Some node.value) ret
                iPrint ret rest (node.left::node.right::next)
            | None ::rest, next -> 
                let ret = f None ret
                iPrint ret rest next
        iPrint init [Some node] []

//    let printFold = levelFold (fun a b -> b + a.ToString()) ""
    let treeNodePrint = function
    | Some n -> n.ToString()
    | None -> "#"

    let printFold = levelFoldOpt (fun a b -> b + (treeNodePrint a)) ""


[<TestFixture>]
type LevelTraversal () = 
    [<Test>]
    member t.runTests () = 
        let l1 = TNode(3, Some (TNode(9, None, None)), 
                         Some (TNode(20, Some(TNode(15, None, None)),
                                          Some(TNode(7,None,None)))))
//        Assert.AreEqual(["3";"9";"20";"#";"#";"15";"7";"#";"#";"#";"#"], Tree.group(l1))
        //Assert.AreEqual(["3";"9";"20";"#";"#";"15";"7";"#";"#";"#";"#"], Tree.group(l1))
        Assert.AreEqual("3920##157####", Tree.printFold(l1))
