using Contracts.Requests;
using Contracts.Responses;
using System.Threading.Tasks;

namespace Application
{
    public interface IGameService
    {
        Task<CreateGameResponse> CreateGameSession(CreateGameRequest request);
        Task<bool> DeployShips(DeployShipsRequest request);
        Task<HitResponse> CannonBallHit(HitRequest request);
        Task<GetPlayerShipsResponse> GetAllPlayerShips(PlayerRequest request);
    }
}
