namespace FSharpLogic
open System
open UserHelpers

type Direction = Left | Down | Right | Up
type SpiralMatrix () =
    let l1 = [ [ 1; 2; 3 ];
                [ 4; 5; 6 ];
                [ 7; 8; 9 ] ]
    let l2 = [ [ 1; 2; 3; 4];
               [ 5; 6; 7; 8 ];
               [ 9; 10; 11; 12 ] 
               [ 13;14;15; 16 ] 
               ]
    let spiral (l1:int list list)  = 
        let size = l1.Length*l1.Length
        let rec ispiral ret r c d max min currentSize = 
           if currentSize = size then ret 
           else
               let ar = r+min
               let ac = c+min
               let v = l1.[ar].[ac]
               let next = (Cons(v, ret))
               match d with 
               | Right -> 
                  if ac <> max then
                     ispiral next r (c+1) Right max min (currentSize+1)
                  else ispiral ret r c Down max min currentSize
               | Down -> 
                  if ar <> max then
                     ispiral next (r+1) c Down max min (currentSize+1)
                  else ispiral ret r c Left max min currentSize
               | Left -> 
                  if ac <> min then
                    ispiral next r (c-1) Left max min (currentSize+1) 
                  else ispiral ret r c Up max min currentSize
               | Up -> 
                  if ar <> (min+1) then
                    ispiral next (r-1) c Up max min (currentSize+1)
                  else ispiral next 0 0 Right (max-1) (min+1) (currentSize+1)
        ispiral Empty 0 0 Right (l1.Length-1) 0 0 |> reverse
    member t.runTests () = 
        System.Console.WriteLine(spiral l2 |> toString )
        System.Console.WriteLine(spiral l2 |> toString |> ((=) "12348121615141395671110"))
        System.Console.WriteLine(spiral l1 |> toString )
        System.Console.WriteLine(spiral l1 |> toString |> ((=) "123698745"))