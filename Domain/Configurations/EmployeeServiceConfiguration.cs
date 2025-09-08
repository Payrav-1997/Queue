using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class EmployeeServiceConfiguration : IEntityTypeConfiguration<EmployeeService>
{
    public void Configure(EntityTypeBuilder<EmployeeService> builder)
    {
        builder.ToTable("EmployeeServices");

        builder.HasKey(x => new { x.EmployeeId, x.ServiceId });

        builder.Property(x => x.EmployeeId)
            .HasColumnName("EmployeeId")
            .IsRequired();

        builder.Property(x => x.ServiceId)
            .HasColumnName("ServiceId")
            .IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Services)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Service)
            .WithMany(s => s.Employees)
            .HasForeignKey(x => x.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}