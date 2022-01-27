

let list = [ 1; 2; 3 ]

printfn "%A" (List.insertAt 2 4 list)
// [1; 2; 4; 3]

printfn "%A" (List.removeAt 0 list)
// [2; 3]

printfn "%A" (List.updateAt 0 5 list)
// [5; 2; 3]

printfn "%A" (List.insertManyAt 0 [9; 8] list)
// [9; 8; 1; 2; 3]

printfn "%A" (List.removeManyAt 1 2 list)
// [1]

