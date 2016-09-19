using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsBlog.Models
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }
        public string Description { get; set; }
        public int SuggestionId { get; set; }
        public virtual Suggestion Suggestion { get; set; }
    }
}
