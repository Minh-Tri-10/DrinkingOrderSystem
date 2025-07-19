using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repositories.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(object id);
        Task AddAsync(User item);
        Task UpdateAsync(User item);
        Task DeleteAsync(object id);

        // Thêm mới:
        Task<IEnumerable<User>> SearchAsync(string? keyword, string? role, bool? isBanned);
        Task BanAsync(int userId);
        Task UnbanAsync(int userId);
    }
}
