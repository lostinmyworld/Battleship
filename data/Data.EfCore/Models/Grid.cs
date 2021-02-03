using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class Grid
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public ICollection<Battleship> Ship { get; set; }
        public ICollection<CannonBall> CannonBallsShot { get; set; }
    }
}
