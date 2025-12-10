using Microsoft.AspNetCore.Mvc;

namespace My_site.Areas.Admin.Controllers
{
    public class DashboardController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
