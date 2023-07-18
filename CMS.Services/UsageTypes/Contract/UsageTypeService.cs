

using ComplexManagment.Services.UsageType.Contract.Dto;

namespace CMS.Services.UsageType.Contract;

public interface UsageTypeService
{
    public void Add(AddUsageTypeDto dto);
    public List<GetAllUsageTypeDto> GetAll();
}