using System;

namespace Data.EfCore.Models
{
    public class BattleSession : BaseEntity
    {
        public Guid SessionId { get; set; }
        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
        public bool IsFinished { get; set; }
    }
}
