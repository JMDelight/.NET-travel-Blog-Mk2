using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class Person
    {
        public Person()
        { }

        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual IList<PersonExperience> PeopleExperiences { get; set; }
    }
}
