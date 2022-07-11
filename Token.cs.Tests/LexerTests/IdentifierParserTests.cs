namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class IdentifierParserTests
{
    
    [Test]
    public void TestCase1()
    {
        AssertParserResult("_abc123_", "_abc123_");
    }
    
    [Test]
    public void TestCase2()
    {
        AssertParserResult("123 abc_", "abc_");
    }
    
    [Test]
    public void TestCase3()
    {
        AssertParserResult("a b c 123", "a", "b", "c");
    }
    
    [Test]
    public void TestCase4()
    {
        AssertParserResult("_ 1-2 calibrate_my_airspace", "_", "calibrate_my_airspace");
    }

    private void AssertParserResult(string input, params string[] output)
    {
        var parser = new IdentifierParser(input);
        var identifiers = parser.ParseIdentifiers().ToArray();

        Assert.That(identifiers.SequenceEqual(output));
    }
    
    private class IdentifierParser
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
}