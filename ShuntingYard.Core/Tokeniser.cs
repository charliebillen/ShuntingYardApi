using ShuntingYard.Core.Tokens;

namespace ShuntingYard.Core;

public static class Tokeniser
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
                yield return Token.From(input.Substring(i, a - i));
                i = a;
            }
            else
            {
                yield return Token.From(input[i].ToString());
                i++;
            }
        }
    }
}
