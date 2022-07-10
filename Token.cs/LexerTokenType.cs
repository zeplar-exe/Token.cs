namespace TokenCs;

/// <summary>
/// Type of a <see cref="LexerToken"/>.
/// </summary>
public enum LexerTokenType
{
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is not handled by the <see cref="Lexer"/>.
    /// </summary>
    Unknown,
    
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is made up of letters and digits.
    /// </summary>
    AlphaNumeric,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is made up of digits and may be a decimal."/>.
    /// </summary>
    Numeric,
    
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a backtick (`).
    /// </summary>
    Backtick,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a tilde (~).
    /// </summary>
    Tilde,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is an exclamation mark (~).
    /// </summary>
    ExclamationMark,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is an at sign (@).
    /// </summary>
    At,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a hashtag (#).
    /// </summary>
    Hashtag,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a dollar sign ($).
    /// </summary>
    Dollar,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a percent symbol (%).
    /// </summary>
    Percent,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a caret (^).
    /// </summary>
    Caret,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is an ampersand (&amp;).
    /// </summary>
    Ampersand,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a star (*).
    /// </summary>
    Star,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a left parenthesis ( ( ).
    /// </summary>
    LeftParenthesis,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is right parenthesis ( ) ).
    /// </summary>
    RightParenthesis,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a dash (-).
    /// </summary>
    Dash,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is an underscore (_).
    /// </summary>
    Underscore,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is an equals sign (=).
    /// </summary>
    Equals,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a plus sign (-).
    /// </summary>
    Plus,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a left bracket ( [ ).
    /// </summary>
    LeftBracket,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a left curly bracket ( { ).
    /// </summary>
    LeftCurlyBracket,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a right bracket ( ] ).
    /// </summary>
    RightBracket,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a right curly bracket ( } ).
    /// </summary>
    RightCurlyBracket,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a backslash (\).
    /// </summary>
    Backslash,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a vertical line (|).
    /// </summary>
    VerticalLine,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a semicolon (;).
    /// </summary>
    Semicolon,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a colon (:).
    /// </summary>
    Colon,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a single quotation mark (').
    /// </summary>
    SingleQuotation,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a double quotation mark (").
    /// </summary>
    DoubleQuotation,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a comma (,).
    /// </summary>
    Comma,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a less than sign (&lt;).
    /// </summary>
    LessThan,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a period (.).
    /// </summary>
    Period,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a greater than sign (&gt;).
    /// </summary>
    GreaterThan,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a forward slash (/).
    /// </summary>
    Slash,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a question mark (?).
    /// </summary>
    QuestionMark,

    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a tab <b>character</b> (\t).
    /// </summary>
    Tab,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a space character ( ).
    /// </summary>
    Space,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a carriage return (\r).
    /// </summary>
    CarriageReturn,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is a line feed (\n).
    /// </summary>
    LineFeed,
    /// <summary>
    /// This <see cref="LexerToken">Token</see> is CRLF (\r\n).
    /// </summary>
    CarriageReturnLineFeed,
}