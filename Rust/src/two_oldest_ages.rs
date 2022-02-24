fn two_oldest_ages(ages: &[u8]) -> [u8; 2] {
    ages.iter().fold([0, 0], |[second_oldest, oldest], &age| {
        if age > oldest {
            [oldest, age]
        } else if age > second_oldest {
            [age, oldest]
        } else {
            [second_oldest, oldest]
        }
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_two_oldest_ages() {
        assert_eq!(two_oldest_ages(&[1, 5, 87, 45, 8, 8]), [45, 87]);
        assert_eq!(two_oldest_ages(&[6, 5, 83, 5, 3, 18]), [18, 83]);
        assert_eq!(two_oldest_ages(&[10, 1]), [1, 10]);
        assert_eq!(two_oldest_ages(&[1, 3, 10, 0]), [3, 10]);
    }
}
