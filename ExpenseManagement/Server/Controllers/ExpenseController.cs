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
    public class ExpenseController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ExpenseController(
               IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public BusinessResult<List<Expense>> Get()
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
            return service.GetFiltered(new QueryCriteria<Expense>() { Expression = x => x.UserId == User.GetId() });
        }

        [HttpGet("recurrent-expenses")]
        public BusinessResult<List<Expense>> RecurrentExpenses()
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
           
            var result = service.GetFiltered(new QueryCriteria<Expense>()
            {
                Expression = x => x.UserId == User.GetId() && x.IsMonthlyRecurrence == 1,
                OrderBy = x => x.ExpenseDate,
                Ascending = false
            });
            return result;
        }

        [HttpGet("recurrent-expenses/{month}")]
        public BusinessResult<List<Expense>> RecurrentExpenses(int month)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();

            var result = service.GetFiltered(new QueryCriteria<Expense>()
            {
                Expression = x => x.UserId == User.GetId() && x.IsMonthlyRecurrence == 1 && x.ExpenseDate.Month == month && x.ExpenseDate.Year == DateTime.Now.Year,
                OrderBy = x => x.ExpenseDate,
                Ascending = false
            });
            return result;
        }

        [HttpPost("recurrent-expenses")]
        public BusinessResult<List<Expense>> RecurrentExpenses(List<Expense> expenses)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
            var userId = User.GetId();
            expenses.ForEach(expense => expense.UserId = userId);
            return service.GenerateRecurringExpenses(expenses);
        }

        [HttpGet("{id}")]
        public BusinessResult<Expense> Get(int id)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
            return service.GetById(id);
        }

        [HttpPost]
        public BusinessResult<Expense> Post(Expense expense)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();

            expense.UserId = User.GetId();

            // se for alteração
            if (expense.Id > 0)
            {
                return service.Update(expense);
            }

            return service.Add(expense);
        }

        [HttpDelete("{id}")]
        public BusinessResult<bool> Delete(int id)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
            return service.Delete(id);
        }

        [HttpPut("confirmpayment")]
        public BusinessResult<Expense> ConfirmPayment(BaseEntity request)
        {
            var service = _serviceProvider.GetRequiredService<IExpenseService>();
            return service.ConfirmPayment(request.Id);
        }
    }
}
