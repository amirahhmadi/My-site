namespace My_site.DataBase.Entities.Users;

public class User : BaseEntity
{
    public string? Email { get; set; }
    public string Phone { get; set; }
    public string? ImgName { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? AboutUser { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
    public string? Github { get; set; }
    public string? Skills { get; set; }
    public UserRole Role { get; set; }

    // رمز عبور هش شده
    public string Password { get; set; }
}
public enum UserRole
{
    Admin = 1,
    Editor = 2,
    Writer = 3,
    Viewer = 4
}