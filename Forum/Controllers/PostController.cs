using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;

namespace Forum.Controllers;

public class PostController : Controller
{
  private readonly ForumContext _db;

  public PostController(ForumContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    List<Post> model = _db.Posts.ToList();
    return View(model);
  }
}
