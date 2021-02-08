using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }

        public string PlayerName { get; set; }
        public Guid PlayerId { get; set; }

        public Grid Grid { get; set; }

        public bool IsWinner { get; set; }
    }
}
