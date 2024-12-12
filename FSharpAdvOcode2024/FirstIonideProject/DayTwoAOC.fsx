open System
open System.Diagnostics

let data: string = System.IO.File.ReadAllText("DayTwo.txt")

// Start the stopwatch
// let stopwatch: Stopwatch = Stopwatch.StartNew()

// // Split the data by newlines once
// let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

// let mutable safe_reports: int = 0  
// for i: int32 in 0..lines.Length-1 do
//     // Split the line only once
//     let parts = lines.[i].Split([|" "|], StringSplitOptions.None)
//                 |> Array.map int
    
//     let ascending = parts |> Array.sort
//     let descending = parts |> Array.sortByDescending id

//     if parts = ascending then
//         let isSafeAscending = 
//             ascending
//             |> Array.pairwise
//             |> Array.forall (fun (a, b) -> 
//                 let diff = b - a
//                 diff <= 3 && diff >= 1
//             )

//         if isSafeAscending then
//             safe_reports <- safe_reports + 1

//         if parts = descending then
//             let isSafeDescending = 
//                 descending
//                     |> Array.pairwise
//                     |> Array.forall (fun (a, b) -> 
//                         let diff = a - b
//                         diff <= 3 && diff >= 1
//                     )

//             if isSafeDescending then
//                 safe_reports <- safe_reports + 1

// stopwatch.Stop()

// printfn "Elapsed time: %A microseconds" stopwatch.Elapsed.Microseconds

// printfn "Safe reports: %A" safe_reports



// pt2

let stopwatch1: Stopwatch = Stopwatch.StartNew()
let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)
let isAscending (arr: int[]) =
    let mutable falseCount = 0
    let result = 
        arr
        |> Array.pairwise
        |> Array.forall (fun (a, b) -> 
            let superior = b > a
            let diff = b - a <= 3
            if superior && diff then true
            else if 
                superior = false && a - b <= 3 then 
                falseCount <- falseCount + 1
                falseCount <= 1
            else  
                false
                // falseCount <- falseCount + 1
                // falseCount <= 1
        )
    printfn "\n"
    printfn "arr: %A" arr
    printfn "falseCount: %d & result: %A" falseCount result
    if result then 
        printfn "result: %A" result 
        1
    else 
        printfn "Number of times false: %d" falseCount
        0

let isDescending (arr: int[]) =
    let mutable falseCount = 0
    let result = 
        arr
        |> Array.pairwise
        |> Array.forall (fun (a, b) -> 
            let inferior = b < a
            let diff = a - b <= 3
            if inferior && diff then true
            else if
                inferior = false && b - a <= 3 then
                falseCount <- falseCount + 1
                falseCount <= 1
            else  
                false
                // falseCount <- falseCount + 1
                // falseCount <= 1
        )
    printfn "\n"
    printfn "arr: %A" arr
    printfn "falseCount: %d" falseCount
    if result then 
        printfn "result: %A" result 
        1
    else 
        printfn "Number of times false: %d" falseCount
        0


let mutable safe_reports: int = 0  
for i: int32 in 0..lines.Length-1 do
    // Split the line only once
    let parts = lines.[i].Split([|" "|], StringSplitOptions.None)
                |> Array.map int 

    if isAscending parts = 1 || isDescending parts = 1 then
        safe_reports <- safe_reports + 1
    // safe_reports <- safe_reports + isAscending parts
    // safe_reports <- safe_reports + isDescending parts
    printfn "res: %A" safe_reports

stopwatch1.Stop()
printfn "Elapsed time: %A microseconds" stopwatch1.Elapsed.Microseconds
printfn "Safe reports: %A" safe_reports




// open System
// open System.Diagnostics
// let lines: string array = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

// let isAscending (arr: int[]) =
//     let mutable falseCount = 0
//     let result = 
//         arr
//         |> Array.pairwise
//         |> Array.forall (fun (a, b) -> 
//             let superior = b > a
//             let diff = b - a <= 3
//             if superior && diff then true
//             else if not superior && a - b <= 3 then 
//                 falseCount <- falseCount + 1
//                 falseCount <= 1
//             else  
//                 false
//         )
//     if result then 1 else 0

// let isDescending (arr: int[]) =
//     let mutable falseCount = 0
//     let result = 
//         arr
//         |> Array.pairwise
//         |> Array.forall (fun (a, b) -> 
//             let inferior = b < a
//             let diff = a - b <= 3
//             if inferior && diff then true
//             else if not inferior && b - a <= 3 then
//                 falseCount <- falseCount + 1
//                 falseCount <= 1
//             else  
//                 false
//         )
//     if result then 1 else 0

// let runProcess () =
//     let mutable safe_reports = 0  
//     for i in 0..lines.Length-1 do
//         let parts = lines.[i].Split([|" "|], StringSplitOptions.None) |> Array.map int 
//         if isAscending parts = 1 || isDescending parts = 1 then
//             safe_reports <- safe_reports + 1
//     safe_reports

// let executionTimes = 
//     [| for _ in 1..100000 do
//         let stopwatch = Stopwatch.StartNew()
//         let _ = runProcess()
//         stopwatch.Stop()
//         stopwatch.Elapsed.TotalMilliseconds |]

// Array.sortInPlace executionTimes

// let minTime = executionTimes.[0]
// let q1Time = executionTimes.[executionTimes.Length / 4]
// let medianTime = executionTimes.[executionTimes.Length / 2]
// let q3Time = executionTimes.[3 * executionTimes.Length / 4]
// let maxTime = executionTimes.[executionTimes.Length - 1]

// printfn "Min time: %f ms" minTime
// printfn "25%% quartile: %f ms" q1Time
// printfn "Median time: %f ms" medianTime
// printfn "75%% quartile: %f ms" q3Time
// printfn "Max time: %f ms" maxTime