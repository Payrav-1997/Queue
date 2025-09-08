using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class OrganizationSpecializationConfiguration : IEntityTypeConfiguration<OrganizationSpecialization>
{
    public void Configure(EntityTypeBuilder<OrganizationSpecialization> builder)
    {
        builder.ToTable("OrganizationSpecializations");

        builder.HasKey(x => new { x.OrganizationId, x.SpecializationId });

        builder.Property(x => x.OrganizationId)
            .HasColumnName("OrganizationId")
            .IsRequired();

        builder.Property(x => x.SpecializationId)
            .HasColumnName("SpecializationId")
            .IsRequired();

        builder.HasOne(x => x.Organization)
            .WithMany(o => o.Specializations)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Specialization)
            .WithMany(s => s.Organizations)
            .HasForeignKey(x => x.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}