using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DAL.Repositories;
using Common.Search;
using BL;

namespace WebApplication1.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OrderItemService _service;

        public OrderItemController(OrderItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Update(int? id)
        {
            var obj = await _service.GetByIdAsync(id.Value);
            return View(obj);
        }

        public async Task<IActionResult> Update(OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _service.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async void Delete(int id) 
        {
            await _service.DeleteAsync(id);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}