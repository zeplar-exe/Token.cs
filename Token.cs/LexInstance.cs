namespace TokenCs;

internal class LexInstance : IDisposable
{
    private bool CurrentReserved { get; set; }
    private bool EnumerationCompleted { get; set; }
    private IEnumerator<Token> Enumerator { get; }
    private List<Token> Tokens { get; }
    private LexerTokenType LexerTokenType { get; set; }

    public LexInstance(IEnumerator<Token> enumerator)
    {
        Enumerator = enumerator;
        Tokens = new List<Token>();
    }

    public LexerToken? ProcessNext()
    {
        if (EnumerationCompleted)
            return null;
        
        var canIterate = CurrentReserved || Enumerator.MoveNext();
        CurrentReserved = false;
        
        while (canIterate)
        {
            var current = Enumerator.Current;
            var type = Lexer.DetermineType(current);
            
            if (type != LexerTokenType)
            {
                if (Tokens.Count > 0)
                {
                    CurrentReserved = true;
                    
                    return CreateToken(LexerTokenType);
                }
            }

            LexerTokenType = type;

            switch (LexerTokenType)
            {
                case LexerTokenType.Alphabetic:
                {
                    Tokens.Add(current);
                    
                    break;
                }
                case LexerTokenType.Numeric:
                {
                    Tokens.Add(current);
                    
                    break;
                }
                default:
                {
                    return CreateToken(type);
                }
            }

            canIterate = Enumerator.MoveNext();
        }

        return null;
    }
    
    private LexerToken ClearAndReturn()
    {
        var token = new LexerToken(Tokens.ToArray(), LexerTokenType);
        Tokens.Clear();
        
        return token;
    }
    
    private LexerToken CreateUnknown()
    {
        return CreateToken(LexerTokenType.Unknown);
    }

    private LexerToken CreateToken(LexerTokenType type)
    {
        return new LexerToken(new[] { Enumerator.Current }, type);
    }

    public void Dispose()
    {
        Enumerator.Dispose();
    }
}