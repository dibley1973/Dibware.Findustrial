namespace Dibware.Findustrial.Game.Logic.Entities;

using Dibware.Findustrial.Game.Logic.Constants;
using Dibware.Findustrial.Game.Logic.SharedKernel.Base;

/// <summary>
/// Represents a material which can be mined or manufactured.
/// </summary>
public class Material : ValueObject
{
    /// <summary>
    /// Gets or sets the name of the entity
    /// </summary>
    public string Name { get; init; } = WellKnownNames.Unknown;

    /// <summary>
    /// Creates an instance of the <see cref="Material"/> class.
    /// </summary>
    /// <param name="name">
    /// the non-null name of the material.
    /// </param>
    public Material(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
