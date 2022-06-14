using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class Tokeniser
{
    public static IEnumerable<Token> Tokenise(string input)
    {
        var i = 0;
        while (i < input.Length)
        {
            if (char.IsDigit(input[i]))
            {
                var a = i + 1;
                while (a < input.Length && char.IsDigit(input[a]))
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
}
