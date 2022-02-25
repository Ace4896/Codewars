//! # Tiny Three-Pass Compiler
//!
//! Source: https://www.codewars.com/kata/5265b0885fda8eac5900093b/train/rust
//!
//! The three passes are the following:
//!
//! 1. Convert the tokens into an unreduced AST (can ignore errors, but might be worth adding anyway)
//!     - The instructions provide a specific format for this AST
//! 2. Reduce the AST by folding constant expressions
//! 3. Convert the AST to assembly
//!
//! The original grammar is this, where `function` is the top-level rule:
//!
//! ```
//! function   ::= '[' arg_list ']' expression
//!
//! arg_list   ::= /* nothing */
//!              | variable arg_list
//!
//! expression ::= term
//!              | expression '+' term
//!              | expression '-' term
//!
//! term       ::= factor
//!              | term '*' factor
//!              | term '/' factor
//!
//! factor     ::= number
//!              | variable
//!              | '(' expression ')'
//! ```
//!
//! Note that commas between variables in arg_list are missing - this needed to be dealt with.
//! This can be implemented using an LL(1) parser; this require removing left recursion first (where `e` is epsilon / empty string):
//!
//! ```
//! function     ::= '[' arg_list ']' expression
//!
//! arg_list     ::= variable arg_list_p
//! arg_list_p   ::= ',' variable arg_list_p
//!                | e
//!
//! expression   ::= term expression_p
//! expression_p ::= '+' term expression_p
//!                | '-' term expression_p
//!                | e
//!
//! term         ::= factor term_p
//! term_p       ::= '*' factor term_p
//!                | '/' factor term_p
//!                | e
//!
//! factor       ::= number
//!                | variable
//!                | '(' expression ')'
//! ```
//!
//! TODO: I never ended up using this - parsing is much simpler than I thought
//! This requires the FIRST and FOLLOW sets:
//!
//! ```
//! FIRST(integer)      = digit
//! FIRST(variable)     = char
//!
//! FIRST(function)     = [
//! FIRST(arg_list)     = FIRST(variable), e = char, e
//! FIRST(arg_list_p)   = ',', e
//! FIRST(expression)   = FIRST(term) = digit, char, (
//! FIRST(expression_p) = +, -, e
//! FIRST(term)         = FIRST(factor) = digit, char, (
//! FIRST(term_p)       = *, /, e
//! FIRST(factor)       = digit, char, (
//!
//! FOLLOW(function)     = EOL
//! FOLLOW(arg_list)     = ]
//! FOLLOW(arg_list_p)   =
//! FOLLOW(expression)   = ), EOL
//! FOLLOW(expression_p) = FOLLOW(expression) = ), EOL
//! FOLLOW(term)         = (FIRST(expression_p - e)), FOLLOW(expression) = +, -, ), EOL
//! FOLLOW(term_p)       = FOLLOW(term) = +, -, ), EOL
//! FOLLOW(factor)       = (FIRST(term_p) - e), FOLLOW(term) = +, -, *, /, ), EOL
//! ```

use std::iter::Peekable;

#[derive(Debug, PartialEq, Eq)]
enum Ast {
    BinOp(String, Box<Ast>, Box<Ast>),
    UnOp(String, i32),
}

struct Compiler {
    args: Vec<String>,
}

impl Compiler {
    fn new() -> Compiler {
        Compiler { args: Vec::new() }
    }

