namespace TokenCs.Extensions;

public static class LexerTokenExtensions
{
    public static bool IsAlphabetic(this LexerToken token)
    {
        return token.Tokens.All(c => c.Type == TokenType.Alphabetic);
    }
    
    public static bool IsAlphaNumeric(this LexerToken token)
    {
        return token.Tokens.Any(t => t.Type is TokenType.Alphabetic) &&
               token.Tokens.All(c => c.Type is TokenType.Alphabetic or TokenType.Numeric);
    }

    public static bool IsNewLine(this LexerToken token)
    {
        return token.Type is 
            LexerTokenType.CarriageReturn or 
            LexerTokenType.LineFeed or 
            LexerTokenType.CarriageReturnLineFeed;
    }
}