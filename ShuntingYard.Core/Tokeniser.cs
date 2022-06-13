namespace ShuntingYard.Core;

public static class Tokeniser
{
    public static IEnumerable<string> Tokenise(string input)
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
                yield return input.Substring(i, a - i);
                i = a;
            }
            else
            {
                yield return input[i].ToString();
                i++;
            }
        }
    }
}
