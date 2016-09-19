using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsBlog.Models
{
    public interface IDetailRepository
    {
        IQueryable<Detail> Details { get; }
        Detail Save(Detail detail);
        Detail Edit(Detail detail);
        void Remove(Detail detail);
    }
}
