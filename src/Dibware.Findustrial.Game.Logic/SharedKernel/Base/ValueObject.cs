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
    /// Gets a value indicating of the left object is equal to the right object.
    /// </summary>
    /// <param name="left">
    /// The first object to check.
    /// </param>
    /// <param name="right">
    /// The second object to check.
    /// </param>
    /// <returns>
    /// Returns <see langword="true"/> if both objects are the same reference,
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
    /// Gets a value indicating of the left object is not equal to the right object.
    /// </summary>
    /// <param name="left">
    /// The first object to check.
    /// </param>
    /// <param name="right">
    /// The second object to check.
    /// </param>
    /// <returns>
    /// Returns the complete opposite of the <see cref="EqualOperator"/> member.
    /// </returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !(EqualOperator(left, right));
    }

    /// <summary>
    /// Override this member to provide a list of members which indciate the
    /// equatable value of the derived class.
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Gets a value indicating if the specified <paramref name="obj"/> is equal to the current object.
    /// </summary>
    /// <param name="obj">
    /// The <see langword="object"/> to check against. May be null.
    /// </param>
    /// <returns
    /// Returns true if the value of the specified <see langword="object"/> is equal to
    /// the value the current instance.
    /// </returns>
    public override bool Equals(object? obj)
    {
        // return false if the other object is false, or
        // if the types differ from each other.
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        // As we have already done a type comparrison of the corrent instance and
        // the other object we know we can direct-cast the other as a ValueObject...
        var other = (ValueObject)obj as ValueObject;

        // ...and then we can use the equality components of both for comparrison.
        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Gets a disitinct hash-code which is specific to the derived class.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Gets a value indicating if the first <see cref="ValueObject"/>
    /// is equal to the second <see cref="ValueObject"/>.
    /// </summary>
    /// <param name="one">The first <see cref="ValueObject"/> to check.</param>
    /// <param name="two">The second <see cref="ValueObject"/> to check.</param>
    /// <returns>
    /// Returns <see langword="true"/> if the value of the first <see cref="ValueObject"/>
    /// is equal to the second <see cref="ValueObject"/>.
    /// </returns>
    public static bool operator ==(ValueObject one, ValueObject two)
    {
        return EqualOperator(one, two);
    }

    /// <summary>
    /// Gets a value indicating if the first <see cref="ValueObject"/>
    /// is not equal to the second <see cref="ValueObject"/>.
    /// </summary>
    /// <param name="one">The first <see cref="ValueObject"/> to check.</param>
    /// <param name="two">The second <see cref="ValueObject"/> to check.</param>
    /// <returns>
    /// <returns>
    /// Returns <see langword="true"/> if the value of the first <see cref="ValueObject"/>
    /// is not equal to the second <see cref="ValueObject"/>.
    /// </returns>
    public static bool operator !=(ValueObject one, ValueObject two)
    {
        return NotEqualOperator(one, two);
    }
}
