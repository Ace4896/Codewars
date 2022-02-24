// NOTE: A regex was probably the best way of checking each order
// But oh well...

enum OrderTotal {
    Buy(f64),
    Sell(f64),
}

fn get_order_details(order: &[&str]) -> Option<OrderTotal> {
    // Check if we have the correct number of components
    if order.len() != 4 {
        return None;
    }

    // Check if quantity is valid
    let quantity = if order[1].chars().all(|c| c.is_digit(10)) {
        order[1].parse::<f64>().unwrap()
    } else {
        return None;
    };

    // Check if price is valid
    let price = if order[2].matches('.').count() == 1
        && order[2]
            .chars()
            .filter(|&c| c != '.')
            .all(|c| c.is_digit(10))
    {
        order[2].parse::<f64>().unwrap()
    } else {
        return None;
    };

    match order[3] {
        "B" => Some(OrderTotal::Buy(quantity * price)),
        "S" => Some(OrderTotal::Sell(quantity * price)),
        _ => None,
    }
}

fn balance_statement(lst: &str) -> String {
    if lst.is_empty() {
        return String::from("Buy: 0 Sell: 0");
    }

    let mut total_bought = 0.0;
    let mut total_sold = 0.0;

    let mut badly_formed: Vec<&str> = Vec::new();

    for order_str in lst.split(", ") {
        let order_components = order_str.split_whitespace().collect::<Vec<_>>();
        if let Some(order_total) = get_order_details(&order_components) {
            match order_total {
                OrderTotal::Buy(total) => total_bought += total,
                OrderTotal::Sell(total) => total_sold += total,
            }
        } else {
            badly_formed.push(order_str);
        }
    }

    let mut result = format!("Buy: {:.0} Sell: {:.0}", total_bought, total_sold);
    if !badly_formed.is_empty() {
        result.push_str(&format!(
            "; Badly formed {}: {} ;",
            badly_formed.len(),
            badly_formed.join(" ;")
        ))
    }

    result
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn basic_tests() {
        assert_eq!(
            balance_statement(
                "GOOG 300 542.0 B, AAPL 50 145.0 B, CSCO 250.0 29 B, GOOG 200 580.0 S"
            ),
            "Buy: 169850 Sell: 116000; Badly formed 1: CSCO 250.0 29 B ;"
        );

        assert_eq!(
            balance_statement("GOOG 90 160.45 B, JPMC 67 12.8 S, MYSPACE 24.0 210 B, CITI 50 450 B, CSCO 100 55.5 S"),
            "Buy: 14440 Sell: 6408; Badly formed 2: MYSPACE 24.0 210 B ;CITI 50 450 B ;"
        );

        assert_eq!(
            balance_statement(
                "ZNGA 1300 2.66 B, CLH15.NYM 50 56.32 B, OWW 1000 11.623 B, OGG 20 580.1 B"
            ),
            "Buy: 29499 Sell: 0"
        );
    }

    #[test]
    fn handles_empty_input() {
        assert_eq!(balance_statement(""), "Buy: 0 Sell: 0")
    }

    #[test]
    fn handles_incorrect_component_count() {
        assert_eq!(
            balance_statement("ZNGA 1300 2.66"),
            "Buy: 0 Sell: 0; Badly formed 1: ZNGA 1300 2.66 ;"
        );
    }
}
