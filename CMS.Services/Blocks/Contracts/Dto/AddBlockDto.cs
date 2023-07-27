using System.ComponentModel.DataAnnotations;

namespace ComplexManagment.Services.Blocks.Contracts.Dto
{
    public class AddBlockDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int UnitCount { get; set; }

        [Required]
        public int ComplexID { get; set; }
    }
}