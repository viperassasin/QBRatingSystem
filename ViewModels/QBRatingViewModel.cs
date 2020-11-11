using QBRatingSystem.Enums;
using QBRatingSystem.Dependencies;
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
    public class QBRatingViewModel : INotifyDataErrorInfo
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

        public bool HasErrors { get; set; } = false;

        public decimal? GetPasserRating()
        {
            return _quarterback.PasserRating;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !HasErrors)
            {
                return null;
            }
            return new List<String> { "Empty", "Invalid" };
        }

        public bool BoxesAreValid()
        {
            bool empty = !PassAttemps.HasValue || !PassCompletions.HasValue || !PassYards.HasValue || !PassTouchdowns.HasValue || !PassInterceptions.HasValue;
            bool passAttemptGreaterThanCompletions = PassAttemps < PassCompletions;
            bool passAttemptsZero = PassAttemps == 0;
            bool tdsIntsAttemptsRatio = PassTouchdowns + PassInterceptions > PassAttemps;


            if (empty)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Empty Stat"));
            }
            else if (passAttemptsZero)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Pass Attempts Can't Be Zero"));
            }
            else if (passAttemptGreaterThanCompletions)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Pass Attempts Can't Be Greater Than Completions"));
            }
            else if (tdsIntsAttemptsRatio)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Touchdowns + Interceptions Can't Be Greater Than Attempts"));
            }

            return !empty && !passAttemptGreaterThanCompletions && !passAttemptsZero && !tdsIntsAttemptsRatio;
        }
    }
}
