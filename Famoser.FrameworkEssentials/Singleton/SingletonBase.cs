namespace Famoser.FrameworkEssentials.Singleton
{
    /// <summary>
    /// Represents a Singleton stored in SingletonManager
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
