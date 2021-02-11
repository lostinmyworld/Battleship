using System.Collections.Generic;

namespace Api.Battle.DataTypes.DTOs
{
    public class BoardDto
    {
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public ICollection<BattleshipDto> Ships { get; set; }
        public ICollection<CannonBallDto> CannonBallsShot { get; set; }
    }
}
