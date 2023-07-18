using CMS.Entities;
using CMS.Services.Complexs.Contract.Dto;
using CMS.Services.ComplexUsageTypes.Contracts;
using ComplexManagment.Services.ComplexUsageTypes.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistanse.EF.ComplexUsageType
{
    public class EFComplexUsageTypeRepository : ComplexUsageTypeRepository
    {
     

        private readonly DbSet<Entities.ComplexUsageType> _complexUsageType;
        private readonly DbSet<UsageType> _usageType;

        public EFComplexUsageTypeRepository(EFDataContext context)
        {
             

            _complexUsageType = context.Set<Entities.ComplexUsageType>();
            _usageType = context.Set<UsageType>();
        }


        public void Add(Entities.ComplexUsageType complexUsageType)
        {
            _complexUsageType.Add(complexUsageType);
        }

        public List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesByComplexId(
            int complexId)
        {
            return
                (from cut in _complexUsageType
                    join u in _usageType on cut.UsageTypeId equals u.Id
                    where cut.ComplexId == complexId
                    select new GetAllUsageTypesOfComplexDto
                    {
                        UsageTypeId = u.Id,
                        UsageTypeName = u.Name
                    }
                ).ToList();
        }

   
    }
}