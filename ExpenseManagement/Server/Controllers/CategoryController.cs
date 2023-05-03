using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.Interfaces.Services;
using ExpenseManagement.Shared.Models.Category;
using ExpenseManagement.Shared.ValueObjects;
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
        public BusinessResult<List<Category>> Get()
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();
            return service.GetFiltered();
        }

        [HttpPost]
        public BusinessResult<Category> Post(Category category)
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();
            return service.Add(category);
        }

        [HttpDelete("{id}")]
        public BusinessResult<bool> Delete(int id)
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();
            return service.Delete(id);
        }
    }
}
