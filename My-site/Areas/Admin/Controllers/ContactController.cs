using Microsoft.AspNetCore.Mvc;
using My_site.Core.Services.ContactService.Queries;

namespace My_site.Areas.Admin.Controllers
{
    public class ContactController : BaseAdminController
    {
        private readonly IContactServiceQuery _contactQuery;

        public ContactController(IContactServiceQuery contactQuery)
        {
            _contactQuery = contactQuery;
        }
        public IActionResult Index()
        {
            return View(_contactQuery.GetContact());
        }
    }
}
