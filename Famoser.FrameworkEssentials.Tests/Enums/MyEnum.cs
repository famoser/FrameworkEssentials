using Famoser.FrameworkEssentials.Attributes;

namespace Famoser.FrameworkEssentials.Tests.Enums
{
    public enum MyEnum
    {
        [Description("content")]
        WithAttribute,
        NoAttribute
    }
}
