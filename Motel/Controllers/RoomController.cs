using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.ViewModels.Room;

namespace Motel.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private int pageSize = 5;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var model = await _roomService.GetRoomList(pageNumber, pageSize);
            return View(model);
        }

        // POST: Room
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] RoomIndexViewModel RoomIndexVM)
        {
            var model = await _roomService.GetRoomList(RoomIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([FromForm] RoomIndexViewModel RoomIndexVM)
        {
            var model = await _roomService.GetRoomList(RoomIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        // GET: Room/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            var compoundVM = await _roomService.GetAddOrEditRoom(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        // POST: Room/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromBody] CompoundViewModel compoundVM)
        {
            if (ModelState.IsValid)
            {
                if (compoundVM.RoomViewModel.Id == null || compoundVM.RoomViewModel.Id == Guid.Empty)
                {
                    await _roomService.AddRoom(compoundVM.RoomViewModel);
                    var model = await _roomService.GetRoomList(1, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
                else
                {
                    await _roomService.UpdateRoom(compoundVM.RoomViewModel);
                    var model = await _roomService.GetRoomList(compoundVM.FilterViewModel, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
            }

            //compoundVM.RoomViewModel.RoomTypeList = new SelectList(_MedicalCenterOrdinanceContext.AspNetRoles, "Id", "Name");


            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RoomDeleteViewModel RoomDeleteVM)
        {
            await _roomService.RemoveRoom(RoomDeleteVM.Id);
            var model = await _roomService.GetRoomList(RoomDeleteVM, pageSize);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }
    }
}
