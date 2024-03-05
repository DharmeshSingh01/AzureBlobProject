namespace AzureBlobProject.Services
{
    public interface IContainerService
    {
        Task<List<string>> GetAllContainersAndBlobAsync();
        Task<List<string>> GetAllContainersAsync();
        Task CreateConatinerAsync(string containerName);
        Task DeleteContainerAsync(string containerName);
    }
}
