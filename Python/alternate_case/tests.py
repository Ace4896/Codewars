import codewars_test as test
from solution import alternate_case


@test.describe("Fixed Tests")
def fixed_tests():
    @test.it("Basic Test Cases")
    def basic_test_cases():
        test.assert_equals(alternate_case("ABC"), "abc")
        test.assert_equals(alternate_case(""), "")
        test.assert_equals(alternate_case(" "), " ")
        test.assert_equals(alternate_case("Hello World"), "hELLO wORLD")
        test.assert_equals(alternate_case("cODEwARS"), "CodeWars")
        test.assert_equals(
            alternate_case("i LIKE MAKING KATAS VERY MUCH"),
            "I like making katas very much",
        )
