using Data.Types;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBattleshipRepository
    {
        Task<SessionIds> CreateGame(string gameName);
    }
}
