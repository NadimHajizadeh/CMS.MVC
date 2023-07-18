using CMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistanse.EF.Complexs;

public class ComplexEntityMap : IEntityTypeConfiguration<Complex>
{
    public void Configure(EntityTypeBuilder<Complex> _)
    {
        _.ToTable("Complexes");
        _.HasKey(t => t.Id);
        _.Property(t => t.Id).ValueGeneratedOnAdd();
        _.Property(_ => _.Name)
            .HasMaxLength(30).
            IsRequired(true);
        _.Property(_ => _.UnitCount).
            IsRequired(true);
    }

   
}