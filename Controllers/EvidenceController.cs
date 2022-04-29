using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PASVE.Models;
using PASVE.Services;

namespace PASVE.Controllers
{
    public class EvidenceController : Controller
    {
        private readonly EvidenceService service = new EvidenceService();
        private readonly UserService userService = new UserService();
        private readonly string ServerRoute;

        public EvidenceController(IConfiguration config)
        {
            if(GlobalVariables.Installment == Guid.Empty)
            {
                this.RedirectToAction("Index", controllerName: "Installments");
            }

            ServerRoute = config.GetSection("Configuration").GetSection("ServerRoute").Value;
        }

        // GET: EvidenceController
        public async Task<IActionResult> Index()
        {
            var result = await service.GetAllAsync(GlobalVariables.Installment);
            var resp = result.Data;

            if(!result.Success && resp == null)
            {
                resp = new List<Evidence>();
            }

            return View(resp);
        }

        // GET: EvidenceController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EvidenceController/Create
        public async Task<IActionResult> Create()
        {
            var result = await userService.GetAllAsync();
            var resp = result.Data;
            
            if(result.Success && resp != null)
            {
                var users = resp
                    .Select(u => new
                    {
                        Text = u.Name,
                        Value = u.Id
                    });
                ViewBag.Users = new SelectList(users, "Value", "Text");
                ViewBag.File = null;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: EvidenceController/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind(include: "Name,Description,File,Authors")]Evidence evidence)
        {
            evidence.FkInstallment = GlobalVariables.Installment;
            var result = await service.CreateAsync(evidence, ServerRoute);
            var resp = result.Data;

            if(result.Success && resp != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(evidence);
            }
        }

        // GET: EvidenceController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: EvidenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EvidenceController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: EvidenceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
