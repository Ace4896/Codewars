from tkinter.tix import MAX
from typing import List


def sum_two_smallest_numbers(numbers: List[int]) -> int:
    if numbers[0] > numbers[1]:
        smallest = numbers[1]
        second_smallest = numbers[0]
    else:
        smallest = numbers[0]
        second_smallest = numbers[1]

    for i in range(2, len(numbers)):
        if numbers[i] < smallest:
            second_smallest = smallest
            smallest = numbers[i]
        elif numbers[i] < second_smallest:
            second_smallest = numbers[i]

    return smallest + second_smallest
