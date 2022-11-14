using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using DAL.Repositories;
using Common.Search;
using BL;
using UI.Models;

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

        public async Task<IActionResult> Update(OrderItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _service.AddAsync(OrderItemModel.ToEntity(model));
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> AjaxOrderItems(string search)
        {
            var res = await _service.GetAsync(new OrderItemSearchParams
            {
                Name = search
            });
            return Json(res);
        }

        public async void Delete(int id) 
        {
            await _service.DeleteAsync(id);
        }

        //public async Task<JsonResult> AjaxProviders(string search) 
        //{

        //    return Json();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}