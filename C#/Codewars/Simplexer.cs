// This one is long, but we're meant to implement a simple lexer
// So we take in an input string, then produce tokens from it
// No offline tests for this since I don't know what the implementation for Iterator<T> is

namespace Codewars
{
#nullable disable
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    // NOTE: This class is hidden from the solution
    // It's an extension of IEnumerator<T> with default implementation of Reset(), Dispose() and Current
    public abstract class Iterator<T>
    {
        public abstract bool MoveNext();
        public abstract Token Current { get; }
    }

    // NOTE: This class is hidden from the solution
    // Hopefully it doesn't matter too much
    public class Token
    {
        public string Text { get; }
        public string Type { get; }

        public Token(string text, string type)
        {
            Text = text;
            Type = type;
        }
    }

    public class Simplexer : Iterator<Token>
    {
        // Various tokens and regexes for language constructs
        private static readonly Regex STRING_REGEX = new Regex(@""".*""", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex IDENT_REGEX = new Regex(@"[a-zA-Z_\$][a-zA-Z0-9_\$]*", RegexOptions.Compiled);

        private static readonly string[] BOOLEAN = { "true", "false" };
        private static readonly char[] OPERATORS =
        {
            '+', '-', '*', '/', '%', '(', ')', '='
        };

        private static readonly string[] KEYWORDS =
        {
            "if", "else", "for", "while", "return", "func", "break"
        };

        private readonly string _buffer;    // Input string
        private Token _current;             // The current token
        private int _currentPos;            // Cursor position; everything before this index has been parsed

        public Simplexer(string buffer)
        {
            _buffer = buffer;
            _current = null;
        }

        public override Token Current
        {
            get => _current ?? throw new InvalidOperationException();
        }

        public override bool MoveNext()
        {
            if (_buffer is null || _buffer.Length == 0 || _currentPos >= _buffer.Length)
            {
                _current = null;
                return false;
            }

            // Special case: Check if the current character is an operator
            // Necessary since they're strings of length 1, and there may not be any whitespace between this and any identifiers / constants
            if (OPERATORS.Contains(_buffer[_currentPos]))
            {
                _current = new Token(_buffer.Substring(_currentPos, 1), "operator");
                _currentPos += 1;
                return true;
            }

            // Main case: Find the start and end index for the token we're currently trying to parse
            // Non-operator tokens are separated by whitespace or operators, so use this to determine when the current token ends
            var start = _currentPos;
            var end = _currentPos + 1;
            var startIsWhitespace = char.IsWhiteSpace(_buffer[start]);

            while (end < _buffer.Length && char.IsWhiteSpace(_buffer[end]) == startIsWhitespace && !OPERATORS.Contains(_buffer[end]))
            {
                end += 1;
            }

            // The value of the new token is everything from start until (non-inclusive) end
            // Due to initial check when this function started, we're guaranteed to have at least one character in this token
            var text = _buffer[start..end];

            // New current position is where we stopped looping
            _currentPos = end;

            // Determine which kind of token this is
            // Priority is based on order of checks here
            // - Only conflict to manage is boolean and keyword need to be checked before identifier
            // 
            // NOTE: Behaviour for invalid tokens wasn't specified, so "unknown" type was used
            var type = "unknown";
            if (startIsWhitespace)
            {
                type = "whitespace";
            }
            else if (IsInteger(text))
            {
                type = "integer";
            }
            else if (IsBoolean(text))
            {
                type = "boolean";
            }
            else if (IsString(text))
            {
                type = "string";
            }
            else if (IsKeyword(text))
            {
                type = "keyword";
            }
            else if (IsIdentifier(text))
            {
                type = "identifier";
            }

            _current = new Token(text, type);
            return true;
        }

        private static bool IsInteger(string s) => s.Length > 0 && s.All(char.IsDigit);
        private static bool IsBoolean(string s) => BOOLEAN.Contains(s);
        private static bool IsString(string s) => STRING_REGEX.IsMatch(s);
        private static bool IsKeyword(string s) => KEYWORDS.Contains(s);
        private static bool IsIdentifier(string s) => IDENT_REGEX.IsMatch(s);
    }
#nullable restore
}
