using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Entities
{
    public class SportEvent : BaseEntity
    {
        public string Name { get; set; }

        public double? OddsForFirstTeam { get; set; }

        public double? OddsForDraw { get; set; }

        public double? OddsForSecondTeam { get; set; }

        public DateTime StartDate { get; set; }
    }
}
