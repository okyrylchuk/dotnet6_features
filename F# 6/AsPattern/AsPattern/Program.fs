type Point = Point of int * int

let processInput (input: obj) =
    match input with
    | :? Point as Point (x, y) -> printfn $"A Point: {x}, {y}"
    | :? (int * int) as (x, y) -> printfn $"A tuple: {x}, {y}"
    | _ -> printfn "Bad input"

processInput(Point(1, 2))
processInput((1, 2))
processInput([1,2])
// Output:
// A Point: 1, 2
// A tuple: 1, 2
// Bad input

