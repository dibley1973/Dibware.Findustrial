namespace Dibware.Findustrial.Game.Logic.Configuration;

using System;
using System.Collections.Generic;
using System.Text;

public class Recipe
{
    /// <summary>
    /// Contains a list of materials and quantities.
    /// </summary>
    public Ingredients Ingredients { get; set; } = new();

    public string Name { get; set; }

    /// <summary>
    /// Defines the process to create the new material.
    /// </summary>
    public ManufactoringProcess Process { get; set; }
}
