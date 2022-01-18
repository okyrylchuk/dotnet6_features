open System.IO

let readFileTask (path) =
   task {
        let! text = File.ReadAllTextAsync(path)
        return text
   }
