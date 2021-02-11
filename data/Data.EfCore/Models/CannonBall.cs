﻿namespace Data.EfCore.Models
{
    public class CannonBall : BaseEntity
    {
        public byte Row { get; set; }
        public byte Column { get; set; }
        public bool Hit { get; set; }
        public Board Board { get; set; }
    }
}
