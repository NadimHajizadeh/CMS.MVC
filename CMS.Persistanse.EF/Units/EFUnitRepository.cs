using CMS.Entities;
using CMS.Services.Units.Contracts;
using ComplexManagment.Services.Units.Contracts.Dto;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistanse.EF.Units
{
    public class EFUnitRepository : UnitRepository
    {
     
        private readonly DbSet<Unit> _units;


        public EFUnitRepository(EFDataContext context)
        {
            
            _units=context.Set<Unit>();
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public bool DuplicatedNameByBlockId(string name, int blockId)
        {
            return
                _units.Any(_ => _.Name == name && _.BlockId == blockId);

        }

        public List<GetAllDto> GetAll()
        {
            return
                _units.Select(_ => new GetAllDto
           {
               Id = _.Id,
               Name = _.Name,
               blockId = _.BlockId,
               BlockName = _.Block.Name,
               ComplexId = _.Block.ComplexId,
               ComplexName = _.Block.Complex.Name
           }).ToList();
        }

        public int GetUnitsCountByBlockId(int blockId)
        {
            return
                _units.Count(_ => _.BlockId == blockId);
        }

        public bool UnitIsExistedByComplexId(int complexId)
        {
            return
                _units.Any(_ => _.Block.ComplexId == complexId);
        }
    }
}