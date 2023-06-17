using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation {
    public class UserRepository : IUserRepository {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public Task<User> Register() {
            throw new NotImplementedException();
        }
    }
}
