using Domain.DTOs;
using System.Collections.Generic;

namespace Contracts.Responses
{
    public class GetPlayerShipsResponse
    {
        public List<BattleshipDto> Ships { get; set; }
    }
}
