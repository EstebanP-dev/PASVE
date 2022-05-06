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
        private readonly GeneralService generalService = new GeneralService();
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
                ViewBag.Users = new MultiSelectList(users, "Value", "Text");
                ViewBag.File = null;

                var result2 = await generalService.GetChaptersAsync();
                var result3 = await generalService.GetArticlesAsync();
                //var result4 = await generalService.GetParagraphsAsync();
                var result5 = await generalService.GetSectionsAsync();
                var result6 = await generalService.GetNumeralsAsync();

                if(result2.Success && result3.Success && result5.Success && result6.Success)
                {
                    var chapters = result2.Data
                        .Select(u => new
                        {
                            Text = u.Name,
                            Value = u.Id
                        }).ToList();
                    var articles = result3.Data
                        .Select(u => new
                        {
                            Text = u.Name,
                            Value = u.Id
                        });
                    //var paragraphs = result4.Data
                    //    .Select(u => new
                    //    {
                    //        Text = u.Content,
                    //        Value = u.Id
                    //    });
                    var sections = result5.Data
                        .Select(u => new
                        {
                            Text = u.Content,
                            Value = u.Id
                        });
                    var numerals = result6.Data
                        .Select(u => new
                        {
                            Text = u.Content,
                            Value = u.Id
                        });
                    ViewBag.Chapters = new SelectList(chapters, "Value", "Text");
                    ViewBag.Articles = new SelectList(articles, "Value", "Text");
                    ViewBag.Sections = new SelectList(sections, "Value", "Text");
                    ViewBag.Numerals = new SelectList(numerals, "Value", "Text");
                    //ViewBag.Paragraphs = new SelectList(chapters, "Value", "Text");

                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }

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
