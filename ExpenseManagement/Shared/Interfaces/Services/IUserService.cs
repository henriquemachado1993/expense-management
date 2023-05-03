using System.Security.Claims;
using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Interfaces.Services
{
    public interface IUserService
    {
        public Task<BusinessResult<User>> CreateAsync(BusinessObject<User> bo);
        public Task<BusinessResult<User>> UpdateAsync(BusinessObject<User> bo);
        public Task<BusinessResult<User>> UpdatePasswordAsync(BusinessObject<User> bo);
        public Task<BusinessResult<User>> GetByIdAsync(string userId);
        public Task<BusinessResult<User>> GetByEmailAsync(string email);
        public bool IsUserLogged(ClaimsPrincipal claimsPrincipal, string userId);
        public Task<BusinessResult<List<User>>> GetAllAsync();
    }
}
