namespace Dibware.Findustrial.Game.Logic.Locations;

/// <summary>
/// Represents a location in 2D space.
/// </summary>
public class Location2D : LocationBase
{
    /// <summary>
    /// Gets the X coordinate for the location.
    /// </summary>
    public int XCoordinate { get; init; }

    /// <summary>
    /// Gets the Y coordiante for the location.
    /// </summary>
    public int YCoordinate { get; init; }

    /// <summary>
    /// Creates an new instance of the <see cref="LocationBase"/> class.
    /// </summary>
    /// <param name="x">The X coordinate for the location.</param>
    /// <param name="y">The Y coordinate for the location.</param>
    protected Location2D(int x, int y)
    {
        this.XCoordinate = x;
        this.YCoordinate = y;
    }
}

