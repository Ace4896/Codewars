use std::collections::HashMap;

fn simple_assembler(program: Vec<&str>) -> HashMap<String, i64> {
    let mut registers = HashMap::new();
    let mut pc = 0;
    while pc < program.len() as i32 {
        let ins = program[pc as usize];
        let tokens = ins.split_whitespace().collect::<Vec<_>>();
        let increment = match tokens[0] {
            "mov" => mov(&mut registers, tokens[1], tokens[2]),
            "inc" => inc(&mut registers, tokens[1]),
            "dec" => dec(&mut registers, tokens[1]),
            "jnz" => jnz(&mut registers, tokens[1], tokens[2]),
            _ => panic!("Unknown instruction"),
        };

        pc += increment;
    }

    registers
}

fn mov(registers: &mut HashMap<String, i64>, register: &str, source: &str) -> i32 {
    let value = source.parse::<i64>().unwrap_or_else(|_| registers[source]);

    registers.insert(register.to_string(), value);
    1
}

fn inc(registers: &mut HashMap<String, i64>, register: &str) -> i32 {
    registers.get_mut(register).map(|val| *val += 1);
    1
}

fn dec(registers: &mut HashMap<String, i64>, register: &str) -> i32 {
    registers.get_mut(register).map(|val| *val -= 1);
    1
}

fn jnz(registers: &mut HashMap<String, i64>, condition: &str, offset: &str) -> i32 {
    let condition = condition
        .parse::<i64>()
        .unwrap_or_else(|_| registers[condition]);

    if condition == 0 {
        1
    } else {
        offset
            .parse::<i32>()
            .unwrap_or_else(|_| registers[offset] as i32)
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    macro_rules! map {
        ($($key:expr => $value:expr),*) => {{
             let mut map = HashMap::new();
             $(
                 map.insert($key.to_string(), $value);
             )*
             map
        }};
    }

    #[test]
    fn short_tests() {
        let program = vec!["mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a"];
        let expected = map! { "a" => 1 };
        compare_registers(expected, simple_assembler(program));

        let program = vec![
            "mov c 12",
            "mov b 0",
            "mov a 200",
            "dec a",
            "inc b",
            "jnz a -2",
            "dec c",
            "mov a b",
            "jnz c -5",
            "jnz 0 1",
            "mov c a",
        ];
        let expected = map! { "a" => 409600, "c" => 409600, "b" => 409600};
        compare_registers(expected, simple_assembler(program));
    }

    fn compare_registers(expected: HashMap<String, i64>, actual: HashMap<String, i64>) {
        let result = expected
            .iter()
            .all(|(key, value)| actual.get(key).map(|v| v == value).unwrap_or(false));
        assert!(
            result,
            "Expected the registers to be like that:\n{:#?}\n\nBut got this:\n{:#?}\n",
            expected, actual
        )
    }
}
