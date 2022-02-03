VOWELS = {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}


def disemvowel(s: str):
    without_vowels = [ch for ch in s if ch not in VOWELS]
    return "".join(without_vowels)
