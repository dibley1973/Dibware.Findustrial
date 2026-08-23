using Dibware.Findustrial.Game.Logic.Quantities;

namespace Dibware.Findustrial.Game.Logic.Extensions;

using System.Runtime.CompilerServices;
using Dibware.Findustrial.Game.Logic.Entities;

/// <summary>
/// entension methosdofor the <see cref="Material"/> class.
/// </summary>
public static class MaterialExtensions
{
    /// <summary>
    /// Creates a <see cref="MaterialQuantity"/> from the specified <paramref name="material"/>,
    /// and the specified <paramref name="quantity"/>.
    /// </summary>
    /// <param name="material">
    /// A non-null reference to a <see cref="Material"/>.
    /// </param>
    /// <param name="quantity">
    /// The quantity of the specified material.
    /// </param>
    /// <returns>
    /// Returns a newly constructed <see cref="MaterialQuantity"/>.
    /// </returns>
    public static MaterialQuantity OfMaterial(this Material material, int quantity)
    {
        ArgumentNullException.ThrowIfNull(material);

        return new MaterialQuantity(material, quantity);
    }
}
