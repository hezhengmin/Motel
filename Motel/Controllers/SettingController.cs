using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Controllers
{
    public class SettingController : Controller
    {
        private readonly MotelDbContext _dbContext;

        public SettingController(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SettingController
        public ActionResult Index()
        {

            return View();
        }

        [Obsolete]
        public IActionResult Setting(string button)
        {
            if (button == "success")
            {
                TempData["Setting"] = "設定成功!";

                var customers = _dbContext.Customer.FromSqlRaw("select * from customer").ToList();

                TempData["Customers"] = JsonConvert.SerializeObject(customers);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: SettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SettingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
