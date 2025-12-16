using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using My_site.Core.Services.AboutServices.Queries;
using My_site.Core.Services.ContactService.Commands;
using My_site.Core.Services.ContactService.Queries;
using My_site.Core.Services.PortfolioServices.Queries;
using My_site.Core.ViewModels.ContactViewModel;
using My_site.Models;
using Newtonsoft.Json;

namespace My_site.Controllers;

public class HomeController : Controller
{
    private readonly IAboutServicesQuery _aboutQuery;
    private readonly IPortfolioServiceQuery _portfolioQuery;
    private readonly IContactServiceCommands _contactCommands;
    private readonly IContactServiceQuery _contactqQuery;

    public HomeController(IAboutServicesQuery aboutQuery, IPortfolioServiceQuery portfolioQuery, IContactServiceCommands contactCommands, IContactServiceQuery contactqQuery)
    {
        _aboutQuery = aboutQuery;
        _portfolioQuery = portfolioQuery;
        _contactCommands = contactCommands;
        _contactqQuery = contactqQuery;
    }
    public IActionResult Index()
    {
        var model = new HomeIndexVM
        {
            Abouts = _aboutQuery.GetAbout(),
            Portfolios = _portfolioQuery.GetPortfolio(),
            Contact = new ContactVM()
        };
        return View(model);
    }

    //[HttpGet]
    //public IActionResult _ContactPartial()
    //{
    //    return View();
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> _ContactPartial(ContactVM model)
    {
        if (!ModelState.IsValid)
        {
            // اطلاعات مدل رو در TempData ذخیره می‌کنیم تا بعدا در صفحه جدید استفاده بشه
            TempData["ContactModel"] = JsonConvert.SerializeObject(model);
            return Redirect("/#contact");
        }

        await _contactCommands.AddContactAsync(model);

        TempData["Success"] = "پیام شما با موفقیت ارسال شد";
        return Redirect("/#contact");
    }
}
