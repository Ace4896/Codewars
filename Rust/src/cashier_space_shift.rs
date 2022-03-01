// NOTE: None of the solutions used regex LOL
// - Make a static list of all the menu items
// - For each menu item:
//   - Count how many case insensitive matches there are
//   - Keep this in a Vec / output string

use lazy_static::lazy_static;
use regex::Regex;

lazy_static! {
    static ref ORDER_REGEX: Regex =
        Regex::new(r"(burger|fries|chicken|pizza|sandwich|onionrings|milkshake|coke)").unwrap();
}

fn capitalize_word(word: &str) -> String {
    let mut chars = word.chars();
    match chars.next() {
        Some(c) => c.to_uppercase().chain(chars).collect(),
        None => String::new(),
    }
}

fn menu_item_index(item: &str) -> usize {
    match item {
        "Burger" => 1,
        "Fries" => 2,
        "Chicken" => 3,
        "Pizza" => 4,
        "Sandwich" => 5,
        "Onionrings" => 6,
        "Milkshake" => 7,
        "Coke" => 8,
        i => panic!("Unknown menu item '{i}'"),
    }
}

fn get_order(input: String) -> String {
    let mut orders = ORDER_REGEX
        .find_iter(&input)
        .map(|mat| capitalize_word(mat.as_str()))
        .collect::<Vec<_>>();

    orders.sort_unstable_by(|item1, item2| {
        let (item1, item2) = (menu_item_index(item1), menu_item_index(item2));
        item1.cmp(&item2)
    });

    orders.join(" ")
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_1() {
        assert_eq!(
            get_order(
                "milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza".to_string()
            ),
            "Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke".to_string()
        );
    }

    #[test]
    fn test_2() {
        assert_eq!(
            get_order("pizzachickenfriesburgercokemilkshakefriessandwich".to_string()),
            "Burger Fries Fries Chicken Pizza Sandwich Milkshake Coke".to_string()
        );
    }
}
