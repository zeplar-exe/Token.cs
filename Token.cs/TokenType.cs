namespace TokenCs;

/// <summary>
/// Type of a <see cref="Token"/>.
/// </summary>
public enum TokenType
{
    /// <summary>
    /// This token is not handled by the <see cref="Tokenizer"/>.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// This <see cref="Token"/> is made up of letters and digits.
    /// </summary>
    Alphabetic,
    /// <summary>
    /// This <see cref="Token"/> is made up of digits.
    /// </summary>
    Numeric,
    /// <summary>
    /// This <see cref="Token"/> is a symbol.
    /// </summary>
    Symbol,
    /// <summary>
    /// This <see cref="Token"/> is a whitespace character.
    /// </summary>
    Whitespace,
    /// <summary>
    /// This <see cref="Token"/> is a newline character.
    /// </summary>
    NewLine
}