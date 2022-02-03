import codewars_test as test
from solution import is_isogram


@test.describe("Fixed Tests")
def fixed_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(is_isogram("Dermatoglyphics"), True)
        test.assert_equals(is_isogram("isogram"), True)
        test.assert_equals(is_isogram("aba"), False, "same chars may not be adjacent")
        test.assert_equals(
            is_isogram("moOse"), False, "same chars may not be same case"
        )
        test.assert_equals(is_isogram("isIsogram"), False)
        test.assert_equals(is_isogram(""), True, "an empty string is a valid isogram")
