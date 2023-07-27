using CMS.Entities;
using CMS.Services.Blocks.Contracts;
using CMS.Services.Blocks.Contracts.Dto;
using ComplexManagment.Services.Blocks.Contracts;
using ComplexManagment.Services.Blocks.Contracts.Dto;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistanse.EF.Blocks
{
    public class EfBlockRepository : BlockRepository
    {
      
        private readonly DbSet<Block> _blocks;
        private readonly DbSet<Unit> _units;

        public EfBlockRepository(EFDataContext contex)
        {
            
            _blocks=contex.Set<Block>();
             contex.Set<Entities.ComplexUsageType>();
             _units=contex.Set<Unit>();
            
        }

        public void Add(Block block)
        {
            _blocks.Add(block);
        }

        public bool IsExist(int id)
        {
            return

            _blocks.Any(_ => _.Id == id);
        }

        public bool DuplicatedNameByComplexId(string name, int complexId)
        {
            return
                _blocks.Any(_ => _.Name == name && _.ComplexId == complexId);

        }
        public bool GetDuplicatedNameById(string name)
        {
            return _blocks.Any(_ => _.Name == name);
        }

        public int GetAllUnitCountOfBlocksByComplexId(int complexId)
        {
            return
                _blocks.Where(_ => _.ComplexId == complexId)
                .Select(_ => _.UnitCount)
                .Sum();
        }
        public List<GetblockDto> GetAllWithUnitCountDetails()
        {
            var result = _blocks.Select(_ => new GetblockDto
            {
                Name = _.Name,
                UnitCount = _.UnitCount,
                RegisterUnitCount = _.Units.Count,
                ReminaingUnitCount = _.UnitCount - _.Units.Count()
            }).ToList();
            return result;
        }

        public GetsingleBlockDto? GetById(int id)
        {
            IQueryable<GetsingleBlockDto?> result =
                 _blocks.Where(_ => _.Id == id).Select(_ => new GetsingleBlockDto
                 {
                     Name = _.Name,
                     UnitsInBlock = _.Units.Select(u => new UnitsInBlockDto
                     {
                         Name = u.Name,
                         Resedent = u.ResidenseType.ToString()
                     }).ToList()
                 });

            return result.FirstOrDefault();
            
        }
        public int GetIdByComplexId(int complexId)
        {
            return
            _blocks.Where(_ => _.ComplexId == complexId)
            .Select(_ => _.Id)
            .FirstOrDefault();
        }

        public int GetUnitCount(int id)
        {
            return
            _blocks.Where(_ => _.Id == id).Select(_ => _.UnitCount).FirstOrDefault();
        }

        public Block? FindById(int id)
        {
            return
                 _blocks.FirstOrDefault(_ => _.Id == id);
        }
        public List<Block> GetAllAndSetUnitCountsToZeroByComplexId(int id)
        {
            return _blocks.Where(_ => _.ComplexId == id)
                .ToList();
        }

        public bool UnitIsExistedByBlockId(int id)
        {
            return
                _units.Any(_ => _.BlockId == id);
        }

        public void Update(Block block)
        {
            _blocks.Update(block);
        }

        public int UsedBlockUnitByComplexId(int complexId)
        {
            return
            _blocks.Where(_ => _.ComplexId == complexId)
                  .Select(_ => _.UnitCount).Sum();
        }

        public List<GetAllByComplexIDto> GetMajid(int id)
        {
          return
                _blocks.Where(_=>_.ComplexId==id).Select(_=> new GetAllByComplexIDto
                {
                    
                    Id= _.Id,
                    Name= _.Name,
                    UnitCount= _.UnitCount,
                    RegisteredUnits = _.Units.Count(),
                }).ToList();
        }
    }
}