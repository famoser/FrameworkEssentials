using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Annotations;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    public class ProgressService : IProgressService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region percentageProgress

        private int _percentageProgressMaxValue;

        private void SetPercentageProgressMaxValue(int newValue)
        {
            _percentageProgressMaxValue = newValue;
            //todo
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IncrementPercentageProgress"));
        }
        private int _percentageProgressActiveValue;
        public void ConfigurePercentageProgress(int maxValue, int activeValue = 0)
        {
            SetPercentageProgressMaxValue(maxValue);
            _percentageProgressActiveValue = activeValue;
        }

        public void IncrementPercentageProgress()
        {
            ++_percentageProgressActiveValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IncrementPercentageProgress"));
        }

        public void HidePercentageProgress()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void StartIndeterminateProgress(object key)
        {
            throw new NotImplementedException();
        }

        public void StopIndeterminateProgress(object key)
        {
            throw new NotImplementedException();
        }

        public int GetMaxValueProgressBar()
        {
            throw new NotImplementedException();
        }

        public int GetActiveValueProgressBar()
        {
            throw new NotImplementedException();
        }

        public bool IsPercentageProgressActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ActiveIndeterminateProgress()
        {
            throw new NotImplementedException();
        }

        public bool IsIndeterminateProgressActive()
        {
            throw new NotImplementedException();
        }

        public bool IsAnyProgressActive()
        {
            throw new NotImplementedException();
        }
    }
}
