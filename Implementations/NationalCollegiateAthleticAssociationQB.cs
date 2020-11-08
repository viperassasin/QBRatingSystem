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
    public class NationalCollegiateAthleticAssociationQB : IQuarterback
    {
        public PasserStats PasserStats { get; set; }
        public LevelOfPlayer PlayerLevel { get; set; }

        public NationalCollegiateAthleticAssociationQB()
        {
            PasserStats = new PasserStats();
            PlayerLevel = LevelOfPlayer.NCAA;
        }

        public void SetPasserRating()
        {
            this.PasserStats.PasserRating = QBRatingCalculator.CalculatePasserRating(this);
        }
    }
}
