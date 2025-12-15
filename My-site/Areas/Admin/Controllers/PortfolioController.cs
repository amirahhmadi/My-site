using Microsoft.AspNetCore.Mvc;
using My_site.Core.Services.PortfolioServices.Commands;
using My_site.Core.Services.PortfolioServices.Queries;
using My_site.Core.ViewModels.PortfolioViewModel;

namespace My_site.Areas.Admin.Controllers
{
    public class PortfolioController : BaseAdminController
    {
        private readonly IPortfolioServiceCommand _command;
        private readonly IPortfolioServiceQuery _query;

        public PortfolioController(
            IPortfolioServiceCommand command,
            IPortfolioServiceQuery query)
        {
            _command = command;
            _query = query;
        }

        public IActionResult Index()
        {
            return View(_query.GetPortfolio());
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPortfolio(PortfolioVM portfolioVm)
        {
            if (!ModelState.IsValid)
                return View(portfolioVm);

            await _command.AddPortfolio(portfolioVm);

            return RedirectToAction(nameof(Index));
        }
    }
}