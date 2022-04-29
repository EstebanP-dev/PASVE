using Microsoft.AspNetCore.Mvc;
using PASVE.Models;
using PASVE.Services;

namespace PASVE.Controllers
{
    public class LoginController : Controller
    {
        LoginService service = new LoginService();

        public IActionResult Index()
        {
            if(GlobalVariables.UserInfo != null)
            {
                return RedirectToAction("Index", controllerName: "Installments");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Email,Password")]Credentials credentials)
        {
            var result = await service.LoginAsync(credentials);
            var resp = result.Response;

            if(result.Authorized && resp != null)
            {
                return RedirectToAction("Index", controllerName: "Installments");
            }
            else
            {
                TempData["Error"] = result.Message;
                return View(credentials);
            }
        }
    }
}
