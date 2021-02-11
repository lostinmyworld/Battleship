namespace Data.EfCore.Models
{
    public class Battleship : BaseEntity
    {
        public byte RowStart { get; set; }
        public byte ColumnStart { get; set; }

        public int Orientation { get; set; }
        public int ShipType { get; set; }

        public byte HitsTaken { get; set; }
        public bool IsDestroyed { get; set; }

        public Board Board { get; set; }
    }
}
