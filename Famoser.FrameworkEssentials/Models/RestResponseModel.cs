using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models
{
    public class RestResponseModel
    {
        public bool IsRequestSuccessfull
        {
            get { return ErrorMessage == null; }
        }

        public string ErrorMessage { get; set; }

        public byte[] Response { get; set; }
    }
}
