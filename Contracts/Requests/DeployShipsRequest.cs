using Domain.DTOs;
using System.Collections.Generic;

namespace Contracts.Requests
{
    public class DeployShipsRequest : PlayerRequest
    {
        public IEnumerable<Ship> Ships { get; set; }
    }
}
