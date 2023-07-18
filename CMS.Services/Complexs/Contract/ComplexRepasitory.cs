

using CMS.Entities;
using CMS.Services.Complexs.Contract.Dto;

namespace CMS.Services.Complexs.Contract;
//todo start from here 

public interface ComplexRepasitory
{
    void Add(Complex complex);
    List<GetAllComplexesWithUnitCountDeataiDto> GetAllComplexesWithUnitCountDeatail();
    List<GetAllComplexWithBlockDetaisDto> GetAllComplexWithBlockDetails(string? name);
    bool IsExisted(int id);
    GetOneComplexWithBlockAndUnitcountDeatilAndDto getOne(int id);
    Complex? FindById(int id);
    void Update(Complex complex);
    int GetUnitCount(int id);
  
    void Delete(Complex complex);
}