from typing import List


def multiplication_table(size: int) -> List[List[int]]:
    table = []
    for n in range(1, size + 1):
        table.append([i * n for i in range(1, size + 1)])

    return table
