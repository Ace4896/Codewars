import codewars_test as test
from solution import multiplication_table

test.describe("Basic Tests")
test.it("Should pass basic tests")
test.assert_equals(multiplication_table(3), [[1,2,3],[2,4,6],[3,6,9]])
