using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSkill.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Web.Controllers
{
    public class StudentsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new StudentModel();
            var data = await model.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentModel model)
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