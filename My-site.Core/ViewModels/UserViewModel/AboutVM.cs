using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace My_site.Core.ViewModels.UserViewmodel;

public class AboutVM
{
    public int AboutId { get; set; }
    public IFormFile? ImgFile { get; set; } // فایل آپلودی
    public string? ImgName { get; set; }    // اسم فایل ذخیره‌شده
    public string? UserFullName { get; set; }
    public string? AboutUser { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
    public string? Github { get; set; }
    public string? Skills { get; set; }
}