using Microsoft.EntityFrameworkCore;
using My_site.Core.ViewModels.UserViewmodel;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Users;

namespace My_site.Core.Services.UserService.Queries;

public interface IUserServiceQuery
{
    Task<User?> GetUserByPhone(string phone);
    List<UserVM> GetUsers();
}

public class UserServiceQuery : IUserServiceQuery
{
    private readonly My_SiteContext _context;
    public UserServiceQuery(My_SiteContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByPhone(string phone)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone);
        if (user == null) return null;

        return new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Email = user.Email,
            Role = user.Role,
            Password = user.Password // حتما اضافه شود
        };
    }

    public List<UserVM> GetUsers()
    {
        return _context.Users.Select(x => new UserVM
        {
            UserId = x.Id,
            Phone = x.Phone,
            Role = x.Role,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            CreationDate = x.CreationDate

        }).ToList();
    }
}