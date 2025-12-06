using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}