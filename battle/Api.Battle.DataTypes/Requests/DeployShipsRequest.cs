using System;
using System.Collections.Generic;

namespace Api.Battle.DataTypes.Requests
{
    public class DeployShipsRequest
    {
        public Guid PlayerId { get; set; }
        public IEnumerable<Ship> Ships { get; set; }
    }
}
