public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        ValueObject toCompare = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(toCompare.GetEqualityComponents());
    }
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(component => component != null ? component.GetHashCode() : 0)
            .Aggregate((aggregated, newhashcode) => HashCode.Combine(aggregated, newhashcode));
    }
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if(left is null || right is null)
            return false;
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
}