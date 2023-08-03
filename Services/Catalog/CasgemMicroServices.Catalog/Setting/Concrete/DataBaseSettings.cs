using CasgemMicroServices.Catalog.Setting.Abstact;

namespace CasgemMicroServices.Catalog.Setting.Concrete
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
