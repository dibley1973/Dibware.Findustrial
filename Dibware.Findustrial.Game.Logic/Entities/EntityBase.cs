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
    public string Name { get; set; } = WellKnownNames.Unknown;
}
