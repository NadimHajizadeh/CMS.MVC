using CMS.Entities;
using CMS.Services.Blocks.Contracts;
using CMS.Services.Complexs.Contract;
using CMS.Services.Complexs.Contract.Dto;
using CMS.Services.Complexs.Exeptions;
using CMS.Services.ComplexUsageTypes.Contracts;
using CMS.Services.Contracts;
using CMS.Services.Units.Contracts;

namespace CMS.Services.Complexs;

public class ComplexAppService : ComplexService
{
    private readonly ComplexRepasitory _repasitory;
    private readonly UnitOfWork _unitOfWork;
    private readonly ComplexUsageTypeRepository _complexUsageTypeRepository;
    private readonly UnitRepository _unitRepository;
    private readonly BlockRepository _blockRepository;

    public ComplexAppService(ComplexRepasitory repasitory,UnitOfWork unitOfWork,
    ComplexUsageTypeRepository complexUsageTypeRepository,
    UnitRepository unitRepository,
    BlockRepository blockRepository)
    {
        _repasitory = repasitory;
        _unitOfWork = unitOfWork;
        _complexUsageTypeRepository = complexUsageTypeRepository;
        _unitRepository = unitRepository;
        _blockRepository = blockRepository;
    }
    public void Add(AddComplexDto dto)
    {
        var complex = new Complex()
        {
            Name = dto.Name,
            UnitCount = dto.UnitCount

        };
        
        _repasitory.Add(complex);
        _unitOfWork.Complete();
        
    }

    public List<GetAllComplexesWithUnitCountDeataiDto> GetAllComplexesWithUnitCountDeatail()
    {
        return
            _repasitory.GetAllComplexesWithUnitCountDeatail();
    }

    public List<GetAllComplexWithBlockDetaisDto> GetAllComplexWithBlockDetails(string? blockName)
    {
        return
            _repasitory.GetAllComplexWithBlockDetails(blockName);
    }

    public List<GetAllUsageTypesOfComplexDto> GetAllUsageTypesById(int id)
    {
        return 
            _complexUsageTypeRepository.GetAllUsageTypesByComplexId(id);
    }

    public GetOneComplexWithBlockAndUnitcountDeatilAndDto Get(int id)
    {
        return 
            _repasitory.getOne(id);
    }

    public void Update(int id, NewUnitCountDto dto)
    {
        var complex = _repasitory.FindById(id);
        StopIfComplexNotFound(complex);
        
        var UnitIsExisted = _unitRepository.UnitIsExistedByComplexId(id);
        
        if (UnitIsExisted)
        {
            throw new ComplexHasUnitsException();
        }
        
        if (dto.UnitCount < complex!.UnitCount)
        {
            var blocks = _blockRepository
                .GetAllAndSetUnitCountsToZeroByComplexId(id);
            foreach (var block in blocks)
            {
                block.UnitCount = 0;
            }
        }
        
        complex.UnitCount = dto.UnitCount;
        _repasitory.Update(complex);
        _unitOfWork.Complete();
    }
    
    public void Delete(int id)
    {
        var complex = _repasitory.FindById(id);
        StopIfComplexNotFound(complex);
        
        _repasitory.Delete(complex!);
        _unitOfWork.Complete();
    }
    
    private static void StopIfComplexNotFound(Complex? complex)
    {
        if (complex is null)
        {
            throw new ComplexNotFoundException();
        }
    }

}