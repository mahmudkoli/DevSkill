using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSkill.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Web.Controllers
{
    public class SubjectsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new SubjectModel();
            var data = await model.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new SubjectModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}