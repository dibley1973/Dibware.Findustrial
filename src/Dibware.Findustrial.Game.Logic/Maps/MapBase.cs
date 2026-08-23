namespace Dibware.Findustrial.Game.Logic.Maps;

using Dibware.Findustrial.Game.Logic.Dimensions;

/// <summary>
/// Represents the base class all maps should inherit from.
/// </summary>
public abstract class MapBase<TDimensions>
    where TDimensions : DimensionBase
{
    /// <summary>
    /// Gets or sets the dimensions of the map.
    /// </summary>
    public abstract TDimensions Dimensions { get; init; }
}

public class Map2D : MapBase<Dimension2D>
{
    public override Dimension2D Dimensions { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
}

public class Map3D : MapBase<Dimension3D>
{
    public override Dimension3D Dimensions { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
}
