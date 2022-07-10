namespace TokenCs.Tests.LexerTests;

[TestFixture]
public class SymbolTests
{
    [Test]
    public void TestBacktick()
    {
        var results = LexHelper.GetTokens("`");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Backtick));
    }
    
    [Test]
    public void TestTilde()
    {
        var results = LexHelper.GetTokens("~");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Tilde));
    }
    
    [Test]
    public void TestExclamation()
    {
        var results = LexHelper.GetTokens("!");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.ExclamationMark));
    }
    
    [Test]
    public void TestAt()
    {
        var results = LexHelper.GetTokens("@");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.At));
    }
    
    [Test]
    public void TestHashtag()
    {
        var results = LexHelper.GetTokens("#");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Hashtag));
    }
    
    [Test]
    public void TestDollar()
    {
        var results = LexHelper.GetTokens("$");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Dollar));
    }
    
    [Test]
    public void TestPercent()
    {
        var results = LexHelper.GetTokens("%");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Percent));
    }
    
    [Test]
    public void TestCaret()
    {
        var results = LexHelper.GetTokens("^");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Caret));
    }
    
    [Test]
    public void TestAmpersand()
    {
        var results = LexHelper.GetTokens("&");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Ampersand));
    }
    
    [Test]
    public void TestStar()
    {
        var results = LexHelper.GetTokens("*");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Star));
    }
    
    [Test]
    public void TestDash()
    {
        var results = LexHelper.GetTokens("-");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Dash));
    }
    
    [Test]
    public void TestUnderscore()
    {
        var results = LexHelper.GetTokens("_");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Underscore));
    }
    
    [Test]
    public void TestPlus()
    {
        var results = LexHelper.GetTokens("+");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Plus));
    }
    
    [Test]
    public void TestEquals()
    {
        var results = LexHelper.GetTokens("=");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Equals));
    }
    
    [Test]
    public void TestSemicolon()
    {
        var results = LexHelper.GetTokens(";");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Semicolon));
    }
    
    [Test]
    public void TestColon()
    {
        var results = LexHelper.GetTokens(":");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Colon));
    }
    
    [Test]
    public void TestQuote()
    {
        var results = LexHelper.GetTokens("'");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.SingleQuotation));
    }
    
    [Test]
    public void TestDoubleQuote()
    {
        var results = LexHelper.GetTokens("\"");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.DoubleQuotation));
    }
    
    [Test]
    public void TestComma()
    {
        var results = LexHelper.GetTokens(",");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Comma));
    }
    
    [Test]
    public void TestLessThan()
    {
        var results = LexHelper.GetTokens("<");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.LessThan));
    }
    
    [Test]
    public void TestPeriod()
    {
        var results = LexHelper.GetTokens(".");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Period));
    }
    
    [Test]
    public void TestGreaterThan()
    {
        var results = LexHelper.GetTokens(">");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.GreaterThan));
    }
    
    [Test]
    public void TestSlash()
    {
        var results = LexHelper.GetTokens("/");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Slash));
    }
    
    [Test]
    public void TestQuestion()
    {
        var results = LexHelper.GetTokens("?");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.QuestionMark));
    }
    
    [Test]
    public void TestVertical()
    {
        var results = LexHelper.GetTokens("|");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.VerticalLine));
    }
    
    [Test]
    public void TestBackslash()
    {
        var results = LexHelper.GetTokens("\\");
        
        Assert.That(results[0].Type, Is.EqualTo(LexerTokenType.Backslash));
    }
    
    [Test]
    public void TestParenthesis()
    {
        var results = LexHelper.GetTokens("()");
        
        AssertEx.All(
            results[0].Type == LexerTokenType.LeftParenthesis,
            results[1].Type == LexerTokenType.RightParenthesis);
    }
    
    [Test]
    public void TestBrackets()
    {
        var results = LexHelper.GetTokens("[]").ToArray();
        
        AssertEx.All(
            results[0].Type == LexerTokenType.LeftBracket,
            results[1].Type == LexerTokenType.RightBracket);
    }
    
    [Test]
    public void TestCurlyBrackets()
    {
        var results = LexHelper.GetTokens("{}").ToArray();
        
        AssertEx.All(
            results[0].Type == LexerTokenType.LeftCurlyBracket,
            results[1].Type == LexerTokenType.RightCurlyBracket);
    }

    [Test]
    public void TestDoublePeriod()
    {
        var results = LexHelper.GetTokens("..").ToArray();
        
        AssertEx.All(
            results.Length == 2,
            results.All(t => t.Type == LexerTokenType.Period));
    }
}