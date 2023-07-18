using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistanse.EF.ComplexUsageType;

public class ComplexUsageTypeEntityMap : IEntityTypeConfiguration<Entities.ComplexUsageType>
{
    public void Configure(EntityTypeBuilder<Entities.ComplexUsageType> _)
    {
        _.ToTable("ComplexUsageType");
        _.HasKey(_ => new { _.ComplexId, _.UsageTypeId });
    }
}