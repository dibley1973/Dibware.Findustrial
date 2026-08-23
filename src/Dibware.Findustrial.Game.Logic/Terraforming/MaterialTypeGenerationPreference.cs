namespace Dibware.Findustrial.Game.Logic.Terraforming;

/// <summary>
/// Defines the parameters for creating a new map.
/// </summary>
public enum MaterialTypeGenerationPreference
{
    /// <summary>
    /// Create a map that has raw materials biased to a prticular type.
    /// </summary>
    Biased = 0,

    /// <summary>
    /// Create a map that has raw materials that are totally random.
    /// </summary>
    Random = 1,

    /// <summary>
    /// Create a map with only one type of raw material. This will not be used in the game
    /// but is included to make testing easier.
    /// </summary>
    Fixed = 2
}
