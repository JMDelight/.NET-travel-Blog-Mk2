using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelsBlog.Models
{
    public class EFSuggestionRepository : ISuggestionRepository
    {
        TravelBlogContext db = new TravelBlogContext();

        public IQueryable<Suggestion> Suggestions
        { get { return db.Suggestions; } }

        public Suggestion Save(Suggestion suggestion)
        {
            db.Suggestions.Add(suggestion);
            db.SaveChanges();
            return suggestion;
        }

        public Suggestion Edit(Suggestion suggestion)
        {
            db.Entry(suggestion).State = EntityState.Modified;
            db.SaveChanges();
            return suggestion;
        }

        public void Remove(Suggestion suggestion)
        {
            db.Suggestions.Remove(suggestion);
            db.SaveChanges();
        }
    }
}
