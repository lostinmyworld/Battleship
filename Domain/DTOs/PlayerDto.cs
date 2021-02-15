using System;

namespace Domain.DTOs
{
    public class PlayerDto
    {
        public string PlayerName { get; set; }
        public Guid PlayerId { get; set; }

        public BoardDto Board { get; set; }

        public bool IsWinner { get; set; }
    }
}
