using BettingSport.API.Specifications.SportEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSport.API.Helper
{
    public class FilterSportEventParams
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string NameFilter { get; set; }

        public SportEventNameFilterSpecification ToSpecification()
        {
            return new SportEventNameFilterSpecification(NameFilter, PageSize, PageNumber);
        }
    }
}
