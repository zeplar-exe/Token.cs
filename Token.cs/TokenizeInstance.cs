using System.Text;

namespace TokenCs;

internal class TokenizeInstance : IDisposable
{
    private IEnumerator<char> Enumerator { get; }
    private StringBuilder StringBuilder { get; }
    private TokenType TokenType { get; set; }
        
    private int Index { get; set; }

    public TokenizeInstance(IEnumerator<char> enumerator)
    {
        Enumerator = enumerator;
        StringBuilder = new StringBuilder();
    }

    public Token? ProcessNext(char? start = null)
    {
        while (Enumerator.MoveNext())
        {
            var current = Enumerator.Current;
            var type = DetermineType(current);
            
            if (type != TokenType)
            {
                if (StringBuilder.Length > 0)
                {
                    return CreateToken();
                }
            }

            TokenType = type;
            StringBuilder.Append(current);

            if (type == TokenType.NewLine)
            {
                if (StringBuilder.Length == 2)
                {
                    if (StringBuilder.ToString() == "\r\n")
                    {
                        return CreateToken();
                    }
                    else
                    {
                        return CreateToken();
                    }
                }
            }

            Index++;
        }
        
        if (StringBuilder.Length > 0)
        {
            return new Token(Index, StringBuilder.ToString(), TokenType);
        }

        return null;
    }

    private Token CreateToken()
    {
        return new Token(Index, ClearAndReturn(), TokenType);
    }

    private string ClearAndReturn()
    {
        var text = StringBuilder.ToString();
        StringBuilder.Clear();

        return text;
    }
        
    private TokenType DetermineType(char c)
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
        else if (char.IsWhiteSpace(c))
        {
            return TokenType.Whitespace;
        }
        else if (c is '\r' or '\n')
        {
            return TokenType.NewLine;
        }
        else
        {
            return TokenType.Unknown;
        }
    }

    public void Dispose()
    {
        Enumerator.Dispose();
    }
}