using Microsoft.EntityFrameworkCore;

namespace Data.EfCore.Models
{
    public class BattleShipContext : DbContext
    {
        public BattleShipContext(DbContextOptions<BattleShipContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Battleship> Battleships { get; set; }
        public DbSet<Grid> Grids { get; set; }
    }
}
