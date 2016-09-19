using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelsBlog.Models
{
    public class EFDetailRepository : IDetailRepository
    {
        TravelBlogContext db = new TravelBlogContext();

        public IQueryable<Detail> Details
        { get { return db.Details; } }

        public Detail Save(Detail detail)
        {
            db.Details.Add(detail);
            db.SaveChanges();
            return detail;
        }

        public Detail Edit(Detail detail)
        {
            db.Entry(detail).State = EntityState.Modified;
            db.SaveChanges();
            return detail;
        }

        public void Remove(Detail detail)
        {
            db.Details.Remove(detail);
            db.SaveChanges();
        }
    }
}
