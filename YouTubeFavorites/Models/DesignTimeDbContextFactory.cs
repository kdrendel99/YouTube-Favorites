using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YouTubeFavorites.Models
{
  public class YouTubeFavoritesContextFactory : IDesignTimeDbContextFactory<YouTubeFavoritesContext>
  {
    YouTubeFavoritesContext IDesignTimeDbContextFactory<YouTubeFavoritesContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<YouTubeFavoritesContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new YouTubeFavoritesContext(builder.Options);
    }
  }
}