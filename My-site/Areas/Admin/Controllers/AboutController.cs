using Microsoft.AspNetCore.Mvc;
using My_site.Core.Services.AboutServices.Commands;
using My_site.Core.Services.AboutServices.Queries;
using My_site.Core.ViewModels.UserViewmodel;

namespace My_site.Areas.Admin.Controllers
{
    public class AboutController : BaseAdminController
    {
        private readonly IAboutServicesQuery _query;
        private readonly IAboutServicesCommand _command;

        public AboutController(IAboutServicesQuery query, IAboutServicesCommand command)
        {
            _query = query;
            _command = command;
        }

        public IActionResult Index()
        {
            var model = _query.GetAbout();
            return View(model);
        }

        // GET: AddOrEdit
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new AboutVM());

            var about = _query.GetAboutById(id);

            if (about == null) return NotFound();

            return View(new AboutVM
            {
                AboutId = about.AboutId,
                UserFullName = about.UserFullName,
                AboutUser = about.AboutUser,
                Skills = about.Skills,
                Github = about.Github,
                Instagram = about.Instagram,
                Linkedin = about.Linkedin,
                ImgName = about.ImgName
            });
        }

        // POST: AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(AboutVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _command.SetAbout(model);

            return RedirectToAction("Index");
        }
    }
}