//! https://www.codewars.com/kata/584daf7215ac503d5a0001ae/train/rust
//!
//! This solution solves the Kata in four steps:
//!
//! 1. Parse the prefix expression into an AST
//! 2. Simplify the AST where possible
//! 3. Differentiate the simplified AST
//! 4. Convert the final AST into a string
//!
//! The grammar that each prefix expression follows is this:
//!
//! ```
//! expr        ::= factor
//!               | '(' binary_op expr expr ')'
//!               | '(' function expr ')'
//!
//! binary_op   ::= '+' | '-' | '*' | '/' | '^'
//! function    ::= 'sin' | 'cos' | 'tan' | 'exp' | 'ln'
//! factor      ::= number | 'x'
//! ```
//!
//! We can parse this with an LL(1) recursive descent parser, but left factoring is required for `expr`:
//!
//! ```
//! expr        ::= factor
//!               | '(' expr_p ')'
//! expr_p      ::= binary_op expr expr
//!               | function expr
//! ```

/// AST representation of the mathematical expression.
#[derive(Debug, PartialEq, Eq)]
pub enum Ast {
    /// The variable `x` with a particular coefficient.
    X(i32),

    /// An integer literal.
    Literal(i32),

    /// A binary operation.
    BinaryOp(Operator, Box<Ast>, Box<Ast>),

    /// A function application.
    Function(Function, Box<Ast>),
}

/// Represents the supported binary operators.
#[derive(Debug, PartialEq, Eq)]
pub enum Operator {
    Add,
    Sub,
    Mul,
    Div,
    Pow,
}

impl TryFrom<&str> for Operator {
    type Error = &'static str;

    fn try_from(value: &str) -> Result<Self, Self::Error> {
        match value {
            "+" => Ok(Self::Add),
            "-" => Ok(Self::Sub),
            "*" => Ok(Self::Mul),
            "/" => Ok(Self::Div),
            "^" => Ok(Self::Pow),
            _ => Err("Unsupported operator"),
        }
    }
}

/// Represents the supported functions.
#[derive(Debug, PartialEq, Eq)]
pub enum Function {
    Sin,
    Cos,
    Tan,
    Exp,
    Ln,
}

impl TryFrom<&str> for Function {
    type Error = &'static str;

    fn try_from(value: &str) -> Result<Self, Self::Error> {
        match value {
            "sin" => Ok(Self::Sin),
            "cos" => Ok(Self::Cos),
            "tan" => Ok(Self::Tan),
            "exp" => Ok(Self::Exp),
            "ln" => Ok(Self::Ln),
            _ => Err("Unsupported function"),
        }
    }
}

fn diff(expr: &str) -> String {
    let ast = parser::build_ast(expr);
    // TODO: AST Simplification
    // TODO: AST Differentation
    // TODO: AST -> Prefix Expression

    expr.to_string()
}

mod parser {
    use std::iter::Peekable;

    use super::{Ast, Function, Operator};

    const BINARY_OPS: [&'static str; 5] = ["+", "-", "*", "/", "^"];
    const FUNCTIONS: [&'static str; 5] = ["sin", "cos", "tan", "exp", "ln"];

    #[inline]
    fn is_integer(s: &str) -> bool {
        s.chars().all(|c| c.is_ascii_digit() || c == '-')
    }

    pub fn build_ast(expr: &str) -> Ast {
        // To make parsing slightly easier, add a single space after '(' and before ')'
        // This allows us to split the tokens by whitespace
        let expr = expr.replace('(', "( ").replace(')', " )");
        let mut iter = expr.split_whitespace().peekable();

        parse_expr(&mut iter)
    }

    fn parse_expr<'a>(iter: &mut Peekable<impl Iterator<Item = &'a str>>) -> Ast {
        match *iter.peek().unwrap() {
            x if x == "x" || is_integer(x) => parse_factor(iter),
            "(" => {
                // Consume left parenthesis, parse subexpression, and consume right parenthesis
                iter.next();
                let expr = parse_expr_p(iter);
                iter.next();

                expr
            }
            t => panic!("Invalid token '{}' found in expression", t),
        }
    }

    fn parse_expr_p<'a>(iter: &mut Peekable<impl Iterator<Item = &'a str>>) -> Ast {
        match *iter.peek().unwrap() {
            x if BINARY_OPS.contains(&x) => {
                let operator = Operator::try_from(x).unwrap();
                iter.next();

                let lhs = parse_expr(iter);
                let rhs = parse_expr(iter);

                Ast::BinaryOp(operator, Box::new(lhs), Box::new(rhs))
            }
            x if FUNCTIONS.contains(&x) => {
                let function = Function::try_from(x).unwrap();
                iter.next();

                let argument = parse_expr(iter);

                Ast::Function(function, Box::new(argument))
            }
            t => panic!("Invalid token '{}' found in expression", t),
        }
    }

