using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DAL.Repositories;
using Common.Search;
using BL;
using UI.Models;

namespace WebApplication1.Controllers
{
    public class ProviderController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProviderService _service;

        public ProviderController(ProviderService service)
        {
            _service = service;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public async Task<JsonResult> AjaxProviders(string search) 
        {
            var res = await _service.GetAsync(new ProviderSearchParams
            {
                Name = search
            });
            return Json(res);
        }

        public async Task<IActionResult>Index(int page = 1)
        {
            var obj = await _service.GetAllAsync();
            return View(obj);
        }

        public async Task<IActionResult> Update(int? id)
        {
            var model = new ProviderModel();
            if (id != null) 
            {
                model = ProviderModel.FromEntity(await _service.GetByIdAsync(id.Value));
                if (model == null)
                    return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProviderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.AddAsync(ProviderModel.ToEntity(model));
            return RedirectToAction("Index");
        }

        public async void Delete(int id) 
        {
            await _service.DeleteAsync(id);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}