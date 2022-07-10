using TokenCs.Extensions;

namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class ExtensionTests
{
    [Test]
    public void TestAlphabetic()
    {
        var token = LexHelper.GetTokens("abc")[0];
        
        Assert.That(token.IsAlphabetic);
    }
    
    [Test]
    public void TestNotAlphabetic()
    {
        var token = LexHelper.GetTokens("abc123")[0];
        
        Assert.That(!token.IsAlphabetic());
    }
    
    [Test]
    public void TestAlphaNumeric()
    {
        var token = LexHelper.GetTokens("abc123")[0];
        
        Assert.That(token.IsAlphaNumeric);
    }
    
    [Test]
    public void TestNotAlphaNumeric()
    {
        var token = LexHelper.GetTokens("123")[0];
        
        Assert.That(!token.IsAlphaNumeric());
    }

    [Test]
    public void TestNewLineCr()
    {
        var token = LexHelper.GetTokens("\r")[0];
        
        Assert.That(token.IsNewLine);
    }
    
    [Test]
    public void TestNewLineLf()
    {
        var token = LexHelper.GetTokens("\n")[0];
        
        Assert.That(token.IsNewLine);
    }
    
    [Test]
    public void TestNewLineCrlf()
    {
        var token = LexHelper.GetTokens("\r\n")[0];
        
        Assert.That(token.IsNewLine);
    }
    
    [Test]
    public void TestNotNewLineCr()
    {
        var token = LexHelper.GetTokens("foo")[0];
        
        Assert.That(!token.IsNewLine());
    }
}