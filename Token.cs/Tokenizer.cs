using System.Collections;

namespace TokenCs;

/// <summary>
/// Underlying text-to-token parser.
/// </summary>
public class Tokenizer : IEnumerable<Token>
{
    private IEnumerable<char> Enumerable { get; }

    /// <summary>
    /// Create a tokenizer with an enumerable of characters..
    /// </summary>
    /// <param name="enumerable"></param>
    public Tokenizer(IEnumerable<char> enumerable)
    {
        ExceptionHelper.ArgumentNull(enumerable);
        
        Enumerable = enumerable;
    }

    /// <inheritdoc />
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
    
    /// <summary>
    /// Determine the <see cref="TokenType"/> of a given <see cref="Char"/>.
    /// </summary>
    /// <param name="c">Character to check.</param>
    public static TokenType DetermineType(char c)
    {
        ExceptionHelper.ArgumentNull(c);
        
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