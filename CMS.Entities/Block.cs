namespace CMS.Entities;

public class Block
{
    public Block()
    {
        Units = new();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int UnitCount { get; set; }
    public int ComplexId { get; set; }
    
    public Complex Complex { get; set; } = null!;
    public HashSet<Unit> Units { get; set; }
}