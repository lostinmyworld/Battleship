using System.Collections.Generic;

namespace Api.Battle.DataTypes.Requests
{
    public class DeployShipsRequest : PlayerRequest
    {
        public IEnumerable<Ship> Ships { get; set; }
    }
}
