using AzureBlobProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobProject.Controllers
{
    public class BlobController : Controller
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string containerName)
        {
            var blobObj = await _blobService.GetAllBlobs(containerName);

            return View(blobObj);
        }
        public async Task<IActionResult> AddFile(string containerName)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(string containerName,IFormFile file)
        {
            if (file == null || file.Length < 1)
                return View();

            var fileName=Path.GetFileNameWithoutExtension(file.FileName)+"_"+ Guid.NewGuid()+ Path.GetExtension(file.FileName);
           var a= await _blobService.UploadBlobAsync(fileName, file,containerName);
            return RedirectToAction(nameof(Manage));
        }
    }

}
