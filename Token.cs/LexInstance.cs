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

        if (!canIterate)
        {
            EnumerationCompleted = true;

            return null;
        }
        
        while (canIterate)
        {
            var current = Enumerator.Current;
            var type = Lexer.DetermineType(current);
            
            if (type != LexerTokenType)
            {
                if (Tokens.Count > 0)
                {
                    CurrentReserved = true;

                    return ClearAndReturn();
                }
            }

            LexerTokenType = type;

            switch (LexerTokenType)
            {
                case LexerTokenType.AlphaNumeric:
                {
                    Tokens.Add(current);

                    while (Enumerator.MoveNext())
                    {
                        var alphaCurrent = Enumerator.Current;
                        var alphaType = Lexer.DetermineType(alphaCurrent);

                        switch (alphaType)
                        {
                            case LexerTokenType.AlphaNumeric:
                            case LexerTokenType.Numeric:
                            {
                                Tokens.Add(alphaCurrent);

                                break;
                            }
                            default:
                            {
                                CurrentReserved = true;

                                goto Complete;
                            }
                        }
                    }
                    
                    Complete:
                    
                    return ClearAndReturn();
                }
                case LexerTokenType.Numeric:
                {
                    Tokens.Add(current);
                    
                    var isDecimal = false;

                    while (Enumerator.MoveNext())
                    {
                        var numCurrent = Enumerator.Current;
                        var numType = Lexer.DetermineType(numCurrent);

                        switch (numType)
                        {
                            case LexerTokenType.Numeric:
                            {
                                Tokens.Add(numCurrent);
                                
                                break;
                            }
                            case LexerTokenType.Period:
                            {
                                if (isDecimal)
                                {
                                    CurrentReserved = true;
                                    
                                    goto Complete;
                                }
                                
                                Tokens.Add(numCurrent);
                                isDecimal = true;
                                break;
                            }
                            default:
                            {
                                CurrentReserved = true;
                                
                                goto Complete;
                            }
                        }
                    }
                    
                    Complete:

                    return ClearAndReturn();
                }
                default:
                {
                    return ClearAndReturn();
                }
            }
        }

        return null;
    }
    
    private LexerToken ClearAndReturn()
    {
        var token = new LexerToken(Tokens.ToArray(), LexerTokenType);
        Tokens.Clear();
        
        return token;
    }
    
    public void Dispose()
    {
        Enumerator.Dispose();
    }
}