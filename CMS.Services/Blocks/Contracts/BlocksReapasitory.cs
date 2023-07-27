using CMS.Entities;
using CMS.Services.Blocks.Contracts.Dto;
using ComplexManagment.Services.Blocks.Contracts;
using ComplexManagment.Services.Blocks.Contracts.Dto;

namespace CMS.Services.Blocks.Contracts
{
    public interface BlockRepository
    {
        void Add(Block block);

        bool DuplicatedNameByComplexId(string name, int complexId);

        int UsedBlockUnitByComplexId(int complexId);

        List<GetblockDto> GetAllWithUnitCountDetails();

        bool IsExist(int id);

        int GetUnitCount(int id);

        int GetIdByComplexId(int complexId);

        GetsingleBlockDto? GetById(int id);

        Block? FindById(int id);

        bool UnitIsExistedByBlockId(int id);

        bool GetDuplicatedNameById(string name);

        void Update(Block block);

        int GetAllUnitCountOfBlocksByComplexId(int complexId);

        List<Block> GetAllAndSetUnitCountsToZeroByComplexId(int id);
        List<GetAllByComplexIDto> GetMajid(int id);
    }
}