using CMS.Entities;
using CMS.Services.Complexs.Contract;
using CMS.Services.Complexs.Contract.Dto;
using Microsoft.EntityFrameworkCore;

namespace CMS.Persistanse.EF.Complexs;

public class EFComplexRepasitory : ComplexRepasitory
{
    private readonly DbSet<Complex> _complexes;

    public EFComplexRepasitory(EFDataContext context)
    {
        _complexes = context.Set<Complex>();
    }

    public void Add(Complex complex)
    {
        _complexes.Add(complex);
    }

    public List<GetAllComplexesWithUnitCountDeataiDto>
        GetAllComplexesWithUnitCountDeatail()
    {
        return
            _complexes.Select(c =>
                new GetAllComplexesWithUnitCountDeataiDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    RegisterdUnitCount = c.Blocks.SelectMany(_ => _.Units).Count(),
                    LeftUnitCount = c.UnitCount -
                                    c.Blocks.SelectMany(_ => _.Units).Count(),
                }).ToList();
    }

    public List<GetAllComplexWithBlockDetaisDto> GetAllComplexWithBlockDetails(
        string? name)
    {
        var result = _complexes.Select(_ => new GetAllComplexWithBlockDetaisDto
        {
            Name = _.Name,
            Block = _.Blocks.Select(b => new ComplexBlockDto
            {
                BlockName = b.Name,
                BlockUnitCount = b.UnitCount,
                RemainingUnitCount = b.UnitCount - b.Units.Count()
            }).ToList()
        });

        if (name != null)
        {
            result = result.Where(_ =>
                _.Block.Any(_ => _.BlockName == name));
        }

        return result.ToList();
    }

    public bool IsExisted(int id)
    {
        return
            _complexes.Any(_ => _.Id == id);
    }

    public GetOneComplexWithBlockAndUnitcountDeatilAndDto getOne(int id)
    {
        return
            _complexes
                .Where(_ => _.Id == id)
                .Select(_ => new
                    GetOneComplexWithBlockAndUnitcountDeatilAndDto()
                    {
                        Id = _.Id,
                        Name = _.Name,
                        RegisterdUnitCount =
                            _.Blocks.SelectMany(_ => _.Units).Count(),
                        LeftUnitCount = _.UnitCount -
                                        _.Blocks.SelectMany(_ => _.Units).Count(),
                        BlockCount = _.Blocks.Count()
                    })
                .FirstOrDefault();
    }


    public Complex? FindById(int id)
    {
        return
            _complexes.FirstOrDefault(_ => _.Id == id);
    }

    public void Update(Complex complex)
    {
        _complexes.Update(complex);
    }

    public int GetUnitCount(int id)
    {
        return
            _complexes.Where(_ => _.Id == id).Select(_ => _.UnitCount)
                .FirstOrDefault();
    }


    public void Delete(Complex complex)
    {
        _complexes.Remove(complex);
    }
}