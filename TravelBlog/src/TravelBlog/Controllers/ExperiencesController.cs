using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Experiences.Include(experiences => experiences.Location).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateRelationship(int experienceId, int personId)
        {
            PersonExperience personExperience = new PersonExperience(personId, experienceId);
            db.PeopleExperiences.Add(personExperience);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = experienceId });
        }

        public IActionResult Details(int id)
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name");

            Experience thisExperience = db.Experiences
                .Include(experiences => experiences.People)
                .ThenInclude(pE => pE.Person)
                .FirstOrDefault(experience => experience.ExperienceId == id);

            return View(thisExperience);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            Experience thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            db.Entry(experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Experience thisExp = db.Experiences.FirstOrDefault(exp => exp.ExperienceId == id);
            return View(thisExp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Experience exp = db.Experiences.FirstOrDefault(exper => exper.ExperienceId == id);
            db.Experiences.Remove(exp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}