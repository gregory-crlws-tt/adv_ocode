# import numpy as np
# import time

# # Read the data from the file
# with open("DayTwo.txt", "r") as file:
#     data = file.read()

# # Start the stopwatch
# start_time = time.time()

# # Split the data by newlines once
# lines = data.strip().split('\n')

# safe_reports = 0
# for line in lines:
#     # Split the line only once
#     parts = np.array(list(map(int, line.split())))

#     ascending = np.sort(parts)
#     descending = np.sort(parts)[::-1]

#     if np.array_equal(parts, ascending):
#         is_safe_ascending = all(1 <= b - a <= 3 for a, b in zip(ascending[:-1], ascending[1:]))
#         if is_safe_ascending:
#             safe_reports += 1

#     if np.array_equal(parts, descending):
#         is_safe_descending = all(1 <= a - b <= 3 for a, b in zip(descending[:-1], descending[1:]))
#         if is_safe_descending:
#             safe_reports += 1

# # Stop the stopwatch
# elapsed_time = (time.time() - start_time) * 1e6  # Convert to microseconds

# print(f"Elapsed time: {elapsed_time:.0f} microseconds")
# print(f"Safe reports: {safe_reports}")

# # import numpy as np
# # import time

# # # Read the data from the file
# # with open("DayTwo.txt", "r") as file:
# #     data = file.read()

# # # Start the stopwatch
# # start_time = time.time()

# # # Split the data by newlines once
# # lines = data.strip().split('\n')

# # safe_reports = 0
# # for line in lines:
# #     # Split the line only once
# #     parts = np.array(list(map(int, line.split())))

# #     ascending = np.sort(parts)
# #     descending = ascending[::-1]

# #     if np.array_equal(parts, ascending):
# #         diffs = np.diff(ascending)
# #         if np.all((1 <= diffs) & (diffs <= 3)):
# #             safe_reports += 1

# #     if np.array_equal(parts, descending):
# #         diffs = np.diff(descending)
# #         if np.all((1 <= diffs) & (diffs <= 3)):
# #             safe_reports += 1

# # # Stop the stopwatch
# # elapsed_time = (time.time() - start_time) * 1e6  # Convert to microseconds

# # print(f"Elapsed time: {elapsed_time:.0f} microseconds")
# # print(f"Safe reports: {safe_reports}")

import numpy as np
import time

def optimize_safe_reports(file_path):
    # Read the data from the file
    with open(file_path, "r") as file:
        data = file.read()

    # Start the stopwatch
    start_time = time.time()

    # Split the data by newlines once
    lines = data.strip().split('\n')

    safe_reports = 0

    # Pre-convert all lines into NumPy arrays for faster processing
    # This avoids repeated calls to list(map(int, ...)) within the loop
    all_parts = [np.fromstring(line, sep=' ', dtype=int) for line in lines if line.strip()]

    for parts in all_parts:
        if parts.size < 2:
            # Cannot compute differences with less than 2 elements
            continue

        # Check if the array is sorted ascending
        is_ascending = np.all(parts[:-1] <= parts[1:])
        if is_ascending:
            diffs = np.diff(parts)
            if np.all((diffs >= 1) & (diffs <= 3)):
                safe_reports += 1

        # Check if the array is sorted descending
        is_descending = np.all(parts[:-1] >= parts[1:])
        if is_descending:
            diffs = np.diff(parts)
            if np.all((diffs >= -3) & (diffs <= -1)):
                safe_reports += 1

    # Stop the stopwatch
    elapsed_time = (time.time() - start_time) * 1e6  # Convert to microseconds

    print(f"Elapsed time: {elapsed_time:.0f} microseconds")
    print(f"Safe reports: {safe_reports}")

if __name__ == "__main__":
    optimize_safe_reports("DayTwo.txt")
