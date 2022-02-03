import codewars_test as test
from solution import get_average


@test.describe("Fixed Tests")
def fixed_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(get_average([2, 2, 2, 2]), 2, "didn't work for [2, 2, 2, 2]")
        test.assert_equals(
            get_average([1, 5, 87, 45, 8, 8]),
            25,
            "didn't work for [1, 5, 87, 45, 8, 8]",
        )
        test.assert_equals(
            get_average([2, 5, 13, 20, 16, 16, 10]),
            11,
            "didn't work for [2,5,13,20,16,16,10]",
        )
        test.assert_equals(
            get_average([1, 2, 15, 15, 17, 11, 12, 17, 17, 14, 13, 15, 6, 11, 8, 7]),
            11,
            "didn't work for [1,2,15,15,17,11,12,17,17,14,13,15,6,11,8,7]",
        )
