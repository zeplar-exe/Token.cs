namespace TokenCs;

public record LexerToken(Token[] Tokens, LexerTokenType Type)
{
    public override string ToString()
    {
        return string.Join("", Tokens.Select(t => t.ToString()));
    }
}