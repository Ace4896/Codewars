#[derive(Clone, Copy, Debug, PartialEq, Eq)]
enum Direction {
    North,
    East,
    West,
    South,
}

fn dir_reduc(arr: &[Direction]) -> Vec<Direction> {
    let mut result = Vec::with_capacity(arr.len());
    for &direction in arr {
        match (direction, result.last()) {
            (Direction::North, Some(Direction::South))
            | (Direction::South, Some(Direction::North))
            | (Direction::East, Some(Direction::West))
            | (Direction::West, Some(Direction::East)) => {
                result.pop();
            }
            _ => result.push(direction),
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
