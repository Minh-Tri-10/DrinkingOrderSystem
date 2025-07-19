using DAL.Models;
using DAL.Data;
using DAL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DrinkOrderDbContext _context;

        public UserRepository(DrinkOrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(object id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _context.Users.FindAsync(id);
            if (item != null)
            {
                _context.Users.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
public async Task<IEnumerable<User>> SearchAsync(string? keyword, string? role, bool? isBanned)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(u => u.Username.Contains(keyword)
                                      || (u.FullName != null && u.FullName.Contains(keyword))
                                      || (u.Email != null && u.Email.Contains(keyword)));
            }
            if (!string.IsNullOrEmpty(role))
            {
                query = query.Where(u => u.Role == role);
            }
            if (isBanned.HasValue)
            {
                query = query.Where(u => u.IsBanned == isBanned);
            }

            return await query.ToListAsync();
        }

        public async Task BanAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.IsBanned = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnbanAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.IsBanned = false;
                await _context.SaveChangesAsync();
            } } 
    } 
}

        
    

