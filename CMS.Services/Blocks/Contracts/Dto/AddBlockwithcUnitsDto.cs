using System.ComponentModel.DataAnnotations;
using CMS.Entities;

namespace CMS.Services.Blocks.Contracts.Dto
{
    public class AddBlockwithcUnitsDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 400)]
        public int UnitCount { get; set; }

        [Required]
        public int ComplexID { get; set; }

        public List<AddUnitAlongBlockDto> Units { get; set; }
    }
    public class AddUnitAlongBlockDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public ResidenseType ResidenseType { get; set; }

       
    }
}
