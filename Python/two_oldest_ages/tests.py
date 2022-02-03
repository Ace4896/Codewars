import codewars_test as test
from solution import two_oldest_ages


@test.describe("Sample Tests")
def basic_tests():
    test.assert_equals(two_oldest_ages([1, 5, 87, 45, 8, 8]), [45, 87])
    test.assert_equals(two_oldest_ages([6, 5, 83, 5, 3, 18]), [18, 83])
    test.assert_equals(two_oldest_ages([10, 1]), [1, 10])
