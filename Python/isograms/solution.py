def is_isogram(string: str) -> bool:
    used_chars = set(string.lower())
    return len(string) == len(used_chars)
