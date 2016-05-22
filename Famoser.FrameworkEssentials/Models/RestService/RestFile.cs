using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models.RestService
{
    public class RestFile
    {
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public string ContentName { get; set; }
    }
}
