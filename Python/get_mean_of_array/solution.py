from statistics import mean
from typing import List


def get_average(marks: List[int]) -> int:
    # Alternate: sum(marks) // len(marks)
    # // is for integer divisiion
    return int(mean(marks))
