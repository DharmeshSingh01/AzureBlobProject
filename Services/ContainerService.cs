
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureBlobProject.Services
{
    public class ContainerService : IContainerService
    {
        private readonly BlobServiceClient _blobClient;

        public ContainerService(BlobServiceClient blobServiceClient)
        {
            _blobClient = blobServiceClient;
        }
        public async Task CreateConatinerAsync(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
        }

        public async Task DeleteContainerAsync(string containerName)
        {
            BlobContainerClient blobContainerClient=_blobClient.GetBlobContainerClient(containerName);
            await blobContainerClient.DeleteIfExistsAsync();
        }

        public Task<List<string>> GetAllContainersAndBlobAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetAllContainersAsync()
        {
            List<String> containerName = new();
            await foreach(BlobContainerItem blobContainerItem in _blobClient.GetBlobContainersAsync())
            {
                containerName.Add(blobContainerItem.Name);
            }
            return containerName;
        }
    }
}
