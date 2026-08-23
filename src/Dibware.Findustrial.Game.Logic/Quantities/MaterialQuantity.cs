namespace Dibware.Findustrial.Game.Logic.Quantities;

using Dibware.Findustrial.Game.Logic.Entities;

/// <summary>
/// Represents a quantity of a particular material.
/// </summary>
public record class MaterialQuantity 
{
    /// <summary>
    /// Represents the material which the quantity of is known.
    /// </summary>
    public Material Material { get; init; }

    /// <summary>
    /// Represents the quantity of the specified material.
    /// </summary>
    public int Quantity { get; init; }

    /// <summary>
    /// Creates a new instance of the <see cref="MaterialQuantity"/> class.
    /// </summary>
    /// <param name="material">Represents the material which the quantity of is known.</param>
    /// <param name="quantity">Represents the quantity of the specified material.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the value of <paramref name="material"/> is <see langword="null"/>.
    /// </exception>
    public MaterialQuantity(Material material, int quantity)
    {
        Material = material ?? throw new ArgumentNullException(nameof(material));
        Quantity = quantity;
    }
}
