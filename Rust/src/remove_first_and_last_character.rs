pub fn remove_char(s: &str) -> String {
    // NOTE: len() is the length in bytes, not the length of the string
    // So using len() to count isn't correct
    // https://doc.rust-lang.org/std/primitive.str.html#method.len
    s.chars().skip(1).take(s.chars().count() - 2).collect()
}

#[cfg(test)]
mod tests {
    use super::remove_char;

    #[test]
    fn sample_cases() {
        assert_eq!(remove_char("eloquent"), "loquen");
        assert_eq!(remove_char("country"), "ountr");
        assert_eq!(remove_char("person"), "erso");
        assert_eq!(remove_char("place"), "lac");
        assert_eq!(remove_char("ok"), "");
        assert_eq!(remove_char("ooopsss"), "oopss");
    }
}
