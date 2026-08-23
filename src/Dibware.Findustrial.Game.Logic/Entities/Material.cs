namespace Dibware.Findustrial.Game.Logic.Entities;
/// <summary>
/// Represents a material which can be mined or manufactured.
/// </summary>
public class Material : EntityBase
{
    /// <summary>
    /// Creates an instance of the <see cref="Material"/> class.
    /// </summary>
    /// <param name="name">
    /// the non-null name of the material.
    /// </param>
    public Material(string name) : base(name) { }
}
