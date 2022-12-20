using StaffManagement.Model;
using StaffManagement.Web.Models;

namespace StaffManagement.Web.Data.Services
{
    public interface IDataService<T> where T : BaseModel
    {
        public Task CreateAsync(T createModel);
        public Task<T> GetAsync(int id, bool useCache = true);
        public Task<IEnumerable<T>> GetAllAsync(int skip, int take, string search);
        public Task UpdateAsync(int id, T updateModel);
        public Task DeleteAsync(int id);
        public Task<int> CountAsync();
        public Task<int> CountAsync(string query);
    }
}
