using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    /// <summary>
    /// This is an implementation of the IProgressService.
    /// It also implementes the IPropertyChanged interface, so you may use the properties of this instance directly in the view
    /// </summary>
    public class ProgressService : PropertyChangedModel, IProgressService
    {
        #region percentageProgress

        private int _percentageProgressMaxValue;
        public int PercentageProgressMaxValue
        {
            get { return _percentageProgressMaxValue; }
            set { Set(ref _percentageProgressMaxValue, value); }
        }

        private int _percentageProgressActiveValue;
        public int PercentageProgressActiveValue
        {
            get { return _percentageProgressActiveValue; }
            set { Set(ref _percentageProgressActiveValue, value); }
        }

        private bool _percentageProgressActive;
        public bool PercentageProgressActive
        {
            get { return _percentageProgressActive; }
            set
            {
                if (Set(ref _percentageProgressActive, value))
                {
                    RaisePropertyChanged(() => AnyProgressActive);
                }
            }
        }

        public void ConfigurePercentageProgress(int maxValue, int activeValue = 0)
        {
            PercentageProgressMaxValue = maxValue;
            PercentageProgressActiveValue = activeValue;
            PercentageProgressActive = true;
        }

        public void IncrementPercentageProgress()
        {
            PercentageProgressActiveValue++;
        }

        public void SetPercentageProgress(int activeValue)
        {
            PercentageProgressActiveValue = activeValue;
        }

        public void HidePercentageProgress()
        {
            PercentageProgressActive = false;
        }
        #endregion

        #region indeterminateProgress
        private bool _indeterminateProgressActive;
        public bool IndeterminateProgressActive
        {
            get { return _indeterminateProgressActive; }
            set
            {
                if (Set(ref _indeterminateProgressActive, value))
                {
                    RaisePropertyChanged(() => AnyProgressActive);
                }
            }
        }

        private readonly List<object> _indeterminateProgresses = new List<object>();

        public void StartIndeterminateProgress(object key)
        {
            _indeterminateProgresses.Add(key);
            IndeterminateProgressActive = true;
        }

        public void StopIndeterminateProgress(object key)
        {
            if (_indeterminateProgresses.Contains(key))
                _indeterminateProgresses.Remove(key);
            IndeterminateProgressActive = _indeterminateProgresses.Any();
        }
        #endregion

        #region common
        public bool AnyProgressActive => PercentageProgressActive || IndeterminateProgressActive;
        #endregion

        #region methods for propertyAccess
        public int GetPercentageProgressMaxValue()
        {
            return PercentageProgressMaxValue;
        }

        public int GetPercentageProgressActiveValue()
        {
            return PercentageProgressActiveValue;
        }

        public bool IsPercentageProgressActive()
        {
            return PercentageProgressActive;
        }

        public bool IsIndeterminateProgressActive()
        {
            return IndeterminateProgressActive;
        }

        public bool IsAnyProgressActive()
        {
            return AnyProgressActive;
        }

        public IList<object> GetActiveIndeterminateProgresses()
        {
            return _indeterminateProgresses;
        }
        #endregion
    }
}
