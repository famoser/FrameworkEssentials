namespace Famoser.FrameworkEssentials.Singleton
{
    /// <summary>
    /// Represents a Singleton stored in SingletonManager
    /// inherit from this class to use the Singleton pattern for the parent
    /// </summary>
    public class SingletonBase<T>
        where T : class, new()
    {
        public static T Instance
        {
            get { return SingletonManager.Instance.Get<T>(); }
        }
    }
}
