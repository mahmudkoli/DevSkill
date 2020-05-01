using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSkill.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Web.Controllers
{
    public class GradesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new GradeModel();
            var data = await model.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GradeModel();
            await model.LoadAllAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GradeModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddAsync();
                return RedirectToAction("Index");
            }

            await model.LoadAllAsync();
            return View(model);
        }
    }
}