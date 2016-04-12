using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Famoser.FrameworkEssentials.Models
{
    public class PropertyChangedModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Assigns a new value to the property. Then, raises the
        ///             PropertyChanged event if needed, and broadcasts a
        ///             PropertyChangedMessage using the Messenger instance (or the
        ///             static default instance if no Messenger instance is available).
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam><param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The property's value after the change</param>
        /// <param name="propertyName">(optional) The name of the property that changed.</param>
        /// <returns>
        /// True if the PropertyChanged event was raised, false otherwise.
        /// </returns>
        protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;
            T oldValue = field;
            field = newValue;
            this.RaisePropertyChanged<T>(propertyName, oldValue, field);
            return true;
        }


        /// <summary>
        /// Raises the PropertyChanged event if needed, and broadcasts a
        ///             PropertyChangedMessage using the Messenger instance (or the
        ///             static default instance if no Messenger instance is available).
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the property that
        ///             changed.</typeparam><param name="propertyName">An expression identifying the property
        ///             that changed.</param><param name="oldValue">The property's value before the change
        ///             occurred.</param><param name="newValue">The property's value after the change</param>
        protected virtual void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, T oldValue, T newValue, bool broadcast)
        {
            string propertyName = GetPropertyName<T>(propertyExpression);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        /// <summary>
        /// Extracts the name of a property from an expression.
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam><param name="propertyExpression">An expression returning the property's name.</param>
        /// <returns>
        /// The name of the property returned by the expression.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">If the expression is null.</exception><exception cref="T:System.ArgumentException">If the expression does not represent a property.</exception>
        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");
            MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Invalid argument", "propertyExpression");
            PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("Argument is not a property", "propertyExpression");
            return propertyInfo.Name;
        }
    }
}
