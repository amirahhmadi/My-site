using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using My_site.DataBase.Context;
using My_site.DataBase.Entities.Users;

namespace My_site.Core.Services.UserService.Commands;

public interface IUserServiceCommand
{
    Task<bool> CreateUserAsync(User user);
}

public class UserServiceCommand : IUserServiceCommand
{
    private readonly My_SiteContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserServiceCommand(My_SiteContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        user.Role = UserRole.Admin; // نقش پیش‌فرض

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }
}