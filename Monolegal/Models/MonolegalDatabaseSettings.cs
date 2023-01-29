namespace Monolegal.Models
{
    public class MonolegalDatabaseSettings : IMonolegalDatabaseSettings
    {
        public string Server { get; set; } 

        public string Database { get; set; } 

        public string Collection { get; set; } 
    }

    public interface IMonolegalDatabaseSettings
    {
        string Server { get; set; }

        string Database { get; set; }

        string Collection { get; set; }
    }
}
