using EmployeeCrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudMvc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();
}
