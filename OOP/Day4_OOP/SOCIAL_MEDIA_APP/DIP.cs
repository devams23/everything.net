
// File created on 2026-02-1

/* Dependency Inversion Principle (DIP)----------------------------
    Depend on abstractions, not on concrete classes. The FeedManager (High-level) 
    shouldn't depend on a specific database (Low-level). It depends on an interface.
 */
namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    public interface IDataStore
    {
        void SaveData(string data);
    }

    public class SqlDatabase : IDataStore
    {
        public void SaveData(string data)
        {
            Console.WriteLine($"Saving '{data}' to SQL Server.");
        }
    }

    public class MongoDbDatabase : IDataStore
    {
        public void SaveData(string data)
        {
            Console.WriteLine($"Saving '{data}' to MongoDB.");
        }
    }
    public class FeedManager
    {
        private readonly IDataStore _database;

        // We inject the interface, not the concrete SqlDatabase class
        public FeedManager(IDataStore database)
        {
            _database = database;
        }

        public void Publish(string content)
        {
            _database.SaveData(content);
            Console.WriteLine("Post published to feed.");
        }
    }
}

