namespace TableStorage
{
    public interface IStorageConfiguration
    {
        string StorageConnectionString { get; }

        string StudentDetailsTableName { get; }
    }
}
