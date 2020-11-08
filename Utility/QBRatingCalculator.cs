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
        public static double CalculatePasserRating(QuarterbackAware quarterBack)
        {
            switch (quarterBack)
            {
                case NationalFootballLeagueQB nflQB:
                case CanadianFootbalLeagueQB cflQB:
                    {
                        double a = ((quarterBack.Completions.Value / quarterBack.Attempts.Value) - .3) * 5;
                        double b = ((quarterBack.PassYards.Value / quarterBack.Attempts.Value) - 3) * .25;
                        double c = (quarterBack.TouchDowns.Value / quarterBack.Attempts.Value) * 20;
                        double d = 2.375 - ((quarterBack.Interceptions.Value / quarterBack.Attempts.Value) * 25);
                        double passerRating = Math.Round(((a + b + c + d) / 6) * 100, 1);
                        return passerRating < 158.3 ? passerRating : 158.3;

                    }
                case NationalCollegiateAthleticAssociationQB ncaaQB:
                    {
                        var passerRating = Math.Round(((8.4 * quarterBack.PassYards.Value) +
                            (330 * quarterBack.TouchDowns.Value) +
                            (100 * quarterBack.Completions.Value) -
                            (200 * quarterBack.Interceptions.Value)) /
                            quarterBack.Attempts.Value, 1);
                        return passerRating < 1261.6 ? passerRating : 1261.6;

                    }
                default: return -1.0;
            }
        }
    }
}
