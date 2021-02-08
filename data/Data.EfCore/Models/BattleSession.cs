using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class BattleSession
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool IsFinished { get; set; }
    }
}
