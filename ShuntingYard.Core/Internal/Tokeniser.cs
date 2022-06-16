using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class Tokeniser
{
    public static IEnumerable<Token> Tokenise(string input)
    {
        var i = 0;
        while (i < input.Length)
        {
            if (IsDecimalCharacter(input[i]))
            {
                var a = i + 1;
                while (a < input.Length && IsDecimalCharacter(input[a]))
                {
                    a++;
                }
                yield return TokenFactory.TokenFrom(input.Substring(i, a - i));
                i = a;
            }
            else
            {
                yield return TokenFactory.TokenFrom(input[i].ToString());
                i++;
            }
        }
    }

    private static bool IsDecimalCharacter(char c)
        => char.IsDigit(c) || c == '.';
}
