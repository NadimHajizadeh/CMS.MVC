﻿namespace CMS.Services.Complexs.Contract.Dto;

public class GetAllComplexesWithUnitCountDeataiDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int RegisterdUnitCount { get; set; }
    public int? LeftUnitCount { get; set; }
}