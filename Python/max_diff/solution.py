from typing import List


def max_diff(lst: List[int]) -> int:
    # NOTE: For very large lists, it'd be better to loop manually and find the min and max at the same time
    if len(lst) <= 1:
        return 0

    return max(lst) - min(lst)
