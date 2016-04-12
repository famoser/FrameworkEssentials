using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IProgressService : INotifyPropertyChanged
    {
        void ConfigurePercentageProgress(int maxValue, int activeValue = 0);
        void IncrementPercentageProgress();
        void HidePercentageProgress();
        void StartIndeterminateProgress(object key);
        void StopIndeterminateProgress(object key);

        int GetMaxValueProgressBar();
        int GetActiveValueProgressBar();
        bool IsPercentageProgressActive();
        IEnumerable<object> ActiveIndeterminateProgress();
        bool IsIndeterminateProgressActive();
        bool IsAnyProgressActive();
    }
}
