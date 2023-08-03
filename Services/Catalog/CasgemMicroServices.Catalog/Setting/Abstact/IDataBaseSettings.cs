namespace CasgemMicroServices.Catalog.Setting.Abstact
{
    public interface IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
