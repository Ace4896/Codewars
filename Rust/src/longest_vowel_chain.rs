fn longest_vowel_chain(s: &str) -> usize {
    s.chars()
        .fold((0usize, 0usize), |(max, local_max), c| {
            if matches!(c, 'a' | 'e' | 'i' | 'o' | 'u') {
                let tmp = local_max + 1;
                (usize::max(max, tmp), tmp)
            } else {
                (max, 0)
            }
        })
        .0
}

#[cfg(test)]
mod tests {
    use super::longest_vowel_chain;

    #[test]
    fn basic_tests() {
        assert_eq!(longest_vowel_chain("codewarriors"), 2);
        assert_eq!(longest_vowel_chain("suoidea"), 3);
        assert_eq!(longest_vowel_chain("ultrarevolutionariees"), 3);
        assert_eq!(longest_vowel_chain("strengthlessnesses"), 1);
        assert_eq!(longest_vowel_chain("cuboideonavicuare"), 2);
        assert_eq!(longest_vowel_chain("chrononhotonthuooaos"), 5);
        assert_eq!(longest_vowel_chain("iiihoovaeaaaoougjyaw"), 8);
    }
}
