﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.ViewModels.Customer;

namespace Motel.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private int pageSize = 5;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customer
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

        // GET: Customer/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                var model = new CompoundCustomerViewModel();
                model.CustomerViewModel = new CustomerViewModel();
                return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
            }
            else
            {
                var customerVM = await _customerService.GetCustomer(id.Value);
                var model = new CompoundCustomerViewModel();
                model.CustomerViewModel = customerVM;
                return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
            }
        }

        // POST: Customer/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromBody] CompoundCustomerViewModel compoundVM)
        {
            if (ModelState.IsValid)
            {
                if (compoundVM.CustomerViewModel.Id == null || compoundVM.CustomerViewModel.Id == Guid.Empty)
                {
                    await _customerService.AddCustomer(compoundVM.CustomerViewModel);
                    var model = await _customerService.GetCustomerList(1, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
                else
                {
                    await _customerService.UpdateCustomer(compoundVM.CustomerViewModel);
                    var model = await _customerService.GetCustomerList(compoundVM.FilterViewModel, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] CustomerDeleteViewModel customerDeleteVM)
        {
            await _customerService.RemoveCustomer(customerDeleteVM.Id);
            var model = await _customerService.GetCustomerList(customerDeleteVM, pageSize);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }
    }
}
