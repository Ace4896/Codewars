from typing import Tuple


def longest_repetition(chars: str) -> Tuple[str, int]:
    # NOTE: There's a cleaner solution where we perform the current/longest swap after checking if the character matches:
    # max_char, max_count = '', 0
    # char, count = '', 0
    # for c in chars:
    #     if c != char:
    #         count, char = 0, c
    #     count += 1
    #     if count > max_count:
    #         max_char, max_count = char, count
    # return max_char, max_count

    longest_char = ""
    longest_count = 0

    current_char = ""
    current_count = 0

    for char in chars:
        if char != current_char:
            if current_count > longest_count:
                (longest_char, longest_count) = (current_char, current_count)

            current_char = char
            current_count = 1
        else:
            current_count += 1

    if current_count > longest_count:
        (longest_char, longest_count) = (current_char, current_count)

    return (longest_char, longest_count)
