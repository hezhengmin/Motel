using Application.Repository.ReservationEnums;
using Application.Services;
using Application.ViewModels.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    public class OccupiedRoomController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IReservationService _reservationService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;

        private int pageSize = 5;

        public OccupiedRoomController(ICustomerService customerService,
                                     IReservationService reservationService,
                                     IRoomTypeService roomTypeService,
                                     IRoomService roomService)
        {
            _customerService = customerService;
            _reservationService = reservationService;
            _roomTypeService = roomTypeService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var model = await _reservationService.GetReservationList(pageNumber, pageSize);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] ReservationIndexViewModel reservationIndexVM)
        {
            var model = await _reservationService.GetReservationList(ReservationSearchField.RoomNumber, reservationIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservationSearch([FromForm] ReservationIndexViewModel reservationIndexVM)
        {
            var model = await _reservationService.GetReservationList(ReservationSearchField.RoomNumber, reservationIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        // GET: Reservation/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id, Guid customerId)
        {
            var compoundVM = await _reservationService.GetAddOrEditReservation(id, customerId);
            return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }
    }
}
