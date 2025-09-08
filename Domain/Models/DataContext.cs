using Domain.Configurations;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
   
    public DbSet<Employee> Employees { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<EmployeeFeedback> EmployeeFeedbacks { get; set; }
    public DbSet<EmployeeOrganization> EmployeeOrganizations { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }
    public DbSet<EmployeeService> EmployeeServices { get; set; }
    public DbSet<OrganizationFeedback> OrganizationFeedbacks { get; set; }
    public DbSet<OrganizationSpecialization> OrganizationSpecializations { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Region> Regions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeOrganizationConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeePositionConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeServiceConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationSpecializationConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}