namespace ShuntingYard.Core.Internal.Tokens;

internal abstract class Token : IEquatable<Token>
{
    public string Value { get; protected init; } = string.Empty;
    public int Precedence { get; protected init; }

    public static bool operator <=(Token left, Token right)
        => left.Precedence <= right.Precedence;

    public static bool operator >=(Token left, Token right)
        => left.Precedence >= right.Precedence;

    #region IEquatable members implemented by Rider

    public bool Equals(Token? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value && Precedence == other.Precedence;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Token)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Precedence);
    }
    
    #endregion
}
