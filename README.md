# Token.cs (TokenCs)

![build](https://github.com/zeplar-exe/Token.cs/actions/workflows/dotnet.yml/badge.svg)

A simple library to abstract the gritty process of lexical parsing.

- [Installation](#installation)
- [Samples](#samples)
  - [Identifier Parser](./samples/identifier_parser.cs)
- [Quirks and Miscellaneous Features](#quirks-and-miscellaneous-features)

## Installation

This package is available on [nuget](https://www.nuget.org/packages/TokenCs).

## Samples

For extended samples, see [/samples/](./samples).

## Quirks and Miscellaneous Features

- Symbols are always parsed as single units. That is, a token containing more than one symbol will never be generated by
the tokenizer or lexer. The same goes for whitespace (CRLF is an exception).
- [LexerTokenType.AlphaNumeric](./Token.cs/LexerTokenType.cs#L16) will always contain alphabetical characters.
It may or may not contain numeric characters, and will never be purely numeric.