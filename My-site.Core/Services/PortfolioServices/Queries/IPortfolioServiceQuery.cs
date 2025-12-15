using My_site.Core.ViewModels.PortfolioViewModel;
using My_site.DataBase.Context;

namespace My_site.Core.Services.PortfolioServices.Queries;

public interface IPortfolioServiceQuery
{
    List<PortfolioVM> GetPortfolio();

}

public class PortfolioServiceQuery : IPortfolioServiceQuery
{
    private readonly My_SiteContext _context;

    public PortfolioServiceQuery(My_SiteContext context)
    {
        _context = context;
    }
    public List<PortfolioVM> GetPortfolio()
    {
        return _context.Portfolios.Select(p => new PortfolioVM()
        {
            PortfolioId = p.Id,
            PortfolioName = p.Name,
            ImgName = p.ImgName
        }).ToList();
    }
}