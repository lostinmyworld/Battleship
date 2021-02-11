using System;

namespace Data.EfCore.Models
{
    public class Player : BaseEntity
    {
        public string PlayerName { get; set; }
        public Guid PlayerId { get; set; }

        public virtual Board Board { get; set; }

        public bool IsWinner { get; set; }
    }
}
