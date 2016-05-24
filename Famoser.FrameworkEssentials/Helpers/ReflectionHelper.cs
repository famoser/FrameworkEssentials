using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Helpers
{
    /// <summary>
    /// This class helps you with some Reflection tasks
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Get the attribute from the specified Property or Field
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retrieve</typeparam>
        /// <typeparam name="TO">The type of the object with the specified Property</typeparam>
        /// <param name="propertyOrFieldExpression">The Property or Field to retrieve the attribute from</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttribute<TA, TO>(Expression<Func<object>> propertyOrFieldExpression) where TA : Attribute
        {
            var type = typeof(TO);
            MemberExpression memberExpression = propertyOrFieldExpression?.Body as MemberExpression;
            if (memberExpression?.Member is FieldInfo)
            {
                var fieldInfo = (FieldInfo) memberExpression.Member;
                if (fieldInfo == null)
                    return null;
                var reflectionName = fieldInfo.Name;
                var field = type.GetRuntimeField(reflectionName);
                return field?.GetCustomAttribute<TA>();
            }
            else
            {
                PropertyInfo propertyInfo = memberExpression?.Member as PropertyInfo;
                if (propertyInfo == null)
                    return null;
                var reflectionName = propertyInfo.Name;
                var property = type.GetRuntimeProperty(reflectionName);
                return property?.GetCustomAttribute<TA>();
            }
        }

        /// <summary>
        /// Get the attribute from an enum value
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retreive</typeparam>
        /// <typeparam name="TE">The type of the enum with the passed enum value</typeparam>
        /// <param name="en">Your enum value</param>
        /// <returns></returns>
        public static TA GetAttributeFromEnum<TA, TE>(TE en) where TA : Attribute
        {
            var type = typeof(TE);
            return type.GetRuntimeField(en.ToString()).GetCustomAttribute<TA>();
        }
    }
}
