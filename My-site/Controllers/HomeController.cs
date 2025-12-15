using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using My_site.Core.Services.AboutServices.Queries;
using My_site.Core.Services.PortfolioServices.Queries;
using My_site.Models;

namespace My_site.Controllers;

public class HomeController : Controller
{
    private readonly IAboutServicesQuery _aboutQuery;
    private readonly IPortfolioServiceQuery _portfolioQuery;

    public HomeController(IAboutServicesQuery aboutQuery, IPortfolioServiceQuery portfolioQuery)
    {
        _aboutQuery = aboutQuery;
        _portfolioQuery = portfolioQuery;
    }
    public IActionResult Index()
    {
        var model = new HomeIndexVM
        {
            Abouts = _aboutQuery.GetAbout(),
            Portfolios = _portfolioQuery.GetPortfolio()
        };
        return View(model);
    }
}
