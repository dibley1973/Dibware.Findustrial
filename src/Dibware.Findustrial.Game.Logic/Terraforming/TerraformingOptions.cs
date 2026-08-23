namespace Dibware.Findustrial.Game.Logic.Terraforming;

using Dibware.Findustrial.Game.Logic.Dimensions;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Extensions;
using Dibware.Findustrial.Game.Logic.Extensions.Exceptions;
using Dibware.Findustrial.Game.Logic.SharedKernel.Amplifiers;

/// <summary>
/// Contains the parameters required for creating a map.
/// </summary>
public record TerraformingOptions
{
    /// <summary>
    /// Gets or sets the size of the map.
    /// </summary>
    public DimensionBase Dimensions { get; init; }

    /// <summary>
    /// Indicates the preference on type generation
    /// </summary>
    public MaterialTypeGenerationPreference MaterialTypePreference { get; init; }

    /// <summary>
    /// An optional
    /// </summary>
    public Maybe<Material> PreferredMaterial { get; init; }

    /// <summary>
    /// Creates a new instance of the <see cref="TerraformingOptions"/> class.
    /// </summary>
    /// <param name="Dimensions">Indicates the size of the map.</param>
    /// <param name="MaterialTypePreference">
    /// The preference for how the map should be gerenerated, for example rasdnomly or with a bias towards one type of raw material.
    /// </param>
    /// <param name="preferredMaterial">
    /// The optional
    /// </param>
    public TerraformingOptions(DimensionBase dimensions, MaterialTypeGenerationPreference materialTypePreference, Maybe<Material> preferredMaterial)
    {
        ArgumentNullException.ThrowIfNull(nameof(dimensions));
        ArgumentNullException.ThrowIfNull(nameof(materialTypePreference));
        ArgumentNullException.ThrowIfNull(nameof(preferredMaterial));
        InvalidOperationException.ThrowIfTrue(
            (materialTypePreference != MaterialTypeGenerationPreference.Random && preferredMaterial.HasNoValue),
            "A preferred material must be set if the generation preference is not set to 'random'.");

        Dimensions = dimensions;
        MaterialTypePreference = materialTypePreference;
        PreferredMaterial = preferredMaterial;
    }
}
