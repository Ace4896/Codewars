def rot13(message: str) -> str:
    output = []
    for char in message:
        if char.isalpha():
            last_char_ascii = ord("Z") if char.isupper() else ord("z")
            new_char = (
                chr(ord(char) + 13)
                if ord(char) + 13 <= last_char_ascii
                else chr(ord(char) - 13)
            )
            output.append(new_char)
        else:
            output.append(char)

    return "".join(output)
