namespace TokenCs.Extensions;

/// <summary>
/// Extensions pertaining to <see cref="LexerToken">LexerTokens</see>.
/// </summary>
public static class LexerTokenExtensions
{
    /// <summary>
    /// Determine whether a token is entirely alphabetic.
    /// </summary>
    /// <param name="token">The token to check.</param>
    public static bool IsAlphabetic(this LexerToken token)
    {
        return token.Tokens.All(c => c.Type == TokenType.Alphabetic);
    }
    
    /// <summary>
    /// Determine whether a token is truly alphanumeric. Useful in cases when you want to check whether a
    /// <see cref="LexerTokenType.AlphaNumeric"/> token isn't just alphabetic.
    /// </summary>
    /// <param name="token">The token to check.</param>
    public static bool IsAlphaNumeric(this LexerToken token)
    {
        return token.Tokens.Any(t => t.Type is TokenType.Alphabetic) &&
               token.Tokens.All(c => c.Type is TokenType.Alphabetic or TokenType.Numeric);
    }

    /// <summary>
    /// Determine whether a token is an integer.
    /// </summary>
    /// <param name="token">The token to check.</param>
    public static bool IsNumeric(this LexerToken token)
    {
        return token.Tokens.All(t => t.Type == TokenType.Numeric);
    }

    /// <summary>
    /// Determine whether a token is an decimal (has a mantissa).
    /// </summary>
    /// <param name="token">The token to check.</param>
    public static bool IsDecimal(this LexerToken token)
    {
        return token.Type == LexerTokenType.Numeric &&
               token.Tokens.Any(t => t.Type == TokenType.Symbol && t.Text == ".");
    }

    /// <summary>
    /// Determine whether a token is any type of newline.
    /// </summary>
    /// <param name="token">The token to check.</param>
    /// <remarks>This method checks for carriage return (\r), line feed, (\n), and CRLF (\r\n).</remarks>
    public static bool IsNewLine(this LexerToken token)
    {
        return token.Type is 
            LexerTokenType.CarriageReturn or 
            LexerTokenType.LineFeed or 
            LexerTokenType.CarriageReturnLineFeed;
    }
}