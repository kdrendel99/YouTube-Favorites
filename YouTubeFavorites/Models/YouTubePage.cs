using System.Collections.Generic;

namespace YouTubeFavorites.Models
{
  public class YouTubePage
  {

    public YouTubePage()
    {
      this.JoinEntities = new HashSet<CategoryYouTubePage>();
    }

    public int YouTubePageId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }

    public int CategoryId { get; set; }
    public virtual ICollection<CategoryYouTubePage> JoinEntities { get;}
  }
}