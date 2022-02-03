def longest(a1: str, a2: str):
    chars = set(a1) | set(a2)
    return "".join(sorted(chars))
