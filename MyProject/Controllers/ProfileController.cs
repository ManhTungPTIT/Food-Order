using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MyProject.Controllers;

[Authorize]
[Authorize(Roles = "USER")]
public class ProfileController : Controller
{
    private readonly IUserService _userService;
    private readonly IFileUploadService _fileUpload;

    public ProfileController(IUserService userService, IFileUploadService fileUpload)
    {
        _userService = userService;
        _fileUpload = fileUpload;
    }
    public async Task<IActionResult> Index(User? user)
    {
       
        
        var name = User.Identity?.Name;
        var getUser = await _userService.GetUser(name);
        ViewBag.GetUser = getUser;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadInfo(IFormFile postFiles, DateTime birthday, string address, string phone)
    {
        try
        {
            if (await _fileUpload.UploadFile(postFiles))
            {
                ViewBag.Message = "File Upload Succesfully";
                var user = new User
                {
                    UserName = User.Identity.Name,
                    Avatar = "FileAvatar/" + postFiles.FileName,
                    Birthday = birthday,
                    Address = address,
                    Phone = phone,
                };
                await _userService.UpdateInfoUser(user);
            }
            else
            {
                ViewBag.Message = "File Upload Failed";
            }
        }
        catch (Exception e)
        {
            ViewBag.Message = "file Upload Failed" + e;
        }
        return RedirectToAction("Index");
    }
}