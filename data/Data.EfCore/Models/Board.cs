using System.Collections.Generic;

namespace Data.EfCore.Models
{
    public class Board : BaseEntity
    {
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public virtual ICollection<Battleship> Ships { get; set; }
        public virtual ICollection<CannonBall> CannonBallsShot { get; set; }
    }
}
