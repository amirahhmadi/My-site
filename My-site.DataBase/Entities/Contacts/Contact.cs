namespace My_site.DataBase.Entities.Contacts;

public class Contact : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
}