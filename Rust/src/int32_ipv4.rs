// NOTE: Another solution is to use int.to_be_bytes()
// This gives us the 4 bytes in this u32, in big-endian (MSB first).
fn int32_to_ip(int: u32) -> String {
    format!(
        "{}.{}.{}.{}",
        (int & 0xFF00_0000) >> 24,
        (int & 0x00FF_0000) >> 16,
        (int & 0x0000_FF00) >> 8,
        int & 0x0000_00FF
    )
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn basic() {
        assert_eq!(int32_to_ip(2154959208), "128.114.17.104");
        assert_eq!(int32_to_ip(2149583361), "128.32.10.1");
        assert_eq!(int32_to_ip(0), "0.0.0.0");
    }
}
