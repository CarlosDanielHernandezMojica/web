namespace TecNM.Project.Core.Entities;

public class User: EntityBase
{
    public string username { get; set; }
    public string password { get; set; }
    public string type { get; set; }
}