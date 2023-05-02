using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;

namespace ExpenseManagement.Domain.Interfaces.Services
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
