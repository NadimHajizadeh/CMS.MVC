using CMS.Entities;

namespace ComplexManagment.Services.Units.Contracts.Dto
{
    public class GetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ResidenseType residenseType { get; set; }
    }
}