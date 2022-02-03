import codewars_test as test
from solution import clean_string

test.assert_equals(clean_string("abc#d##c"), "ac")
test.assert_equals(clean_string("abc####d##c#"), "")
test.assert_equals(clean_string("#######"), "")
test.assert_equals(clean_string(""), "")
