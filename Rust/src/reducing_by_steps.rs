fn som(x: i64, y: i64) -> i64 {
    x + y
}

fn maxi(x: i64, y: i64) -> i64 {
    x.max(y)
}

fn mini(x: i64, y: i64) -> i64 {
    x.min(y)
}

fn gcdi(x: i64, y: i64) -> i64 {
    let (x, y) = (x.abs(), y.abs());
    let (mut a, mut b) = if x > y { (x, y) } else { (y, x) };
    let mut remainder: i64;

    while b > 0 {
        remainder = a % b;
        a = b;
        b = remainder;
    }

    a
}

fn lcmu(x: i64, y: i64) -> i64 {
    (x * y).abs() / gcdi(x, y)
}

fn oper_array<F>(fct: F, a: &[i64], init: i64) -> Vec<i64>
where
    F: Fn(i64, i64) -> i64,
{
    a.iter()
        .fold(
            (init, Vec::with_capacity(a.len())),
            |(mut prev, mut v), &current| {
                prev = fct(prev, current);
                v.push(prev);
                (prev, v)
            },
        )
        .1
}

#[cfg(test)]
mod tests {
    use super::*;

    fn testing_som(a: &[i64], exp: &Vec<i64>) -> () {
        assert_eq!(&oper_array(som, a, 0), exp);
    }
    fn testing_lcmu(a: &[i64], exp: &Vec<i64>) -> () {
        assert_eq!(&oper_array(lcmu, a, a[0]), exp);
    }
    fn testing_gcdi(a: &[i64], exp: &Vec<i64>) -> () {
        assert_eq!(&oper_array(gcdi, a, a[0]), exp);
    }
    fn testing_maxi(a: &[i64], exp: &Vec<i64>) -> () {
        assert_eq!(&oper_array(maxi, a, a[0]), exp);
    }

    #[test]
    fn basics_som() {
        testing_som(&[18, 69, -90, -78, 65, 40], &vec![18, 87, -3, -81, -16, 24]);
    }
    #[test]
    fn basics_lcmu() {
        testing_lcmu(
            &[18, 69, -90, -78, 65, 40],
            &vec![18, 414, 2070, 26910, 26910, 107640],
        );
    }
    #[test]
    fn basics_maxi() {
        testing_maxi(&[18, 69, -90, -78, 65, 40], &vec![18, 69, 69, 69, 69, 69]);
    }
    #[test]
    fn basics_gcdi() {
        testing_gcdi(&[18, 69, -90, -78, 65, 40], &vec![18, 3, 3, 3, 1, 1]);
    }
}
