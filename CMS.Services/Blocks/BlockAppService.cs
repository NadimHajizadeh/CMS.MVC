using CMS.Entities;
using CMS.Services.Blocks.Contracts;
using CMS.Services.Blocks.Contracts.Dto;
using CMS.Services.Complexs.Contract;
using CMS.Services.Complexs.Exeptions;
using CMS.Services.Contracts;
using ComplexManagment.Services.Blocks.Contracts;
using ComplexManagment.Services.Blocks.Contracts.Dto;
using ComplexManagment.Services.Blocks.Exeptions;

namespace CMS.Services.Blocks;

public class BlockAppService : BlockService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BlockRepository _blockRepository;
    private readonly ComplexRepasitory _complexRepasitory;

    public BlockAppService(UnitOfWork unitOfWork,
        BlockRepository blockRepository,
        ComplexRepasitory complexRepasitory)
    {
        _unitOfWork = unitOfWork;
        _blockRepository = blockRepository;
        _complexRepasitory = complexRepasitory;
    }

    public void Add(AddBlockDto dto)
    {
        AddValidations(dto);

        var usedBlockUnittIncomplex = _blockRepository
            .UsedBlockUnitByComplexId(dto.ComplexID);
        var complexUnitCount = _complexRepasitory
            .GetUnitCount(dto.ComplexID);
        if (dto.UnitCount > complexUnitCount)
        {
            throw new ToMuchBlockCountException();
        }

        var letfUnit = complexUnitCount - usedBlockUnittIncomplex;
        if (dto.UnitCount > letfUnit)
        {
            throw new ComplexISFullException();
        }

        var block = new Block
        {
            Name = dto.Name,
            ComplexId = dto.ComplexID,
            UnitCount = dto.UnitCount,
        };

        _blockRepository.Add(block);
        _unitOfWork.Complete();
    }


    public List<GetblockDto> GetAllWithUnitCountDetails()
    {
        return
            _blockRepository.GetAllWithUnitCountDetails();
    }

    public GetsingleBlockDto? GetById(int id)
    {
        return
            _blockRepository.GetById(id);
    }

    public void UpdateById(int id, UpdateBlockDto dto)
    {
        var block = _blockRepository.FindById(id);
        if (block is null)
        {
            throw new BlockNotFoundException();
        }

        var unitIsExisted = _blockRepository
            .UnitIsExistedByBlockId(block.Id);

        if (unitIsExisted)
        {
            throw new blockHasUnitsExeption();
        }

        var isDuplicatedName = _blockRepository
            .GetDuplicatedNameById(dto.Name);
        if (isDuplicatedName)
        {
            throw new BlockDuplicatedNameException();
        }

        block.UnitCount = dto.UnitCount;
        block.Name = dto.Name;
        _blockRepository.Update(block);
        _unitOfWork.Complete();
    }

    public void AddWithUnits(AddBlockwithcUnitsDto dto)
    {
        AddWithUnitValidation(dto);

        var usedBlockUnitInComplex = _blockRepository
            .UsedBlockUnitByComplexId(dto.ComplexID);

        var complexUnitCount = _complexRepasitory
            .GetUnitCount(dto.ComplexID);

        if (dto.UnitCount > complexUnitCount)
        {
            throw new ToMuchBlockCountException();
        }

        var leftUnits = complexUnitCount - usedBlockUnitInComplex;

        if (dto.UnitCount > leftUnits)
        {
            throw new ComplexISFullException();
        }


        var block = new Block
        {
            Name = dto.Name,
            ComplexId = dto.ComplexID,
            UnitCount = dto.UnitCount,
        };

        var unitsToAdd = AddUnitsToBlock(dto.Units, block);

        block.Units = unitsToAdd;
        _blockRepository.Add(block);
        _unitOfWork.Complete();
    }


    private static HashSet<Unit> AddUnitsToBlock(List<AddUnitAlongBlockDto> units,
        Block block)
    {
        var unitsToAdd = new HashSet<Unit>();

        foreach (var unit in units)
        {
            unitsToAdd.Add(new Unit
            {
                Name = unit.Name,
                ResidenseType = unit.ResidenseType,
                Block = block
            });
        }

        return unitsToAdd;
    }

    private void AddWithUnitValidation(AddBlockwithcUnitsDto dto)
    {
        if (dto.UnitCount < dto.Units.Count)
        {
            throw new InvalidUnitCountToCreateException();
        }

        if (!_complexRepasitory.IsExisted(dto.ComplexID))
        {
            throw new ComplexNotFoundException();
        }

        if (_blockRepository.DuplicatedNameByComplexId(dto.Name,
                dto.ComplexID))
        {
            throw new BlockAlredyExistedInThisComplexException();
        }
    }

    private void AddValidations(AddBlockDto dto)
    {
        if (!_complexRepasitory.IsExisted(dto.ComplexID))
        {
            throw new ComplexNotFoundException();
        }

        if (_blockRepository.DuplicatedNameByComplexId(dto.Name,
                dto.ComplexID))
        {
            throw new BlockAlredyExistedInThisComplexException();
        }
    }

    public List<GetAllByComplexIDto> GetAll(int id)
    {
        return
             _blockRepository.GetMajid(id);
    }
}