import codewars_test as test
from solution import check_alive


@test.describe("Fixed Tests")
def fixed_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(check_alive(5), True)
        test.assert_equals(check_alive(0), False)
        test.assert_equals(check_alive(-5), False)
