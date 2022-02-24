/// # Last digit of a large number
///
/// Find the last digit of a number raised to a particular power.
///
/// https://www.codewars.com/kata/5511b2f550906349a70004e1/train/rust

fn get_last_digit_str(s: &str) -> i32 {
    s.chars()
        .last()
        .expect("Input string is empty")
        .to_digit(10)
        .expect("Could not convert last digit of input string into integer!") as i32
}

fn last_digit(a_str: &str, b_str: &str) -> i32 {
    // Get the last digit in a
    let last_digit_a = get_last_digit_str(a_str);

    // Some base cases to handle separately (in this order):
    // - Power = 0: Return 1
    // - Last digit = 0/1/5/6: Return last digit
    //
    // Then the main cases:
    // - Last digit = 2:
    //   - 2 -> 4 -> 8 -> 16 -> 32 (wraps after 4 multiplies)
    // - Last digit = 3:
    //   - 3 -> 9 -> 27 -> 81 -> 243 (wraps after 4 multiplies)
    // - Last digit = 4:
    //   - 4 -> 16 -> 64 (wraps after 2 multiplies)
    // - Last digit = 7:
    //   - 7 -> 49 -> 343 -> 2401 -> 16807 (wraps after 4 multiplies)
    // - Last digit = 8:
    //   - 8 -> 64 -> 512 -> 4096 -> 32768 (wraps after 4 multiplies)
    // - Last digit = 9:
    //   - 9 -> 81 -> 729 (wraps after 2 multiplies)
    //
    // For simplicity, let all of them wrap after 4 multiplies
    match (last_digit_a, b_str) {
        (_, "0") => 1,
        (0, _) | (1, _) | (5, _) | (6, _) => last_digit_a,
        _ => {
            // Reduce the power to <= 4 (our wrap point)
            // Achived by first reducing it to <= 20 (as e.g. 11 wraps to power 3, not 1)
            // Don't need > 20 since 21 wraps to 1 as normal - can be proven w/ induction
            let reduced_power = {
                let reduced = if b_str.len() == 1 {
                    get_last_digit_str(b_str)
                } else {
                    b_str[b_str.len() - 2..]
                        .parse::<i32>()
                        .expect("Couldn't convert last two characters in b into an integer!")
                        % 20
                };

                // 4, 8, ..., 20 should have power 4, not 0
                // Rest can be obtained by using remainder
                if reduced % 4 == 0 {
                    4
                } else {
                    reduced % 4
                }
            };

            let mut result = last_digit_a;
            for _ in 1..reduced_power {
                result = (result * last_digit_a) % 10;
            }

            result
        }
    }
}

#[cfg(test)]
mod tests {
    use super::last_digit;

    #[test]
    fn returns_expected() {
        assert_eq!(last_digit("4", "1"), 4);
        assert_eq!(last_digit("4", "2"), 6);
        assert_eq!(last_digit("9", "7"), 9);
        assert_eq!(last_digit("10", "10000000000"), 0);
        assert_eq!(
            last_digit(
                "1606938044258990275541962092341162602522202993782792835301376",
                "2037035976334486086268445688409378161051468393665936250636140449354381299763336706183397376"
            ),
            6
        );
        assert_eq!(
            last_digit(
                "3715290469715693021198967285016729344580685479654510946723",
                "68819615221552997273737174557165657483427362207517952651"
            ),
            7
        );
    }

    #[test]
    fn handles_zero_power() {
        assert_eq!(last_digit("0", "0"), 1);
        assert_eq!(last_digit("1", "0"), 1);
        assert_eq!(last_digit("2", "0"), 1);
        assert_eq!(last_digit("3", "0"), 1);
    }

    #[test]
    fn handles_non_wrapping_power() {
        assert_eq!(last_digit("2", "1"), 2);
        assert_eq!(last_digit("2", "2"), 4);
        assert_eq!(last_digit("2", "3"), 8);
        assert_eq!(last_digit("2", "4"), 6);
    }

    #[test]
    fn handles_wrapping_power() {
        // Normal Wrapping
        assert_eq!(last_digit("2", "5"), 2);
        assert_eq!(last_digit("2", "6"), 4);
        assert_eq!(last_digit("2", "7"), 8);
        assert_eq!(last_digit("2", "8"), 6);
        assert_eq!(last_digit("2", "9"), 2);

        // Wrapping for 10 <= b <= 20
        assert_eq!(last_digit("2", "10"), 4);
        assert_eq!(last_digit("2", "11"), 8);
        assert_eq!(last_digit("2", "12"), 6);
        assert_eq!(last_digit("2", "13"), 2);
    }
}
