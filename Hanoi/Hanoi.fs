module HanoiSolver

open Xunit
open FsUnit.Xunit

let rec Solve start temp destination diskNumber =
    match diskNumber with
    | diskNumber when diskNumber <= 0 -> []
    | _ ->  Solve start destination temp (diskNumber - 1)
            @ [start,destination] @
            Solve temp start  destination (diskNumber - 1)

type ``Hanoi tests`` ()=
    [<Fact>] member test.
     ``Should not make move when there is zero discs`` ()=
        Solve  'a' 'b' 'c' 0 |> should be Empty

    [<Fact>] member test.
     ``Should not make move when there is less than zero discs`` ()=
        Solve  'a' 'b' 'c' -10 |> should be Empty

    [<Fact>] member test.
     ``Should make 3 specyfic moves given two disks`` ()=
        let expecteMoves = [('a','b'); ('a','c'); ('b','c')]

        in let actualMoves = Solve  'a' 'b' 'c' 2
        in Assert.Equal<(char*char)list>(expecteMoves, actualMoves)

    [<Fact>] member test.
     ``Should make 7 moves given three disks`` ()=
        Solve  'a' 'b' 'c' 3 |> should haveLength 7