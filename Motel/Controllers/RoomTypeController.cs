using Application.Services;
using Application.ViewModels.RoomType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _RoomTypeService;
        private int pageSize = 5;

        public RoomTypeController(IRoomTypeService RoomTypeService)
        {
            _RoomTypeService = RoomTypeService;
        }

        // GET: RoomType
        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var model = await _RoomTypeService.GetRoomTypeList(pageNumber, pageSize);
            return View(model);
        }

        // POST: RoomType
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] RoomTypeIndexViewModel RoomTypeIndexVM)
        {
            var model = await _RoomTypeService.GetRoomTypeList(RoomTypeIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([FromForm] RoomTypeIndexViewModel RoomTypeIndexVM)
        {
            var model = await _RoomTypeService.GetRoomTypeList(RoomTypeIndexVM, pageSize);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }

        // GET: RoomType/AddOrEdit
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                var model = new CompoundViewModel();
                model.RoomTypeViewModel = new RoomTypeViewModel();
                return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
            }
            else
            {
                var RoomTypeVM = await _RoomTypeService.GetRoomType(id.Value);
                var model = new CompoundViewModel();
                model.RoomTypeViewModel = RoomTypeVM;
                return Json(new { html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
            }

        }

        // POST: RoomType/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromBody] CompoundViewModel compoundVM)
        {
            if (ModelState.IsValid)
            {
                if (compoundVM.RoomTypeViewModel.Id == null || compoundVM.RoomTypeViewModel.Id == Guid.Empty)
                {
                    await _RoomTypeService.AddRoomType(compoundVM.RoomTypeViewModel);
                    var model = await _RoomTypeService.GetRoomTypeList(1, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
                else
                {
                    await _RoomTypeService.UpdateRoomType(compoundVM.RoomTypeViewModel);
                    var model = await _RoomTypeService.GetRoomTypeList(compoundVM.FilterViewModel, pageSize);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
                }
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", compoundVM) });
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RoomTypeDeleteViewModel RoomTypeDeleteVM)
        {
            await _RoomTypeService.RemoveRoomType(RoomTypeDeleteVM.Id);
            var model = await _RoomTypeService.GetRoomTypeList(RoomTypeDeleteVM, pageSize);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_IndexPartial", model) });
        }
    }
}