    fn parse_factor<'a>(iter: &mut Peekable<impl Iterator<Item = &'a str>>) -> Ast {
        match iter.next().unwrap() {
            "x" => Ast::X(1),
            x if is_integer(x) => Ast::Literal(x.parse::<i32>().unwrap()),
            t => panic!("Cannot use '{}' as integer literal or variable", t),
        }
    }
}

#[cfg(test)]
mod tests {
    use super::parser::*;
    use super::*;

    macro_rules! diff_eq {
        ($input:expr, $expected:expr) => {
            assert_eq!(diff($input), $expected);
        };
    }

    macro_rules! ast_eq {
        ($input:expr, $expected:expr) => {
            assert_eq!(build_ast($input), $expected);
        };
    }

    #[test]
    fn build_ast_single_value() {
        ast_eq!("5", Ast::Literal(5));
        ast_eq!("x", Ast::X(1));
    }

    #[test]
    fn build_ast_single_operator() {
        ast_eq!(
            "(+ x 1)",
            Ast::BinaryOp(
                Operator::Add,
                Box::new(Ast::X(1)),
                Box::new(Ast::Literal(1))
            )
        );

        ast_eq!(
            "(- x 1)",
            Ast::BinaryOp(
                Operator::Sub,
                Box::new(Ast::X(1)),
                Box::new(Ast::Literal(1))
            )
        );

        ast_eq!(
            "(* x 1)",
            Ast::BinaryOp(
                Operator::Mul,
                Box::new(Ast::X(1)),
                Box::new(Ast::Literal(1))
            )
        );

        ast_eq!(
            "(/ x 1)",
            Ast::BinaryOp(
                Operator::Div,
                Box::new(Ast::X(1)),
                Box::new(Ast::Literal(1))
            )
        );

        ast_eq!(
            "(^ x 1)",
            Ast::BinaryOp(
                Operator::Pow,
                Box::new(Ast::X(1)),
                Box::new(Ast::Literal(1))
            )
        );
    }

    #[test]
    fn build_ast_single_function() {
        ast_eq!("(sin x)", Ast::Function(Function::Sin, Box::new(Ast::X(1))));
        ast_eq!("(cos x)", Ast::Function(Function::Cos, Box::new(Ast::X(1))));
        ast_eq!("(tan x)", Ast::Function(Function::Tan, Box::new(Ast::X(1))));
        ast_eq!("(exp x)", Ast::Function(Function::Exp, Box::new(Ast::X(1))));
        ast_eq!("(ln x)", Ast::Function(Function::Ln, Box::new(Ast::X(1))));
    }

