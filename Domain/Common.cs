using System.Collections.Generic;

namespace Domain
{
    public static class Common
    {
        public static readonly Dictionary<ShipTypeEnum, int> ShipSizes = new Dictionary<ShipTypeEnum, int>
        {
            { ShipTypeEnum.Carrier, 5 },
            { ShipTypeEnum.Battleship, 4 },
            { ShipTypeEnum.Cruiser, 3 },
            { ShipTypeEnum.Submarine, 3 },
            { ShipTypeEnum.Destroyer, 2 }
        };
    }
}
