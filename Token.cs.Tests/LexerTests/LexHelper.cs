namespace TokenCs.Tests.LexerTests;

public static class LexHelper
{
    public static LexerToken[] GetTokens(string text) => new Lexer(text).ToArray();
}