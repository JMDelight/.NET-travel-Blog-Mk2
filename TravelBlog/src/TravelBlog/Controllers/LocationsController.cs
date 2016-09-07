using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Locations.Include(locations => locations.Experiences).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Locations.Include(locations => locations.Experiences).FirstOrDefault(locations => locations.LocationId == id);
            return View(thisItem);
        }
    }
}
