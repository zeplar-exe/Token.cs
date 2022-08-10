namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class NumericTests
{
    [Test]
    public void TestInteger()
    {
        var result = LexHelper.GetTokens("100000000000");
        
        AssertEx.All(
            result.Length == 1,
            result[0] is { Type: LexerTokenType.Numeric },
            result[0].ToString() == "100000000000");
    }

    [Test]
    public void TestDecimal()
    {
        var result = LexHelper.GetTokens("3.14");
        
        AssertEx.All(
            result.Length == 3,
            result[0] is { Type: LexerTokenType.Numeric },
            result[0].ToString() == "3");
    }
    
    [Test]
    public void TestParenthesisMix()
    {
        var result = LexHelper.GetTokens("(3.14)");
        
        AssertEx.All(
            result.Length == 5,
            result[1] is { Type: LexerTokenType.Numeric },
            result[1].ToString() == "3");
    }
}