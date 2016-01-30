using System.Collections.Generic;

namespace Famoser.FrameworkEssentials.Logging
{
    public class LogModel
    {
        public LogLevel LogLevel { get; set; }

        public string Location { get; set; }
        public string Message { get; set; }


        public string Header
        {
            get { return "Log (Level: " + LogLevel + ")"; }
        }

        public string Body
        {
            get { return "Location: " + Location + "\nMessage: " + Message; }
        }

        public Dictionary<string, string> Values
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"LogLevel",LogLevel.ToString() },
                    {"Location",Location },
                    {"Message",Message }
                };
            }
        }
    }
}
