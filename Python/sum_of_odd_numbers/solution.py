def row_sum_odd_numbers(n: int):
    # NOTE: There's a better solution:
    # Observe the pattern when adding each row:
    # 1 --> 1
    # 2 --> 3 + 5 = 8
    # 3 --> 7 + 9 + 11 = 27
    #
    # This is just n cubed...
    # So a one line answer is n ** 3

    # First number for this sequence is determined by this sequence:
    # an: 1 3 7 13 21 ...
    # 1st diff: 2 4 6 8 ...
    # 2nd diff: 2 2 2 ...
    #
    # Since 2nd diff is the same, this corresponds to a quadratic sequence where the nth term is:
    # an = n^2 + bn + c
    #
    # After solving for b and c (by substituting values of n), we get:
    # an = n^2 - n + 1
    first_num = (n * n) - n + 1

    # Each row can be represented using an arithmetic sequence, where the difference is 2
    # This can be summed using:
    # n/2 * (2a + (n-1)d)
    # a = first term = first_num
    # d = common difference = 2
    # n = number of values to sum (which is also number of values in the nth row)
    numerator = n * (2 * first_num + (n - 1) * 2)
    return numerator / 2
