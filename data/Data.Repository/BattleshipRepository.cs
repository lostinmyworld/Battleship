using Data.EfCore.Models;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Player> GetPlayerById(Guid playerId)
        {
            if (playerId == default)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return await _context.Players
                .FirstOrDefaultAsync(p => p.PlayerId == playerId)
                .ConfigureAwait(false);
        }

        public async Task<Player> GetEnemyPlayer(Guid playerId)
        {
            if (playerId == default)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(s => s.Player1.PlayerId == playerId || s.Player2.PlayerId == playerId)
                .ConfigureAwait(false);

            if (session == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return session.Player1.PlayerId == playerId
                ? session.Player2
                : session.Player1;
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
    }
}
