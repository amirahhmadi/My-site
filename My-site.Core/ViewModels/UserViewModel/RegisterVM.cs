using System.ComponentModel.DataAnnotations;
using My_site.DataBase.Entities.Users;

namespace My_site.Core.ViewModels.UserViewmodel;

public class RegisterVM
{
    public int UserId { get; set; }
    public string? Email { get; set; }
    [Required(ErrorMessage = "شماره موبایل لازم است")]
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public UserRole Role { get; set; }

    [Required(ErrorMessage = "رمز عبور لازم است")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "پسوردها با هم مطابقت ندارند")]
    public string ConfirmPassword { get; set; }

    public DateTime CreationDate { get; set; }

}