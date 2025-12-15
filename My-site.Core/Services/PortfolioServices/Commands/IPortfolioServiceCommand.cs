using My_site.Core.Extensions;
using My_site.Core.ViewModels.PortfolioViewModel;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Portfolios;

namespace My_site.Core.Services.PortfolioServices.Commands;

public interface IPortfolioServiceCommand
{
    Task AddPortfolio(PortfolioVM command);
}

public class PortfolioServiceCommand : IPortfolioServiceCommand
{
    private readonly My_SiteContext _context;

    public PortfolioServiceCommand(My_SiteContext context)
    {
        _context = context;
    }
    public async Task AddPortfolio(PortfolioVM command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        if (command.ImgFile == null)
            throw new Exception("عکس نمونه کار انتخاب نشده است");

        string imageName = command.ImgFile.UploadImage(PathTools.PathImagePrAdmin);

        var portfolio = new Portfolio
        {
            CreationDate = DateTime.Now,
            ImgName = imageName,
            Name = command.PortfolioName
        };

        await _context.Portfolios.AddAsync(portfolio);
        await _context.SaveChangesAsync();
    }
}