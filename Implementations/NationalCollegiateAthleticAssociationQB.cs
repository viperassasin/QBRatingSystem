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
    public class NationalCollegiateAthleticAssociationQB : QuarterbackAware
    {
        public int? Attempts {get; set; }
        public int? Completions {get; set; }
        public int? PassYards {get; set; }
        public int? TouchDowns {get; set; }
        public int? Interceptions {get; set; }
        public double? PasserRating {get; set; }

        public void SetPasserRating()
        {
            PasserRating=QBRatingCalculator.CalculatePasserRating(this);
        }
    }
}
