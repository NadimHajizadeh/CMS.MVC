using CMS.Entities;
using CMS.Services.Blocks.Contracts;
using CMS.Services.Contracts;
using CMS.Services.Units.Contracts;
using CMS.Services.Units.Contracts.Dto;
using ComplexManagment.Services.Blocks.Exeptions;
using ComplexManagment.Services.Units.Contracts;
using ComplexManagment.Services.Units.Contracts.Dto;
using ComplexManagment.Services.Units.Exeptions;

namespace ComplexManagment.Services.Units;

public class UnitAppService : UnitService
{
    //todo kolan
    private readonly UnitRepository _unitRepository;
    private readonly UnitOfWork _unitOfWork;
    private readonly BlockRepository _blockRepository;

    public UnitAppService(UnitRepository unitRepository,
        UnitOfWork unitOfWork,
        BlockRepository blockRepository
    )
    {
        _unitRepository = unitRepository;
        _unitOfWork = unitOfWork;
        _blockRepository = blockRepository;
    }

    public void Add(AddUnitDto dto)
    {
        if (!_blockRepository.IsExist(dto.BlockId))
        {
            throw new BlockNotFoundException();
        }

        if (_unitRepository.DuplicatedNameByBlockId(dto.Name, dto.BlockId))
        {
            throw new UnitAlredyExistedInThisComplexException();
        }

        var blocksUnitCount = _blockRepository.GetUnitCount(dto.BlockId);
        var unitsInBlock = _unitRepository.GetUnitsCountByBlockId(dto.BlockId);

        if (blocksUnitCount <= unitsInBlock)
        {
            throw new BlockIsFullException();
        }

        var unit = new Unit
        {
            BlockId = dto.BlockId,
            Name = dto.Name,
            ResidenseType = dto.ResidenseType,
        };

        _unitRepository.Add(unit);
        _unitOfWork.Complete();
    }

    public List<GetAllDto> GettAllByBlockId(int id)
    {
        return
            _unitRepository.GettAllByBlockId(id);
    }
}