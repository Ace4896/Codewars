fn parts_sums(ls: &[u64]) -> Vec<u64> {
    let mut result = Vec::with_capacity(ls.len() + 1);

    let mut sum = ls.iter().sum();
    result.push(sum);

    for &val in ls {
        sum -= val;
        result.push(sum);
    }

    result
}

#[cfg(test)]
mod tests {
    use super::*;

    fn dotest(ls: Vec<u64>, expect: Vec<u64>) {
        let actual = parts_sums(&ls);
        assert_eq!(actual, expect);
    }

    #[test]
    fn example() {
        dotest(vec![], vec![0]);
        dotest(vec![0, 1, 3, 6, 10], vec![20, 20, 19, 16, 10, 0]);
        dotest(vec![1, 2, 3, 4, 5, 6], vec![21, 20, 18, 15, 11, 6, 0]);
        dotest(
            vec![
                744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358,
            ],
            vec![
                10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057,
                2580168, 2579358, 0,
            ],
        );
    }
}
