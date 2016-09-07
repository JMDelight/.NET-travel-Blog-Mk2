using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Experiences.ToList());
        }
    }
}
