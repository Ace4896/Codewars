// NOTE: Correct, but way too slow!
// - 100 seconds: Counting 2's and 5's separately
// - 72 seconds: Counting 2's and 5's together
// - 56 seconds: Counting total 5's only
//
// The idea is there, but I'm not sure how to do it faster...
// - LeetCode Discussions: https://leetcode.com/problems/factorial-trailing-zeroes/discuss/?currentPage=1&orderBy=hot&query=
// - Turns out that no. of fives is always less than number of twos - duh...

// This solution counts how many 5's are present in the prime factorization of n; runs in O(log n)
// Example for n = 30:
// - Numbers up to 30 that are divisible by 5: 5, 10, 15, 20, 25, 30
//   - 6 total - add to counter
//   - Set n = 6
// - Numbers up to 6 that are divisible by 5: 5
//   - 1 total - add to counter
//   - Set n = 1
// - n < 6, so stop
// - Trailing Zeroes: 7
fn zeros(mut n: u64) -> u64 {
    if n == 0 {
        return 0;
    }

    let mut fives = 0;
    while n >= 5 {
        let count = n / 5;
        fives += count;
        n = count;
    }

    fives
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn sample_tests() {
        assert_eq!(zeros(0), 0);
        assert_eq!(zeros(6), 1);
        assert_eq!(zeros(14), 2);
        assert_eq!(zeros(30), 7);
        assert_eq!(zeros(1000), 249);
        assert_eq!(zeros(100000), 24999);
        assert_eq!(zeros(1000000000), 249999998);
    }
}
