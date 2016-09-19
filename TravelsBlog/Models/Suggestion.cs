using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsBlog.Models
{
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string Destination { get; set; }
        public bool Visited { get; set; }
        public int Votes { get; set; }
        public virtual ICollection<Detail> Details { get; set; }


    }
}
