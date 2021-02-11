using Data.EfCore.Models;
using Data.Types;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBattleshipRepository
    {
        Task<SessionIds> CreateGame(string gameName);

        Task<Player> RetrievePlayerById(Guid playerId);
        Task<Player> RetrieveEnemyPlayer(Guid playerId);

        bool IsHitRepeated(Player player, byte row, byte column);

        void UpdateShipsHits(Player player, Board board);
        void UpdateCannonbalsShot(Player player, CannonBall cannonBall);

        Task<bool> IsItFinished(Guid playerId);
        Task AnnounceWinner(Player player);

        Task<bool> SaveAsync();
    }
}
