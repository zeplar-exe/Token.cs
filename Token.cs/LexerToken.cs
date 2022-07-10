﻿namespace TokenCs;

/// <summary>
/// A single token generated by a <see cref="Lexer"/>.
/// </summary>
/// <param name="Tokens">Array of <see cref="Token">Tokens</see> which make up this token.</param>
/// <param name="Type">Type of this token.</param>
public record LexerToken(Token[] Tokens, LexerTokenType Type)
{
    /// <inheritdoc />
    public override string ToString()
    {
        return string.Join("", Tokens.Select(t => t.ToString()));
    }
}