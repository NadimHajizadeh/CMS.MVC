namespace ComplexManagment.Services.Units.Contracts.Dto
{
    public class GetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int blockId { get; set; }
        public string BlockName { get; set; }
        public int ComplexId { get; set; }
        public string ComplexName { get; set; }
    }
}