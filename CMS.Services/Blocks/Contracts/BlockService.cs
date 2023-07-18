using CMS.Services.Blocks.Contracts.Dto;
using ComplexManagment.Services.Blocks.Contracts.Dto;

namespace ComplexManagment.Services.Blocks.Contracts;

public interface BlockService
{
    void Add(AddBlockDto dto);
    List<GetblockDto> GetAllWithUnitCountDetails();
    GetsingleBlockDto? GetById(int id);
    
    void UpdateById(int id ,UpdateBlockDto dto);
    public void AddWithUnits(AddBlockwithcUnitsDto dto );
}