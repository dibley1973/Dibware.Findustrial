namespace Dibware.Findustrial.Game.Logic.Mines;

using Dibware.Findustrial.Game.Logic.Constants;
using Dibware.Findustrial.Game.Logic.Dimensions;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Locations;
using Dibware.Findustrial.Game.Logic.Maps;

/// <summary>
/// Represents the base class which all mines should inherit from.
/// </summary>
public abstract class MineBase<TMap, TDimension>
    where TMap : MapBase<TDimension>
    where TDimension : DimensionBase
{
    /// <summary>
    /// Gets or sets the name of the processor
    /// </summary>
    public string Name { get; set; } = WellKnownNames.Unknown;

    /// <summary>
    /// Creates a new instance of the <see cref="MineBase"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the value of <paramref name="name"/> is <see langword="null"/>. 
    /// </exception>
    protected MineBase(string name) => this.Name = name ?? throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// Tries to mine the specified <paramref name="location"/> for material.
    /// </summary>
    /// <param name="location"></param>
    /// <returns>
    /// Returns any material found or <see cref="WellKnownMaterials.Empty"/> if none was found.
    /// </returns>
    public abstract Material TryToMine(LocationBase location, MapBase<TDimension> map);
}
