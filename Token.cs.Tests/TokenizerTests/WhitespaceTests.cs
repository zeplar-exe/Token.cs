namespace TokenCs.Tests.TokenizerTests;

[TestFixture]
public class WhitespaceTests
{
    [Test]
    public void TestAlphabeticMixture()
    {
        var results = TokenizeHelper.GetTokens("ABC\nDEF");

        AssertEx.All(
            results[1] is { Text: "\n", Type: TokenType.NewLine });
    }

    [Test]
    public void TestNumericMixture()
    {
        var results = TokenizeHelper.GetTokens("123\n456");

        AssertEx.All(
            results[1] is { Text: "\n", Type: TokenType.NewLine });
    }
    
    [Test]
    public void TestSymbolMixture()
    {
        var results = TokenizeHelper.GetTokens("([{\n}])");

        AssertEx.All(
            results[3] is { Text: "\n", Type: TokenType.NewLine });
    }

    [Test]
    public void TestWhitespaceMixture()
    {
        var results = TokenizeHelper.GetTokens("   \n   ");

        AssertEx.All(
            results[1] is { Text: "\n", Type: TokenType.NewLine });
    }
    
    [Test]
    public void TestWhitespaceTabMixture()
    {
        var results = TokenizeHelper.GetTokens(" \t \n \t ");

        AssertEx.All(
            results[1] is { Text: "\n", Type: TokenType.NewLine });
    }

    [Test]
    public void TestCr()
    {
        var results = TokenizeHelper.GetTokens("\r");

        AssertEx.All(
            results[0] is { Text: "\r", Type: TokenType.NewLine });
    }
    
    [Test]
    public void TestLf()
    {
        var results = TokenizeHelper.GetTokens("\n");

        AssertEx.All(
            results[0] is { Text: "\n", Type: TokenType.NewLine });
    }

    [Test]
    public void TestCrlf()
    {
        var results = TokenizeHelper.GetTokens("\r\n");

        AssertEx.All(
            results.Length == 1,
            results[0] is { Text: "\r\n", Type: TokenType.NewLine });
    }
    
    [Test]
    public void TestLfCr()
    {
        var results = TokenizeHelper.GetTokens("\n\r");

        AssertEx.All(
            results.Length == 2,
            results[0] is { Text: "\n", Type: TokenType.NewLine },
            results[1] is { Text: "\r", Type: TokenType.NewLine });
    }

    [Test]
    public void TestLfLf()
    {
        var results = TokenizeHelper.GetTokens("\n\n");

        AssertEx.All(
            results.Length == 2,
            results[0] is { Text: "\n", Type: TokenType.NewLine },
            results[1] is { Text: "\n", Type: TokenType.NewLine });
    }

    [Test]
    public void TestCrCr()
    {
        var results = TokenizeHelper.GetTokens("\r\r");

        AssertEx.All(
            results.Length == 2,
            results[0] is { Text: "\r", Type: TokenType.NewLine },
            results[1] is { Text: "\r", Type: TokenType.NewLine });
    }
}