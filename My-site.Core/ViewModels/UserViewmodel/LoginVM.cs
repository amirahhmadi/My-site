using System.ComponentModel.DataAnnotations;

namespace My_site.Core.ViewModels.UserViewmodel;

public class LoginVM
{
    [Required(ErrorMessage = "شماره موبایل لازم است")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "رمز عبور لازم است")]
    public string Password { get; set; }
}