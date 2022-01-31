

[<return: Struct>]
let (|Int|_|) (str:string) =
    match System.Int32.TryParse(str) with
    | true, int -> ValueSome(int)
    | _ -> ValueNone


