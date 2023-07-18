using System.ComponentModel.DataAnnotations;

namespace CMS.Services.Complexs.Contract.Dto;

public class AddComplexDto
{
   [Required]
   [MaxLength(50)]
    public string Name { get; set; }

 
   [Required]
   [Range(1,100)]
    public int UnitCount { get; set; }
}