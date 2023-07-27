using CMS.Entities;
using ComplexManagment.Services.Units.Contracts.Dto;

namespace CMS.Services.Units.Contracts
{
    public interface UnitRepository
    {
        bool DuplicatedNameByBlockId(string name, int blockId);

        int GetUnitsCountByBlockId(int blockId);

        void Add(Unit unit);

        List<GetAllDto> GettAllByBlockId(int blockId);

        bool UnitIsExistedByComplexId(int complexId);
    }
}