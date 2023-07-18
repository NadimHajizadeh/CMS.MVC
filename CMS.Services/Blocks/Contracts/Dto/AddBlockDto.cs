using System.ComponentModel.DataAnnotations;

namespace ComplexManagment.Services.Blocks.Contracts.Dto
{
    public class AddBlockDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 400)]
        public int UnitCount { get; set; }

        [Required]
        public int ComplexID { get; set; }
    }
}