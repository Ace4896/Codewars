const VOWELS: [char; 5] = ['a', 'e', 'i', 'o', 'u'];

fn get_count(string: &str) -> usize {
    string.chars().fold(0, |count, c| {
        if VOWELS.contains(&c) {
            count + 1
        } else {
            count
        }
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn my_tests() {
        assert_eq!(get_count("abracadabra"), 5);
    }
}
