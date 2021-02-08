using Api.Battle.DataTypes.Requests;
using Api.Battle.DataTypes.Responses;
using System.Threading.Tasks;

namespace Api.Battle.Interfaces
{
    public interface IGameService
    {
        Task<CreateGameResponse> CreateGameSession(CreateGameRequest request);
    }
}
