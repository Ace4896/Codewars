//! https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/rust

fn product_fib(prod: u64) -> (u64, u64, bool) {
    let mut a = 0;
    let mut b = 1;
    let mut current_prod = a * b;

    while current_prod < prod {
        let next = a + b;
        a = b;
        b = next;
        current_prod = a * b;
    }

    (a, b, current_prod == prod)
}

#[cfg(test)]
mod tests {
    use super::*;

    fn dotest(prod: u64, exp: (u64, u64, bool)) -> () {
        assert_eq!(product_fib(prod), exp)
    }

    #[test]
    fn basics_product_fib() {
        dotest(4895, (55, 89, true));
        dotest(5895, (89, 144, false));
    }
}
