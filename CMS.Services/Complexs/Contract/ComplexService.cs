using CMS.Services.Complexs.Contract.Dto;

namespace CMS.Services.Complexs.Contract;

public interface ComplexService
{
    void Add(AddComplexDto dto);
    List<GetAllComplexesWithUnitCountDeataiDto> GetAllComplexesWithUnitCountDeatail();
    List<GetAllComplexWithBlockDetaisDto> GetAllComplexWithBlockDetails(string? blockName);
    List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesById(int id);
    GetOneComplexWithBlockAndUnitcountDeatilAndDto Get(int id);
    void Update(int id, NewUnitCountDto dto);
    void Delete(int id);
}