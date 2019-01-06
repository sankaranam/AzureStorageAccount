using TableStorage;

namespace StorageAccessSamples
{
    class StorageConfiguration : IStorageConfiguration
    {
        // ideally should get the connection string from hosted website/microservice config. Hard coded here for simplicity.
        public string StorageConnectionString { get => "DefaultEndpointsProtocol=https;AccountName=sankarstorage1;AccountKey=YdCt1kTngimvzfAXGozj6aqqrvXvGyAA/TsDVgMcLIG7oJnwemG6SMWcS7XJXG7vBzocfPQm0OoGjBa4nEAb4w==;EndpointSuffix=core.windows.net"; }

        public string StudentDetailsTableName => "StudentDetails";
    }
}
