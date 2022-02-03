from math import sqrt


def find_next_square(sq: int):
    root = sqrt(sq)
    if not root.is_integer():
        return -1

    return (int(root) + 1) ** 2
