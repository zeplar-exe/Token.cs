using System.Collections.Generic;
using System.Linq;
using TokenCs;

// Parses identifiers picked out from a given inpt
public class IdentifierParser
{
    private Lexer Lexer { get; }

    public IdentifierParser(string input)
    {
        Lexer = new Lexer(input);
    }

    public IEnumerable<string> ParseIdentifiers()
    {
        using var enumerator = Lexer.GetEnumerator();
        var reserveCurrent = false;
        var tokenList = new List<LexerToken>();

        while (reserveCurrent || enumerator.MoveNext()) // If enumerator.Current is unused, don't move to the next token
        {
            reserveCurrent = false;
            LexerToken token = enumerator.Current;

            if (!IsValidToken(token))
                continue;

            do
            {
                token = enumerator.Current;
                
                if (IsValidToken(token))
                {
                    tokenList.Add(token);
                }
                else
                {
                    reserveCurrent = true;
                    break;
                }
            } while (enumerator.MoveNext());

            if (tokenList.Count > 0)
            {
                yield return string.Join("", tokenList.Select(t => t.ToString()));
            
                tokenList.Clear();
            }
        }
    }

    private bool IsValidToken(LexerToken token)
    {
        return token.Type is LexerTokenType.AlphaNumeric or LexerTokenType.Underscore;
    }
}

// In: _abc123_
// Out: _abc123_

// In: 123 abc_
// Out: abc_

// In: a b c 123
// Out: a, b, c

// In: _ 1-2 calibrate_my_airspace
// Out: _, calibrate_my_airspace