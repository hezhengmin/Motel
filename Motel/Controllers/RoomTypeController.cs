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
using Motel.Repository;
using Motel.ViewModel;

namespace Motel.Controllers
{
    [Authorize]
    public class RoomTypeController : Controller
    {
        private readonly MotelDbContext _context;
        private IRoomTypeRepository _roomTypeRepository;
        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        // GET: RoomType
        public async Task<IActionResult> Index()
        {
            //var list = await _context.RoomType.ToListAsync();
            var list = await _roomTypeRepository.GetRoomTypeList();
            var roomTypeListVM = new List<RoomTypeViewModel>();
            roomTypeListVM = list.Select(m => new RoomTypeViewModel()
            {
                Id = m.Id,
                Name = m.Name,
                Area = m.Area,
                BedQuantity = m.BedQuantity,
                Price = m.Price,
                Hprice = m.Hprice,
                Qkprice = m.Qkprice,
                Qk2price = m.Qk2price,
                AirCondition = m.AirCondition,
                Tv = m.Tv
            }).ToList();

            return View(roomTypeListVM);
        }

        // GET: RoomType/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            if (id == null)
                return View(new RoomTypeViewModel());
            else
            {
                var roomType = await _roomTypeRepository.GetRoomType(id.Value);
                var roomTypeVM = new RoomTypeViewModel();
                roomTypeVM.Id = roomType.Id;
                roomTypeVM.Name = roomType.Name;
                roomTypeVM.Area = roomType.Area;
                roomTypeVM.BedQuantity = roomType.BedQuantity;
                roomTypeVM.Price = roomType.Price;
                roomTypeVM.Hprice = roomType.Hprice;
                roomTypeVM.Qkprice = roomType.Qkprice;
                roomTypeVM.Qk2price = roomType.Qk2price;
                roomTypeVM.AirCondition = roomType.AirCondition;
                roomTypeVM.Tv = roomType.Tv;
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
                var roomType = new RoomType();
                roomType.Name = roomTypeVM.Name;
                roomType.Area = roomTypeVM.Area;
                roomType.BedQuantity = roomTypeVM.BedQuantity;
                roomType.Price = roomTypeVM.Price;
                roomType.Hprice = roomTypeVM.Hprice;
                roomType.Qkprice = roomTypeVM.Qkprice;
                roomType.Qk2price = roomTypeVM.Qk2price;
                roomType.AirCondition = roomTypeVM.AirCondition;
                roomType.Tv = roomTypeVM.Tv;

                if (roomTypeVM.Id == null)
                    await _roomTypeRepository.AddRoomType(roomType);
                else
                    await _roomTypeRepository.UpdateRoomType(roomType);

                return RedirectToAction(nameof(Index));
            }
            return View(roomTypeVM);
        }

        // GET: RoomType/Remove/5
        public async Task<IActionResult> Remove(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _roomTypeRepository.RemoveRoomType(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
