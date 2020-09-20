using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Tests.UnitTest.Helpers
{
    public static class SportEventData
    {
        public static IEnumerable<SportEvent> GenerateData(int numberOfItems = 20)
        {
            for (int i = 1; i < numberOfItems; i++)
            {
                yield return new SportEvent()
                {
                    Id = i,
                    Name = "Event - " + i,
                    OddsForDraw = 1,
                    OddsForFirstTeam = 1,
                    OddsForSecondTeam = 1,
                    StartDate = DateTime.Now
                };
            }
        }
    }
}
