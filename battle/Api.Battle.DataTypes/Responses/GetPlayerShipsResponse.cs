using Api.Battle.DataTypes.DTOs;
using System.Collections.Generic;

namespace Api.Battle.DataTypes.Responses
{
    public class GetPlayerShipsResponse
    {
        public List<BattleshipDto> Ships { get; set; }
    }
}
