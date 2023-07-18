
using CMS.Services.Contracts;
using CMS.Services.UsageType.Contract;
using ComplexManagment.Services.UsageType.Contract.Dto;

namespace CMS.Services.UsageTypes;

public class UsageTypeAppService : UsageTypeService
{
     private readonly UnitOfWork _unitOfWork;
     private readonly UsageTypeRepository _usageTypeRepository;
    
    public UsageTypeAppService(UnitOfWork unitOfWork,
        UsageTypeRepository usageTypeRepository)
    {
        _unitOfWork = unitOfWork;
        _usageTypeRepository = usageTypeRepository;
    }
   


    public void Add(AddUsageTypeDto dto)
    {
        var usageType = new Entities.UsageType() 
        {
            Name = dto.Name
        };
        
        _usageTypeRepository.Add(usageType);
        _unitOfWork.Complete();
    }

    public List<GetAllUsageTypeDto> GetAll()
    {
        return
            _usageTypeRepository.GetAllUsageType();
    }
}