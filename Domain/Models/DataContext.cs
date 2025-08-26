using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public class DataContext(DbContextOptions options) : DbContext
{
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
    public DbSet<User?> Users { get; set; }
}