using My_site.Core.ViewModels.ContactViewModel;
using My_site.Core.ViewModels.PortfolioViewModel;
using My_site.Core.ViewModels.UserViewmodel;

namespace My_site.Models
{
    public class HomeIndexVM
    {
        public IEnumerable<AboutVM> Abouts { get; set; }
        public IEnumerable<PortfolioVM> Portfolios { get; set; }
        public ContactVM Contact { get; set; }
    }
}
