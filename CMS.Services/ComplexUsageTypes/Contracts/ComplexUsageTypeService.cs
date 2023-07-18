using CMS.Services.Complexs.Contract.Dto;
using ComplexManagment.Services.ComplexUsageTypes.Contracts.Dto;

namespace CMS.Services.ComplexUsageTypes.Contracts;

public interface ComplexUsageTypeService
{
    List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesByComplexId(int complexId);
    void Add(AddComplexUsageTypeDto dto);

}