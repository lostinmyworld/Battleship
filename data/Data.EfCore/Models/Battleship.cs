using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class Battleship
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }
        public bool IsHit { get; set; }
        public bool IsDestroyed { get; set; }
        public Grid Grid { get; set; }
    }
}
