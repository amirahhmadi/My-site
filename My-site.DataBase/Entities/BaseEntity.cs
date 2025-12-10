using System.ComponentModel.DataAnnotations;

namespace My_site.DataBase.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime? RemoveDate { get; set; }
    public bool IsRemove { get; set; }
}