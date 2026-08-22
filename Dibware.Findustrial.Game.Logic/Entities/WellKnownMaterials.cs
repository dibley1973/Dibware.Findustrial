namespace Dibware.Findustrial.Game.Logic.Entities;

using Dibware.Findustrial.Game.Logic.Constants;

/// <summary>
/// Represents all of the well-know materials. Normally system materials,
/// which are hard-code and are not included in the configuration.
/// </summary>
public static class WellKnownMaterials
{
    /// <summary>
    /// Represents an absence of any material. Maybe a void in the ground which is being mined,
    /// or somewhere which has already been mined.
    /// </summary>
    public static Material Empty = new Material(WellKnownNames.Empty);
}
