namespace TecNM.Project.Core.Entities;

public class TestGrade: EntityBase
{
    public int idTest { get; set; }
    public int idUser { get; set; }
    public decimal grade { get; set; }
}