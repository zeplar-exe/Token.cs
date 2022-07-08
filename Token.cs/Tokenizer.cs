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
}