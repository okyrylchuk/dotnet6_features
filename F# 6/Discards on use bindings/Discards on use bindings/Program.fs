open System

let disposable () = { new IDisposable with
                            member x.Dispose() = ()}

let example () =
    use _ = disposable ()
    printfn "discard on use binding"