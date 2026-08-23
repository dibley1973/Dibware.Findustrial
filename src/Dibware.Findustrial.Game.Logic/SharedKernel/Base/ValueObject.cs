namespace Dibware.Findustrial.Game.Logic.SharedKernel.Base;

using System;
using System.Collections.Generic;

/// <summary>
/// The class which non-entity types should inherit from
/// to provide proper value-equality.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Gets a value indicating of the left object equals the right object.
    /// </summary>
    /// <param name="left">
    /// The first object to check.
    /// </param>
    /// <param name="right">
    /// The second object to check.
    /// </param>
    /// <returns>
    /// Returns <see langword="true"/> if bothe objects are the same reference,
    /// both objects have a <see langword="null"/> reference, or both objects
    /// values are equal.
    /// </returns>
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        // If either left or right equals null, but not both return false
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }

        // ReferenceEquals retursn true if both are the same reference, or both are  null.
        // Otherwise delegate to the left object's Equals member, by which time
        // neither will be none so we can "Bang!" out.the compiler warning.
        return ReferenceEquals(left, right) || left!.Equals(right!);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !(EqualOperator(left, right));
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
    

    public static bool operator ==(ValueObject one, ValueObject two)
    {
        return EqualOperator(one, two);
    }

    public static bool operator !=(ValueObject one, ValueObject two)
    {
        return NotEqualOperator(one, two);
    }
}
