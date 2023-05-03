using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Server.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
