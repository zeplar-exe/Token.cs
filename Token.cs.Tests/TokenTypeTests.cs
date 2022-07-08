namespace TokenCs.Tests;

public class TokenTypeTests
{
    [Test]
    public void TestAlphabetical()
    {
        Assert.True(Tokenizer.DetermineType('a') == TokenType.Alphabetic);
    }

    [Test]
    public void TestNumeric()
    {
        Assert.True(Tokenizer.DetermineType('0') == TokenType.Numeric);
    }

    [Test]
    public void TestSymbolic()
    {
        Assert.True(Tokenizer.DetermineType('~') == TokenType.Symbol);
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