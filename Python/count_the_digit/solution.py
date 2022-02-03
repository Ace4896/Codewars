def nb_dig(n: int, d: int):
    total = 0
    d_str = str(d)

    for k in range(n + 1):
        squared_str = str(k**2)
        total += sum(1 for digit in squared_str if digit == d_str)

    return total
