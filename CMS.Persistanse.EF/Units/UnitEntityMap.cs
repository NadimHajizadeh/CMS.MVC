﻿using CMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistanse.EF.Units;

public class UnitEntityMap : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> _)
    {
        _.ToTable("Units");
        _.HasKey("Id");
        _.Property(_ => _.Id)
            .ValueGeneratedOnAdd();
        _.Property(_ => _.Name)
            .IsRequired(true)
            .HasMaxLength(30);
        _.Property(_ => _.ResidenseType)
            .IsRequired(true);
        _.Property(_ => _.BlockId)
            .IsRequired();
        _.HasOne(_ => _.Block)
            .WithMany(_ => _.Units)
            .HasForeignKey(_ => _.BlockId);
    }
    
}