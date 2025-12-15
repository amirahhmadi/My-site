using Microsoft.AspNetCore.Http;

namespace My_site.Core.ViewModels.PortfolioViewModel;

public class PortfolioVM
{
    public int PortfolioId { get; set; }
    public IFormFile? ImgFile { get; set; } // فایل آپلودی
    public string? ImgName { get; set; }    // اسم فایل ذخیره‌شده
    public string? PortfolioName { get; set; }
}