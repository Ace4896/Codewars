def alternate_case(s: str):
    # NOTE: There is the swapcase function
    # So answer could just be s.swapcase()
    return "".join([x.upper() if x.islower() else x.lower() for x in s])
