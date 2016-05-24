using System;
using System.Collections.Generic;
using Famoser.FrameworkEssentials.Singleton;

namespace Famoser.FrameworkEssentials.DebugTools
{
    /// <summary>
    /// Check performance of your application with this utility.
    /// Call Stop() at breakpoints, in the end invoke GetAnalytics to get you performance report
    /// </summary>
    public class TimerHelper : SingletonBase<TimerHelper>
    {
        private readonly Dictionary<Guid, Tuple<DateTime, string>> _lastEntry = new Dictionary<Guid, Tuple<DateTime, string>>();
        private readonly Dictionary<Guid, Tuple<DateTime, string>> _firstEntry = new Dictionary<Guid, Tuple<DateTime, string>>();
        private readonly Dictionary<Guid, string> _result = new Dictionary<Guid, string>();

        /// <summary>
        /// Call this at breakpoint of your application
        /// </summary>
        /// <param name="description">a small description where you are in your application</param>
        /// <param name="place">pass the class or an identifier from where you've invoked the method</param>
        /// <param name="identi">(optional) pass a guid to identify the stoppwatch you want to use.</param>
        public void Stop(string description, object place, Guid? identi = null)
        {
            var classname = place is string ? (string)place : place.GetType().Name;
            var newEntry = new Tuple<DateTime, string>(DateTime.Now, classname + ": " + description);
            var identifier = identi ?? Guid.Empty;

            if (!_lastEntry.ContainsKey(identifier))
            {
                _lastEntry.Add(identifier, newEntry);
                _result.Add(identifier, classname + ": " + description + " (" + FormatDateTime(DateTime.Now) + ")\n");
                _firstEntry.Add(identifier, newEntry);

            }
            else
            {
                _result[identifier] += classname + ": " + description + " " + FormatTimeSpan(DateTime.Now - _lastEntry[identifier].Item1) + " (" + FormatDateTime(DateTime.Now) + ")\n";
                _lastEntry[identifier] = newEntry;
            }
        }

        /// <summary>
        /// Get Analytics of your applciation. 
        /// </summary>
        public string GetAnalytics
        {
            get
            {
                var res = "";
                foreach (var s in _result)
                {
                    var key = "Key: " + s.Key + "\n";

                    if (_result.Values == null)
                        res += key + "No entries\n\n\n";
                    else
                        res += "Start: " + FormatDateTime(_firstEntry[s.Key].Item1) + "\n" +
                        "End: " + FormatDateTime(_lastEntry[s.Key].Item1) + "\n" +
                        "Duration: " + FormatTimeSpan(_lastEntry[s.Key].Item1 - _firstEntry[s.Key].Item1) + "\n" + "\n" + _result[s.Key] + "\n\n\n";
                }
                return res;
            }
        }

        private string FormatDateTime(DateTime date)
        {
            return date.ToString("hh:mm:ss.fff");
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalMinutes + "m " + timeSpan.Seconds + "s " + timeSpan.Milliseconds + "ms";
        }
    }
}

