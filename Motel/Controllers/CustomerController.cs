using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motel.Data;
using Motel.Models;
using Motel.Services;
using Motel.ViewModels;

namespace Motel.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _CustomerService;
        private int pageSize = 5;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        // GET: Customer
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var customerIndexVM = await _CustomerService.GetCustomerList(pageNumber ?? 1, pageSize);

            return View(customerIndexVM);
        }

        // GET: Customer/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            if (id == null)
                return View(new CustomerViewModel());
            else
            {
                var CustomerVM = await _CustomerService.GetCustomer(id.Value);
                return View(CustomerVM);
            }

        }

        // POST: Customer/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(CustomerViewModel CustomerVM)
        {
            if (ModelState.IsValid)
            {
                if (CustomerVM.Id == null)
                    await _CustomerService.AddCustomer(CustomerVM);
                else
                    await _CustomerService.UpdateCustomer(CustomerVM);

                return RedirectToAction(nameof(Index));
            }
            return View(CustomerVM);
        }

        // GET: Customer/Remove/5
        public async Task<IActionResult> Remove(Guid? id)
        {
            if (id == null) return NotFound();
            await _CustomerService.RemoveCustomer(id.Value);

            return RedirectToAction(nameof(Index));
        }

        //-------------------------------------------  return Json

        //url: Customer/GetAllDataApiJson
        [HttpGet]
        public async Task<IActionResult> GetAllDataApiJson()
        {
            return Json(new { data = await _CustomerService.GetCustomerList() });
        }

        //url: Customer/DeleteByDataApiJson
        [HttpDelete]
        public async Task<IActionResult> DeleteByDataApiJson(Guid id)
        {
            if (!_CustomerService.GetCustomerExists(id))
            {
                return Json(new { success = false, message = "找不到資料!" });
            }

            await _CustomerService.RemoveCustomer(id);
            return Json(new { success = true, message = "成功刪除!" });
        }
    }
}
