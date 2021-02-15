using Contracts.Requests;
using Domain.DTOs;
using System.Linq;

namespace Infrastructure.Extensions
{
    internal static class ValidationExtensions
    {
        private const int MAX_SHIPS = 5;

        internal static bool IsValid(this CreateGameRequest request)
        {
            return request != null;
        }

        internal static bool IsValid(this DeployShipsRequest request)
        {
            var parentRequest = (PlayerRequest)request;

            return parentRequest.IsValid()
                && request.Ships != null && request.Ships.Count() == MAX_SHIPS
                && request.Ships.All(IsValid);
        }

        internal static bool IsValid(this HitRequest request)
        {
            var parentRequest = (PlayerRequest)request;

            return parentRequest.IsValid()
                && request.Hit != null;
        }

        internal static bool IsValid(this PlayerRequest request)
        {
            return request != null
                && request.PlayerId != default;
        }

        private static bool IsValid(this Ship ship)
        {
            return ship != null
                && ship.CoordinateStart != null;
        }
    }
}
