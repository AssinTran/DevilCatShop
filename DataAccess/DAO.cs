namespace DataAccess
{
    public class DAO<T> where T : class, new()
    {
        private static T? _instance;
        private static readonly object _lock = new object();

        public DAO()
        {
            DB = new DevilCatContext();
        }

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ?? new T { };
                }
            }
        }

        public DevilCatContext DB { get; set; }
    }
}
