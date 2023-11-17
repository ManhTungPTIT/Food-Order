using Microsoft.AspNetCore.Http;

namespace MyProject.AppService.IService;

public interface IFileUploadService
{
    Task<bool> UploadFile(IFormFile file);
}