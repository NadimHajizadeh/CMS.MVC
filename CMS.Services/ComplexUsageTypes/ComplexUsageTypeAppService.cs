using CMS.Entities;
using CMS.Services.Complexs.Contract;
using CMS.Services.Complexs.Contract.Dto;
using CMS.Services.Complexs.Exeptions;
using CMS.Services.Contracts;
using CMS.Services.UsageType.Contract;
using CMS.Services.UsageTypes.Exeptions;
using ComplexManagment.Services.ComplexUsageTypes.Contracts.Dto;

namespace CMS.Services.ComplexUsageTypes.Contracts;

public class ComplexUsageTypeAppService : ComplexUsageTypeService
{
    private readonly ComplexUsageTypeRepository _repository;
    private readonly ComplexRepasitory _complexRepasitory;
    private readonly UsageTypeRepository _usageTypeRepository;
    private readonly UnitOfWork _unitOfWork;

    public ComplexUsageTypeAppService(ComplexUsageTypeRepository repository,
        ComplexRepasitory complexRepasitory,
        UsageTypeRepository usageTypeRepository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _complexRepasitory = complexRepasitory;
        _usageTypeRepository = usageTypeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesByComplexId(int complexId)
    {
        throw new NotImplementedException();
    }

    public void Add(AddComplexUsageTypeDto dto)
    {

        var isExistCompex = _complexRepasitory.IsExisted(dto.ComplexId);
        if (!isExistCompex)
        {
            throw new ComplexNotFoundException();
        }

        var isExistUsageType = _usageTypeRepository.IsExist( dto.UsageTypeId);
        if (!isExistUsageType)
        {
            throw new UsagTypeNotFoundException();
        }
        
        var complexUsageType = new ComplexUsageType()
        {
            ComplexId = dto.ComplexId,
            UsageTypeId = dto.UsageTypeId
        };
        _repository.Add(complexUsageType);
        _unitOfWork.Complete();
    }
}