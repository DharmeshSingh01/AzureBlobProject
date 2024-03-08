
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

        public async Task<List<string>> GetAllContainersAndBlobAsync()
        {
            List<string> containerAndBlob = new List<string>();
            containerAndBlob.Add("Account Name - " + _blobClient.AccountName);

            await foreach(BlobContainerItem blobContainerItem in _blobClient.GetBlobContainersAsync())
            {
                containerAndBlob.Add("**************************"+ blobContainerItem.Name + " *****************************************************");
                containerAndBlob.Add("--" + blobContainerItem.Name);
                BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(blobContainerItem.Name);

                await foreach(BlobItem blobItem in blobContainerClient.GetBlobsAsync())
                {
                    containerAndBlob.Add("--- " + blobItem.Name);
                }
                containerAndBlob.Add("*******************************************************************************");
            }
            return containerAndBlob;
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
