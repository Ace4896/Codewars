# NOTE: This is provided by the solution, so local tests won't work
MORSE_CODE = dict()


def decode_morse(morse_code: str):
    visible_spaces = morse_code.strip().replace("   ", " s ")
    return "".join(
        " " if x == "s" else MORSE_CODE[x] for x in visible_spaces.split(" ")
    )
