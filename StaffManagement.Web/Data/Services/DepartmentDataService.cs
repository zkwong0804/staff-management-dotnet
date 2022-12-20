using Microsoft.EntityFrameworkCore;
using StaffManagement.Model;
using StaffManagement.Web.Models;

namespace StaffManagement.Web.Data.Services
{
    public class DepartmentDataService : IDataService<Department>
    {
        private readonly ApplicationDbContext _ctx;

        public DepartmentDataService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Department createModel)
        {
            await _ctx.Departments.AddAsync(createModel);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Department department = await GetAsync(id, false);
            _ctx.Departments.Remove(department);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync(int skip, int take, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return await _ctx.Departments.Skip(skip).Take(take).ToListAsync();
            }
            return await _ctx.Departments.Where(x => x.Name.Contains(query)).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Department> GetAsync(int id, bool useCache = true)
        {
            return await _ctx.Departments.FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, Department updateModel)
        {
            Department department = await GetAsync(id, false);
            if (!string.IsNullOrEmpty(updateModel.Name))
            {
                department.Name = updateModel.Name;
            }

            if (!string.IsNullOrEmpty(updateModel.Name))
            {
                department.Name = updateModel.Name;
            }

            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CountAsync() 
        {
            return await _ctx.Departments.CountAsync();
        }

        public async Task<int> CountAsync(string query)
        {
            return await _ctx.Departments.Where(x => x.Name.Contains(query)).CountAsync();
        }
    }
}
