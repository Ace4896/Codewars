use std::collections::HashMap;

struct UrlShortener {
    /// Database of URLs, grouped by number of letters in the ID
    urls: HashMap<usize, Vec<String>>,

    /// Database index of URLs and their corresponding group + ID in that group
    urls_to_group_id: HashMap<String, (usize, usize)>,
}

impl UrlShortener {
    const LETTERS: [char; 26] = [
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
        's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    ];

    fn new() -> Self {
        let mut urls = HashMap::new();
        urls.insert(1, Vec::new());

        Self {
            urls,
            urls_to_group_id: HashMap::new(),
        }
    }

    /// Encodes an ID into the URL's format.
    ///
    /// This is essentially base 26, but is fully represented by lowercase letters
    /// (as opposed to using 0-9, then the first 16 lowercase letters). This makes
    /// 'a' equivalent to '0'.
    ///
    /// The group number indicates the minimum number of characters; if there's any
    /// space at the front of the string, it's padded with 'a'.
    fn encode_id(group: usize, id: usize) -> String {
        debug_assert!(
            id < 26usize.pow(group as u32),
            "ID {} is too large for the provided group number {}!",
            id,
            group
        );

        // Start with the remainder, and push the place values in increasing powers
        let mut chars = Vec::new();

        let mut place_value = id % 26;
        chars.push(Self::LETTERS[place_value]);

        let mut tmp = id - place_value;
        while tmp > 0 {
            tmp /= 26;
            place_value = tmp % 26;
            chars.push(Self::LETTERS[place_value]);

            tmp -= place_value;
        }

        let pad_count = group - chars.len();
        for _ in 0..pad_count {
            chars.push('a');
        }

        // Output was constructed from lowest power first, so reverse this
        String::from_iter(chars.iter().rev())
    }

    /// Decodes the ID from the URL's format.
    /// Returns the group number, then the ID within that group.
    fn decode_id(id_str: &str) -> (usize, usize) {
        debug_assert!(
            !id_str.is_empty() && id_str.chars().all(|c| c.is_ascii_lowercase()),
            "ID is not in the correct form!"
        );

        let group = id_str.len();
        let id = if id_str.chars().all(|c| c == 'a') {
            0
        } else {
            // Remove all leading a's, and find the actual ID for this number
            let mut result = 0;
            let id_trimmed = id_str.trim_start_matches('a');
            for (index, encoded) in id_trimmed.char_indices() {
                let power = id_trimmed.len() - index - 1;
                let value = Self::LETTERS.binary_search(&encoded).unwrap();
                result += value * 26usize.pow(power as u32);
            }

            result
        };

        (group, id)
    }

    fn shorten(&mut self, long_url: &str) -> String {
        let (group, id) = if self.urls_to_group_id.contains_key(long_url) {
            self.urls_to_group_id[long_url]
        } else {
            // If not yet present, insert in the smallest group that isn't full yet
            // A group is considered full if it has 26^n entries, where n is the group number
            let potential_group = *self.urls.keys().max().unwrap();
            let group_size = self.urls[&potential_group].len();

            if group_size < 26usize.pow(potential_group as u32) {
                // Insert into existing group since it isn't full yet
                self.urls
                    .get_mut(&potential_group)
                    .unwrap()
                    .push(long_url.to_string());
                self.urls_to_group_id
                    .insert(long_url.to_string(), (potential_group, group_size));

                (potential_group, group_size)
            } else {
                // Largest existing group is full, so create a new one
                let final_group = potential_group + 1;
                self.urls.insert(final_group, vec![long_url.to_string()]);
                self.urls_to_group_id
                    .insert(long_url.to_string(), (final_group, 0));

                (final_group, 0)
            }
        };

        format!("short.ly/{}", Self::encode_id(group, id))
    }

    fn redirect(&self, short_url: &str) -> String {
        let id_str = short_url
            .strip_prefix("short.ly/")
            .expect("Short URL is not in correct format!");
        let (group, id) = Self::decode_id(id_str);

        self.urls
            .get(&group)
            .expect("Group does not exist in database!")
            .get(id)
            .cloned()
            .expect("ID for this group does not exist in database!")
    }
}

#[cfg(test)]
mod tests {
    use super::UrlShortener;
    use crate::assert_valid_short_url;

    #[test]
    fn encode_id_group_1() {
        assert_eq!(UrlShortener::encode_id(1, 0), "a");
        assert_eq!(UrlShortener::encode_id(1, 1), "b");
        assert_eq!(UrlShortener::encode_id(1, 2), "c");
        assert_eq!(UrlShortener::encode_id(1, 12), "m");
        assert_eq!(UrlShortener::encode_id(1, 21), "v");
        assert_eq!(UrlShortener::encode_id(1, 25), "z");
    }

    #[test]
    fn encode_id_group_2() {
        assert_eq!(UrlShortener::encode_id(2, 28), "bc");
        assert_eq!(UrlShortener::encode_id(2, 28), "bc");
    }

    #[test]
    fn encode_id_group_3() {
        assert_eq!(UrlShortener::encode_id(3, 1234), "bvm");
    }

    #[test]
    fn decode_id_works() {
        assert_eq!(UrlShortener::decode_id("c"), (1, 2));
        assert_eq!(UrlShortener::decode_id("bc"), (2, 28));
        assert_eq!(UrlShortener::decode_id("bvm"), (3, 1234));
    }

    #[test]
    fn two_different_urls() {
        let mut url_shortener = UrlShortener::new();

        let short_url_1 =
            url_shortener.shorten("https://www.codewars.com/kata/5ef9ca8b76be6d001d5e1c3e");
        assert_valid_short_url!(&short_url_1);

        let short_url_2 =
            url_shortener.shorten("https://www.codewars.com/kata/5efae11e2d12df00331f91a6");
        assert_valid_short_url!(&short_url_2);

        assert_eq!(
            url_shortener.redirect(&short_url_1),
            "https://www.codewars.com/kata/5ef9ca8b76be6d001d5e1c3e"
        );
        assert_eq!(
            url_shortener.redirect(&short_url_2),
            "https://www.codewars.com/kata/5efae11e2d12df00331f91a6"
        );
    }

    #[test]
    fn same_urls() {
        let mut url_shortener = UrlShortener::new();

        let short_url_1 =
            url_shortener.shorten("https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f");
        assert_valid_short_url!(&short_url_1);

        let short_url_2 =
            url_shortener.shorten("https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f");
        assert_valid_short_url!(&short_url_2);

        assert_eq!(
            short_url_1, short_url_2,
            "Should work with the same long URLs"
        );
        assert_eq!(
            url_shortener.redirect(&short_url_1),
            "https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f",
            "{} should redirect to https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f",
            &short_url_1,
        );
    }

    #[macro_export]
    macro_rules! assert_valid_short_url {
        ($url:expr) => {
            assert!(
                $url.starts_with("short.ly/"),
                "URL format is incorrect: should start with \"short.ly/\", got: {}",
                $url,
            );

            assert!(
                $url.len() < 14,
                "URL format is incorrect: length should be < 14 characters, got: {}",
                $url,
            );

            // As the URL contains "short.ly/", we can safely index using [9..]
            assert!(
                $url[9..].bytes().all(|b| b.is_ascii_lowercase()),
                "URL format is incorrect: should contain lowercase letters at the end, got: {}",
                $url,
            );
        };
    }
}
