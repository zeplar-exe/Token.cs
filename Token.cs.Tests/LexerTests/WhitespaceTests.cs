namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class WhitespaceTests
{
    [Test]
    public void TestSpace()
    {
        var tokens = LexHelper.GetTokens(" ");
        
        Assert.That(tokens[0].Type, Is.EqualTo(LexerTokenType.Space));
    }
    
    [Test]
    public void TestTab()
    {
        var tokens = LexHelper.GetTokens("\t");
        
        Assert.That(tokens[0].Type, Is.EqualTo(LexerTokenType.Tab));
    }
    
    [Test]
    public void TestCr()
    {
        var tokens = LexHelper.GetTokens("\r");
        
        Assert.That(tokens[0].Type, Is.EqualTo(LexerTokenType.CarriageReturn));
    }
    
    [Test]
    public void TestLf()
    {
        var tokens = LexHelper.GetTokens("\n");
        
        Assert.That(tokens[0].Type, Is.EqualTo(LexerTokenType.LineFeed));
    }
    
    [Test]
    public void TestCrlf()
    {
        var tokens = LexHelper.GetTokens("\r\n");
        
        Assert.That(tokens[0].Type, Is.EqualTo(LexerTokenType.CarriageReturnLineFeed));
    }
}