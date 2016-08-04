using System;

namespace Famoser.FrameworkEssentials.Attributes
{
    /// <summary>
    /// use this attribute to decribe a field or any other element in your application
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; }
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
