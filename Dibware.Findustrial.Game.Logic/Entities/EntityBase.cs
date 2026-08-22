namespace Dibware.Findustrial.Game.Logic.Entities;

using Dibware.Findustrial.Game.Logic.Constants;

/// <summary>
/// The base class which all entities should in herit from.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Gets or sets the name of the entity
    /// </summary>
    public string Name { get; init; } = WellKnownNames.Unknown;

    /// <summary>
    /// Creates a new instance of the <see cref="EntityBase"/> class.
    /// </summary>
    /// <param name="name">
    /// The non-null name of the entitiy.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the value of <paramref name="name"/> is <see langword="null"/>.
    /// </exception>
    protected EntityBase(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
    }
}
