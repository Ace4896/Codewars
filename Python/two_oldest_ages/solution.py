from typing import List


def two_oldest_ages(ages: List[int]) -> List[int]:
    if ages[0] > ages[1]:
        oldest, second_oldest = ages[0], ages[1]
    else:
        oldest, second_oldest = ages[1], ages[0]

    for age in ages[2:]:
        if age > oldest:
            second_oldest = oldest
            oldest = age
        elif age > second_oldest:
            second_oldest = age

    return [second_oldest, oldest]
