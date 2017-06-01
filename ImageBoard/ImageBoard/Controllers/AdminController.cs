using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ImageBoard.Models;
using System.Data;
using System;
using System.Web;

namespace ImageBoard.Controllers
{
    public class AdminController : Controller
    {
        private MainContext db = new MainContext ();

        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Role).ToList();
            return View(users);
        }
        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create()
        {
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }
        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            SelectList roles = new SelectList(db.Roles, "Id", "Name", user.RoleId);
            ViewBag.Roles = roles;

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }
        [Authorize(Roles = "Администратор")]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AllUsers()
        {
            var users = db.Users.Include(u => u.Role).ToList();
            return View(users);
        }

    }
}
