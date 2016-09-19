using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelsBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelsBlog.Controllers
{
    public class DetailsController : Controller
    {
        private IDetailRepository detailRepo;

        public DetailsController(IDetailRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.detailRepo = new EFDetailRepository();
            }
            else
            {
                this.detailRepo = thisRepo;
            }
        }


        public ViewResult Index()
        {
            return View(detailRepo.Details.ToList());
        }

        public IActionResult Details(int id)
        {
            Detail thisDetail = detailRepo.Details.FirstOrDefault(x => x.DetailId == id);
            return View(thisDetail);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Detail detail)
        {
            detailRepo.Save(detail);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Detail thisDetail = detailRepo.Details.FirstOrDefault(x => x.DetailId == id);
            return View(thisDetail);
        }

        [HttpPost]
        public IActionResult Edit(Detail detail)
        {
            detailRepo.Edit(detail);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Detail thisDetail = detailRepo.Details.FirstOrDefault(x => x.DetailId == id);
            return View(thisDetail);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Detail thisDetail = detailRepo.Details.FirstOrDefault(x => x.DetailId == id);
            detailRepo.Remove(thisDetail);
            return RedirectToAction("Index");
        }
    }
}
