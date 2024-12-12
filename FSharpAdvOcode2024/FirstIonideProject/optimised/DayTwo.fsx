
open System
open System.Diagnostics

// Function to check if the array is sorted ascending with pairwise differences in [1,3]
let isSortedAscending (arr: int[]) =
    let mutable isValid = true
    for i in 0 .. arr.Length - 2 do
        let diff = arr.[i + 1] - arr.[i]
        if diff < 1 || diff > 3 then
            isValid <- false
    isValid

// Function to check if the array is sorted descending with pairwise differences in [1,3]
let isSortedDescending (arr: int[]) =
    let mutable isValid = true
    for i in 0 .. arr.Length - 2 do
        let diff = arr.[i] - arr.[i + 1]
        if diff < 1 || diff > 3 then
            isValid <- false
    isValid

// Main optimization function
let optimizeSafeReports () =
    // Read all data from the file
    let data = System.IO.File.ReadAllText("DayTwo.txt")

    // Start the stopwatch
    let stopwatch = Stopwatch.StartNew()

    // Split the data by newlines once, removing empty entries
    let lines = data.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)

    let mutable safe_reports = 0  

    // Iterate through each line
    for i = 0 to lines.Length - 1 do
        // Split the line by spaces, removing empty entries to handle multiple spaces
        let parts = 
            lines.[i].Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.map int

        // Check if the parts are sorted ascending or descending with required differences
        if isSortedAscending parts || isSortedDescending parts then
            safe_reports <- safe_reports + 1

    // Stop the stopwatch
    stopwatch.Stop()

    // Output the results
    printfn "Elapsed time: %d microseconds" stopwatch.Elapsed.Microseconds
    printfn "Safe reports: %d" safe_reports

// Execute the optimization
optimizeSafeReports ()


// // part 2


        

