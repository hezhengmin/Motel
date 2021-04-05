using Application.Services;
using Application.ViewModels.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICustomerService _customerService;
        private int pageSize = 5;

        public ReservationController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: ReservationController
        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var model = await _customerService.GetCustomerList(pageNumber, pageSize);
            return View(model);
        }

        // POST: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] CustomerIndexViewModel customerIndexVM)
        {
            var model = await _customerService.GetCustomerList(customerIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([FromForm] CustomerIndexViewModel customerIndexVM)
        {
            var model = await _customerService.GetCustomerList(customerIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        // GET: ReservationController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ReservationController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ReservationController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ReservationController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ReservationController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ReservationController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ReservationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
