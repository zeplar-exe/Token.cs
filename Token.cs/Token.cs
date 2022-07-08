namespace TokenCs;

public class Token
{
    public int Index { get; }
    public string Text { get; }
    public TokenType Type { get; }
    
    public Token(int index, string text, TokenType type)
    {
        Index = index;
        Text = text;
        Type = type;
    }

    public override string ToString()
    {
        return Text;
    }
}