using QBRatingSystem.Enums;
using QBRatingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.Interfaces
{
    public interface IQuarterback
    {
        //double GetPasserRating(PasserStats passerStats);

        PasserStats PasserStats { get; set; }
        LevelOfPlayer PlayerLevel { get; set; }

        void SetPasserRating();
    }
}
