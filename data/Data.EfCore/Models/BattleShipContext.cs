using Microsoft.EntityFrameworkCore;

namespace Data.EfCore.Models
{
    public class BattleShipContext : DbContext
    {
        public BattleShipContext(DbContextOptions<BattleShipContext> options)
            : base(options)
        {
        }

        public DbSet<BattleSession> Sessions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Battleship> Battleships { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<CannonBall> CannonBalls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattleSession>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Player>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Battleship>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Board>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<CannonBall>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
