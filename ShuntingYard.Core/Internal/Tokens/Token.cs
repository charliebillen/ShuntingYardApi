using System.Diagnostics.CodeAnalysis;

namespace ShuntingYard.Core.Internal.Tokens;

internal abstract class Token
{
    protected int Precedence { get; init; }

    public static bool operator <=(Token left, Token right)
        => left.Precedence <= right.Precedence;

    // This must be defined to define <= but is not used in this code
    [ExcludeFromCodeCoverage]
    public static bool operator >=(Token left, Token right)
        => left.Precedence >= right.Precedence;
}
