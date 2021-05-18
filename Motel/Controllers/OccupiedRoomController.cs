using Application.Services;
using Application.ViewModels.OccupiedRoom;
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
        private readonly IReservationService _reservationService;
        private readonly IOccupiedRoomService _occupiedRoomService;

        private int pageSize = 5;

        public OccupiedRoomController(IReservationService reservationService,
                                      IOccupiedRoomService occupiedRoomService)
        {
            _reservationService = reservationService;
            _occupiedRoomService = occupiedRoomService;
        }

        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var model = await _occupiedRoomService.GetOccupiedRoomList(pageNumber, pageSize);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] OccupiedRoomIndexViewModel occupiedRoomIndexVM)
        {
            var model = await _occupiedRoomService.GetOccupiedRoomList(occupiedRoomIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservationSearch([FromForm] OccupiedRoomIndexViewModel occupiedRoomIndexVM)
        {
            var model = await _occupiedRoomService.GetOccupiedRoomList(occupiedRoomIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        // GET: OccupiedRoom/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid id)
        {
            var compoundVM = await _occupiedRoomService.GetAddOrEditOccupiedRoomDetail(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddOrEdit([FromBody] CompoundOccupiedRoomViewModel compoundVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var model = await _reservationService.GetReservationList(compoundVM, pageSize);
        //        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        //    }

        //    compoundVM = await _reservationService.GetAddOrEditReservation(compoundVM);
        //    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        //}
    }
}
