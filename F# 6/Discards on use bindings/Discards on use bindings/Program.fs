// https://twitter.com/okyrylchuk/status/1482089389832429574

open System

let disposable () = { new IDisposable with
                            member x.Dispose() = ()}

let example () =
    use _ = disposable ()
    printfn "discard on use binding"