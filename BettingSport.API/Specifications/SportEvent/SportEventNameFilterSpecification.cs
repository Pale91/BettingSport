using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEventEntity = BettingSport.Core.Entities.SportEvent;

namespace BettingSport.API.Specifications.SportEvent
{
    public class SportEventNameFilterSpecification : PagingSpecification<SportEventEntity>
    {
        public SportEventNameFilterSpecification(string eventNameSubstr) : this(eventNameSubstr, 10, 1)
        {
        }

        public SportEventNameFilterSpecification(string eventNameSubstr, int pageSize, int pageNumber) : base(pageSize, pageNumber)
        {
            if (!String.IsNullOrWhiteSpace(eventNameSubstr))
                Criteria = (SportEventEntity e) => e.Name.Contains(eventNameSubstr);
        }
    }
}
