using Microsoft.AspNetCore.Mvc;

namespace StaffManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
