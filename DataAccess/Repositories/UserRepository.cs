using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialDbContext _ctx;
        public UserRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<User> CreateUser(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return;
            
            _ctx.Users.Remove(user); 
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateUser(User user)
        {
            var userSaved = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userSaved == null) throw new KeyNotFoundException($"User with Id: {user.Id}, not found");

            userSaved.Dni = user.Dni;
            userSaved.Name = user.Name;
            userSaved.lastName = user.lastName;
            userSaved.Email = user.Email;
            userSaved.DateOfBirth = user.DateOfBirth;
            await _ctx.SaveChangesAsync();
            return userSaved;
        }
    }
}
