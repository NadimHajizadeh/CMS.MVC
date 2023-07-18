using CMS.Services.Units.Contracts.Dto;
using ComplexManagment.Services.Units.Contracts.Dto;

namespace ComplexManagment.Services.Units.Contracts;

public interface UnitService
{
    public void Add(AddUnitDto dto);
    public List<GetAllDto> GettAll();//todo
}