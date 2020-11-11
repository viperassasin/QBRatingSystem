using QBRatingSystem.Enums;
using QBRatingSystem.Implementations;
using QBRatingSystem.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRatingSystem.ViewModels
{
    public class QBRatingViewModel:INotifyDataErrorInfo
    {
        private IQuaterback _quarterback;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void SetQuarterBack(IQuaterback quarterback)
        {
            this._quarterback = quarterback;
        }

        public QBRatingViewModel(IQuaterback quaterback)
        {
            this._quarterback = quaterback;
        }

        public int? PassAttemps
        {
            get { return _quarterback.Attempts; }
            set { _quarterback.Attempts = value; }
        }

        public int? PassCompletions
        {
            get { return _quarterback.Completions; }
            set { _quarterback.Completions = value; }
        }

        public int? PassInterceptions
        {
            get { return _quarterback.Interceptions; }
            set { _quarterback.Interceptions = value; }
        }

        public int? PassYards
        {
            get { return _quarterback.PassYards; }
            set { _quarterback.PassYards = value; }
        }

        public int? PassTouchdowns
        {
            get { return _quarterback.TouchDowns; }
            set { _quarterback.TouchDowns = value; }
        }

        public bool HasErrors { get; set; }=false;

        public decimal? GetPasserRating()
        {
            return _quarterback.PasserRating;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)||!HasErrors)
            {
                return null;
            }
            return new List<String> { "Empty","Invalid" };
        }

        public bool NoEmptyStats()
        {
            HasErrors = !PassAttemps.HasValue || !PassCompletions.HasValue || !PassYards.HasValue || !PassTouchdowns.HasValue || !PassInterceptions.HasValue;

            if (HasErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Empty Stat"));
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
