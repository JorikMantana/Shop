using Microsoft.AspNetCore.Mvc;

namespace Shop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CreateNewProduct()
        {
            return View();
        }
    }
}
