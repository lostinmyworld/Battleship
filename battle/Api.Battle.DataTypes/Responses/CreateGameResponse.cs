using System;

namespace Api.Battle.DataTypes.Responses
{
    public class CreateGameResponse
    {
        public Guid GameSession { get; set; }
        public Guid Player1 { get; set; }
        public Guid Player2 { get; set; }
    }
}
