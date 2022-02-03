import codewars_test as test
from solution import rot13

test.assert_equals(rot13("test"), "grfg")
test.assert_equals(rot13("Test"), "Grfg")
