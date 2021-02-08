using Data.EfCore.Models;
using Data.Types;
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

            return new SessionIds
            {
                GameSession = session.SessionId,
                Player1 = player1.PlayerId,
                Player2 = player2.PlayerId
            };
        }
    }
}
