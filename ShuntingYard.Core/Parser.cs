namespace ShuntingYard.Core;

public static class Parser
{
    public static IEnumerable<string> Parse(IEnumerable<string> input)
    {
        var stack = new Stack<string>();

        foreach (var token in input)
        {
            if (IsOperator(token))
            {
                while (stack.Any() && Precedence(token) <= Precedence(stack.Peek()))
                {
                    yield return stack.Pop();
                }
                stack.Push(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                while (stack.Peek() != "(")
                {
                    yield return stack.Pop();
                }

                stack.Pop();
            }
            else
            {
                yield return token;
            }
        }

        foreach (var op in stack)
        {
            yield return op;
        }
    }

    private static bool IsOperator(string token) => Precedence(token) > 0;

    private static int Precedence(string op) =>
        op switch
        {
            "*" => 4,
            "/" => 4,
            "+" => 2,
            "-" => 2,
            _ => 0
        };
}