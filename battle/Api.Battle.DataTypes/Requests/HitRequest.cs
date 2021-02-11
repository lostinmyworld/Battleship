using System;

namespace Api.Battle.DataTypes.Requests
{
    public class HitRequest
    {
        public Guid PlayerId { get; set; }
        public Coordinate Hit { get; set; }
    }
}
