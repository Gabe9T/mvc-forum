using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum.Models;

namespace Forum.Controllers
{
        public class UserController : Controller
        {
            private readonly ForumContext _db;

            public UserController(ForumContext db)
            {
                _db = db;
            }

            public ActionResult Index()
            {
                List<User> model = _db.Users.ToList();
                return View(model);
            }
            public ActionResult Create()
            {
                Dictionary<string, object> model = new() {
                    {"User", new User()},
                    {"Usage", "create"}
                };
                return View(model);
            }
            [HttpPost]
            public ActionResult Create(User user)
            {
                if (!@ModelState.IsValid)
                {
                    Dictionary<string, object> model = new() {
                    {"User", user},
                    {"Usage", "create"}
                };
                    return View(model);
                }
                else
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        public ActionResult Details(int id)
        {
            User targetUser = _db.Users
            .Include(user => user.JoinEntities)
            .ThenInclude(join => join.Post)
            .FirstOrDefault(user => user.UserId == id);
            return View(targetUser);
        }

         public ActionResult Edit(int id)
        {
            User targetUser = _db.Users.FirstOrDefault(user => user.UserId == id);
            Dictionary<string, object> model = new() {
                    {"User", targetUser},
                    {"Usage", "edit"}
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                Dictionary<string, object> model = new() {
                    {"User", user},
                    {"Usage", "edit"}
                };
                return View(model);
            }
            else
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = user.UserId });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            User thisUser = _db.Users.FirstOrDefault(u => u.UserId == id);
            _db.Users.Remove(thisUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        }
}        
