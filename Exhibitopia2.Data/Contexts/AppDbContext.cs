using Exhibitopia2.Data.Configurations;
using Exhibitopia2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exhibitopia2.Data.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DatabaseConfigurations.SqlServerConnectionString);
    }

    public DbSet<Photo> Photos { get; set; }
    public DbSet<PhotoComment> PhotoComments { get; set; }
    public DbSet<PhotoLike> PhotoLikes { get; set; }
    public DbSet<User> Users { get; set; }
}
