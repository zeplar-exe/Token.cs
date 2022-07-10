using System.Collections;

namespace TokenCs;

/// <summary>
/// Wrapper around <see cref="Tokenizer"/> which subdivides tokens into more concrete types.
/// </summary>
public class Lexer : IEnumerable<LexerToken>
{
    private IEnumerable<Token> Enumerable { get; }

    /// <summary>
    /// Create a <see cref="Lexer"/> with an enumerable of characters.
    /// </summary>
    /// <param name="characters">Characters to parse.</param>
    public Lexer(IEnumerable<char> characters) : this(new Tokenizer(characters))
    {
        
    }
    
    /// <summary>
    /// Create a <see cref="Lexer"/> with an enumerable of <see cref="Token">Tokens</see>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <remarks>A <see cref="Tokenizer"/> instance is valid in this constructor due to it inheriting from
    /// <see cref="IEnumerable{Token}"/>.</remarks>
    public Lexer(IEnumerable<Token> enumerable)
    {
        Enumerable = enumerable;
    }

    /// <inheritdoc />
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

    /// <summary>
    /// Determine the <see cref="LexerTokenType"/> of a given <see cref="Token"/>.
    /// </summary>
    /// <param name="token">The token to check.</param>
    public static LexerTokenType DetermineType(Token token)
    {
        switch (token.Type)
        {
            case TokenType.Alphabetic:
            {
                return LexerTokenType.AlphaNumeric;
            }
            case TokenType.Numeric:
            {
                return LexerTokenType.Numeric;
            }
            case TokenType.NewLine:
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
            case TokenType.Symbol:
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
            default:
            {
                return LexerTokenType.Unknown;
            }
        }
    }
}