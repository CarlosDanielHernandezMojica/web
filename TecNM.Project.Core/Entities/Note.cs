namespace TecNM.Project.Core.Entities;

public class Note: EntityBase
{
    public int idCategory { get; set; }
    public string title { get; set; }
    public string note { get; set; }
}