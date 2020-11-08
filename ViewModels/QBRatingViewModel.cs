using QBRatingSystem.Enums;
using QBRatingSystem.Implementations;
using QBRatingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.ViewModels
{
    public class QBRatingViewModel
    {

        public IQuarterback Quarterback { get; set; }

        public LevelOfPlayer LevelOfPlayer
        {
            get; set;
        }

        public void SetQuarterBack(IQuarterback quarterback)
        {
            this.Quarterback = quarterback;
        }

    }
}
