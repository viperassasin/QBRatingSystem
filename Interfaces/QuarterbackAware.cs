using QBRatingSystem.Enums;
using QBRatingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.Interfaces
{
    public interface QuarterbackAware
    {
        //double GetPasserRating(PasserStats passerStats);

         int? Attempts
        {
            get;
            set;
        }

         int? Completions
        {
            get;
            set;
        }

         int? PassYards
        {
            get;
            set;
        }

         int? TouchDowns
        {
            get;
            set;
        }

         int? Interceptions
        {
            get;
            set;
        }

         double? PasserRating
        {
            get;
            set;
        }

         void SetPasserRating();
    }
}
