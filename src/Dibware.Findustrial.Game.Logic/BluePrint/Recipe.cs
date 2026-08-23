namespace Dibware.Findustrial.Game.Logic.BluePrint;

using Dibware.Findustrial.Game.Logic.Constants;

/// <summary>
/// Represents a "recipe" to create a new material from existing materials using a specific process.
/// </summary>
public class Recipe
{
    /// <summary>
    /// Contains a list of materials and quantities.
    /// </summary>
    public IngredientList Ingredients { get; set; } = new();

    /// <summary>
    /// Gets or sets the name of the recipe
    /// </summary>
    public string Name { get; set; } = WellKnownNames.Empty;

    /// <summary>
    /// Defines the process to create the new material.
    /// </summary>
    public ManufactoringProcess Process { get; set; }
}
