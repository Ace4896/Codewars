def solution(number: int):
    return sum(x if x % 3 == 0 or x % 5 == 0 else 0 for x in range(number))
