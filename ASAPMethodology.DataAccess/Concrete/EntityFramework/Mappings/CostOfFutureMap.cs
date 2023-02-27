using ASAPMethodology.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAPMethodology.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CostOfFutureMap : IEntityTypeConfiguration<CostOfFuture>
    {
        public void Configure(EntityTypeBuilder<CostOfFuture> builder)
        {
            builder.ToTable(@"CostOfFuture", @"dbo");

            builder.HasKey(cof => cof.Id);

            builder.Property(cof => cof.CardName).HasColumnName("CardName").HasMaxLength(250);
            builder.Property(cof => cof.CardLastName).HasColumnName("CardLastName").HasMaxLength(250);
            builder.Property(cof => cof.DocNum).HasColumnName("DocNum").ValueGeneratedOnAdd();
            builder.Property(cof => cof.PolicyNum).HasColumnName("PolicyNum");
            builder.Property(cof => cof.PolicyBegDate).HasColumnName("PolicyBegDate");
            builder.Property(cof => cof.InstallementNo).HasColumnName("InstallementNo");
            builder.Property(cof => cof.PolicyEndDate).HasColumnName("PolicyEndDate");
            builder.Property(cof => cof.Comments).HasColumnName("Comments").HasMaxLength(300);
            builder.Property(cof => cof.Methodology).HasColumnName("Methodology").HasColumnType("nvarchar(20)");

            builder.HasOne(cof => cof.ExpenseType).WithMany(cof => cof.CostOfFutures).HasForeignKey(cof => cof.ExpenseTypeId);
        }
    }
}
