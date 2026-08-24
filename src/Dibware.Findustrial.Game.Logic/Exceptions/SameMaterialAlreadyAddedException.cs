namespace Dibware.Findustrial.Game.Logic.Exceptions;

using System;
using Dibware.Findustrial.Game.Logic.Entities;

/// <summary>
/// The exception thrown when the same material has already been added.
/// </summary>
public class SameMaterialAlreadyAddedException : Exception
{
    /// <summary>
    /// Creates a new instance of the <see cref="SameMaterialAlreadyAddedException"/> class.
    /// </summary>
    public SameMaterialAlreadyAddedException() : base() { }

    /// <summary>
    /// Creates a new instance of the <see cref="SameMaterialAlreadyAddedException"/> class.
    /// </summary>
    /// <param name="material">
    /// A reference to the material which is already added.
    /// </param>
    public SameMaterialAlreadyAddedException(Material material)
        : base($"Material '{material.Name}' has already been added. Please update the existing material instead.")
    { }

    /// <summary>
    /// Creates a new instance of the <see cref="SameMaterialAlreadyAddedException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SameMaterialAlreadyAddedException(string message) : base(message) { }

    /// <summary>
    /// Throws a new <see cref="SameMaterialAlreadyAddedException"/> with the specified <paramref name="material"/>
    /// if the specified <paramref name="condition"/> is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <param name="material">
    /// A reference to the material which is already added.
    /// </param>
    /// <exception cref="SameMaterialAlreadyAddedException">
    /// Thrown if the value of <paramref name="condition"/> is <see langword="true"/>.
    /// </exception>
    public static void ThrowIfTrue(bool condition, Material material)
    {
        if (condition)
            throw new SameMaterialAlreadyAddedException(material);
    }

    /// <summary>
    /// Throws a new <see cref="SameMaterialAlreadyAddedException"/> with the specified <paramref name="message"/>
    /// if the specified <paramref name="condition"/> is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <param name="message">The message to include with the exception if it is thrown.</param>
    /// <exception cref="SameMaterialAlreadyAddedException">
    /// Thrown if the value of <paramref name="condition"/> is <see langword="true"/>.
    /// </exception>
    public static void ThrowIfTrue(bool condition, string message)
    {
        if (condition)
            throw new SameMaterialAlreadyAddedException(message);
    }
}
