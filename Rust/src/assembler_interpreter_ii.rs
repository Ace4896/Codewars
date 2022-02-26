//! https://www.codewars.com/kata/58e61f3d8ff24f774400002c/train/rust
//!
//! This ended up being a lot longer than I originally intended :)
//!
//! It could be a lot shorter if the intermediate enums representations were removed, but I opted for this approach since:
//! - It was much easier for me to test as I went along (both unit and manual testing)
//! - I didn't want to repeatedly parse the same instruction (e.g. if there's a loop in the program)

use std::{cmp::Ordering, collections::HashMap};

use lazy_static::lazy_static;
use regex::Regex;

/// Gets the type of instruction this line represents.
#[inline]
fn get_instruction_code(line: &str) -> &str {
    line.split_whitespace()
        .next()
        .expect("Program line is empty!")
}

/// Obtains the first argument of an instruction (assuming there is only one).
fn parse_single_arg(line: &str) -> &str {
    line.split_whitespace()
        .filter(|&s| !s.is_empty())
        .skip(1)
        .next()
        .expect("Missing argument after instruction code!")
}

/// Obtains the two arguments after an instruction code (assuming there are two).
fn parse_two_args(line: &str) -> (&str, &str) {
    let mut iter = line.split_whitespace().filter(|&s| !s.is_empty()).skip(1);
    let first = iter
        .next()
        .expect("Missing first argument after instruction code!")
        .trim_end_matches(",");
    let second = iter
        .next()
        .expect("Missing second argument after instruction code!");

    (first, second)
}

