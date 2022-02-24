fn enumerate_katas(n: i32) -> (Vec<i32>, Vec<i32>) {
    let n = n as usize;
    let mut ann = Vec::with_capacity(n);
    let mut john = Vec::with_capacity(n);

    ann.push(1);
    john.push(0);

    for i in 1..n {
        // John's katas - this needs to be calculated first
        let t = john[i - 1] as usize;
        john.push(i as i32 - ann[t]);

        // Ann's katas
        let t = ann[i - 1] as usize;
        ann.push(i as i32 - john[t]);
    }

    (ann, john)
}

fn john(n: i32) -> Vec<i32> {
    enumerate_katas(n).1
}

fn ann(n: i32) -> Vec<i32> {
    enumerate_katas(n).0
}

fn sum_john(n: i32) -> i32 {
    john(n).iter().sum()
}

fn sum_ann(n: i32) -> i32 {
    ann(n).iter().sum()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_john() {
        dbg!(john(30));
        assert!(false);

        assert_eq!(john(11), vec![0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6]);
        assert_eq!(john(14), vec![0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6, 7, 7, 8]);
    }

    #[test]
    fn test_ann() {
        assert_eq!(ann(6), vec![1, 1, 2, 2, 3, 3]);
        assert_eq!(ann(15), vec![1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6, 7, 8, 8, 9]);
    }

    #[test]
    fn test_sum_john() {
        assert_eq!(sum_john(75), 1720);
        assert_eq!(sum_john(78), 1861);
    }

    #[test]
    fn test_sum_ann() {
        assert_eq!(sum_ann(115), 4070);
        assert_eq!(sum_ann(150), 6930);
    }
}
