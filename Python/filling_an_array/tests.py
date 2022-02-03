import codewars_test as test
from solution import arr


@test.it("Basic Tests")
def basic_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(arr(4), [0, 1, 2, 3])
        test.assert_equals(arr(0), [])
        test.assert_equals(arr(), [])
