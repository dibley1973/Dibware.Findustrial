namespace Dibware.Findustrial.Game.Logic.Mines;

using Dibware.Findustrial.Game.Logic.Dimensions;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Locations;
using Dibware.Findustrial.Game.Logic.Maps;

public sealed class UndergroundMine : MineBase<Map3D, Dimension3D>
{
    public UndergroundMine()
        : base(typeof(UndergroundMine).Name)
    {
    }

    public override Material TryToMine(LocationBase location, MapBase<Dimension3D> map) => throw new NotImplementedException();
}

