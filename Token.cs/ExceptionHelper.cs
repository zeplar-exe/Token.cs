namespace TokenCs;

internal static class ExceptionHelper
{
    public static void ArgumentNull(object? o)
    {
        if (o == null)
        {
            throw new ArgumentNullException(nameof(o));
        }
    }
}