
using ChessCompanionAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ChessCompanionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=chesscompanion;Integrated Security=True;TrustServerCertificate=true;user id=chesscompanion_user;password=P@ssword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ChessGame> ChessGames { get; set; }
    }
}
