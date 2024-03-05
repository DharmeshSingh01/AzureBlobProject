
using Azure.Storage.Blobs;

namespace AzureBlobProject.Services
{
    public class ContainerService : IContainerService
    {
        private readonly BlobServiceClient _blobClient;

        public ContainerService(BlobServiceClient blobServiceClient)
        {
            _blobClient = blobServiceClient;
        }
        public Task CreateConatinerAsync(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContainerAsync(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllContainersAndBlobAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllContainersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
