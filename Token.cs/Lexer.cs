using System.Collections;

namespace TokenCs;

public class Lexer : IEnumerable<LexerToken>
{
    private IEnumerable<Token> Enumerable { get; }

    public Lexer(IEnumerable<char> characters)
    {
        Enumerable = new Tokenizer(characters);
    }
    
    public Lexer(IEnumerable<Token> enumerable)
    {
        Enumerable = enumerable;
    }

    public IEnumerator<LexerToken> GetEnumerator()
    {
        using var instance = new LexInstance(Enumerable.GetEnumerator());

        while (instance.ProcessNext() is { } token) // not null
        {
            yield return token;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static LexerTokenType DetermineType(Token token)
    {
        switch (token.Type)
        {
            case TokenType.Alphabetic:
            {
                return LexerTokenType.Alphabetic;
            }
            case TokenType.Numeric:
            {
                return LexerTokenType.Numeric;
            }
            case TokenType.Symbol:
            {
                return token.Text switch
                {
                    "\r" => LexerTokenType.CarriageReturn,
                    "\n" => LexerTokenType.LineFeed,
                    "\r\n" => LexerTokenType.CarriageReturnLineFeed,
                    _ => LexerTokenType.Unknown
                };
            }
            case TokenType.Whitespace:
            {
                return token.Text switch
                {
                    " " => LexerTokenType.Space,
                    "\t" => LexerTokenType.Tab,
                    _ => LexerTokenType.Unknown
                };
            }
            case TokenType.NewLine:
            {
                return token.Text switch
                {
                    "`" => LexerTokenType.Backtick,
                    "~" => LexerTokenType.Tilde,
                    "!" => LexerTokenType.ExclamationMark,
                    "@" => LexerTokenType.At,
                    "#" => LexerTokenType.Hashtag,
                    "$" => LexerTokenType.Dollar,
                    "%" => LexerTokenType.Percent,
                    "^" => LexerTokenType.Caret,
                    "&" => LexerTokenType.Ampersand,
                    "*" => LexerTokenType.Star,
                    "(" => LexerTokenType.LeftParenthesis,
                    ")" => LexerTokenType.RightParenthesis,
                    "-" => LexerTokenType.Dash,
                    "_" => LexerTokenType.Underscore,
                    "=" => LexerTokenType.Equals,
                    "+" => LexerTokenType.Plus,
                    "[" => LexerTokenType.LeftBracket,
                    "{" => LexerTokenType.LeftCurlyBracket,
                    "]" => LexerTokenType.RightBracket,
                    "}" => LexerTokenType.RightCurlyBracket,
                    "\\" => LexerTokenType.Backslash,
                    "|" => LexerTokenType.VerticalLine,
                    ";" => LexerTokenType.Semicolon,
                    ":" => LexerTokenType.Colon,
                    "'" => LexerTokenType.SingleQuotation,
                    "\"" => LexerTokenType.DoubleQuotation,
                    "," => LexerTokenType.Comma,
                    "<" => LexerTokenType.LessThan,
                    "." => LexerTokenType.Period,
                    ">" => LexerTokenType.GreaterThan,
                    "/" => LexerTokenType.Slash,
                    "?" => LexerTokenType.QuestionMark,
                    _ => LexerTokenType.Unknown
                };
            }
            case TokenType.Unknown:
            {
                return LexerTokenType.Unknown;
            }
        }

        return LexerTokenType.Unknown;
    }
}