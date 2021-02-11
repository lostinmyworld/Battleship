using Api.Battle.DataTypes;
using Api.Battle.DataTypes.Requests;
using System.Linq;

namespace Api.Battle.Services.Extensions
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
            return request != null
                && request.PlayerId != default
                && request.Ships != null && request.Ships.Count() == MAX_SHIPS
                && request.Ships.All(IsValid);
        }

        internal static bool IsValid(this HitRequest request)
        {
            return request != null
                && request.PlayerId != default
                && request.Hit != null;
        }

        private static bool IsValid(this Ship ship)
        {
            return ship != null
                && ship.CoordinateStart != null;
        }
    }
}
