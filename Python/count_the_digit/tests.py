import codewars_test as test
from solution import nb_dig

test.describe("nb_dig")
test.it("Basic tests")
test.assert_equals(nb_dig(10, 1), 4)
test.assert_equals(nb_dig(25, 1), 11)
test.assert_equals(nb_dig(5750, 0), 4700)
test.assert_equals(nb_dig(11011, 2), 9481)
test.assert_equals(nb_dig(12224, 8), 7733)
test.assert_equals(nb_dig(11549, 1), 11905)
