using Api.Base.DataTypes;

namespace Api.Battle.DataTypes
{
    public class Ship
    {
        public Coordinate CoordinateStart { get; set; }
        public ShipOrientationEnum Orientation { get; set; }
        public ShipTypeEnum Type { get; set; }
    }
}
