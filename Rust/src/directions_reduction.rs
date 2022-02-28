#[derive(Clone, Copy, Debug, PartialEq, Eq)]
enum Direction {
    North,
    East,
    West,
    South,
}

fn dir_reduc(arr: &[Direction]) -> Vec<Direction> {
    if arr.len() <= 1 {
        return arr.to_vec();
    }

    let mut result = Vec::with_capacity(arr.len());
    result.push(arr[0]);

    for &next_direction in &arr[1..] {
        if let Some(&last_direction) = result.last() {
            if matches!(
                (last_direction, next_direction),
                (Direction::North, Direction::South)
                    | (Direction::South, Direction::North)
                    | (Direction::East, Direction::West)
                    | (Direction::West, Direction::East)
            ) {
                result.pop();
            } else {
                result.push(next_direction);
            }
        } else {
            result.push(next_direction);
        }
    }

    result
}

#[cfg(test)]
mod tests {
    use super::{dir_reduc, Direction::*};

    #[test]
    fn basic() {
        let a = [North, South, South, East, West, North, West];
        assert_eq!(dir_reduc(&a), [West]);

        let a = [North, West, South, East];
        assert_eq!(dir_reduc(&a), [North, West, South, East]);
    }
}
