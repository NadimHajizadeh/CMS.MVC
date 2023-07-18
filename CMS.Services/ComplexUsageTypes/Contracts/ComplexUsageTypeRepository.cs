using CMS.Services.Complexs.Contract.Dto;
using CMS.Entities;


namespace CMS.Services.ComplexUsageTypes.Contracts
{
    public interface ComplexUsageTypeRepository
    {
        void Add(ComplexUsageType complexUsageType);

        //bool IsExist(int complexId, int usageTypeId);

        List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesByComplexId(int complexId);
    }
}