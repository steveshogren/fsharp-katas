namespace FSharpLogic
open System
open UserHelpers
open NUnit.Framework

type TNode<'a> (v:'a, left:TNode<'a> option, right:TNode<'a> option) =
    new (v:'a) = TNode(v, None, None)
    new (v:'a, l:'a, r:'a) = TNode(v, Some(TNode(l)), Some(TNode(r)))
    new (v:'a, l:TNode<'a>, r:TNode<'a>) = TNode(v, Some(l), Some(r))

    member val value = v with get, set
    member val left = left with get, set
    member val right = right with get, set

module Tree =

    let levelFoldOpt (f:'a option->'b->'b) (init:'b) (node:TNode<'a>) =
        let rec iPrint ret (current:(TNode<'a> option) list) (next:(TNode<'a> option) list) = 
            match current, next with
            | [], [] -> ret
            | [], next -> iPrint ret next []
            | (Some node)::rest, next ->
                let ret = f (Some node.value) ret
                let next = List.append next [node.left;node.right]
                iPrint ret rest next
            | None ::rest, next -> 
                let ret = f None ret
                iPrint ret rest next
        iPrint init [Some node] []

    let treeNodePrint = function
    | Some n -> n.ToString()
    | None -> "#"

    let printFold = levelFoldOpt (fun next ret -> ret+(treeNodePrint next)) ""

    let levels (node:TNode<'a>) =
        let rec ilevels (ret:'a list list) (pre_ret:'a list) (current:TNode<'a> list) (next:TNode<'a> list) =
            match current, next with
            | [], [] -> ret@[pre_ret]
            | [], next -> ilevels (ret@[pre_ret]) [] next []
            | node::rest, next -> 
                let v = node.value
                let pre_ret = pre_ret@[v]
                match node.left, node.right with
                | Some l, Some r -> ilevels ret pre_ret rest (next@[l;r])
                | None, Some n
                | Some n, None -> ilevels ret pre_ret rest (next@[n])
                | None, None -> ilevels ret pre_ret rest next
        ilevels [] [] [node] []


    let inOrderFold (f:'a->'b->'b) (init:'b) (node:TNode<'a>) =
        let rec folder ret (current:TNode<'a> option) = 
            match current with
            | None -> ret
            | Some node ->
                let ret = f node.value ret
                let ret = folder ret node.left
                folder ret node.right
        let r = folder init (Some node)
        Console.WriteLine(r)
        r

    let inOrder = inOrderFold (fun next ret -> ret@[next]) []

[<TestFixture>]
type LevelTraversal () = 
    [<Test>]
    member t.runTests () = 
        let l1 = TNode(3, TNode(9, Some(TNode 0), None),
                          TNode(20, 15, 7))
        Assert.AreEqual([3;9;0;20;15;7], Tree.inOrder(l1))

        let l1 = TNode(3, TNode(9), 
                          TNode(20, TNode(15,6,4), TNode 7))
        Assert.AreEqual([[3];[9;20];[15;7];[6;4]], Tree.levels(l1))
//        Assert.AreEqual(l1, (Tree.makeTree ["3";"9";"20";"#";"#";"15";"7";"#";"#";"#";"#"]))
        //Assert.AreEqual(["3";"9";"20";"#";"#";"15";"7";"#";"#";"#";"#"], Tree.group(l1))
        let l1 = TNode(3, TNode(9), 
                          TNode(20, 15, 7))
        Assert.AreEqual("3920##157####", Tree.printFold(l1))
