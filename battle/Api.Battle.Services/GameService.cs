using Api.Battle.DataTypes.Requests;
using Api.Battle.DataTypes.Responses;
using Api.Battle.Interfaces;
using Data.Repository;
using System;
using System.Threading.Tasks;

namespace Api.Battle.Services
{
    public class GameService : IGameService
    {
        private readonly IBattleshipRepository _repo;

        public GameService(IBattleshipRepository repo)
        {
            _repo = repo;
        }

        public async Task<CreateGameResponse> CreateGameSession(CreateGameRequest request)
        {
            var session = _repo.CreateGame(request.GameName);

            throw new NotImplementedException();
            
        }
    }
}
