using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.ToTable("EmployeePositions");

        builder.HasKey(x => new { x.EmployeeId, x.PositionId });

        builder.Property(x => x.EmployeeId)
            .HasColumnName("EmployeeId")
            .IsRequired();

        builder.Property(x => x.PositionId)
            .HasColumnName("PositionId")
            .IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Positions)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}