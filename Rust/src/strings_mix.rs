use std::{
    cmp::Ordering,
    collections::{HashMap, HashSet},
    fmt,
};

struct CharMaximum {
    ch: char,
    count: usize,
    source: Source,
}

// NOTE: Since we're deriving PartialOrd and Ord, these are sorted by order of declaration
#[derive(PartialEq, Eq, PartialOrd, Ord)]
enum Source {
    S1,
    S2,
    Equal,
}

impl fmt::Display for Source {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        match self {
            &Source::S1 => f.write_str("1"),
            &Source::S2 => f.write_str("2"),
            &Source::Equal => f.write_str("="),
        }
    }
}

// Count occurrences for each lowercase character, filtering out characters with <= 1 ocurrences
fn count_occurrences(s: &str) -> HashMap<char, usize> {
    let mut result =
        s.chars()
            .filter(|ch| ch.is_ascii_lowercase())
            .fold(HashMap::new(), |mut occ, ch| {
                *occ.entry(ch).or_insert(0) += 1;
                occ
            });

    result.retain(|_, count| *count > 1);
    result
}

fn mix(s1: &str, s2: &str) -> String {
    // Count occurrences of each string
    let occurrences_s1 = count_occurrences(s1);
    let occurrences_s2 = count_occurrences(s2);

    // Create a combined set from each HashMap's keyset
    let combined_set: HashSet<&char> =
        HashSet::from_iter(occurrences_s1.keys().chain(occurrences_s2.keys()));

    // For each character in the combined set, see which string has the higher number of occurrences
    // Since they were pre-filtered, no need to check counter
    let mut char_maximums: Vec<_> = combined_set
        .iter()
        .map(|&ch| {
            let count_s1 = occurrences_s1.get(ch).copied().unwrap_or(0);
            let count_s2 = occurrences_s2.get(ch).copied().unwrap_or(0);

            let (count, source) = match count_s1.cmp(&count_s2) {
                Ordering::Greater => (count_s1, Source::S1),
                Ordering::Equal => (count_s1, Source::Equal),
                Ordering::Less => (count_s2, Source::S2),
            };

            CharMaximum {
                count,
                source,
                ch: *ch,
            }
        })
        .collect();

    // Sort the maximums by number of occurrences (descending), then by source (ascending), then by character (ascending)
    char_maximums.sort_by(|a, b| {
        match b.count.cmp(&a.count) {
            Ordering::Equal => {}
            ord => return ord,
        }
        match a.source.cmp(&b.source) {
            Ordering::Equal => {}
            ord => return ord,
        }
        a.ch.cmp(&b.ch)
    });

    // Finally, generate the desired output string format
    char_maximums
        .iter()
        .map(|ch_max| {
            format!(
                "{}:{}",
                ch_max.source,
                String::from(ch_max.ch).repeat(ch_max.count)
            )
        })
        .collect::<Vec<_>>()
        .join("/")
}

#[cfg(test)]
mod tests {
    use super::mix;

    #[test]
    fn basics_mix() {
        testing(
            "Are they here",
            "yes, they are here",
            "2:eeeee/2:yy/=:hh/=:rr",
        );
        testing(
            "looping is fun but dangerous",
            "less dangerous than coding",
            "1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg",
        );
        testing(
            " In many languages",
            " there's a pair of functions",
            "1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt",
        );
        testing("Lords of the Fallen", "gamekult", "1:ee/1:ll/1:oo");
        testing("codewars", "codewars", "");
        testing(
            "A generation must confront the looming ",
            "codewarrs",
            "1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr",
        );
    }

    fn testing(s1: &str, s2: &str, exp: &str) -> () {
        assert_eq!(&mix(s1, s2), exp)
    }
}
