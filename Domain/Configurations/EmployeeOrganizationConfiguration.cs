using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class EmployeeOrganizationConfiguration : IEntityTypeConfiguration<EmployeeOrganization>
{
    public void Configure(EntityTypeBuilder<EmployeeOrganization> builder)
    {
        // составной ключ
        builder.HasKey(eo => new { eo.EmployeeId, eo.OrganizationId });

        builder.HasOne(eo => eo.Employee)
            .WithMany(e => e.Organizations)
            .HasForeignKey(eo => eo.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(eo => eo.Organization)
            .WithMany(o => o.Employees)
            .HasForeignKey(eo => eo.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("EmployeeOrganizations");
    }
}