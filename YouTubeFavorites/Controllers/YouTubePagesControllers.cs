using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using YouTubeFavorites.Models;
using System.Collections.Generic;
using System.Linq;

namespace YouTubeFavorites.Controllers
{
  public class YouTubePagesController : Controller
  {
    private readonly YouTubeFavoritesContext _db;

    public YouTubePagesController(YouTubeFavoritesContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.YouTubePages.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(YouTubePage youtubepage, int CategoryId)
    {
      _db.YouTubePages.Add(youtubepage);
      _db.SaveChanges();
      if (CategoryId != 0)
      {
        _db.CategoryYouTubePage.Add(new CategoryYouTubePage() { CategoryId = CategoryId, YouTubePageId = youtubepage.YouTubePageId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisYouTubePage = _db.YouTubePages
          .Include(youtubepage => youtubepage.JoinEntities)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(youtubepage => youtubepage.YouTubePageId == id);
      return View(thisYouTubePage);
    }

    public ActionResult Edit(int id)
    {
      var thisYouTubePage = _db.YouTubePages.FirstOrDefault(youtubepages => youtubepages.YouTubePageId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisYouTubePage);
    }

    [HttpPost]
    public ActionResult Edit(YouTubePage youtubepage, int CategoryId)
    {
      if (CategoryId != 0)
      {
        _db.CategoryYouTubePage.Add(new CategoryYouTubePage() { CategoryId = CategoryId, YouTubePageId = youtubepage.YouTubePageId });
      }
      _db.Entry(youtubepage).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCategory(int id)
    {
      var thisYouTubePage = _db.YouTubePages.FirstOrDefault(youtubepage => youtubepage.YouTubePageId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories,"CategoryId", "Name");
      return View(thisYouTubePage);
    }

    [HttpPost]
    public ActionResult AddCategory(YouTubePage youtubepage, int CategoryId)
    {
        if (CategoryId != 0)
        {
        _db.CategoryYouTubePage.Add(new CategoryYouTubePage() { CategoryId = CategoryId, YouTubePageId = youtubepage.YouTubePageId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisYouTubePage = _db.YouTubePages.FirstOrDefault(youtubepages => youtubepages.YouTubePageId == id);
      return View(thisYouTubePage);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisYouTubePage = _db.YouTubePages.FirstOrDefault(youtubepages => youtubepages.YouTubePageId == id);
      _db.YouTubePages.Remove(thisYouTubePage);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
      var joinEntry = _db.CategoryYouTubePage.FirstOrDefault(entry => entry.CategoryYouTubePageId == joinId);
      _db.CategoryYouTubePage.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
