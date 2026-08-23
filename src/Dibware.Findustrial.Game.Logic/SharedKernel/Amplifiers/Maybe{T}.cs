namespace Dibware.Findustrial.Game.Logic.SharedKernel.Amplifiers;

using System;
using System.Collections.Generic;
using System.Text;
using Dibware.Findustrial.Game.Logic.Extensions.Exceptions;

/// <summary>
/// Amplifies any given Type to provide expression of clear intent that the
/// given object may or may not be present. Can be used to indicate an absence
/// of an object, or maybe that nothing was returned. 
/// </summary>
/// <typeparam name="T">
/// Indicates the type of the entities identifier. Normally a Long or Guid
/// </typeparam>
public struct Maybe<T> : IEquatable<Maybe<T>>
{
    /// <summary>
    /// Defines the special case "Empty" Maybe
    /// </summary>
    public static readonly Maybe<T> Empty = new Maybe<T>(default(T));

    /// <summary>
    /// Defines the optional value
    /// </summary>
    private readonly T? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Maybe{T}"/> struct.
    /// </summary>
    /// <param name="value">the optional value to encapsulate.</param>
    private Maybe(T? value)
    {
        _value = value;
    }

    /// <summary>
    /// Gets a value indicating whether this instance has value.
    /// </summary>
    /// <value><see langword="true"/> if this instance has value; otherwise, <see langword="false"/>.</value>
    public bool HasValue => _value != null;

    /// <summary>
    /// Gets a value indicating whether this instance has no value.
    /// </summary>
    /// <value><see langword="true"/> if this instance has no value; otherwise, <see langword="false"/>.</value>
    public bool HasNoValue => !HasValue;

    /// <summary>
    /// Gets the value, of this instance has a value to get; otherwise throws an exception.
    /// </summary>
    /// <value>The value.</value>
    /// <exception cref="InvalidOperationException">
    /// Thrown is this property is accessed when this instance does not have a value.
    /// </exception>
    public T Value
    {
        get
        {
            InvalidOperationException.ThrowIfTrue(HasValue, "Cannot return value if no value has been set");
            
            // If we got this far we DO have a value so help the compiler with a bang!
            return _value!;
        }
    }

    /// <summary>
    /// Performs an implicit conversion from object of type &lt;T&gt; to <see cref="Maybe{T}"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Maybe<T>(T value)
    {
        return new Maybe<T>(value);
    }

    /// <summary>
    /// Determines whether the value of the specified <see cref="Maybe{T}"/> is the same as the
    /// specified value
    /// </summary>
    /// <param name="maybe">The maybe.</param>
    /// <param name="value">The value.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Maybe<T> maybe, T value)
    {
        if (maybe.HasNoValue)
            return false;

        // If we got this far we DO have a value so help the compiler with a bang!
        return maybe.Value!.Equals(value);
    }

    /// <summary>
    /// Determines whether the value of the specified <see cref="Maybe{T}"/> is not the same as
    /// the specified value
    /// </summary>
    /// <param name="maybe">The maybe.</param>
    /// <param name="value">The value.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Maybe<T> maybe, T value)
    {
        return !(maybe == value);
    }

    /// <summary>
    /// Determines whether the value of the primary specified <see cref="Maybe{T}"/> is the same as
    /// the value of the secondary specified <see cref="Maybe{T}"/>.
    /// </summary>
    /// <param name="primary">The primary maybe.</param>
    /// <param name="secondary">The secondary value.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Maybe<T> primary, Maybe<T> secondary)
    {
        if (primary.HasValue ^ secondary.HasValue)
        {
            return false;
        }

        if (primary.HasNoValue && secondary.HasNoValue)
        {
            return true;
        }

        // If we got this far we DO have a value so help the compiler with a bang!
        return primary.Value!.Equals(secondary.Value);
    }

    /// <summary>
    /// Determines whether the value of the primary specified <see cref="Maybe{T}"/> is not the
    /// same as the value of the secondary specified <see cref="Maybe{T}"/>.
    /// </summary>
    /// <param name="first">The primary maybe.</param>
    /// <param name="second">The secondary value.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Maybe<T> first, Maybe<T> second)
    {
        return !(first == second);
    }

    /// <summary>
    /// Wraps the specified type in a <see cref="Maybe{T}"/> with the <see cref="Value"/> set to
    /// the specified object.
    /// </summary>
    /// <param name="obj">The object to wrap.</param>
    /// <returns>Returns an instance of a <see cref="Maybe{T}"/> with the type as the value</returns>
    public static Maybe<T> Wrap(T obj)
    {
        return new Maybe<T>(obj);
    }

    /// <summary>
    /// Determines whether the specified <see cref="object"/>, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
    /// <returns>
    /// If the specified <paramref name="obj"/> is <see langword="null"/>, then return <see langword="false"/>.
    /// Otherwise return <see langword="true"/> if the specified <see cref="object"/> is equal to this instance;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        var objectCanBeWrapped = obj is T;
        if (objectCanBeWrapped)
        {
            obj = Wrap((T)obj);
        }

        var objectIsNotSameType = !(obj is Maybe<T>);
        if (objectIsNotSameType)
            return false;

        var otherMaybe = (Maybe<T>)obj;
        return Equals(otherMaybe);
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    public bool Equals(Maybe<T> other)
    {
        var bothHaveNoValue = HasNoValue && other.HasNoValue;
        if (bothHaveNoValue)
            return true;

        var oneHasValueAndOtherDoesNot = HasNoValue || other.HasNoValue;
        if (oneHasValueAndOtherDoesNot)
            return false;

        // If we got this far we DO have a value so help the compiler with a bang!
        return _value!.Equals(other._value);
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures
    /// like a hash table.
    /// </returns>
    public override int GetHashCode()
    {
        if (HasNoValue)
            return GetHashCodeBasedUponTypeNames();

        // If we got this far we DO have a value so help the compiler with a bang!
        return _value!.GetHashCode();
    }

    /// <summary>
    /// Returns a <see cref="string"/> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents this instance.</returns>
    public override string ToString()
    {
        if (HasNoValue)
            return $"An empty maybe of type {typeof(T).Name}";

        // If we got this far we DO have a value so help the compiler with a bang!
        return $"A maybe of type {typeof(T).Name} with a value of: {Value!.ToString()}";
    }

    /// <summary>Gets the hash code based upon type names.</summary>
    /// <returns>Returns in <c>int</c> representation</returns>
    private int GetHashCodeBasedUponTypeNames()
    {
        int initialPrimeNumber = 61;
        int multiplierPrimeNumber = 79;

        // Overflow is fine, just wrap
        unchecked
        {
            int hash = initialPrimeNumber;

            hash = (hash * multiplierPrimeNumber) + GetType().Name.GetHashCode();
            hash = (hash * multiplierPrimeNumber) + typeof(T).Name.GetHashCode();

            return hash;
        }
    }
}
