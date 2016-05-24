using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models.RestService
{
    /// <summary>
    /// Specifiy all informations need for the RestService to upload this file
    /// </summary>
    public class RestFile
    {
        /// <summary>
        /// The content of this file
        /// </summary>
        public byte[] Content { get; set; }
        /// <summary>
        /// The filename of the file. (php: $_SERVER["FILES"]["ContentName"]["FileName])
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// The POST or PUT value of this file. (php: $_SERVER["FILES"]["ContentName"]["FileName])
        /// </summary>
        public string ContentName { get; set; }
    }
}
