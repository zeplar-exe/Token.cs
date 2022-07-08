using System.Collections;

namespace TokenCs;

public class Tokenizer : IEnumerable<Token>
{
    private IEnumerable<char> Enumerable { get; }

    public Tokenizer(IEnumerable<char> enumerable)
    {
        Enumerable = enumerable;
    }

    public IEnumerator<Token> GetEnumerator()
    {
        using var instance = new TokenizeInstance(Enumerable.GetEnumerator());

        while (instance.ProcessNext() is { } token) // not null
        {
            yield return token;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public static TokenType DetermineType(char c)
    {
        if (char.IsLetter(c))
        {
            return TokenType.Alphabetic;
        }
        else if (char.IsNumber(c))
        {
            return TokenType.Numeric;
        }
        else if (char.IsSymbol(c) || char.IsPunctuation(c))
        {
            return TokenType.Symbol;
        }
        else if (c is '\r' or '\n')
        {
            return TokenType.NewLine;
        }
        else if (char.IsWhiteSpace(c))
        {
            return TokenType.Whitespace;
        }
        else
        {
            return TokenType.Unknown;
        }
    }
}