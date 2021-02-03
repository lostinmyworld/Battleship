using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public int GridId { get; set; }
        public Grid Grid { get; set; }
        public string PlayerName { get; set; }
        public bool IsWinner { get; set; }
    }
}
