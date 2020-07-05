using Microsoft.EntityFrameworkCore;

namespace WorkShake.Models
{
  public class WorkShakeContext : DbContext
  {
    public WorkShakeContext(DbContextOptions<WorkShakeContext> options) : base(options)
    {
    }

    public DbSet<ChainStore> ChainStore { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<User> User { get; set; }
  }
}