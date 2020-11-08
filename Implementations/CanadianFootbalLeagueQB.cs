using QBRatingSystem.Enums;
using QBRatingSystem.Interfaces;
using QBRatingSystem.Utility;
using QBRatingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.Implementations
{
    public class CanadianFootbalLeagueQB : IQuarterback
    {
        public PasserStats PasserStats { get; set; }
        public LevelOfPlayer PlayerLevel { get; set; }

        public CanadianFootbalLeagueQB()
        {
            PasserStats = new PasserStats();
            PlayerLevel = LevelOfPlayer.CFL;
        }

        public double GetPasserRating(PasserStats passerStats)
        {
            return QBRatingCalculator.CalculatePasserRating(this);
        }

        public void SetPasserRating()
        {
            this.PasserStats.PasserRating = QBRatingCalculator.CalculatePasserRating(this);
        }
    }
}
