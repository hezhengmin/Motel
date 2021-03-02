using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motel.Services;
using Motel.ViewModels;

namespace Motel.Controllers
{
    [Authorize]
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
      
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // GET: RoomType
        public async Task<IActionResult> Index()
        {
            var roomTypeListVM = await _roomTypeService.GetRoomTypeList();
            return View(roomTypeListVM);
        }

        // GET: RoomType/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            if (id == null)
                return View(new RoomTypeViewModel());
            else
            {
                var roomTypeVM = await _roomTypeService.GetRoomType(id.Value);
                return View(roomTypeVM);
            }

        }

        // POST: RoomType/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(RoomTypeViewModel roomTypeVM)
        {
            if (ModelState.IsValid)
            {
                if (roomTypeVM.Id == null)
                {
                    await _roomTypeService.AddRoomType(roomTypeVM);
                }
                else
                {
                    await _roomTypeService.UpdateRoomType(roomTypeVM);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(roomTypeVM);
        }

        // GET: RoomType/Remove/5
        public async Task<IActionResult> Remove(Guid? id)
        {
            if (id == null) return NotFound();
            await _roomTypeService.RemoveRoomType(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
