using GameOnline.Core.ExtenstionMethods;
using My_site.Core.Extensions;
using My_site.Core.Services.AboutServices.Queries;
using My_site.Core.ViewModels.UserViewmodel;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Users;

namespace My_site.Core.Services.AboutServices.Commands;

public interface IAboutServicesCommand
{
    Task SetAbout(AboutVM model);
}

public class AboutServicesCommand : IAboutServicesCommand
{
    private readonly My_SiteContext _context;
    private readonly IAboutServicesQuery _query;

    public AboutServicesCommand(My_SiteContext context)
    {
        _context = context;
    }

    public async Task SetAbout(AboutVM model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            // آپلود عکس جدید فقط اگر فایل موجود باشد
            string newImageName = null;
            if (model.ImgFile != null)
            {
                newImageName = model.ImgFile.UploadImage(PathTools.PathImageAdmin);
            }

            if (model.AboutId != 0)
            {
                // EDIT رکورد موجود
                var aboutEntity = await _context.AboutMe.FindAsync(model.AboutId);

                if (aboutEntity == null)
                    throw new Exception("رکورد About پیدا نشد.");

                // آپدیت فیلدها
                aboutEntity.UserFullName = model.UserFullName;
                aboutEntity.AboutUser = model.AboutUser;
                aboutEntity.Skills = model.Skills;
                aboutEntity.Github = model.Github;
                aboutEntity.Instagram = model.Instagram;
                aboutEntity.Linkedin = model.Linkedin;

                // فقط وقتی عکس جدید آپلود شد، جایگزین شود
                if (!string.IsNullOrEmpty(newImageName))
                    aboutEntity.ImgName = newImageName;

                await _context.SaveChangesAsync();
                return;
            }

            // ADD رکورد جدید
            AboutMe newAbout = new AboutMe
            {
                CreationDate = DateTime.Now,
                UserFullName = model.UserFullName,
                AboutUser = model.AboutUser,
                Skills = model.Skills,
                Github = model.Github,
                Instagram = model.Instagram,
                Linkedin = model.Linkedin,
                ImgName = newImageName
            };

            await _context.AboutMe.AddAsync(newAbout);
            await _context.SaveChangesAsync();
        }
}