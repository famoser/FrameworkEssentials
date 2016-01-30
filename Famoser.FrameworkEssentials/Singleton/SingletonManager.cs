using System;
using System.Collections.Generic;

namespace Famoser.FrameworkEssentials.Singleton
{
    /// <summary>
    /// Stores singleton instances
    /// </summary>
    public class SingletonManager
    {
        public static readonly SingletonManager Instance = new SingletonManager();
        private readonly Dictionary<Type, object> _contentDictionary = new Dictionary<Type, object>();
        private readonly object _locker = new object();

        protected SingletonManager()
        {
        }

        /// <summary>
        /// Adds the specified new element.
        /// </summary>
        /// <param name="newElement">The new element.</param>
        public void Add(object newElement)
        {
            _contentDictionary.Add(newElement.GetType(), newElement);
        }

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Remove(object element)
        {
            _contentDictionary.Remove(element.GetType());
        }

        public bool Contains(Type elementType)
        {
            return _contentDictionary.ContainsKey(elementType);
        }

        public void Clear()
        {
            _contentDictionary.Clear();
        }

        public T Get<T>() where T : class, new()
        {
            lock (_locker)
            {
                if (!_contentDictionary.ContainsKey(typeof(T)))
                    Add(new T());
            }
            return (T)_contentDictionary[typeof(T)];
        }
    }
}
