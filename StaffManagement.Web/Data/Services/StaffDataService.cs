using Microsoft.EntityFrameworkCore;
using StaffManagement.Model;
using StaffManagement.Web.Errors;
using StaffManagement.Web.Models;

namespace StaffManagement.Web.Data.Services
{
    public class StaffDataService : IDataService<Staff>
    {
        private readonly ApplicationDbContext _ctx;
        public StaffDataService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> CountAsync()
        {
            return await _ctx.Staffs.CountAsync();
        }

        public async Task<int> CountAsync(string query)
        {
            return await _ctx.Staffs.Where(x => x.Name.Contains(query)).CountAsync();
        }

        public async Task CreateAsync(Staff createModel)
        {
            await _ctx.Staffs.AddAsync(createModel);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Staff staff = await GetAsync(id, false);
            _ctx.Staffs.Remove(staff);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Staff>> GetAllAsync(int skip, int take, string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await _ctx.Staffs.Skip(skip).Take(take).ToListAsync();
            }
            return await _ctx.Staffs.Where(x => x.Name.Contains(search)).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Staff> GetAsync(int id, bool useCache = true)
        {
            try
            {
                return await _ctx.Staffs.FirstAsync(x => x.Id == id);
            } catch(InvalidOperationException oex)
            {
                throw new NotFoundException($"Unable to find staff with id: {id}", oex);
            } catch (Exception ex)
            {
                throw new InvalidProcessException($"Fail to find staff with id {id}", ex);
            }
        }

        public async Task UpdateAsync(int id, Staff updateModel)
        {
            Staff staff = await GetAsync(id, false);
            if (!string.IsNullOrEmpty(updateModel.Name))
            {
                staff.Name = updateModel.Name;
            }

            if (!(updateModel.DepartmentID == default(int)))
            {
                staff.DepartmentID = updateModel.DepartmentID;
            }

            await _ctx.SaveChangesAsync();
        }
    }
}
