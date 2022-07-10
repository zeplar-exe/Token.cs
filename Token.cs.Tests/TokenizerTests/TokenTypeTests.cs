namespace TokenCs.Tests.TokenizerTests;

public class TokenTypeTests
{
    [Test]
    public void TestAlphabetical()
    {
        Assert.That(TokenIs('a', TokenType.Alphabetic));
    }

    [Test]
    public void TestNumeric()
    {
        Assert.That(TokenIs('0', TokenType.Numeric));
    }

    [Test]
    public void TestSymbolic()
    {
        Assert.That(TokenIs('~', TokenType.Symbol));
    }

    [Test]
    public void TestWhitespace()
    {
        AssertEx.All(
            TokenIs(' ', TokenType.Whitespace),
            TokenIs('\t', TokenType.Whitespace));
    }

    [Test]
    public void TestNewline()
    {
        AssertEx.All(
            TokenIs('\n', TokenType.NewLine),
            TokenIs('\r', TokenType.NewLine));
    }
    
    [Test]
    public void TestUnknownCharacter()
    {
        Assert.That(TokenIs('⑕', TokenType.Unknown));
    }

    private static bool TokenIs(char c, TokenType type) => Tokenizer.DetermineType(c) == type;
}