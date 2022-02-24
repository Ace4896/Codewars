// NOTE: Another solution would've been to use sort by key, and have the key be (weight_str, weight)
// Then there's no need to create an intermediate Vec at the beginning

fn get_weight(w: &str) -> Option<u32> {
    if w.is_empty() {
        None
    } else {
        Some(w.chars().filter_map(|digit| digit.to_digit(10)).sum())
    }
}

fn order_weight(s: &str) -> String {
    let mut weights = s
        .split_whitespace()
        .filter_map(|w_str| get_weight(w_str).map(|w| (w_str, w)))
        .collect::<Vec<_>>();

    weights.sort_by(
        |&(a_str, a), &(b_str, b)| {
            if a == b {
                a_str.cmp(&b_str)
            } else {
                a.cmp(&b)
            }
        },
    );

    weights
        .iter()
        .map(|&(w_str, _)| w_str)
        .collect::<Vec<_>>()
        .join(" ")
}

#[cfg(test)]
mod tests {
    use super::order_weight;

    fn testing(s: &str, exp: &str) -> () {
        assert_eq!(order_weight(s), exp)
    }

    #[test]
    fn basics_order_weight() {
        testing("103 123 4444 99 2000", "2000 103 123 4444 99");
        testing(
            "2000 10003 1234000 44444444 9999 11 11 22 123",
            "11 11 2000 10003 22 123 1234000 44444444 9999",
        );
    }
}
