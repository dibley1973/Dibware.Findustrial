namespace Dibware.Findustrial.Game.Logic.Exceptions;

using System;
using System.Collections.Generic;
using System.Text;
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

    public SameMaterialAlreadyAddedException(Material material)
        : base($"Material '{material.Name}' has already been added. Please update the existing material instead.")
    { }

    /// <summary>
    /// Creates a new instance of the <see cref="SameMaterialAlreadyAddedException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SameMaterialAlreadyAddedException(string message) : base(message) { }
}
