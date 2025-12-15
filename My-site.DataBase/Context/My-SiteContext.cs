using Microsoft.EntityFrameworkCore;
using My_site.DataBase.Entities.Contacts;
using My_site.DataBase.Entities.Portfolios;
using My_site.DataBase.Entities.Users;

namespace My_site.DataBase.Context;

public class My_SiteContext : DbContext
{
    public My_SiteContext(DbContextOptions<My_SiteContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<AboutMe> AboutMe { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}