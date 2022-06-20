using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class Tokeniser
{
    public static IEnumerable<Token> Tokenise(string input)
    {
        var i = 0;
        while (i < input.Length)
        {
            if (char.IsWhiteSpace(input[i]))
            {
                i++;
            }
            else if (IsDecimalCharacter(input[i]))
            {
                // Look ahead to the end of the decimal value
                var j = i + 1;
                while (j < input.Length && IsDecimalCharacter(input[j]))
                {
                    j++;
                }
                yield return TokenFactory.TokenFrom(input.Substring(i, j - i));
                i = j;
            }
            else
            {
                yield return TokenFactory.TokenFrom(input[i]);
                i++;
            }
        }
    }

    private static bool IsDecimalCharacter(char c)
        => char.IsDigit(c) || c == '.';
}
