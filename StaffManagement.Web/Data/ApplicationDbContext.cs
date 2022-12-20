using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffManagement.Model;
using StaffManagement.Web.Models;

namespace StaffManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }

        public static void SeedData(ApplicationDbContext ctx)
        {
            if (!ctx.Departments.Any())
            {
                ctx.Departments.AddRange(
                    new Department()
                    {
                        Name = "Unassigned"
                    },
                    new Department()
                    {
                        Name = "IT Department"
                    },
                    new Department()
                    {
                        Name = "HR Department"
                    },
                    new Department()
                    {
                        Name = "Marketing Department"
                    });

                for (int i = 1; i <= 95; i++)
                {
                    ctx.Departments.Add(new Department() { Name = $"Department {i}" });
                }

                ctx.SaveChanges();
            }

            if (!ctx.Staffs.Any())
            {
                ctx.Staffs.AddRange(
                    new Staff()
                    {
                        Name = "Joseph Joestar",
                        DepartmentID = 1
                    },
                    new Staff()
                    {
                        Name = "Wong Zhen Kai",
                        DepartmentID = 2
                    },
                    new Staff()
                    {
                        Name = "Giorno Giovana",
                        DepartmentID = 3
                    },
                    new Staff()
                    {
                        Name = "Dio Brando",
                        DepartmentID = 4
                    });

                for (int i = 1; i <= 95; i++)
                {
                    ctx.Staffs.Add(new Staff()
                    {
                        Name = "Staff "+i,
                        DepartmentID = 1
                    });
                }

                ctx.SaveChanges();
            }
        }
    }
}