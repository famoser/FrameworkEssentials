using Famoser.FrameworkEssentials.Attributes;

namespace Famoser.FrameworkEssentials.Tests.Enums
{
    internal enum MyEnum
    {
        [Description("content")]
        WithAttribute,
        NoAttribute
    }
}
