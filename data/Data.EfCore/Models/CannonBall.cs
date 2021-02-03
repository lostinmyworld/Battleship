using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class CannonBall
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Hit { get; set; }
        public int GridId { get; set; }
        public Grid Grid { get; set; }
    }
}
