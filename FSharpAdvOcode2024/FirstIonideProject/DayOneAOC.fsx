// read data from file DayOne.txt
let data: string = System.IO.File.ReadAllText("DayOne.txt")

open System.Diagnostics

let stopwatch = Stopwatch.StartNew()

let lines1 = data.Split('\n') 

let orderedDataLeft1 : int array = 
    lines1
    |> Array.map (fun x -> x.Split("   ").[0]) 
    |> Array.map int
    |> Array.sort

let orderedDataRight1 = 
    lines1 
    |> Array.map (fun x -> x.Split("   ").[1]) 
    |> Array.map int
    |> Array.sort

let absoluteDifference1 = 
    Array.zip orderedDataLeft1 orderedDataRight1 
    |> Array.map (fun (x: int, y) -> y - x) 
    |> Array.map abs 
    |> Array.sum

stopwatch.Stop()

printfn "absoluteDifferencearr1"
printfn "%A" absoluteDifference1
printfn "Elapsed time: %A microseconds" stopwatch.Elapsed.Microseconds





// part 2
let stopwatch1: Stopwatch = Stopwatch.StartNew()

let leftValues: int array = orderedDataLeft1
let rightValues: int array = orderedDataRight1

let rightValuesDict: Map<int,int> = rightValues |> Array.countBy id |> Map.ofArray

let mutable finalSum = 0

for i: int32 in 0 .. leftValues.Length - 1 do
    let value: int = 
        match rightValuesDict.TryGetValue(leftValues.[i]) with
        | (true, v: int) -> v
        | (false, _) -> 0
    finalSum <- finalSum + (leftValues.[i] * value)

stopwatch1.Stop()
printfn "finalSum"
printfn "%A" finalSum
printfn "Elapsed time: %A microseconds" stopwatch1.Elapsed.Microseconds

// open System
// open System.Diagnostics
// open System.Collections.Generic

// let stopwatch1: Stopwatch = Stopwatch.StartNew()

// // Convert rightValues to a dictionary for O(1) lookups
// let counts = rightValues |> Array.countBy id

// // printfn "counts: %A" counts
// let dict = Dictionary<int,int>(counts.Length)


// for (k,v) in counts do
//     dict.[k] <- v

// let mutable finalSum = 0
// for lv in leftValues do
//     // Fast dictionary lookup
//     let count = 
//         match dict.TryGetValue(lv) with
//         | true, cnt -> cnt
//         | false, _  -> 0
//     finalSum <- finalSum + (lv * count)

// stopwatch1.Stop()
// printfn "finalSum: %A" finalSum
// printfn "Elapsed time: %A microseconds" stopwatch1.Elapsed.Microseconds
