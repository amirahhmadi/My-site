using My_site.Core.ViewModels.UserViewmodel;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Users;

namespace My_site.Core.Services.AboutServices.Queries;

public interface IAboutServicesQuery
{
    List<AboutVM> GetAbout();
    AboutVM? GetAboutById(int aboutId);

}

public class AboutServicesQuery : IAboutServicesQuery
{
    private readonly My_SiteContext _context;

    public AboutServicesQuery(My_SiteContext context)
    {
        _context = context;
    }

    public List<AboutVM> GetAbout()
    {
        return _context.AboutMe.Select(x => new AboutVM()
        {
            AboutId = x.Id,
            UserFullName = x.UserFullName,
            AboutUser = x.AboutUser,
            Skills = x.Skills,
            Instagram = x.Instagram,
            Linkedin = x.Linkedin,
            Github = x.Github,
            ImgName = x.ImgName
        }).ToList();
    }

    public AboutVM? GetAboutById(int aboutId)
    {
        return _context.AboutMe.Where(x => x.Id == aboutId)
            .Select(x => new AboutVM()
            {
                AboutId = x.Id,
                UserFullName = x.UserFullName,
                AboutUser = x.AboutUser,
                Skills = x.Skills,
                Instagram = x.Instagram,
                Linkedin = x.Linkedin,
                Github = x.Github,
                ImgName = x.ImgName
            }).SingleOrDefault();
    }
}