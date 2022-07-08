namespace TokenCs;

public record Token(int Index, string Text, TokenType Type)
{
    public override string ToString()
    {
        return Text;
    }
}