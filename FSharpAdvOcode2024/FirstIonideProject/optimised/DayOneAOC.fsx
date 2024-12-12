open System
open System.Diagnostics


let data: string = System.IO.File.ReadAllText("../DayOne.txt")

let stopwatch: Stopwatch = Stopwatch.StartNew()

let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

// Pre-allocate arrays for left and right values
let leftValues: int array = Array.zeroCreate<int> lines.Length
let rightValues: int array = Array.zeroCreate<int> lines.Length

for i: int32 in 0..lines.Length-1 do
    // Split the line only once
    // If you know the delimiter is three spaces, you can do:
    let parts = lines.[i].Split([|"   "|], StringSplitOptions.None)
    // Convert directly to int
    let leftVal = int parts.[0]
    let rightVal = int parts.[1]

    leftValues.[i] <- leftVal
    rightValues.[i] <- rightVal

// Sort the arrays in-place
Array.sortInPlace leftValues
Array.sortInPlace rightValues

// Compute the sum of absolute differences in one pass
let mutable absoluteDifference = 0
for i: int32 in 0..leftValues.Length - 1 do
    absoluteDifference <- absoluteDifference + abs (rightValues.[i] - leftValues.[i])

// Stop timing
stopwatch.Stop()

printfn "absoluteDifferencearr1"
printfn "%A" absoluteDifference
printfn "Elapsed time: %A microseconds" stopwatch.Elapsed.Microseconds



// part 2

open System
open System.Diagnostics
open System.Collections.Generic

let stopwatch1: Stopwatch = Stopwatch.StartNew()

// Convert rightValues to a dictionary for O(1) lookups
let counts = rightValues |> Array.countBy id
printfn "counts: %A" counts

// printfn "counts: %A" counts
let dict = Dictionary<int,int>(counts.Length)


for (k,v) in counts do
    dict.[k] <- v

let mutable finalSum = 0
for lv in leftValues do
    // Fast dictionary lookup
    let count = 
        match dict.TryGetValue(lv) with
        | true, cnt -> cnt
        | false, _  -> 0
    finalSum <- finalSum + (lv * count)

stopwatch1.Stop()
printfn "finalSum: %A" finalSum
printfn "Elapsed time: %A microseconds" stopwatch1.Elapsed.Microseconds

printfn "Total Elapsed time: %A microseconds" (stopwatch.Elapsed.Microseconds + stopwatch1.Elapsed.Microseconds)
