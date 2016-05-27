using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Attributes;
using Famoser.FrameworkEssentials.Tests.Enums;

namespace Famoser.FrameworkEssentials.Tests.Models
{
    public class MyModel
    {
        [Description("content")]
        public string WithAttribute { get; set; }
        public string NoAttribute { get; set; }

        [Description("content")]
        public string FieldWithAttribute;
        public string FieldNoAttribute;

        [Description("content")]
        public void MethodWithAttribute() { }
        public void MethodNoAttribute() { }

        public MyEnum EnumProperty { get; set; }
    }
}
