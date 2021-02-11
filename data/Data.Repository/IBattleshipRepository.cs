using Data.EfCore.Models;
using Data.Types;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBattleshipRepository
    {
        Task<SessionIds> CreateGame(string gameName);

        Task<Player> GetPlayerById(Guid playerId);
        Task<Player> GetEnemyPlayer(Guid playerId);

        Task<bool> SaveAsync();
    }
}
