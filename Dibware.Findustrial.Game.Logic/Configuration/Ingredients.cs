namespace Dibware.Findustrial.Game.Logic.Configuration;

using System.Collections.Concurrent;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Extensions.Exceptions;
using Dibware.Findustrial.Game.Logic.Quantities;

public class Ingredients
{
    /// <summary>
    /// The internal map of materials and quantities.
    /// </summary>
    private readonly ConcurrentDictionary<Material, int> _ingredients = new();

    /// <summary>
    /// Adds the specified <paramref name="materialQuantity"/> to this instance.
    /// <para>
    /// Will throw an exception if the material already exists, therefore it is suggested
    /// that <see cref="HasMaterial"/> is called prior to calling this member.
    /// </para>
    /// </summary>
    /// <param name="materialQuantity">
    /// The <see cref="MaterialQuantity"/> to ass to this instance.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the material already exists.
    /// </exception>
    public void Add(MaterialQuantity materialQuantity)
    {
        InvalidOperationException.ThrowIfTrue(
            _ingredients.ContainsKey(materialQuantity.Material),
            $"Material '{materialQuantity.Material.Name}' already exists. Use 'HasMaterial' to check before calling this member.");

        AddOrUpdate(materialQuantity.Material, materialQuantity.Quantity);
    }

    /// <summary>
    /// If the material does not already exist in this instance, the specified <paramref name="material"/>
    /// will be added with specified <paramref name="quantity"/>. If the material already exists then the
    /// specified <paramref name="quantity"/> will be added to the existing quantity for this material.
    /// </summary>
    /// <param name="material">The <see cref="Material"/> to add or update.</param>
    /// <param name="quantity">The quantity to add</param>
    public void AddOrUpdate(Material material, int quantity)
    {
        _ingredients.AddOrUpdate(material, quantity, (material, originalQuantity) => originalQuantity + quantity);
    }

    /// <summary>
    /// Gets a value indicating if this instance already has the specified <paramref name="material"/>.
    /// </summary>
    /// <param name="material"></param>
    /// <returns>
    /// Returns <see langword="true"/> if this instance contains the material already.
    /// </returns>
    public bool HasMaterial(Material material) => _ingredients.ContainsKey(material);
}
