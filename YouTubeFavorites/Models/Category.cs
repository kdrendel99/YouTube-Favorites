using System.Collections.Generic;

namespace YouTubeFavorites.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryYouTubePage>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryYouTubePage> JoinEntities { get; set; }
  }
}