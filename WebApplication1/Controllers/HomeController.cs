using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DAL.Repositories;
using Common.Search;
using BL;
using UI.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OrderService _service;

        public HomeController(OrderService service)
        {
            _service = service;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        

        public async Task<IActionResult>Index(int page = 1)
        {
            var obj = await _service.GetAllAsync();
            return View(obj);
        }

        public async Task<IActionResult> Update(int? id)
        {
            var model = new OrderModel();
            if (id != null) 
            {
                model = OrderModel.FromEntity(await _service.GetByIdAsync(id.Value));
                if (model == null)
                    return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.AddAsync(OrderModel.ToEntity(model));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderSearchParams searchParams)
        {
            var obj = await _service.GetAsync(searchParams);
            return View(obj);
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