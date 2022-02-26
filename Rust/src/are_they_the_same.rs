fn comp(mut a: Vec<i64>, mut b: Vec<i64>) -> bool {
    if a.len() != b.len() {
        return false;
    }

    a.sort_unstable_by_key(|n| n.abs());
    b.sort_unstable_by_key(|n| n.abs());

    for (&num_a, &num_b) in a.iter().zip(b.iter()) {
        if num_a * num_a != num_b {
            return false;
        }
    }

    true
}

#[cfg(test)]
mod tests {
    use super::*;

    fn testing(a: Vec<i64>, b: Vec<i64>, exp: bool) -> () {
        assert_eq!(comp(a, b), exp)
    }

    #[test]
    fn comp_with_same_returns_true() {
        testing(
            vec![121, 144, 19, 161, 19, 144, 19, 11],
            vec![
                11 * 11,
                121 * 121,
                144 * 144,
                19 * 19,
                161 * 161,
                19 * 19,
                144 * 144,
                19 * 19,
            ],
            true,
        );
    }

    #[test]
    fn comp_with_not_same_returns_false() {
        testing(
            vec![121, 144, 19, 161, 19, 144, 19, 11],
            vec![
                11 * 21,
                121 * 121,
                144 * 144,
                19 * 19,
                161 * 161,
                19 * 19,
                144 * 144,
                19 * 19,
            ],
            false,
        );
    }
}