    #[test]
    fn build_ast_parenthesised_expr() {
        ast_eq!(
            "(+ x (+ x x))",
            Ast::BinaryOp(
                Operator::Add,
                Box::new(Ast::X(1)),
                Box::new(Ast::BinaryOp(
                    Operator::Add,
                    Box::new(Ast::X(1)),
                    Box::new(Ast::X(1))
                ))
            )
        );

        ast_eq!(
            "(- (+ x x) x)",
            Ast::BinaryOp(
                Operator::Sub,
                Box::new(Ast::BinaryOp(
                    Operator::Add,
                    Box::new(Ast::X(1)),
                    Box::new(Ast::X(1))
                )),
                Box::new(Ast::X(1)),
            )
        );

        ast_eq!(
            "(- (+ x x) (* x 2))",
            Ast::BinaryOp(
                Operator::Sub,
                Box::new(Ast::BinaryOp(
                    Operator::Add,
                    Box::new(Ast::X(1)),
                    Box::new(Ast::X(1))
                )),
                Box::new(Ast::BinaryOp(
                    Operator::Mul,
                    Box::new(Ast::X(1)),
                    Box::new(Ast::Literal(2))
                )),
            )
        );

        ast_eq!(
            "(cos (+ x (- 2 1)))",
            Ast::Function(
                Function::Cos,
                Box::new(Ast::BinaryOp(
                    Operator::Add,
                    Box::new(Ast::X(1)),
                    Box::new(Ast::BinaryOp(
                        Operator::Sub,
                        Box::new(Ast::Literal(2)),
                        Box::new(Ast::Literal(1))
                    ))
                ))
            )
        );
    }

    #[test]
    fn diff_single_value() {
        diff_eq!("5", "0");
        diff_eq!("x", "1");
        diff_eq!("5", "0");
    }

    #[test]
    fn diff_simple_operator() {
        diff_eq!("(+ x x)", "2");
        diff_eq!("(- x x)", "0");
        diff_eq!("(* x 2)", "2");
        diff_eq!("(/ x 2)", "0.5");
        diff_eq!("(^ x 2)", "(* 2 x)");

        let result = diff(&diff("(^ x 3)"));
        assert!(
            result == "(* 3 (* 2 x))" || result == "(* 6 x)",
            "expected (* 3 (* 2 x)) or (* 6 x)"
        );
    }

    #[test]
    fn diff_simple_function() {
        diff_eq!("(cos x)", "(* -1 (sin x))");
        diff_eq!("(sin x)", "(cos x)");

        let result = diff("(tan x)");
        assert!(
            result == "(+ 1 (^ (tan x) 2))" || result == "(/ 1 (^ (cos x) 2))",
            "expected (+ 1 (^ (tan x) 2)) or (/ 1 (^ (cos x) 2))"
        );

        diff_eq!("(exp x)", "(exp x)");
        diff_eq!("(ln x)", "(/ 1 x)");
    }

    #[test]
    fn diff_multiple_operators() {
        diff_eq!("(+ x (+ x x))", "3");
        diff_eq!("(- (+ x x) x)", "1");
        diff_eq!("(* 2 (+ x 2))", "2");
        diff_eq!("(/ 2 (+ 1 x))", "(/ -2 (^ (+ 1 x) 2))");
    }

    #[test]
    fn diff_complex_functions() {
        diff_eq!("(cos (+ x 1))", "(* -1 (sin (+ x 1)))");

        let result = diff("(cos (* 2 x))");
        assert!(
            result == "(* 2 (* -1 (sin (* 2 x))))"
                || result == "(* -2 (sin (* 2 x)))"
                || result == "(* (* -1 (sin (* 2 x))) 2)",
            "expected (* 2 (* -1 (sin (* 2 x)))) or (* -2 (sin (* 2 x))) or (* (* -1 (sin (* 2 x))) 2)"
        );

        diff_eq!("(sin (+ x 1))", "(cos (+ x 1))");
        diff_eq!("(sin (* 2 x))", "(* 2 (cos (* 2 x)))");

        let result = diff("(tan (* 2 x))");
        assert!(
            result == "(* 2 (+ 1 (^ (tan (* 2 x)) 2)))"
                || result == "(* 2 (/ 1 (^ (cos (* 2 x)) 2)))",
            "expected (* 2 (+ 1 (^ (tan (* 2 x)) 2))) or (* 2 (/ 1 (^ (cos (* 2 x)) 2)))"
        );

        diff_eq!("(exp (* 2 x))", "(* 2 (exp (* 2 x)))");
        assert_eq!(diff(&diff("(exp x)")), "(exp x)");
        assert_eq!(diff(&diff("(sin x)")), "(* -1 (sin x))");
    }
}
