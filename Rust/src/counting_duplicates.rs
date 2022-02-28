use std::collections::HashMap;

fn count_duplicates(text: &str) -> u32 {
    let mut char_count: HashMap<char, u32> = HashMap::new();

    for ch in text.chars().map(|c| c.to_ascii_lowercase()) {
        *char_count.entry(ch).or_insert(0) += 1;
    }

    char_count.retain(|_, count| *count > 1);
    char_count.len() as u32
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_abcde() {
        assert_eq!(count_duplicates("abcde"), 0);
    }

    #[test]
    fn test_abcdea() {
        assert_eq!(count_duplicates("abcdea"), 1);
    }

    #[test]
    fn test_indivisibility() {
        assert_eq!(count_duplicates("indivisibility"), 1);
    }
}
