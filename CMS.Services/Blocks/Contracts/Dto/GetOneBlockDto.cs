using CMS.Entities;

namespace CMS.Services.Blocks.Contracts.Dto;

public class GetOneBlockDto
{
    public string? UnitName { get; set; }
    public ResidenseType? residenseType { get; set; }
}

public class GetblockDto
{
    public string Name { get; set; }
    public int UnitCount { get; set; }
    public int RegisterUnitCount { get; set; }
    public int ReminaingUnitCount { get; set; }
}