    fn tokenize<'a>(&self, program: &'a str) -> Vec<String> {
        let mut tokens: Vec<String> = vec![];

        let mut iter = program.chars().peekable();
        loop {
            match iter.peek() {
                Some(&c) => match c {
                    'a'..='z' | 'A'..='Z' => {
                        let mut tmp = String::new();
                        while iter.peek().is_some() && iter.peek().unwrap().is_alphabetic() {
                            tmp.push(iter.next().unwrap());
                        }
                        tokens.push(tmp);
                    }
                    '0'..='9' => {
                        let mut tmp = String::new();
                        while iter.peek().is_some() && iter.peek().unwrap().is_numeric() {
                            tmp.push(iter.next().unwrap());
                        }
                        tokens.push(tmp);
                    }
                    ' ' => {
                        iter.next();
                    }
                    _ => {
                        tokens.push(iter.next().unwrap().to_string());
                    }
                },
                None => break,
            }
        }

        tokens
    }

    fn compile(&mut self, program: &str) -> Vec<String> {
        let ast = self.pass1(program);
        let ast = self.pass2(&ast);
        self.pass3(&ast)
    }

    fn pass1(&mut self, program: &str) -> Ast {
        let tokens = self.tokenize(program);
        let mut iter = tokens.iter().peekable();

        // Top-level rule: Parse [ arg_list ] expression
        // The AST for the top-level expression is what we're after, so return that
        if iter.next().expect("Iterator is empty!") != "[" {
            panic!("Expected '[' to start argument list");
        }

        self.args = self.parse_arg_list(&mut iter);

        if iter.next().expect("Expected ']' after argument list") != "]" {
            panic!("Expected ']' after argument list");
        }

        self.parse_expression(&mut iter)
    }

    /// arg_list     ::= variable arg_list_p
    /// arg_list_p   ::= ',' variable arg_list_p
    ///                | e
    fn parse_arg_list<'a>(
        &self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
    ) -> Vec<String> {
        // The two production rules can be parsed in-line - no need for recursion
        let mut arguments = Vec::new();

        match iter.peek().expect("Incomplete argument list").as_str() {
            // No arguments provided
            "]" => arguments,
            _ => {
                // Parse the argument
                arguments.push(iter.next().unwrap().clone());

                // Keep parsing arguments while the next token is a ','
                while iter.peek().expect("Incomplete argument list").as_str() == "," {
                    // Consume the ',', then parse the argument
                    iter.next().unwrap();
                    arguments.push(iter.next().unwrap().clone());
                }

                arguments
            }
        }
    }

    /// expression   ::= term expression_p
    fn parse_expression<'a>(
        &mut self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
    ) -> Ast {
        let lhs = self.parse_term(iter);
        self.parse_expression_p(iter, lhs)
    }

    /// expression_p ::= '+' term expression_p
    ///                | '-' term expression_p
    ///                | e
    fn parse_expression_p<'a>(
        &mut self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
        lhs: Ast,
    ) -> Ast {
        if matches!(iter.peek().map(|s| s.as_str()), Some("+") | Some("-")) {
            // TODO: This performs a rightmost derivation, which is incorrect for division
            let op = iter.next().unwrap();
            let rhs = self.parse_term(iter);

            // If this additive expression continues, use rhs as the "lhs" for that subtree
            let subtree = self.parse_expression_p(iter, rhs);

            Ast::BinOp(op.clone(), Box::new(lhs), Box::new(subtree))
        } else {
            lhs
        }
    }

    /// term         ::= factor term_p
    fn parse_term<'a>(&mut self, iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> Ast {
        let lhs = self.parse_factor(iter);
        self.parse_term_p(iter, lhs)
    }

    /// term_p       ::= '*' factor term_p
    ///                | '/' factor term_p
    ///                | e
    fn parse_term_p<'a>(
        &mut self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
        lhs: Ast,
    ) -> Ast {
        if matches!(iter.peek().map(|s| s.as_str()), Some("*") | Some("/")) {
            // TODO: This performs a rightmost derivation, which is incorrect for division
            let op = iter.next().unwrap();
            let rhs = self.parse_factor(iter);

            // If this multiplicative expression continues, use rhs as the "lhs" for that subtree
            let subtree = self.parse_expression_p(iter, rhs);

            Ast::BinOp(op.clone(), Box::new(lhs), Box::new(subtree))
        } else {
            lhs
        }
    }

    /// factor       ::= number
    ///                | variable
    ///                | '(' expression ')'
    fn parse_factor<'a>(&mut self, iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> Ast {
        match iter
            .next()
            .expect("Incomplete arithmetic expression")
            .as_str()
        {
            // Immediate integer value
            n if n.chars().all(|c| c.is_ascii_digit()) => {
                let imm_val = n
                    .parse::<i32>()
                    .expect("Could not parse immediate value into i32!");

                Ast::UnOp("imm".to_string(), imm_val)
            }
            // Variable reference
            n if n.chars().all(|c| c.is_ascii_alphabetic()) => {
                let var_index = self
                    .args
                    .iter()
                    .position(|arg| arg == n)
                    .expect("Non-existent variable used") as i32;

                Ast::UnOp("arg".to_string(), var_index)
            }
            // Subexpression
            "(" => {
                // Parse the subtree and consume the right parenthesis
                let subtree = self.parse_expression(iter);
                iter.next().unwrap();

                subtree
            }
            _ => panic!("Expected integer, variable or parenthesised subexpression"),
        }
    }

    fn pass2(&mut self, ast: &Ast) -> Ast {
        todo!()
    }

    fn pass3(&mut self, ast: &Ast) -> Vec<String> {
        todo!()
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    macro_rules! pass1_test {
        ($name:ident, $program:expr, $expected_args:expr, $expected_ast:expr) => {
            #[test]
            fn $name() {
                let mut compiler = Compiler::new();

                let actual_ast = compiler.pass1($program);

                assert_eq!(actual_ast, $expected_ast);
                assert_eq!(&compiler.args, &$expected_args);
            }
        };
    }

    pass1_test!(
        simple_program,
        "[ x ] x + 5",
        ["x"],
        Ast::BinOp(
            "+".to_string(),
            Box::new(Ast::UnOp("arg".to_string(), 0)),
            Box::new(Ast::UnOp("imm".to_string(), 5)),
        )
    );

    pass1_test!(
        multiple_adds_subs,
        "[ x ] x + 5 - 2 + 4",
        ["x"],
        Ast::BinOp(
            "+".to_string(),
            Box::new(Ast::BinOp(
                "-".to_string(),
                Box::new(Ast::BinOp(
                    "+".to_string(),
                    Box::new(Ast::UnOp("arg".to_string(), 0)),
                    Box::new(Ast::UnOp("imm".to_string(), 5)),
                )),
                Box::new(Ast::UnOp("imm".to_string(), 2)),
            )),
            Box::new(Ast::UnOp("imm".to_string(), 4)),
        )
    );

    pass1_test!(
        multiple_muls_divs,
        "[ x ] x * 5 / 4 * 2",
        ["x"],
        Ast::BinOp(
            "*".to_string(),
            Box::new(Ast::BinOp(
                "/".to_string(),
                Box::new(Ast::BinOp(
                    "*".to_string(),
                    Box::new(Ast::UnOp("arg".to_string(), 0)),
                    Box::new(Ast::UnOp("imm".to_string(), 5)),
                )),
                Box::new(Ast::UnOp("imm".to_string(), 4)),
            )),
            Box::new(Ast::UnOp("imm".to_string(), 2)),
        )
    );

    pass1_test!(
        mixed_add_mul,
        "[ ] 1 * 2 + 3 * 4",
        Vec::<String>::new(),
        Ast::BinOp(
            "+".to_string(),
            Box::new(Ast::BinOp(
                "*".to_string(),
                Box::new(Ast::UnOp("imm".to_string(), 1)),
                Box::new(Ast::UnOp("imm".to_string(), 2)),
            )),
            Box::new(Ast::BinOp(
                "*".to_string(),
                Box::new(Ast::UnOp("imm".to_string(), 3)),
                Box::new(Ast::UnOp("imm".to_string(), 4)),
            )),
        )
    );

    pass1_test!(
        parenthesised_expression,
        "[ ] ( 1 + 2 ) * ( 4 - 3 )",
        Vec::<String>::new(),
        Ast::BinOp(
            "*".to_string(),
            Box::new(Ast::BinOp(
                "+".to_string(),
                Box::new(Ast::UnOp("imm".to_string(), 1)),
                Box::new(Ast::UnOp("imm".to_string(), 2)),
            )),
            Box::new(Ast::BinOp(
                "-".to_string(),
                Box::new(Ast::UnOp("imm".to_string(), 4)),
                Box::new(Ast::UnOp("imm".to_string(), 3)),
            )),
        )
    );

    #[test]
    fn simulator() {
        assert_eq!(simulate(vec!["IM 7".to_string()], vec![3]), 7);
        assert_eq!(simulate(vec!["AR 1".to_string()], vec![1, 2, 3]), 2);
    }

    fn simulate(assembly: Vec<String>, argv: Vec<i32>) -> i32 {
        let mut r = (0, 0);
        let mut stack: Vec<i32> = vec![];

        for ins in assembly {
            let mut ws = ins.split_whitespace();
            match ws.next() {
                Some("IM") => r.0 = i32::from_str_radix(ws.next().unwrap(), 10).unwrap(),
                Some("AR") => {
                    r.0 = argv[i32::from_str_radix(ws.next().unwrap(), 10).unwrap() as usize]
                }
                Some("SW") => r = (r.1, r.0),
                Some("PU") => stack.push(r.0),
                Some("PO") => r.0 = stack.pop().unwrap(),
                Some("AD") => r.0 += r.1,
                Some("SU") => r.0 -= r.1,
                Some("MU") => r.0 *= r.1,
                Some("DI") => r.0 /= r.1,
                _ => panic!("Invalid instruction encountered"),
            }
        }
        r.0
    }
}
