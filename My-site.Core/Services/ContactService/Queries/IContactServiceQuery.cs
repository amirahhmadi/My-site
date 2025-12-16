using Microsoft.EntityFrameworkCore;
using My_site.Core.ViewModels.ContactViewModel;
using My_site.Core.ViewModels.PortfolioViewModel;
using My_site.DataBase.Context;

namespace My_site.Core.Services.ContactService.Queries;

public interface IContactServiceQuery
{
    List<ContactVM> GetContact();

}
public class ContactServiceQuery : IContactServiceQuery
{
    private readonly My_SiteContext _context;

    public ContactServiceQuery(My_SiteContext context)
    {
        _context = context;
    }
    public List<ContactVM> GetContact()
    {
        return _context.Contacts.Select(p => new ContactVM()
        {
            ContactId = p.Id,
            Name = p.Name,
            Phone = p.Phone,
            Message = p.Message,
            CreationDate = p.CreationDate
        }).ToList();
    }
}