using System.ComponentModel.DataAnnotations;
using CMS.Entities;

namespace CMS.Services.Units.Contracts.Dto
{
    public class AddUnitDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public ResidenseType ResidenseType { get; set; }

        public int BlockId { get; set; }
    }

    
}