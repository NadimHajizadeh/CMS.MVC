namespace ComplexManagment.Services.Blocks.Contracts;

public class GetAllByComplexIDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public  int UnitCount  { get; set; }
    public int RegisteredUnits { get; set; }
}