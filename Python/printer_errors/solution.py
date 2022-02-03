def printer_error(s: str):
    invalid_count = sum(1 for ctrl in s if ctrl > "m" and ctrl <= "z")
    total = len(s)
    return f"{invalid_count}/{total}"
