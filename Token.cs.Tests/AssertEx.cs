namespace TokenCs.Tests;

public static class AssertEx
{
    public static void All(params bool[] items)
    {
        Assert.That(items.All(i => i));
    }
}