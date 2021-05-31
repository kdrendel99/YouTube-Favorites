using Microsoft.EntityFrameworkCore;

namespace YouTubeFavorites.Models
{
  public class YouTubeFavoritesContext : DbContext
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<YouTubePage> YouTubePages { get; set; }
    public DbSet<CategoryYouTubePage> CategoryYouTubePage { get; set;}

    public YouTubeFavoritesContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}