
namespace EventEase2.Controllers
{
    internal class BlobServiceClient
    {
        private string connectionString;

        public BlobServiceClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal BlobContainerClient GetBlobContainerClient(string containerName)
        {
            throw new NotImplementedException();
        }
    }
}