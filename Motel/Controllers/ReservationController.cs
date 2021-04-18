using Application.Services;
using Application.ViewModels.Customer;
using Application.ViewModels.Reservation;
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
        private readonly IReservationService _reservationService;

        private int pageSize = 5;

        public ReservationController(ICustomerService customerService,
                                     IReservationService reservationService)
        {
            _customerService = customerService;
            _reservationService = reservationService;
        }


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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservationSearch([FromForm] ReservationIndexViewModel reservationIndexVM)
        {
            var model = await _reservationService.GetReservationList(reservationIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ReservationIndex", model) });
        }

        

        public async Task<IActionResult> ReservationIndex(Guid id)
        {
            int pageNumber = 1;
            var model = await _reservationService.GetReservationList(id, pageNumber, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ReservationIndex", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservationIndex([FromBody] ReservationIndexViewModel reservationIndexVM)
        {
            var model = await _reservationService.GetReservationList(reservationIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ReservationIndex", model) });
        }

        // GET: Reservation/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id, Guid customerId)
        {
            var compoundVM = await _reservationService.GetAddOrEditReservation(id, customerId);
            return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        // POST: Reservation/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromBody] CompoundReservationViewModel compoundVM)
        {
            if (ModelState.IsValid)
            {
                var model = await _reservationService.GetReservationList(compoundVM, pageSize);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ReservationIndex", model) });
            }

            compoundVM = await _reservationService.GetAddOrEditReservation(compoundVM);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] ReservationDeleteViewModel ReservationDeleteVM)
        {
            await _reservationService.RemoveReservation(ReservationDeleteVM.Id);
            var model = await _reservationService.GetReservationList(ReservationDeleteVM, pageSize);
            return Json(new { html = Helper.RenderRazorViewToString(this, "ReservationIndex", model) });
        }
    }
}
