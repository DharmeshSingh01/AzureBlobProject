
using AspNetCore;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.VisualBasic;

namespace AzureBlobProject.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public  async Task<bool> DeleteBlobAsync(string name, string conatainerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(conatainerName);
            var blobClient = blobContainerClient.GetBlobClient(name);
            return await blobClient.DeleteIfExistsAsync();


        }

        public async Task<List<string>> GetAllBlobs(string conatinerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(conatinerName);
            var blob =  blobContainerClient.GetBlobsAsync();
            
            var blobList= new List<string>();
            await foreach(var item in blob)
            {
                blobList.Add(item.Name);
            }
            return blobList;
        }

        public async Task<string> GetBlob(string blobName, string conainerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(conainerName);
            var blobClient= blobContainerClient.GetBlobClient(blobName);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadBlobAsync(string name, IFormFile file, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);
            var httpHeaders = new BlobHttpHeaders() { 
             ContentType= file.ContentType
            };
            var result=  await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if(result != null)
            {
                return true;
            }
            return false;
        }
    }
}
