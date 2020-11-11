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
        private const decimal PASSERCONST = 2.375M;

        private const int ZERO = 0;

        public static decimal CalculatePasserRating(IQuaterback quarterback)
        {
            switch (quarterback)
            {
                case NationalFootballLeagueQB nflQB:
                case CanadianFootbalLeagueQB cflQB:
                    {
                        decimal a = Math.Round((Decimal.Divide(quarterback.Completions.Value, quarterback.Attempts.Value) - .3M) * 5, 3);

                        decimal b = Math.Round((Decimal.Divide(quarterback.PassYards.Value, quarterback.Attempts.Value) - 3M) * .25M, 3);

                        decimal c = Math.Round((Decimal.Divide(quarterback.TouchDowns.Value, quarterback.Attempts.Value)) * 20, 3);

                        decimal d = Math.Round(PASSERCONST - (Decimal.Divide(quarterback.Interceptions.Value, quarterback.Attempts.Value) * 25), 3);

                        decimal passerRating = Math.Round(((ValueOrLimits(a,0,PASSERCONST) + ValueOrLimits(b,0,PASSERCONST) + ValueOrLimits(c,0,PASSERCONST) + ValueOrLimits(d,0,PASSERCONST)) / 6) * 100, 2);

                        return ValueOrLimits(passerRating, 0, 158.3M);

                    }
                case NationalCollegiateAthleticAssociationQB ncaaQB:
                    {
                        var passerRating = Math.Round(((8.4M * quarterback.PassYards.Value) +
                            (330M * quarterback.TouchDowns.Value) +
                            (100M * quarterback.Completions.Value) -
                            (200M * quarterback.Interceptions.Value)) /
                            quarterback.Attempts.Value, 2);
                        return ValueOrLimits(passerRating, -731.6M, 1261.6M);

                    }
                default: return -1.0M;
            }
        }

        private static decimal ValueOrLimits(decimal passerRating, decimal min, decimal max)
        {
            if (passerRating < min)
            {
                return min;
            }
            else if (passerRating > max)
            {
                return max;

            }
            return passerRating;
        }
    }
}
