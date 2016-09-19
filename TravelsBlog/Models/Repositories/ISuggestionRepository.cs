using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsBlog.Models
{
    public interface ISuggestionRepository
    {
        IQueryable<Suggestion> Suggestions { get; }
        Suggestion Save(Suggestion suggestion);
        Suggestion Edit(Suggestion suggestion);
        void Remove(Suggestion suggestion);

    }
}
