using ABNAmro.CrossCutting.Specifications;
using ABNAmro.Domain.Calculations;
using ABNAmro.Domain.Progresses;
using Microsoft.EntityFrameworkCore;

namespace ABNAmro.Database.ValueConverters
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ConfigureCalculation(this ModelBuilder modelBuilder)
        {
            var clubEntity = modelBuilder.Entity<Calculation>();
            clubEntity
                .HasKey(c => c.Id)
                .IsClustered(false);
            clubEntity
                .HasIndex(c => c.CreatedAt)
                .IsClustered();
            clubEntity
                .HasMany(c => c.Progresses)
                .WithOne(p => p.Calculation)
                .HasForeignKey(t => t.CalculationId)
                .OnDelete(DeleteBehavior.ClientCascade);
            clubEntity.Property(c => c.Input1)
                .HasMaxLength(Limitations.MaxLengthInput1)
                .IsRequired();
            clubEntity.Property(c => c.Input2)
                .HasMaxLength(Limitations.MaxLengthInput2)
                .IsRequired();

            return modelBuilder;
        }

        public static ModelBuilder ConfigureProgress(this ModelBuilder modelBuilder)
        {
            var clubEntity = modelBuilder.Entity<Progress>();
            clubEntity
                .HasKey(c => c.Id)
                .IsClustered(false);
            clubEntity
                .HasIndex(c => c.CreatedAt)
                .IsClustered();
            clubEntity
                .HasOne(c => c.Calculation)
                .WithMany(p => p.Progresses)
                .HasForeignKey(t => t.CalculationId)
                .OnDelete(DeleteBehavior.ClientCascade);
            clubEntity.Property(c => c.CalculationId)
                .IsRequired();
            clubEntity.Property(c => c.Percentage)
                .HasDefaultValue(0)
                .IsRequired();

            return modelBuilder;
        }
    }
}
