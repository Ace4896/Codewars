fn solution(s: &str) -> Vec<String> {
    let mut result = Vec::new();
    let mut iter = s.chars().peekable();
    while iter.peek().is_some() {
        let mut pair: String = iter.by_ref().take(2).collect();
        if pair.len() == 1 {
            pair.push('_');
        }

        result.push(pair);
    }

    result
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn basic() {
        assert_eq!(solution("abcdef"), ["ab", "cd", "ef"]);
        assert_eq!(solution("abcdefg"), ["ab", "cd", "ef", "g_"]);
        assert_eq!(solution(""), [] as [&str; 0]);
    }
}
