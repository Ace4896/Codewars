fn gcd(x: i64, y: i64) -> i64 {
    let (mut a, mut b) = if x > y { (x, y) } else { (y, x) };
    let mut remainder: i64;

    while b > 0 {
        remainder = a % b;
        a = b;
        b = remainder;
    }

    a
}

fn lcm(x: i64, y: i64) -> i64 {
    x * y / gcd(x, y)
}

fn sum_fracts(l: Vec<(i64, i64)>) -> Option<(i64, i64)> {
    if l.is_empty() {
        return None;
    } else if l.len() == 1 {
        return Some(l[0]);
    }

    // Find the LCM for all of the denominators
    let first_denominator = l[0].1;
    let lcm = l
        .iter()
        .skip(1)
        .map(|&(_, d)| d)
        .fold(first_denominator, |acc, d| lcm(acc, d));

    // Convert all to same denominator, then sum
    let sum = l
        .iter()
        .map(|&(numerator, denominator)| {
            let factor = lcm / denominator;
            (numerator * factor, lcm)
        })
        .fold((0, lcm), |(total_numerator, lcm), (numerator, _)| {
            (total_numerator + numerator, lcm)
        });

    // Finally, reduce the sum
    let gcd = gcd(sum.0, sum.1);
    Some((sum.0 / gcd, sum.1 / gcd))
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn returns_expected() {
        assert_eq!(sum_fracts(vec![(1, 2), (1, 3), (1, 4)]), Some((13, 12)));
        assert_eq!(sum_fracts(vec![(1, 3), (5, 3)]), Some((2, 1)));
        assert_eq!(
            sum_fracts(vec![(10, 20), (100, 300), (10, 40)]),
            Some((13, 12))
        );
    }
}