/// Represents an assembly instruction.
#[derive(Debug, PartialEq, Eq)]
enum Instruction<'a> {
    Mov(&'a str, Value<'a>),
    Inc(&'a str),
    Dec(&'a str),
    Add(&'a str, Value<'a>),
    Sub(&'a str, Value<'a>),
    Mul(&'a str, Value<'a>),
    Div(&'a str, Value<'a>),

    Label(&'a str),
    Jmp(Option<JumpCondition>, &'a str),
    Cmp(Value<'a>, Value<'a>),
    Call(&'a str),
    Ret,
    Msg(Vec<MessageValue<'a>>),
    End,
}

/// Represents either a register reference or an immediate value.
#[derive(Debug, PartialEq, Eq)]
enum Value<'a> {
    Reg(&'a str),
    Imm(i32),
}

/// Represents either a string literal or a register reference for message output.
#[derive(Debug, PartialEq, Eq)]
enum MessageValue<'a> {
    Lit(&'a str),
    Reg(&'a str),
}

/// Represents the possible conditions required to jump to a label.
#[derive(Debug, PartialEq, Eq)]
enum JumpCondition {
    Ne,
    E,
    Ge,
    G,
    Le,
    L,
}

/// Represents the result of a comparison.
struct ComparisonResult {
    eq: bool,
    lt: bool,
    gt: bool,
}

/// Interpreter context.
pub struct AssemblerInterpreter<'a> {
    /// Program counter - starts at 0
    pc: usize,

    /// Register values - initially empty
    regs: HashMap<&'a str, i32>,

    /// Mapping for label -> program line
    labels: HashMap<&'a str, usize>,

    /// Function call stack
    call_stack: Vec<usize>,

    /// Holds the result of a comparison - starts as None
    comparison: Option<ComparisonResult>,

    /// Program output - defaults to None
    ///
    /// If it's value is Some(...), then the value is only returned upon proper exit w/ 'end' command
    output: Option<String>,
}

impl<'a> TryFrom<&'a str> for Instruction<'a> {
    type Error = String;

    fn try_from(line: &'a str) -> Result<Self, Self::Error> {
        match get_instruction_code(line) {
            "mov" => {
                let (arg, val) = parse_two_args(line);
                Ok(Instruction::Mov(arg, Value::try_from(val)?))
            }
            "inc" => Ok(Instruction::Inc(parse_single_arg(line))),
            "dec" => Ok(Instruction::Dec(parse_single_arg(line))),
            "add" => {
                let (dst, val) = parse_two_args(line);
                Ok(Instruction::Add(dst, Value::try_from(val)?))
            }
            "sub" => {
                let (dst, val) = parse_two_args(line);
                Ok(Instruction::Sub(dst, Value::try_from(val)?))
            }
            "mul" => {
                let (dst, val) = parse_two_args(line);
                Ok(Instruction::Mul(dst, Value::try_from(val)?))
            }
            "div" => {
                let (dst, val) = parse_two_args(line);
                Ok(Instruction::Div(dst, Value::try_from(val)?))
            }
            l if l.ends_with(":") => Ok(Instruction::Label(l.trim_end_matches(":"))),
            "jmp" => Ok(Instruction::Jmp(None, parse_single_arg(line))),
            x if matches!(x, "jne" | "je" | "jge" | "jg" | "jle" | "jl") => Ok(Instruction::Jmp(
                Some(JumpCondition::try_from(x)?),
                parse_single_arg(line),
            )),
            "cmp" => {
                let (lhs, rhs) = parse_two_args(line);
                Ok(Instruction::Cmp(
                    Value::try_from(lhs)?,
                    Value::try_from(rhs)?,
                ))
            }
            "call" => Ok(Instruction::Call(parse_single_arg(line))),
            "ret" => Ok(Instruction::Ret),
            "msg" => {
                lazy_static! {
                    // Captures any strings or register references
                    // This will match 'msg' as well, so need to exclude it
                    static ref MSG_REGEX: Regex = Regex::new(r"('.*?'|\w+)+").unwrap();
                }

                let message_values = MSG_REGEX
                    .find_iter(line)
                    .skip(1)
                    .map(|m| MessageValue::try_from(m.as_str()).expect("Invalid msg argument"))
                    .collect::<Vec<_>>();

                Ok(Instruction::Msg(message_values))
            }
            "end" => Ok(Instruction::End),
            _ => Err(format!("Unknown instruction code '{}'", line)),
        }
    }
}

impl<'a> TryFrom<&'a str> for Value<'a> {
    type Error = String;

    fn try_from(value: &'a str) -> Result<Self, Self::Error> {
        if let Ok(int) = value.parse::<i32>() {
            Ok(Value::Imm(int))
        } else if value.chars().all(|c| c.is_ascii_alphabetic()) {
            Ok(Value::Reg(value))
        } else {
            Err(format!("Invalid integer or register reference '{}'", value))
        }
    }
}

impl TryFrom<&str> for JumpCondition {
    type Error = String;

    fn try_from(value: &str) -> Result<Self, Self::Error> {
        match value {
            "jne" => Ok(Self::Ne),
            "je" => Ok(Self::E),
            "jge" => Ok(Self::Ge),
            "jg" => Ok(Self::G),
            "jle" => Ok(Self::Le),
            "jl" => Ok(Self::L),
            _ => Err(format!("Invalid jump instruction '{}'", value)),
        }
    }
}

impl<'a> TryFrom<&'a str> for MessageValue<'a> {
    type Error = String;

    fn try_from(value: &'a str) -> Result<Self, Self::Error> {
        if value.starts_with('\'') && value.ends_with('\'') {
            Ok(MessageValue::Lit(
                value.trim_start_matches('\'').trim_end_matches('\''),
            ))
        } else if value.chars().all(|c| c.is_ascii_alphabetic()) {
            Ok(MessageValue::Reg(value))
        } else {
            Err(format!("Invalid message argument '{}'", value))
        }
    }
}

impl<'a> Value<'a> {
    /// Gets the actual integer value for this value wrapper.
    fn actual_value(&self, regs: &HashMap<&'a str, i32>) -> i32 {
        match self {
            &Value::Reg(reg) => *regs
                .get(reg)
                .expect("Attempted to read value from unintialized register"),
            &Value::Imm(val) => val,
        }
    }
}

impl From<Ordering> for ComparisonResult {
    fn from(ord: Ordering) -> Self {
        match ord {
            Ordering::Less => Self {
                lt: true,
                eq: false,
                gt: false,
            },
            Ordering::Equal => Self {
                lt: false,
                eq: true,
                gt: false,
            },
            Ordering::Greater => Self {
                lt: false,
                eq: false,
                gt: true,
            },
        }
    }
}

impl ComparisonResult {
    fn matches(&self, condition: &JumpCondition) -> bool {
        match condition {
            JumpCondition::Ne => !self.eq,
            JumpCondition::E => self.eq,
            JumpCondition::Ge => self.eq || self.gt,
            JumpCondition::G => self.gt,
            JumpCondition::Le => self.eq || self.lt,
            JumpCondition::L => self.lt,
        }
    }
}

impl<'a> AssemblerInterpreter<'a> {
    pub fn new() -> Self {
        Self {
            pc: 0,
            regs: HashMap::new(),
            labels: HashMap::new(),
            call_stack: Vec::new(),
            comparison: None,
            output: None,
        }
    }

    pub fn interpret(input: &str) -> Option<String> {
        let mut ctx = AssemblerInterpreter::new();

        // Convert the input string into a list of program lines:
        // - Split by newline
        // - Remove comments and trim leading/trailing whitespace
        // - Filter out empty lines
        let program = input
            .split_terminator('\n')
            .map(|line| match line.split_once(';') {
                Some((first, _)) => first.trim(),
                _ => line.trim(),
            })
            .filter(|&line| !line.is_empty())
            .map(|line| Instruction::try_from(line).expect("Invalid instruction encountered"))
            .collect::<Vec<_>>();

        // dbg!(program.iter().enumerate().collect::<Vec<_>>());

        // If there are any labels, note down where they are
        program.iter().enumerate().for_each(|(index, ins)| {
            if let &Instruction::Label(label) = ins {
                if ctx.labels.insert(label, index).is_some() {
                    panic!("Duplicate label {} found at index {}", label, index);
                }
            }
        });

        // dbg!(&ctx.labels);

        ctx.fetch_execute(&program)
    }

    /// Fetch-execute cycle.
    /// Returns the output (if present and the program terminates correctly), None otherwise.
    fn fetch_execute(&mut self, program: &'a [Instruction]) -> Option<String> {
        while self.pc < program.len() {
            match &program[self.pc] {
                Instruction::Mov(dst, val) => {
                    let val = val.actual_value(&self.regs);
                    self.regs.insert(dst, val);
                }
                Instruction::Inc(reg) => {
                    *self
                        .regs
                        .get_mut(reg)
                        .expect("Attempted to increment uninitialised register") += 1;
                }
                Instruction::Dec(reg) => {
                    *self
                        .regs
                        .get_mut(reg)
                        .expect("Attempted to decrement uninitialised register") -= 1;
                }
                Instruction::Add(dst, val) => {
                    let val = val.actual_value(&self.regs);
                    *self
                        .regs
                        .get_mut(dst)
                        .expect("Attempted to add to uninitialized register") += val;
                }
                Instruction::Sub(dst, val) => {
                    let val = val.actual_value(&self.regs);
                    *self
                        .regs
                        .get_mut(dst)
                        .expect("Attempted to subtract from uninitialized register") -= val;
                }
                Instruction::Mul(dst, val) => {
                    let val = val.actual_value(&self.regs);
                    *self
                        .regs
                        .get_mut(dst)
                        .expect("Attempted to multiply uninitialized register") *= val;
                }
                Instruction::Div(dst, val) => {
                    let val = val.actual_value(&self.regs);
                    *self
                        .regs
                        .get_mut(dst)
                        .expect("Attempted to divide uninitialized register") /= val;
                }
                Instruction::Label(_) => {}
                Instruction::Jmp(None, label) => {
                    self.pc = self.labels[label];
                }
                Instruction::Jmp(Some(cond), label) => {
                    if self
                        .comparison
                        .as_ref()
                        .expect("Attempted to jump without making a comparison first!")
                        .matches(cond)
                    {
                        self.pc = self.labels[label];
                    }
                }
                Instruction::Cmp(lhs, rhs) => {
                    let (lhs, rhs) = (lhs.actual_value(&self.regs), rhs.actual_value(&self.regs));
                    self.comparison = Some(ComparisonResult::from(lhs.cmp(&rhs)));
                }
                Instruction::Call(label) => {
                    self.call_stack.push(self.pc);
                    self.pc = self.labels[label];
                }
                Instruction::Ret => {
                    self.pc = self
                        .call_stack
                        .pop()
                        .expect("Attempted to return from call with empty call stack!");
                }
                Instruction::Msg(values) => {
                    if !values.is_empty() {
                        self.output = Some(
                            values
                                .iter()
                                .map(|val| match val {
                                    MessageValue::Lit(s) => s.to_string(),
                                    MessageValue::Reg(reg) => self.regs[reg].to_string(),
                                })
                                .collect::<String>(),
                        );
                    }
                }
                Instruction::End => return self.output.clone(),
            }

            self.pc += 1;
        }

        None
    }
}

#[cfg(test)]
pub mod tests {
    use super::*;

    macro_rules! parse_ins_test {
        ($name:ident, $str:expr, $expected:expr) => {
            #[test]
            fn $name() {
                assert_eq!(Instruction::try_from($str), Ok($expected));
            }
        };
    }

    macro_rules! program_test {
        ($name:ident, $filename:expr, $expected:expr) => {
            #[test]
            fn $name() {
                let program = include_str!($filename);
                let actual = AssemblerInterpreter::interpret(program);
                assert_eq!(actual, $expected.map(str::to_string));
            }
        };
    }

    #[test]
    fn remove_comments() {
        let string = "mov a, b  ; hello world";
        assert_eq!(string.split_once(";"), Some(("mov a, b  ", " hello world")));

        let string = "mov a, b";
        assert_eq!(string.split_once(";"), None);

        let string = "; mov a, b";
        assert_eq!(string.split_once(";"), Some(("", " mov a, b")));
    }

    #[test]
    fn get_instruction_code_works() {
        assert_eq!(get_instruction_code("mov a, b"), "mov");
        assert_eq!(get_instruction_code("ret"), "ret");
        assert_eq!(get_instruction_code("add     x,    y"), "add");
    }

    #[test]
    fn parse_single_arg_works() {
        assert_eq!(parse_single_arg("inc   a"), "a");
        assert_eq!(parse_single_arg("dec b"), "b");
    }

    #[test]
    fn parse_two_args_works() {
        assert_eq!(parse_two_args("mov a, b"), ("a", "b"));
        assert_eq!(parse_two_args("mul x,    y"), ("x", "y"));
    }

    // Instruction Parsing Tests
    parse_ins_test!(parse_mov, "mov a, 2", Instruction::Mov("a", Value::Imm(2)));
    parse_ins_test!(parse_inc, "inc x", Instruction::Inc("x"));
    parse_ins_test!(parse_dec, "dec y", Instruction::Dec("y"));
    parse_ins_test!(
        parse_add,
        "add b, x",
        Instruction::Add("b", Value::Reg("x"))
    );
    parse_ins_test!(
        parse_sub,
        "sub b, x",
        Instruction::Sub("b", Value::Reg("x"))
    );
    parse_ins_test!(
        parse_mul,
        "mul b, x",
        Instruction::Mul("b", Value::Reg("x"))
    );
    parse_ins_test!(
        parse_div,
        "div b, x",
        Instruction::Div("b", Value::Reg("x"))
    );

    parse_ins_test!(parse_label, "function:", Instruction::Label("function"));
    parse_ins_test!(parse_jmp, "jmp label", Instruction::Jmp(None, "label"));
    parse_ins_test!(
        parse_jne,
        "jne label",
        Instruction::Jmp(Some(JumpCondition::Ne), "label")
    );
    parse_ins_test!(
        parse_je,
        "je label",
        Instruction::Jmp(Some(JumpCondition::E), "label")
    );
    parse_ins_test!(
        parse_jge,
        "jge label",
        Instruction::Jmp(Some(JumpCondition::Ge), "label")
    );
    parse_ins_test!(
        parse_jg,
        "jg label",
        Instruction::Jmp(Some(JumpCondition::G), "label")
    );
    parse_ins_test!(
        parse_jle,
        "jle label",
        Instruction::Jmp(Some(JumpCondition::Le), "label")
    );
    parse_ins_test!(
        parse_jl,
        "jl label",
        Instruction::Jmp(Some(JumpCondition::L), "label")
    );

    parse_ins_test!(
        parse_cmp,
        "cmp 4, x",
        Instruction::Cmp(Value::Imm(4), Value::Reg("x"))
    );
    parse_ins_test!(parse_ret, "ret", Instruction::Ret);
    parse_ins_test!(
        parse_msg,
        "msg 'hello world', x, 'hi there', 'goodbye', y",
        Instruction::Msg(vec![
            MessageValue::Lit("hello world"),
            MessageValue::Reg("x"),
            MessageValue::Lit("hi there"),
            MessageValue::Lit("goodbye"),
            MessageValue::Reg("y"),
        ])
    );
    parse_ins_test!(parse_end, "end", Instruction::End);

    program_test!(
        simple_test_1,
        "assembler_interpreter_ii/simple_test_1.txt",
        Some("(5+1)/2 = 3")
    );

    program_test!(
        simple_test_2,
        "assembler_interpreter_ii/simple_test_2.txt",
        Some("5! = 120")
    );

    program_test!(
        simple_test_3,
        "assembler_interpreter_ii/simple_test_3.txt",
        Some("Term 8 of Fibonacci series is: 21")
    );

    program_test!(
        simple_test_4,
        "assembler_interpreter_ii/simple_test_4.txt",
        Some("mod(11, 3) = 2")
    );

    program_test!(
        simple_test_5,
        "assembler_interpreter_ii/simple_test_5.txt",
        Some("gcd(81, 153) = 9")
    );

    program_test!(
        simple_test_6,
        "assembler_interpreter_ii/simple_test_6.txt",
        None
    );

    program_test!(
        simple_test_7,
        "assembler_interpreter_ii/simple_test_7.txt",
        Some("2^10 = 1024")
    );
}
