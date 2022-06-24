using Microsoft.AspNetCore.Mvc;

namespace EmploymentAgencyApi.Controllers
{
    public class ContractsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
