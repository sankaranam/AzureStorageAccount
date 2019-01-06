using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace TableStorage
{
    public class StudentDetails : ITableEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SchoolName { get; set; }
        public string PartitionKey { get => SchoolName; set => SchoolName = value; }
        public string RowKey { get => Id.ToString(); set => Id = Guid.Parse(value); }
        public DateTimeOffset Timestamp { get => DateTimeOffset.Now; set => Timestamp = value; }

        public string ETag { get => null; set => ETag = value; }

        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            StudentDetails customEntity = TableEntity.ConvertBack<StudentDetails>(properties, operationContext);
            // Do the memberwise clone for this object from the returned CustomEntity object
            CloneThisObject(this, customEntity);
        }

        private void CloneThisObject(StudentDetails studentDetails, StudentDetails customEntity)
        {
            studentDetails = customEntity.MemberwiseClone() as StudentDetails;
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            IDictionary<string, EntityProperty> flattenedProperties = TableEntity.Flatten(this, operationContext);
            flattenedProperties.Remove("Timestamp");
            flattenedProperties.Remove("ETag");
            return flattenedProperties;
        }
    }
}
