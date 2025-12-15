namespace My_site.DataBase.Entities.Users;

public class AboutMe : BaseEntity
{
    public string? ImgName { get; set; }
    public string UserFullName { get; set; }
    public string? AboutUser { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
    public string? Github { get; set; }
    public string? Skills { get; set; }
}