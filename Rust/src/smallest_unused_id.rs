fn next_id(ids: &[usize]) -> usize {
    let mut ids = ids.to_vec();
    ids.sort_unstable();
    ids.dedup();

    let mut smallest = 0;
    for id in ids.iter() {
        if *id == smallest {
            smallest += 1;
        } else {
            break;
        }
    }

    smallest
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_basics() {
        assert_eq!(next_id(&[0, 1, 2, 4, 5]), 3);
        assert_eq!(next_id(&[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]), 11);
    }
}
