
using CMS.Entities;
using CMS.Services.UsageType.Contract;
using ComplexManagment.Services.UsageType.Contract.Dto;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistanse.EF.UsageTypes
{
    public class EFUsageTypeRepository : UsageTypeRepository
    {
       
        private readonly DbSet<UsageType> _usageType;

        public EFUsageTypeRepository(EFDataContext context)
        {
            
            _usageType = context.Set<UsageType>();
        }


        public void Add(UsageType usageType)
        {
            _usageType.Add(usageType);
        }

        public List<GetAllUsageTypeDto> GetAllUsageType()
        {
            return
                _usageType.Select(_ => new GetAllUsageTypeDto
                {
                    Id = _.Id,
                    Name = _.Name
                }).ToList();

        }

        public bool IsExist(int id)
        {
            return 
            _usageType.Any(_ => _.Id == id);
        }
    }
}