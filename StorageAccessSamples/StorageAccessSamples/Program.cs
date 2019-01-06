using System;
using TableStorage;

namespace StorageAccessSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Storage access samples");

            var studentStore = new StudentDataStore(new StorageConfiguration());

            studentStore.InitializeAsync().Wait();

            var data = new StudentDetails { Id = Guid.NewGuid(), FirstName = "Shiv", LastName = "Samba", SchoolName = "DPS" };
            studentStore.InsertAsync(data).Wait();

            var result = studentStore.GetAsync(data.Id, data.SchoolName).Result;
        }
    }
}
