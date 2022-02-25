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
//! function   ::= '[' arg-list ']' expression
//!
//! arg-list   ::= /* nothing */
//!              | variable arg-list
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
//! This can be implemented using an LL(1) parser; this require removing left recursion first (where `e` is epsilon / empty string):
//!
//! ```
//! function     ::= '[' arg-list ']' expression
//!
//! arg-list     ::= variable arg-list
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
//! This requires the FIRST and FOLLOW sets:
//!
//! ```
//! FIRST(integer)      = digit
//! FIRST(variable)     = char
//!
//! FIRST(function)     = [
//! FIRST(arg-list)     = FIRST(variable), e = char, e
//! FIRST(expression)   = FIRST(term) = digit, char, (
//! FIRST(expression_p) = +, -, e
//! FIRST(term)         = FIRST(factor) = digit, char, (
//! FIRST(term_p)       = *, /, e
//! FIRST(factor)       = digit, char, (
//!
//! FOLLOW(function)     = EOL
//! FOLLOW(arg-list)     = ], (FIRST(arg-list) - e) = ], char
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
    args: Option<Vec<String>>,
}

impl Compiler {
    fn new() -> Compiler {
        Compiler { args: None }
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

        // Top-level rule: Parse [ arg-list ] expression
        // The AST for the top-level expression is what we're after, so return that
        if iter.next().expect("Iterator is empty!") != "[" {
            panic!("Expected '[' to start argument list");
        }

        self.args = Some(self.parse_arg_list(&mut iter));

        if iter.next().expect("Expected ']' after argument list") != "]" {
            panic!("Expected ']' after argument list");
        }

        self.parse_expression(&mut iter)
    }

    fn parse_arg_list<'a>(
        &self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
    ) -> Vec<String> {
        // Parsing arguments is straightforward - can just loop until we have no more variables
        let mut arguments = Vec::new();
        while let Some(token) = iter.next() {
            if token == "]" {
                break;
            }

            arguments.push(token.clone());
        }

        arguments
    }

    /// expression   ::= term expression_p
    fn parse_expression<'a>(
        &mut self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
    ) -> Ast {
        todo!()
    }

    /// expression_p ::= '+' term expression_p
    ///                | '-' term expression_p
    ///                | e
    fn parse_expression_p<'a>(
        &mut self,
        iter: &mut Peekable<impl Iterator<Item = &'a String>>,
    ) -> Ast {
        todo!()
    }

    /// term         ::= factor term_p
    fn parse_term<'a>(&mut self, iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> Ast {
        todo!()
    }

    /// term_p       ::= '*' factor term_p
    ///                | '/' factor term_p
    ///                | e
    fn parse_term_p<'a>(&mut self, iter: &mut Peekable<impl Iterator<Item = &'a String>>) -> Ast {
        todo!()
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

    #[test]
    fn pass1_simple_program_works() {
        let mut compiler = Compiler::new();
        let actual_ast = compiler.pass1("[ x, y ] x + y");
        let expected_ast = Ast::BinOp(
            "+".to_string(),
            Box::new(Ast::UnOp("arg".to_string(), 0)),
            Box::new(Ast::UnOp("arg".to_string(), 1)),
        );

        assert_eq!(actual_ast, expected_ast);
    }

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
