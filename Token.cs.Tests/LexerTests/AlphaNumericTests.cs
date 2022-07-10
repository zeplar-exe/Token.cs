namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class AlphaNumericTests
{
    [Test]
    public void TestAlphabetic()
    {
        var results = LexHelper.GetTokens("abc");
        
        AssertEx.All(
            results.Length == 1,
            results[0] is { Type: LexerTokenType.AlphaNumeric },
            results[0].ToString() == "abc");
    }
    
    [Test]
    public void TestAlphaNumeric()
    {
        var results = LexHelper.GetTokens("abc123");
        
        AssertEx.All(
            results.Length == 1,
            results[0] is { Type: LexerTokenType.AlphaNumeric },
            results[0].ToString() == "abc123");
    }

    [Test]
    public void TestAlphaNumericAlpha()
    {
        var results = LexHelper.GetTokens("abc123def456");
        
        AssertEx.All(
            results.Length == 1,
            results[0] is { Type: LexerTokenType.AlphaNumeric },
            results[0].ToString() == "abc123def456");
    }

    [Test]
    public void TestParenthesisMix()
    {
        var results = LexHelper.GetTokens("(abc123)");
        
        AssertEx.All(
            results.Length == 3,
            results[1] is { Type: LexerTokenType.AlphaNumeric },
            results[1].ToString() == "abc123");
    }
}