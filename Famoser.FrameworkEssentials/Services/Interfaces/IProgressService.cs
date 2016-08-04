using System.Collections.Generic;
using System.ComponentModel;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    /// <summary>
    /// A progress service which handles different types of progresses 
    /// </summary>
    public interface IProgressService : INotifyPropertyChanged
    {
        /// <summary>
        /// Configure you max & active progress value. This method call also sets the percentage progress to active
        /// </summary>
        /// <param name="maxValue"></param>
        /// <param name="activeValue"></param>
        void ConfigurePercentageProgress(int maxValue, int activeValue = 0);
        /// <summary>
        /// Increment the active value of the percentage progress
        /// </summary>
        void IncrementPercentageProgress();
        /// <summary>
        /// Set the active value of the percentage progress
        /// </summary>
        /// <param name="activeValue"></param>
        void SetPercentageProgress(int activeValue);
        /// <summary>
        /// Disable the percentage progress
        /// </summary>
        void HidePercentageProgress();

        /// <summary>
        /// Start an indeterminate progress with a specific key
        /// </summary>
        /// <param name="key"></param>
        void StartIndeterminateProgress(object key);
        /// <summary>
        /// Stop the indeterminate progress with the specified key
        /// </summary>
        /// <param name="key"></param>
        void StopIndeterminateProgress(object key);

        /// <summary>
        /// Return the configured max value of the percentage progress
        /// </summary>
        /// <returns></returns>
        int GetPercentageProgressMaxValue();
        /// <summary>
        /// Return the active value of the percentage progress
        /// </summary>
        /// <returns></returns>
        int GetPercentageProgressActiveValue();

        /// <summary>
        /// Get a list of all indeterminate progresses currently active
        /// </summary>
        /// <returns></returns>
        IList<object> GetActiveIndeterminateProgresses();

        /// <summary>
        /// check if the percentage progress is active
        /// </summary>
        /// <returns></returns>
        bool IsPercentageProgressActive();
        /// <summary>
        /// check if any indeterminate progress is active
        /// </summary>
        /// <returns></returns>
        bool IsIndeterminateProgressActive();
        /// <summary>
        /// check if any progress type is active
        /// </summary>
        /// <returns></returns>
        bool IsAnyProgressActive();
    }
}
