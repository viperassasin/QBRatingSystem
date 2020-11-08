
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
    public class NationalFootballLeagueQB : IQuarterback
    {
        public PasserStats PasserStats { get; set; }
        public LevelOfPlayer PlayerLevel { get; set; }
        public NationalFootballLeagueQB()
        {
            PasserStats = new PasserStats();
            PlayerLevel = LevelOfPlayer.NFL;
        }

        public void SetPasserRating()
        {
            this.PasserStats.PasserRating = QBRatingCalculator.CalculatePasserRating(this);
        }
    }
}
