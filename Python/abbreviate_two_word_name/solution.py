def abbrev_name(name: str):
    names = name.split(" ")
    return f"{names[0][0].upper()}.{names[1][0].upper()}"
