using Api.Base.DataTypes;

namespace Api.Battle.DataTypes.DTOs
{
    public class BattleshipDto
    {
        public byte RowStart { get; set; }
        public byte ColumnStart { get; set; }

        public ShipOrientationEnum Orientation { get; set; }
        public ShipTypeEnum ShipType { get; set; }

        public int HitsTaken { get; set; }
        public bool IsDestroyed { get; set; }
    }
}
