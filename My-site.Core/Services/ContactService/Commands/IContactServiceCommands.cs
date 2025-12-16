using My_site.Core.ViewModels.ContactViewModel;
using My_site.Core.ViewModels.PortfolioViewModel;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Contacts;

namespace My_site.Core.Services.ContactService.Commands;

public interface IContactServiceCommands
{
    Task AddContactAsync(ContactVM command);
}
public class ContactServiceCommands : IContactServiceCommands
{
    private readonly My_SiteContext _context;

    public ContactServiceCommands(My_SiteContext context)
    {
        _context = context;
    }

    public async Task AddContactAsync(ContactVM command)
    {
        var contact = new Contact()
        {
            CreationDate = DateTime.Now,
            Name = command.Name,
            Phone = command.Phone,
            Message = command.Message,
        };
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
    }
}