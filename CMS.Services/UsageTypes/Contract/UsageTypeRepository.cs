

using ComplexManagment.Services.UsageType.Contract.Dto;

namespace CMS.Services.UsageType.Contract
{
    public interface UsageTypeRepository
    {
        void Add(Entities.UsageType usageType);

        List<GetAllUsageTypeDto> GetAllUsageType();

        bool IsExist(int id);
     
    }
}