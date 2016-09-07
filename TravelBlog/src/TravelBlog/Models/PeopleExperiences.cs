using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class PeopleExperiences
    {
        [Key]
        public int PeopleExperiencesId { get; set; }
        public int PersonId { get; set; }
        public int ExperienceId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
