using System;

namespace Data.EfCore.Models
{
    public class BattleSession : BaseEntity
    {
        public Guid SessionId { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool IsFinished { get; set; }
    }
}
