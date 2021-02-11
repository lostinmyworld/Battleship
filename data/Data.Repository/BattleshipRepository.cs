using Data.EfCore.Models;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BattleshipRepository : IBattleshipRepository
    {
        private readonly BattleShipContext _context;

        public BattleshipRepository(BattleShipContext context)
        {
            _context = context;
        }

        public async Task<SessionIds> CreateGame(string gameName)
        {
            if (string.IsNullOrWhiteSpace(gameName))
            {
                gameName = Guid.NewGuid().ToString();
            }

            var player1 = new Player
            {
                PlayerName = $"{gameName}.Player1",
                PlayerId = Guid.NewGuid()
            };

            var player2 = new Player
            {
                PlayerName = $"{gameName}.Player2",
                PlayerId = Guid.NewGuid()
            };

            var session = new BattleSession
            {
                Player1 = player1,
                Player2 = player2,
                SessionId = Guid.NewGuid()
            };

            await _context.Sessions.AddAsync(session).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new SessionIds
            {
                GameSession = session.SessionId,
                Player1 = player1.PlayerId,
                Player2 = player2.PlayerId
            };
        }

        public async Task<Player> RetrievePlayerById(Guid playerId)
        {
            if (playerId == default)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return await _context.Players
                .FirstOrDefaultAsync(p => p.PlayerId == playerId)
                .ConfigureAwait(false);
        }

        public async Task<Player> RetrieveEnemyPlayer(Guid playerId)
        {
            var session = await RetrieveSessionFromPlayerId(playerId)
                .ConfigureAwait(false);

            if (session == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return session.Player1.PlayerId == playerId
                ? session.Player2
                : session.Player1;
        }

        public bool IsHitRepeated(Player player, byte row, byte column)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return player.Board.CannonBallsShot.Any(c => c.Row == row && c.Column == column);
        }

        public void UpdateShipsHits(Player player, Board board)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            foreach (var existedShip in player.Board.Ships)
            {
                var ship = board.Ships.FirstOrDefault(s => s.ShipType == existedShip.ShipType);
                existedShip.IsDestroyed = ship.IsDestroyed;
                existedShip.HitsTaken = ship.HitsTaken;
            }
        }

        public void UpdateCannonbalsShot(Player player, CannonBall newHit)
        {
            if (!player.Board.CannonBallsShot.Any(c => c.Row == newHit.Row && c.Column == newHit.Column))
            {
                newHit.Board = player.Board;
                player.Board.CannonBallsShot.Add(newHit);
            }
        }

        public async Task<bool> IsItFinished(Guid playerId)
        {
            var session = await RetrieveSessionFromPlayerId(playerId).ConfigureAwait(false);
            if (session == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return session.IsFinished;
        }

        public async Task AnnounceWinner(Player player)
        {
            if (player == null || player.PlayerId == default)
            {
                throw new ArgumentNullException(nameof(player));
            }
            var session = await RetrieveSessionFromPlayerId(player.PlayerId).ConfigureAwait(false);
            if (session == null)
            {
                throw new ArgumentNullException(nameof(player.PlayerId));
            }

            player.IsWinner = true;
            session.IsFinished = true;
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        #region private helpers
        private async Task<BattleSession> RetrieveSessionFromPlayerId(Guid playerId)
        {
            if (playerId == default)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return await _context.Sessions
                .FirstOrDefaultAsync(s => s.Player1.PlayerId == playerId || s.Player2.PlayerId == playerId)
                .ConfigureAwait(false);
        }
        #endregion
    }
}
