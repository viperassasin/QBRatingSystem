using QBRatingSystem.Enums;
using QBRatingSystem.Implementations;
using QBRatingSystem.Interfaces;
using QBRatingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.Utility
{
    public class QBRatingCalculator
    {
        public static double CalculatePasserRating(IQuarterback quarterBack)
        {
            switch (quarterBack)
            {
                case NationalFootballLeagueQB nflQB:
                case CanadianFootbalLeagueQB cflQB:
                    {
                        double a = ((quarterBack.PasserStats.Completions / quarterBack.PasserStats.Attempts) - .3) * 5;
                        double b = ((quarterBack.PasserStats.PassYards / quarterBack.PasserStats.Attempts) - 3) * .25;
                        double c = (quarterBack.PasserStats.TouchDowns / quarterBack.PasserStats.Attempts) * 20;
                        double d = 2.375 - ((quarterBack.PasserStats.Interceptions / quarterBack.PasserStats.Attempts) * 25);
                        return ((a + b + c + d) / 6) * 100;

                    }
                case NationalCollegiateAthleticAssociationQB ncaaQB:
                    {
                        return (8.4 * quarterBack.PasserStats.PassYards) + (330 * quarterBack.PasserStats.TouchDowns) + (100 * quarterBack.PasserStats.Completions) - (200 * quarterBack.PasserStats.Interceptions);

                    }
                default: return -1.0;
            }
        }
    }
}
