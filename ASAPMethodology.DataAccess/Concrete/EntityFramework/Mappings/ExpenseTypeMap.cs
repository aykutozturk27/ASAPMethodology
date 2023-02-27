using ASAPMethodology.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAPMethodology.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ExpenseTypeMap : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.ToTable(@"ExpenseType", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Name).HasColumnName("Name");

            builder.HasData
            (
                new ExpenseType { Name = "Sigorta"},
                new ExpenseType { Name = "Kasko"},
                new ExpenseType { Name = "Kira"}
            );
        }
    }
}
