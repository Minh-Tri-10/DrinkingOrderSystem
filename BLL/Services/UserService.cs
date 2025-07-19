using BLL.Services.interfaces;
using DAL.Models;
using DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(object id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(User item)
        {
            await _repo.AddAsync(item);
        }

        public async Task UpdateAsync(User item)
        {
            await _repo.UpdateAsync(item);
        }

        public async Task DeleteAsync(object id)
        {
            await _repo.DeleteAsync(id);
        }
        // Thêm mới:
        public async Task<IEnumerable<User>> SearchAsync(string? keyword, string? role, bool? isBanned)
            => await _repo.SearchAsync(keyword, role, isBanned);

        public async Task BanAsync(int userId)
            => await _repo.BanAsync(userId);

        public async Task UnbanAsync(int userId)
            => await _repo.UnbanAsync(userId);
    }
}
