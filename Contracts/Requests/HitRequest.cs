using Domain.DTOs;

namespace Contracts.Requests
{
    public class HitRequest : PlayerRequest
    {
        public Coordinate Hit { get; set; }
    }
}
