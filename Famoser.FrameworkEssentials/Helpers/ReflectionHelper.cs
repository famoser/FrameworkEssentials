using System;
using System.Linq.Expressions;
using System.Reflection;

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
        /// <param name="propertyOrFieldExpression">The Property or Field to retrieve the attribute from</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttribute<TA>(Expression<Func<object>> propertyOrFieldExpression) where TA : Attribute
        {
            MemberExpression memberExpression = propertyOrFieldExpression?.Body as MemberExpression;
            if (memberExpression?.Member is FieldInfo)
            {
                var fieldInfo = (FieldInfo)memberExpression.Member;
                if (fieldInfo == null)
                    return null;
                var reflectionName = fieldInfo.Name;
                var field = fieldInfo.DeclaringType.GetRuntimeField(reflectionName);
                return field?.GetCustomAttribute<TA>();
            }
            else
            {
                PropertyInfo propertyInfo = memberExpression?.Member as PropertyInfo;
                if (propertyInfo == null)
                    return null;
                var reflectionName = propertyInfo.Name;
                var property = propertyInfo.DeclaringType.GetRuntimeProperty(reflectionName);
                return property?.GetCustomAttribute<TA>();
            }
        }

        /// <summary>
        /// Get the attribute from the specified Field
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retrieve</typeparam>
        /// <param name="fieldExpression">The Field to retrieve the attribute from</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttributeOfField<TA>(Expression<Func<object>> fieldExpression) where TA : Attribute
        {
            MemberExpression memberExpression = fieldExpression?.Body as MemberExpression;
            var fieldInfo = memberExpression?.Member as FieldInfo;
            if (fieldInfo == null)
                return null;
            var reflectionName = fieldInfo.Name;
            var field = fieldInfo.DeclaringType.GetRuntimeField(reflectionName);
            return field?.GetCustomAttribute<TA>();
        }
        /// <summary>
        /// Get the attribute from the specified Property or Field
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retrieve</typeparam>
        /// <param name="propertyExpression">The Property or Field to retrieve the attribute from</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttributeOfProperty<TA>(Expression<Func<object>> propertyExpression) where TA : Attribute
        {
            MemberExpression memberExpression = propertyExpression?.Body as MemberExpression;
            PropertyInfo propertyInfo = memberExpression?.Member as PropertyInfo;
            if (propertyInfo == null)
                return null;
            var reflectionName = propertyInfo.Name;
            var property = propertyInfo.DeclaringType.GetRuntimeProperty(reflectionName);
            return property?.GetCustomAttribute<TA>();
        }

        /// <summary>
        /// Get the attribute from an enum value
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retreive</typeparam>
        /// <typeparam name="TE">The type of the enum with the passed enum value</typeparam>
        /// <param name="en">Your enum value</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttributeOfEnum<TA, TE>(TE en) where TA : Attribute
        {
            var type = typeof(TE);
            return type.GetRuntimeField(en.ToString()).GetCustomAttribute<TA>();
        }

        /// <summary>
        /// Get the attribute from the specified Method
        /// </summary>
        /// <typeparam name="TA">The type of the attribute to retrieve</typeparam>
        /// <param name="methodExpression">The Method to retrieve the attribute from</param>
        /// <returns>null or the attribute</returns>
        public static TA GetAttributeOfMethod<TA>(Expression<Action> methodExpression) where TA : Attribute
        {
            var memberExpression = methodExpression?.Body as MethodCallExpression;
            return memberExpression?.Method.GetCustomAttribute<TA>();
        }
    }
}
