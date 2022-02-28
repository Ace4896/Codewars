fn print(n: i32) -> Option<String> {
    if n < 0 || n % 2 == 0 {
        return None;
    }

    let mut output = String::new();

    // Top half of diamond (including middle)
    for i in (1..=n).step_by(2) {
        let leading_spaces = (n - i) / 2;
        output.push_str(&" ".repeat(leading_spaces as usize));
        output.push_str(&"*".repeat(i as usize));
        output.push('\n');
    }

    // Bottom half of diamond
    for i in (1..=(n - 2)).rev().step_by(2) {
        let leading_spaces = (n - i) / 2;
        output.push_str(&" ".repeat(leading_spaces as usize));
        output.push_str(&"*".repeat(i as usize));
        output.push('\n');
    }

    Some(output)
}

#[test]
fn basic_test() {
    assert_eq!(print(3), Some(" *\n***\n *\n".to_string()));
    assert_eq!(print(5), Some("  *\n ***\n*****\n ***\n  *\n".to_string()));
    assert_eq!(print(-3), None);
    assert_eq!(print(2), None);
    assert_eq!(print(0), None);
    assert_eq!(print(1), Some("*\n".to_string()));
}
