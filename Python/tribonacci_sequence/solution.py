from typing import List


def tribonacci(signature: List[int], n: int) -> List[int]:
    if n == 0:
        return []

    if len(signature) > n:
        return signature[:n]

    seq = [] + signature
    for i in range(n - len(signature)):
        seq.append(seq[i] + seq[i + 1] + seq[i + 2])

    return seq
