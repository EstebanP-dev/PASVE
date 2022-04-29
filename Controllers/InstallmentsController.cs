using Microsoft.AspNetCore.Mvc;
using PASVE.Models;
using PASVE.Services;

namespace PASVE.Controllers
{
    public class InstallmentsController : Controller
    {
        private readonly InstallmentService service = new InstallmentService();
        

        public InstallmentsController()
        {
            if(GlobalVariables.UserInfo != null)
            {
                this.RedirectToAction("Index", controllerName: "Login");
            }
        }

        public async Task<IActionResult> Index()
        {
            GlobalVariables.Installment = Guid.Empty;
            var user = GlobalVariables.UserInfo;
            var result = await service.GetAllAsync(user.Id);
            var resp = result.Data;

            TempData["UserType"] = user.UserType.Name != "ESTUDIANTE";

            if (result.Success && resp != null)
            {
                return View(resp);
            }
            else
            {
                var list = new List<Installment>();

                return View(list);
            }
        }

        public IActionResult Details([Bind(include: "Id")] Guid id)
        {
            GlobalVariables.Installment = id;
            return RedirectToAction("Index", controllerName: "Evidence");
        }
    }
}
