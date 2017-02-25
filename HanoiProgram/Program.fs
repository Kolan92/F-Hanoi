open HanoiSolver
open System

[<EntryPoint>]
let main argv = 
    Solve  'a' 'b' 'c' 4 |>
    List.iter (fun pair -> match pair with
    | start, destination -> printfn "Move the disc from %c to %c" start destination)
     
    Console.ReadLine() |> ignore
    0 
