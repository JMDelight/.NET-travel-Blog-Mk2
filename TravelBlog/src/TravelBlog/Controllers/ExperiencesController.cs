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

        public IActionResult CreateRelationship()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name");
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult CreateRelationship(int experienceId, int personId)
        {
            PersonExperience personExperience = new PersonExperience(personId, experienceId);
            db.PeopleExperiences.Add(personExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Experience otherExperience = db.Experiences
                .Include(experiences => experiences.People)
                .ThenInclude(pE => pE.Person)
                .FirstOrDefault(experience => experience.ExperienceId == id);

            return View(otherExperience);
        }
    }
}