namespace YouTubeFavorites.Models
{
  public class CategoryYouTubePage
  {
    public int CategoryYouTubePageId { get; set;}
    public int YouTubePageId { get; set; }
    public int CategoryId { get; set; }
    public virtual YouTubePage YouTubePage { get; set; }
    public virtual Category Category { get; set; }
  }
}
