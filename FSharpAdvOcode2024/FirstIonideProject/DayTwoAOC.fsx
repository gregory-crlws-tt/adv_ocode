let data: string = System.IO.File.ReadAllText("DayTwo.txt")

open System
open System.Diagnostics

// Start the stopwatch
let stopwatch: Stopwatch = Stopwatch.StartNew()

// Split the data by newlines once
let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

let mutable safe_reports: int = 0  
for i: int32 in 0..lines.Length-1 do
    // Split the line only once
    let parts = lines.[i].Split([|" "|], StringSplitOptions.None)
                |> Array.map int
    
    let ascending = parts |> Array.sort
    let descending = parts |> Array.sortByDescending id

    if parts = ascending then
        let isSafeAscending = 
            ascending
            |> Array.pairwise
            |> Array.forall (fun (a, b) -> b - a <= 3 && b - a >= 1)

        if isSafeAscending then
            // printfn "\n"
            // printfn "Parts asc: %A" parts
            // printfn "Sorted Parts asc: %A" ascending
            safe_reports <- safe_reports + 1

    if parts = descending then
        let isSafeDescending = 
            descending
            |> Array.pairwise
            |> Array.forall (fun (a, b) -> a - b <= 3 && a - b >= 1)

        if isSafeDescending then
            // printfn "\n"
            // printfn "Parts desc: %A" parts
            // printfn "Sorted Parts desc: %A" descending
            safe_reports <- safe_reports + 1

stopwatch.Stop()

printfn "Elapsed time: %A microseconds" stopwatch.Elapsed.Microseconds

printfn "Safe reports: %A" safe_reports




        

