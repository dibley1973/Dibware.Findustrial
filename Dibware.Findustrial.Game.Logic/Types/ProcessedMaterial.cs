namespace Dibware.Findustrial.Game.Logic.Types;

/// <summary>
/// Represents a processed material. Normally created from one or more other materials
/// and is the result of a process upon one or more materials. For example Steel is
/// a product removing impurities with immense heat. The heat needs to be generated
/// so the material processor may require cola for the heat and two units of iron ore to
/// make one.unit of steel.
/// </summary>
public class ProcessedMaterial : MaterialTypeBase
{ }
