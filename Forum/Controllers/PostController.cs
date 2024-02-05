using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
  private SelectList TopicSelectList(int topicId)
  {
    SelectList topics = new(_db.Topics, "TopicId", "Title");
    foreach (SelectListItem topic in topics)
    {
      if (topic.Value == topicId.ToString())
      {
        topic.Selected = true;
      }
    }
    return topics;
  }
  public ActionResult Create(int topicId)
  {
    Dictionary<string, object> model = new() {
      {"Post", new Post()},
      {"SelectList", TopicSelectList(topicId)},
      {"Usage", "create"}
    };
    return View(model);
  }
  [HttpPost]
  public ActionResult Create(Post post)
  {
    if (!ModelState.IsValid)
    {
      Dictionary<string, object> model = new() {
      {"Post", new Post()},
      {"SelectList", TopicSelectList(post.TopicId)},
      {"Usage", "create"}
      };
      return View(model);
    }
    else
    {
      _db.Posts.Add(post);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
  public ActionResult Edit(int id)
  {
    Post targetPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
    Dictionary<string, object> model = new() {
      {"Post", new Post()},
      {"SelectList", TopicSelectList(targetPost.TopicId)},
      {"Usage", "create"}
    };
    return View(model);
  }

  [HttpPost]
  public ActionResult Edit(Post post)
  {
    if (!ModelState.IsValid)
    {
      Dictionary<string, object> model = new() {
      {"Post", post},
      {"SelectList", TopicSelectList(post.TopicId)},
      {"Usage", "create"}
      };
      return View(model);
    }
    else
    {
      _db.Posts.Update(post);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = post.PostId });
    }
  }
  [HttpPost]
  public ActionResult Delete(int id)
  {
    Post targetPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
    int topicId = targetPost.TopicId;
    _db.Posts.Remove(targetPost);
    _db.SaveChanges();
    return RedirectToAction("Details", "Topic", new { id = topicId});
  }
}
