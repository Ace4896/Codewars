import codewars_test as test
from solution import disemvowel


@test.describe("Fixed Tests")
def basic_tests():
    @test.it("First fixed test")
    def fixed_test_1():
        test.assert_equals(
            disemvowel("This website is for losers LOL!"), "Ths wbst s fr lsrs LL!"
        )
