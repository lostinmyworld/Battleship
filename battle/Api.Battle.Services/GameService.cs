using Api.Battle.DataTypes.Requests;
using Api.Battle.DataTypes.Responses;
using Api.Battle.Interfaces;
using Api.Battle.Services.Extensions;
using AutoMapper;
using Data.EfCore.Models;
using Data.Repository;
using System;
using System.Threading.Tasks;

namespace Api.Battle.Services
{
    public class GameService : IGameService
    {
        private readonly ICalculationService _calculationService;
        private readonly IBattleshipRepository _repo;
        private readonly IMapper _mapper;

        public GameService(ICalculationService calculationService, IBattleshipRepository repo, IMapper mapper)
        {
            _calculationService = calculationService;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CreateGameResponse> CreateGameSession(CreateGameRequest request)
        {
            if (!request.IsValid())
            {
                throw new ArgumentNullException(nameof(request));
            }

            var session = await _repo.CreateGame(request.GameName).ConfigureAwait(false);

            return _mapper.Map<CreateGameResponse>(session);
        }

        public async Task<bool> DeployShips(DeployShipsRequest request)
        {
            if (!request.IsValid())
            {
                throw new ArgumentNullException(nameof(request));
            }

            var dbPlayer = await _repo.GetPlayerById(request.PlayerId).ConfigureAwait(false);
            if (dbPlayer == null)
            {
                throw new ArgumentException("Player not found in database.");
            }

            var board = _calculationService.CreatePlayerBoard(request);

            dbPlayer.Board = _mapper.Map<Board>(board);

            return await _repo.SaveAsync().ConfigureAwait(false);
        }

        public Task<bool> CannonBallHit(HitRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
