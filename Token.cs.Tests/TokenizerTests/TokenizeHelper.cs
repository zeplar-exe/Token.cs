namespace TokenCs.Tests.TokenizerTests;

public static class TokenizeHelper
{
    public static Token[] GetTokens(string text) => new Tokenizer(text).ToArray();
}