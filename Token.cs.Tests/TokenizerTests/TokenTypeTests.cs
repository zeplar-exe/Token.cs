namespace TokenCs.Tests.TokenizerTests;

public class TokenTypeTests
{
    [Test]
    public void TestAlphabetical()
    {
        Assert.That(Tokenizer.DetermineType('a'), Is.EqualTo(TokenType.Alphabetic));
    }

    [Test]
    public void TestNumeric()
    {
        Assert.That(Tokenizer.DetermineType('0'), Is.EqualTo(TokenType.Numeric));
    }

    [Test]
    public void TestSymbolic()
    {
        Assert.That(Tokenizer.DetermineType('~'), Is.EqualTo(TokenType.Symbol));
    }

    [Test]
    public void TestWhitespace()
    {
        AssertEx.All(
            Tokenizer.DetermineType(' ') == TokenType.Whitespace,
            Tokenizer.DetermineType('\t') == TokenType.Whitespace);
    }

    [Test]
    public void TestNewline()
    {
        AssertEx.All(
            Tokenizer.DetermineType('\n') == TokenType.NewLine,
            Tokenizer.DetermineType('\r') == TokenType.NewLine);
    }
    
    [Test]
    public void TestUnknownCharacter()
    {
        Assert.True(Tokenizer.DetermineType('⑕') == TokenType.Unknown);
    }
}