// NOTE: Much shorter solution is to:
// - Split the string by ';' to get each name
// - Map this directly to the desired output format
// - Collect into an intermediate vector
// - Sort the intermediate vector
// - Flatten the vector into one final string

fn meeting(s: &str) -> String {
    let s = s.to_ascii_uppercase();
    let mut people = s
        .split(";")
        .map(|full_name| {
            let mut names = full_name.split(":");
            let first_name = names.next().unwrap();
            let last_name = names.next().unwrap();
            (first_name, last_name)
        })
        .collect::<Vec<_>>();

    people.sort_unstable_by(|&(first_p1, last_p1), &(first_p2, last_p2)| {
        match last_p1.cmp(last_p2) {
            std::cmp::Ordering::Equal => {}
            ord => return ord,
        }
        first_p1.cmp(first_p2)
    });

    people
        .iter()
        .map(|&(first_name, last_name)| format!("({}, {})", last_name, first_name))
        .collect::<Vec<_>>()
        .concat()
}

#[cfg(test)]
mod tests {
    use super::*;

    fn dotest(s: &str, exp: &str) -> () {
        let ans = meeting(s);
        assert_eq!(ans, exp);
    }

    #[test]
    fn basic_tests() {
        dotest("Alexis:Wahl;John:Bell;Victoria:Schwarz;Abba:Dorny;Grace:Meta;Ann:Arno;Madison:STAN;Alex:Cornwell;Lewis:Kern;Megan:Stan;Alex:Korn",
               "(ARNO, ANN)(BELL, JOHN)(CORNWELL, ALEX)(DORNY, ABBA)(KERN, LEWIS)(KORN, ALEX)(META, GRACE)(SCHWARZ, VICTORIA)(STAN, MADISON)(STAN, MEGAN)(WAHL, ALEXIS)");
        dotest("John:Gates;Michael:Wahl;Megan:Bell;Paul:Dorries;James:Dorny;Lewis:Steve;Alex:Meta;Elizabeth:Russel;Anna:Korn;Ann:Kern;Amber:Cornwell",
               "(BELL, MEGAN)(CORNWELL, AMBER)(DORNY, JAMES)(DORRIES, PAUL)(GATES, JOHN)(KERN, ANN)(KORN, ANNA)(META, ALEX)(RUSSEL, ELIZABETH)(STEVE, LEWIS)(WAHL, MICHAEL)");
        dotest("Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern",
            "(ARNO, ALEX)(ARNO, HALEY)(BELL, SARAH)(CORNWELL, ALISSA)(DORNY, PAUL)(DORRIES, ANDREW)(KERN, ANN)(KERN, MADISON)");
    }
}
