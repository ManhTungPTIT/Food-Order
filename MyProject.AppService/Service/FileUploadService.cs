using Microsoft.AspNetCore.Http;
using MyProject.AppService.IService;

namespace MyProject.AppService.Service;

public class FileUploadService : IFileUploadService
{
    private readonly IUserService _userService;

    public FileUploadService(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<bool> UploadFile(IFormFile file)
    {
        string path = string.Empty;
        try
        {
            if (file.Length > 0)
            {
                // path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "FileAvatar"));
                path = "D:/Study/LTHDT/ProjectTotNghiep/MyProject/wwwroot/FileAvatar";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var filestream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await filestream.CopyToAsync(filestream);
                    return true;
                }
            }
            
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception("File upload failed", ex);
        }
    }
}