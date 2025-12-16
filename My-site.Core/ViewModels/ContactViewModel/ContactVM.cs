using System.ComponentModel.DataAnnotations;

namespace My_site.Core.ViewModels.ContactViewModel;

public class ContactVM
{
    public int ContactId { get; set; }
    [Required]
    public string Name { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime CreationDate { get; set; }
}