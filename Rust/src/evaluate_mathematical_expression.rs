//! After tokenizing the input, the mathematical expressions follow this grammar, where:
//! - expr is the top-level production
//! - e is the empty string
//!
//! ```ignore
//! expr    ::= term expr_p
//! expr_p  ::= '+' term expr_p
//!           | '-' term expr_p
//!           | e
//!
//! term    ::= neg term_p
//! term_p  ::= '*' neg term_p
//!           | '/' neg term_p
//!           | e
//!
//! neg     ::= '-' factor
//!           | factor
//!
//! factor  ::= number
//!           | '(' expr ')'
//! ```
//!
//! This solution uses an LL(1) parser to parse and evaluate the expression.

use std::iter::Peekable;

fn calc(expr: &str) -> f64 {
    // Tokenize the input to make it easier to interpret
    let mut tokens: Vec<String> = Vec::new();
    let mut iter = expr.chars().peekable();
    while let Some(&c) = iter.peek() {
        match c {
            '0'..='9' => {
                let mut tmp = String::new();
                while iter.peek().is_some() && matches!(iter.peek().unwrap(), '0'..='9' | '.') {
                    tmp.push(iter.next().unwrap());
                }

                tokens.push(tmp);
            }
            '+' | '-' | '*' | '/' | '(' | ')' => tokens.push(iter.next().unwrap().to_string()),
            _ => {
                iter.next();
            }
        }
    }

    let mut iter = tokens.iter().peekable();
    parse_expr(&mut iter)
}

fn parse_expr<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> f64 {
    let lhs = parse_term(iter);
    parse_expr_p(iter, lhs)
}

fn parse_expr_p<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>, lhs: f64) -> f64 {
    match iter.peek().map(|s| s.as_str()) {
        Some("+" | "-") => {
            let op = iter.next().unwrap();
            let rhs = parse_term(iter);
            let subresult = if op == "+" { lhs + rhs } else { lhs - rhs };

            parse_expr_p(iter, subresult)
        }
        _ => lhs,
    }
}

fn parse_term<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> f64 {
    let lhs = parse_neg(iter);
    parse_term_p(iter, lhs)
}

fn parse_term_p<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>, lhs: f64) -> f64 {
    match iter.peek().map(|s| s.as_str()) {
        Some("*" | "/") => {
            let op = iter.next().unwrap();
            let rhs = parse_neg(iter);
            let subresult = if op == "*" { lhs * rhs } else { lhs / rhs };

            parse_term_p(iter, subresult)
        }
        _ => lhs,
    }
}

fn parse_neg<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> f64 {
    if iter
        .peek()
        .expect("Incomplete arithmetic expression")
        .as_str()
        == "-"
    {
        // Consume the "-" symbol, then parse the number
        iter.next();
        -parse_factor(iter)
    } else {
        parse_factor(iter)
    }
}

fn parse_factor<'a>(iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> f64 {
    match iter
        .next()
        .expect("Expected value or parenthesised expression")
        .as_str()
    {
        // No if-let guards :(
        x if x.parse::<f64>().is_ok() => x.parse::<f64>().unwrap(),
        "(" => {
            // Parse the sub-expression, then consume the right parenthesis
            let val = parse_expr(iter);
            iter.next();
            val
        }
        x => panic!(
            "Expected value or parenthesised expression, but got '{}'",
            x
        ),
    }
}

#[cfg(test)]
mod tests {
    use super::calc;

    // Wrap custom message to reduce repitition
    macro_rules! assert_expr_eq {
        ($expr: expr, $expect: expr) => {{
            let result = calc($expr);
            assert_eq!(
                result, $expect,
                "\nexpected expression \"{}\" to equal \"{:?}\", but got \"{:?}\"",
                $expr, $expect, result,
            );
        }};
    }

    #[test]
    fn single_values() {
        assert_expr_eq!("0", 0.0);
        assert_expr_eq!("1", 1.0);
        assert_expr_eq!("42", 42.0);
        assert_expr_eq!("350", 350.0);
    }

    #[test]
    fn basic_operations() {
        assert_expr_eq!("1 + 1", 2.0);
        assert_expr_eq!("1 - 1", 0.0);
        assert_expr_eq!("1 * 1", 1.0);
        assert_expr_eq!("1 / 1", 1.0);
        assert_expr_eq!("12 * 123", 1476.0);
    }

    #[test]
    fn whitespace_between_operators_and_operands() {
        assert_expr_eq!("1-1", 0.0);
        assert_expr_eq!("1 -1", 0.0);
        assert_expr_eq!("1- 1", 0.0);
        assert_expr_eq!("1* 1", 1.0);
    }

    #[test]
    fn unary_minuses() {
        assert_expr_eq!("1- -1", 2.0);
        assert_expr_eq!("1--1", 2.0);
        assert_expr_eq!("1 - -1", 2.0);
        assert_expr_eq!("-42", -42.0);
    }

    #[test]
    fn parentheses() {
        assert_expr_eq!("(1)", 1.0);
        assert_expr_eq!("((1))", 1.0);
        assert_expr_eq!("((80 - (19)))", 61.0);
    }

    #[test]
    fn multiple_operators() {
        assert_expr_eq!("12* 123/(-5 + 2)", -492.0);
        assert_expr_eq!("1 - -(-(-(-4)))", -3.0);
        assert_expr_eq!("2 /2+3 * 4.75- -6", 21.25);
        assert_expr_eq!("2 / (2 + 3) * 4.33 - -6", 7.732);
        assert_expr_eq!("(1 - 2) + -(-(-(-4)))", 3.0);
        assert_expr_eq!("((2.33 / (2.9+3.5)*4) - -6)", 7.45625);
    }
}
