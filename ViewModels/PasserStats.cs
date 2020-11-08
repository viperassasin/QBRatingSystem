using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.ViewModels
{
    public class PasserStats
    {
        public int Attempts
        {
            get;
            set;
        }

        public int Completions
        {
            get;
            set;
        }

        public int PassYards
        {
            get;
            set;
        }

        public int TouchDowns
        {
            get;
            set;
        }

        public int Interceptions
        {
            get;
            set;
        }

        public double PasserRating
        {
            get;
            set;
        }
    }
}
