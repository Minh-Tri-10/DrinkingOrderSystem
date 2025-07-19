using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.interfaces
{
    public interface IUserService
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
