fn what_century(year: &str) -> String {
    let year = year.parse::<u32>().unwrap();
    let century = if year % 100 == 0 {
        (year - 1) / 100 + 1
    } else {
        year / 100 + 1
    };

    let suffix = if century >= 11 && century <= 19 {
        "th"
    } else {
        match century % 10 {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th",
        }
    };

    format!("{}{}", century, suffix)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_basic() {
        assert_eq!(what_century("1999"), "20th");
        assert_eq!(what_century("2011"), "21st");
        assert_eq!(what_century("2154"), "22nd");
        assert_eq!(what_century("2259"), "23rd");
        assert_eq!(what_century("1234"), "13th");
        assert_eq!(what_century("1023"), "11th");
        assert_eq!(what_century("2000"), "20th");
        assert_eq!(what_century("3210"), "33rd");
    }
}
