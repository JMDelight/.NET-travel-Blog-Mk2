using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeopleController : Controller
    {

        private TravelBlogContext db = new TravelBlogContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.People.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Person person = db.People.FirstOrDefault(people => people.PersonId == id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Person person = db.People.FirstOrDefault(people => people.PersonId == id);
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePerson(int id)
        {
            Person person = db.People.FirstOrDefault(people => people.PersonId == id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
