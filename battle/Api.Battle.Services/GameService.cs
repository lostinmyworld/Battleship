using Api.Battle.DataTypes.DTOs;
using Api.Battle.DataTypes.Requests;
using Api.Battle.DataTypes.Responses;
using Api.Battle.Interfaces;
using Api.Battle.Services.Extensions;
using AutoMapper;
using Data.EfCore.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var dbPlayer = await _repo.RetrievePlayerById(request.PlayerId).ConfigureAwait(false);
            if (dbPlayer == null)
            {
                throw new ArgumentException("Player not found in database.");
            }

            var board = _calculationService.CreatePlayerBoard(request);

            dbPlayer.Board = _mapper.Map<Board>(board);

            return await _repo.SaveAsync().ConfigureAwait(false);
        }

        public async Task<HitResponse> CannonBallHit(HitRequest request)
        {
            if (!request.IsValid())
            {
                throw new ArgumentNullException(nameof(request));
            }

            var dbPlayer = await _repo.RetrievePlayerById(request.PlayerId).ConfigureAwait(false);
            var dbEnemyPlayer = await _repo.RetrieveEnemyPlayer(request.PlayerId).ConfigureAwait(false);
            if (dbPlayer == null || dbEnemyPlayer == null)
            {
                throw new ArgumentException("Player not found in database.");
            }

            if (_repo.IsHitRepeated(dbPlayer, request.Hit.Row, request.Hit.Column))
            {
                throw new ArgumentException("You already hit that mark!! Try again in a different spot.");
            }

            var cannonBall = _mapper.Map<CannonBallDto>(request.Hit);
            var enemyBoard = _mapper.Map<BoardDto>(dbEnemyPlayer.Board);

            var hitSuccess = _calculationService.CannonBallHit(enemyBoard, cannonBall);
            
            _repo.UpdateShipsHits(dbEnemyPlayer, _mapper.Map<Board>(enemyBoard));
            _repo.UpdateCannonbalsShot(dbPlayer, _mapper.Map<CannonBall>(cannonBall));

            if (dbEnemyPlayer.Board.Ships.All(s => s.IsDestroyed))
            {
                await _repo.AnnounceWinner(dbPlayer).ConfigureAwait(false);
            }

            await _repo.SaveAsync().ConfigureAwait(false);

            return new HitResponse { Hit = cannonBall };
        }

        public async Task<GetPlayerShipsResponse> GetAllPlayerShips(PlayerRequest request)
        {
            if (!request.IsValid())
            {
                throw new ArgumentNullException(nameof(request));
            }

            var dbPlayer = await _repo.RetrievePlayerById(request.PlayerId).ConfigureAwait(false);
            if (dbPlayer?.Board?.Ships == null)
            {
                throw new ArgumentException("Player not found in database.");
            }

            var ships = _mapper.Map<IEnumerable<BattleshipDto>>(dbPlayer.Board.Ships);

            return new GetPlayerShipsResponse
            {
                Ships = ships.ToList()
            };
        }
    }
}
