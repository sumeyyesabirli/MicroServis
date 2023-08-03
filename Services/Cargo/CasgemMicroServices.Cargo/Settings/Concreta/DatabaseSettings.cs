using CasgemMicroServices.Cargo.Settings.Abstract;

namespace CasgemMicroServices.Cargo.Settings.Concreta
{
    public class DatabaseSettings: IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
