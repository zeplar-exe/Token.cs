using System.Text;

namespace TokenCs;

internal class TokenizeInstance : IDisposable
{
    private bool CurrentReserved { get; set; }
    private bool EnumerationCompleted { get; set; }
    private IEnumerator<char> Enumerator { get; }
    private StringBuilder StringBuilder { get; }
    private TokenType TokenType { get; set; }
        
    private int Index { get; set; }

    public TokenizeInstance(IEnumerator<char> enumerator)
    {
        Enumerator = enumerator;
        StringBuilder = new StringBuilder();
    }

    public Token? ProcessNext()
    {
        if (EnumerationCompleted)
            return null;
        
        var canIterate = CurrentReserved || Enumerator.MoveNext();
        CurrentReserved = false;
        
        while (canIterate)
        {
            var current = Enumerator.Current;
            var type = Tokenizer.DetermineType(current);
            
            if (type != TokenType)
            {
                if (StringBuilder.Length > 0)
                {
                    CurrentReserved = true;
                    
                    return CreateToken();
                }
            }

            TokenType = type;

            if (TokenType == TokenType.NewLine)
            {
                if (current == '\n') // This line feed is always guaranteed to be alone or preceded by a carriage return
                {
                    StringBuilder.Append(current);
                    
                    return CreateToken();
                }
                
                if (current == '\r' && StringBuilder.ToString() == "\r") // If double carriage return, reserve and return
                {
                    CurrentReserved = true;
                    
                    return CreateToken();
                }
                
                // I swear, if another newline character appears in the future, I'll do something
            }

            StringBuilder.Append(current);
            
            switch (TokenType)
            {
                case TokenType.Symbol:
                    return CreateToken();
            }

            canIterate = Enumerator.MoveNext();
        }
        
        if (StringBuilder.Length > 0)
        {
            return CreateToken();
        }

        EnumerationCompleted = true;

        return null;
    }

    private Token CreateToken()
    {
        var text = ClearAndReturn();

        Index += text.Length;
        
        return new Token(Index - text.Length, text, TokenType);
    }

    private string ClearAndReturn()
    {
        var text = StringBuilder.ToString();
        StringBuilder.Clear();

        return text;
    }

    public void Dispose()
    {
        Enumerator.Dispose();
    }
}