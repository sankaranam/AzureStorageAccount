using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace TableStorage
{
    public class StudentDataStore
    {
        private readonly IStorageConfiguration _storageConfiguration;

        private CloudTable _studentTable;

        public StudentDataStore(IStorageConfiguration storageConfiguration)
        {
            _storageConfiguration = storageConfiguration;
        }

        public async Task InitializeAsync()
        {
            var storageAccount = CloudStorageAccount.Parse(_storageConfiguration.StorageConnectionString);

            var tableClient = storageAccount.CreateCloudTableClient();

            _studentTable = tableClient.GetTableReference(_storageConfiguration.StudentDetailsTableName);

            await _studentTable.CreateIfNotExistsAsync();
        }

        public async Task InsertAsync(StudentDetails data)
        {
            try
            {
                if (data == null)
                {
                    data = new StudentDetails { Id = Guid.NewGuid(), FirstName = "Shiv", LastName = "Samba", SchoolName = "DPS" };
                }
                await _studentTable.ExecuteAsync(TableOperation.Insert(data));
            }
            catch (Exception ex)
            {


            }
        }

        public async Task<StudentDetails> GetAsync(Guid id, string schoolName)
        {
            var result = await _studentTable.ExecuteAsync(TableOperation.Retrieve(schoolName, id.ToString()));

            return result.Result as StudentDetails;
        }
    }
}
