namespace ComplexManagment.Services.Blocks.Contracts.Dto
{
    public class GetsingleBlockDto
    {
        public string Name { get; set; }
        public List<UnitsInBlockDto> UnitsInBlock { get; set; } = new();
    }

    public class UnitsInBlockDto
    {
        public string Name { get; set; }
        public string Resedent { get; set; }
    }
}