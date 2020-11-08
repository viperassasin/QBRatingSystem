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
        private QuarterbackAware _quarterback;

        public LevelOfPlayer LevelOfPlayer
        {
            get; set;
        }

        public QBRatingViewModel(QuarterbackAware quarterback)
        {
            this._quarterback = quarterback;
        }

    }
}
