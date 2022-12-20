using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StaffManagement.DataTransfer.Department;
using StaffManagement.DataTransfer.Mapper;
using StaffManagement.DataTransfer.Staff;
using StaffManagement.Model;
using StaffManagement.Web.Data;
using StaffManagement.Web.Data.Services;
using StaffManagement.Web.Models;

namespace StaffManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            RegisterDataServices(builder.Services);
            RegisterMappers(builder.Services);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                ApplicationDbContext
                    .SeedData(scope.ServiceProvider.GetRequiredService<ApplicationDbContext>());

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void RegisterDataServices(IServiceCollection collection)
        {
            collection.AddScoped<IDataService<Staff>, StaffDataService>();
            collection.AddScoped<IDataService<Department>, DepartmentDataService>();
        }

        private static void RegisterMappers(IServiceCollection collection)
        {
            collection.AddSingleton<IMapper<Staff, StaffResponse>, StaffMapper>();
            collection.AddSingleton<IMapper<Department, DepartmentResponse>, DepartmentMapper>();
        }
    }
}