namespace MonolegalApi.Models
{
    public class MonolegalDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientesCollectionName { get; set; } = null!;
    }
}
