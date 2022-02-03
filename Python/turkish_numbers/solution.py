UNITS = {
    0: "sıfır",
    1: "bir",
    2: "iki",
    3: "üç",
    4: "dört",
    5: "beş",
    6: "altı",
    7: "yedi",
    8: "sekiz",
    9: "dokuz",
}

TENS = {
    1: "on",
    2: "yirmi",
    3: "otuz",
    4: "kırk",
    5: "elli",
    6: "altmış",
    7: "yetmiş",
    8: "seksen",
    9: "doksan",
}


def get_turkish_number(num: int) -> str:
    if num < 10:
        return UNITS[num]
    elif num % 10 == 0:
        return TENS[num // 10]
    else:
        return f"{TENS[num // 10]} {UNITS[num % 10]}"
