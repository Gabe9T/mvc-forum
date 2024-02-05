using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum.Models;

namespace Forum.Controllers
{
        public class TopicController : Controller
        {
            private readonly ForumContext _db;

            public TopicController(ForumContext db)
            {
                _db = db;
            }

            public ActionResult Index()
            {
                List<Topic> model = _db.Topics.ToList();
                return View(model);
            }

            public ActionResult Create()
            {
                Dictionary<string, object> model = new() {
                    {"Topic", new Topic()},
                    {"Usage", "create"}
                };
                return View(model);
            }

            [HttpPost]
            public ActionResult Create(Topic topic)
            {
                if (!@ModelState.IsValid)
                {
                    return View(topic);
                }
                else
                {
                    _db.Topics.Add(topic);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            public ActionResult Details(int id)
            {
                Topic targetTopic = _db.Topics
                .Include(topic => topic.Posts)
                .ThenInclude(post => post.JoinEntities)
                .ThenInclude(join => join.User)
                .FirstOrDefault(topic => topic.TopicId == id);
                return View(targetTopic);
            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                Topic thisTopic = _db.Topics.FirstOrDefault(topic => topic.TopicId == id);
                _db.Topics.Remove(thisTopic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Edit(int id)
            {
                Topic targetTopic = _db.Topics.FirstOrDefault(topic => topic.TopicId == id);
                Dictionary<string, object> model = new() {
                    {"Topic", targetTopic},
                    {"Usage", "edit"}
                };
                return View(model);
            }

            [HttpPost]
            public ActionResult Edit(Topic topic)
            {
                _db.Topics.Update(topic);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = topic.TopicId });
            }
        }
}
