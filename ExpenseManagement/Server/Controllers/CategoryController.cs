using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Interfaces.Services;
using ExpenseManagement.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public CategoryController(
               IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public List<Category> Get()
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();
            var bo = service.GetFiltered();
            return bo.Data;
        }
    }
}
