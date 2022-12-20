using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StaffManagement.Web.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Conflict(ModelStateDictionary dict)
        {
            return View("~/Views/Errors/Conflict.cshtml", dict);
        }
    }
}
