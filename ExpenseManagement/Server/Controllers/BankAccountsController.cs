using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.Extensions;
using ExpenseManagement.Shared.Interfaces.Services;
using ExpenseManagement.Shared.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public BankAccountsController(
               IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public BusinessResult<List<BankAccounts>> Get()
        {
            var service = _serviceProvider.GetRequiredService<IBankAccountsService>();
            return service.GetFiltered(new QueryCriteria<BankAccounts>() { Expression = x => x.UserId == User.GetId() });
        }

        [HttpGet("{id}")]
        public BusinessResult<BankAccounts> Get(int id)
        {
            var service = _serviceProvider.GetRequiredService<IBankAccountsService>();
            return service.GetById(id);
        }

        [HttpPost]
        public BusinessResult<BankAccounts> Post(BankAccounts bankAccounts)
        {
            var service = _serviceProvider.GetRequiredService<IBankAccountsService>();

            bankAccounts.UserId = User.GetId();

            // se for alteração
            if (bankAccounts.Id > 0)
            {
                return service.Update(bankAccounts);
            }

            return service.Add(bankAccounts);
        }

        [HttpDelete("{id}")]
        public BusinessResult<bool> Delete(int id)
        {
            var service = _serviceProvider.GetRequiredService<IBankAccountsService>();
            return service.Delete(id);
        }
    }
}
