fn sq_in_rect(len: i32, width: i32) -> Option<Vec<i32>> {
    if len == width {
        return None;
    }

    let mut longer = len.max(width);
    let mut shorter = len.min(width);
    let mut output = Vec::new();

    while shorter > 0 {
        output.push(shorter);
        longer -= shorter;

        if longer < shorter {
            std::mem::swap(&mut longer, &mut shorter);
        }
    }

    Some(output)
}

#[cfg(test)]
mod tests {
    use super::sq_in_rect;

    fn testing(lng: i32, wdth: i32, exp: Option<Vec<i32>>) -> () {
        assert_eq!(sq_in_rect(lng, wdth), exp)
    }

    #[test]
    fn tests_sq_in_rect() {
        testing(5, 3, Some(vec![3, 2, 1, 1]));
        testing(3, 5, Some(vec![3, 2, 1, 1]));
        testing(5, 5, None);
    }
}
