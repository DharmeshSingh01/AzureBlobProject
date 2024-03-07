namespace AzureBlobProject.Services
{
    public interface IBlobService
    {
        Task<string> GetBlob(string blobName,string conainerName);
        Task<List<String>> GetAllBlobs(string conatinerName);
        Task<bool> UploadBlobAsync(string name, IFormFile file, string containerName);
        Task<bool> DeleteBlobAsync(string name, string conatainerName);
    }
}
