﻿namespace CMS.Services.Complexs.Contract.Dto;

public class GetOneComplexWithBlockAndUnitcountDeatilAndDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BlockCount  { get; set; }
    public int RegisterdUnitCount { get; set; }
    public int? LeftUnitCount { get; set; }
}