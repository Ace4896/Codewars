import codewars_test as test
from solution import max_diff


@test.describe("Fixed Tests")
def fixed_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(max_diff([0, 1, 2, 3, 4, 5, 6]), 6)
        test.assert_equals(max_diff([-0, 1, 2, -3, 4, 5, -6]), 11)
        test.assert_equals(max_diff([0, 1, 2, 3, 4, 5, 16]), 16)
        test.assert_equals(max_diff([16]), 0)
        test.assert_equals(max_diff([]), 0)
