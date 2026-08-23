namespace Dibware.Findustrial.Game.Logic.Terraforming;

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Represents the base class which all terraforming classes shoudl inherit from.
/// </summary>
internal class TerraformingBase
{
    /// <summary>
    /// The paramaters required for terraforming a new map.
    /// </summary>
    protected TerraformingOptions _options;

    /// <summary>
    /// Creates a new instance of the <see cref="TerraformingBase"/> class.
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TerraformingBase(TerraformingOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }
}

