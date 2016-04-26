namespace FSharpLogic
open System
open UserHelpers

type Direction = Left | Down | Right | Up
type SpiralMatrix () =
    let l1 = [ [ 1; 2; 3 ];
                [ 4; 5; 6 ];
                [ 7; 8; 9 ] ]
    let spiral (l1:int list list)  = 
        let size = l1.Length*l1.Length
        let rec ispiral ret r c d max min currentSize = 
           if currentSize = size then ret 
           else
               let v = l1.[r+min].[c+min]
               let next = (Cons(v, ret))
               match d with 
               | Right -> 
                  if c = max then
                    ispiral next (r+1) c Down max min (currentSize+1)
                  else ispiral next r (c+1) Right max min (currentSize+1)
               | Down -> 
                  if r = max then
                    ispiral next (r-1) c Left max min (currentSize+1)
                  else ispiral next (r+1) c Down max min (currentSize+1)
               | Left -> 
                  if c = min then
                    ispiral next r (c-1) Up max min (currentSize+1)
                  else ispiral next (r+1) c Down max min (currentSize+1) 
               | Up -> 
                  if r = (min+1) then
                    ispiral next r (c+1) Right (max-1) (min+1) (currentSize+1)
                  else ispiral next (r+1) c Up max min (currentSize+1)
        ispiral Empty 0 0 Left (l1.Length-1) 0 0
    member t.runTests () = 
        System.Console.WriteLine(spiral l1 |> toString )
        System.Console.WriteLine(spiral l1 |> toString |> ((=) "123698745"))