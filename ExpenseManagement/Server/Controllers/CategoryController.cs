using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.Helpers;
using ExpenseManagement.Shared.Interfaces.Services;
using ExpenseManagement.Shared.Models.Category;
using ExpenseManagement.Shared.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("{id}")]
        public BusinessResult<Category> Get(int id)
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();
            return service.GetById(id);
        }

        [HttpGet("GetIconsCategory")]
        public BusinessResult<CategoryIcon> GetIconsCategory()
        {
            try
            {
                string path = Path.Combine(ConfigHelper.GetEnvironment().ContentRootPath, "json\\icons.json"); ;
                CategoryIcon? response = new CategoryIcon();

                if (System.IO.File.Exists(path))
                {
                    string json = System.IO.File.ReadAllText(path);
                    if(!string.IsNullOrEmpty(json))
                        response = JsonConvert.DeserializeObject<CategoryIcon>(json);
                }
                else
                {
                    return BusinessResult<CategoryIcon>.CreateInvalidResult("Não foi possível obter os icones.");
                }

                return BusinessResult<CategoryIcon>.CreateValidResult(response);
            }
            catch (Exception ex)
            {
                return BusinessResult<CategoryIcon>.CreateInvalidResult(ex);
            }
        }

        [HttpPost]
        public BusinessResult<Category> Post(Category category)
        {
            var service = _serviceProvider.GetRequiredService<ICategoryService>();

            // se for alteração
            if (category.Id > 0)
            {
                return service.Update(category);
            }

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
