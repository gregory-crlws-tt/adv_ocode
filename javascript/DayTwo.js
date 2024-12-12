const fs = require('fs');
const { performance } = require('perf_hooks');

// Read the data from the file
const data = fs.readFileSync('DayTwo.txt', 'utf8');

// Start the stopwatch
const startTime = performance.now();

// Split the data by newlines once
const lines = data.trim().split('\n');

let safeReports = 0;
for (const line of lines) {
    // Split the line only once
    const parts = line.split(' ').map(Number);

    const ascending = [...parts].sort((a, b) => a - b);
    const descending = [...parts].sort((a, b) => b - a);

    if (JSON.stringify(parts) === JSON.stringify(ascending)) {
        const isSafeAscending = ascending.every((value, index, array) => {
            if (index === 0) return true;
            const diff = array[index] - array[index - 1];
            return diff >= 1 && diff <= 3;
        });

        if (isSafeAscending) {
            safeReports += 1;
        }
    }

    if (JSON.stringify(parts) === JSON.stringify(descending)) {
        const isSafeDescending = descending.every((value, index, array) => {
            if (index === 0) return true;
            const diff = array[index - 1] - array[index];
            return diff >= 1 && diff <= 3;
        });

        if (isSafeDescending) {
            safeReports += 1;
        }
    }
}

// Stop the stopwatch
const elapsedTime = (performance.now() - startTime) * 1000; // Convert to microseconds

console.log(`Elapsed time: ${elapsedTime.toFixed(0)} microseconds`);
console.log(`Safe reports: ${safeReports}`);