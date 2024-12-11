let data: string = System.IO.File.ReadAllText("DayTwo.txt")

open System
open System.Diagnostics

// Start the stopwatch
let stopwatch: Stopwatch = Stopwatch.StartNew()

// Split the data by newlines once
let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

// Pre-allocate arrays for left and right values
// let values: int array = Array.zeroCreate<int> lines.Length

let safe_reports: int  = 0  
for i: int32 in 0..lines.Length-1 do
    // Split the line only once
    // If you know the delimiter is three spaces, you can do:
    let parts = lines.[i].Split([|" "|], StringSplitOptions.None)
    
    let mutable first = 0
    for i in 0..parts.Length-1 do
        if int(parts.[i]) > first then
            first <- int(parts.[i])
        

