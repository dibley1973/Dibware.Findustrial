namespace Dibware.Findustrial.Game.Logic.Processing;

using System;
using System.Collections.Generic;
using System.Text;
using Dibware.Findustrial.Game.Logic.Constants;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Quantities;

/// <summary>
///  Represents the base class which all processors should inherit from.
/// </summary>
internal abstract class ProcessorBase
{
    protected IReadOnlyCollection<MaterialQuantity> _requiredMaterials = new List<MaterialQuantity>();

    /// <summary>
    /// Gets or sets the name of the processor
    /// </summary>
    public string Name { get; set; } = WellKnownNames.Unknown;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="materials"></param>
    /// <returns></returns>
    public abstract IReadOnlyCollection<Material> Processs(IReadOnlyCollection<Material> materials);
}
