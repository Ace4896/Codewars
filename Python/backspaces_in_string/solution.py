def clean_string(s: str) -> str:
    chars = []
    for char in s:
        if char == "#":
            if len(chars) > 0:
                chars.pop()
        else:
            chars.append(char)

    return "".join(chars)
