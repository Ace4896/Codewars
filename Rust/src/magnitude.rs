struct S {
    s: String,
    xs: Vec<i32>,
}

fn reverse_sort_num(num: i32) -> i32 {
    let mut rearr = num.to_string().chars().collect::<Vec<_>>();
    rearr.sort_by(|a, b| a.cmp(b).reverse());
    rearr.iter().collect::<String>().parse::<i32>().unwrap()
}

fn sqr_modulus(a: S) -> (bool, i32, i32) {
    const INVALID: (bool, i32, i32) = (false, -1, 1);

    if a.xs.len() % 2 != 0 {
        return INVALID;
    }

    let sum: i32 = match a.s.as_str() {
        "cart" => {
            // Since we're doing squared modulus, no need to iterate in pairs
            a.xs.iter().map(|n| n * n).sum()
        }
        "polar" => {
            // Modulus is already given to us, but need to skip every other element when squaring
            a.xs.iter()
                .enumerate()
                .filter(|&(i, _)| i % 2 == 0)
                .map(|(_, &n)| n * n)
                .sum()
        }
        _ => return INVALID,
    };

    (true, sum, reverse_sort_num(sum))
}

#[cfg(test)]
mod tests {
    use super::*;

    fn testing(a: S, exp: (bool, i32, i32)) -> () {
        let ss = a.s.clone();
        let vv = a.xs.clone();
        let ans = sqr_modulus(a);
        assert_eq!(ans, exp, "Testing: {} {:?}", ss, vv);
    }

    #[test]
    fn handles_invalid_type() {
        testing(
            S {
                s: String::from("pola"),
                xs: vec![2, 3],
            },
            (false, -1, 1),
        );
    }

    #[test]
    fn handles_cartesian() {
        testing(
            S {
                s: String::from("cart"),
                xs: vec![3, 4],
            },
            (true, 25, 52),
        );
    }

    #[test]
    fn handles_polar() {
        testing(
            S {
                s: String::from("polar"),
                xs: vec![2, 3],
            },
            (true, 4, 4),
        );
    }
}
