namespace Dibware.Findustrial.Game.Logic.Locations;

/// <summary>
/// Represents a location in 3D space.
/// </summary>
public class Location3D : LocationBase {

    /// <summary>
    /// Gets the X coordinate for the location.
    /// </summary>
    public int XCoordinate { get; init; }

    /// <summary>
    /// Gets the Y coordiante for the location.
    /// </summary>
    public int YCoordinate { get; init; }

    /// <summary>
    /// Gets the Z (vertical) coordiante for the location.
    /// </summary>
    public int ZCoordinate { get; init; }

    /// <summary>
    /// Creates a new instance of the <see cref="Location3D"/> class.
    /// </summary>
    /// <param name="xCoordinate">The X coordinate for the location.</param>
    /// <param name="yCoordinate">The Y coordinate for the location.</param>
    /// <param name="zCoordinate">The Y coordinate for the location.</param>
    public Location3D(int xCoordinate, int yCoordinate, int zCoordinate)
    {
        this.XCoordinate = xCoordinate;
        this.YCoordinate = yCoordinate;
        this.ZCoordinate = zCoordinate;
    }
}
