using CMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistanse.EF.UsageTypes;

public class UsageTypeEntityMap : IEntityTypeConfiguration<UsageType>
{
    public void Configure(EntityTypeBuilder<UsageType> _)
    {
        _.ToTable("UsageType");
        _.HasKey("Id");
        _.Property(_ => _.Id)
            .ValueGeneratedOnAdd();
        _.Property(_ => _.Name)
            .IsRequired(true)
            .HasMaxLength(30);
    }
}