using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSkill.Training.Entities;
using DevSkill.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevSkill.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ILogger<CoursesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CourseModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            var model = new CourseModel();

            #region for edit
            if (id.HasValue && id != 0)
            {
                await model.LoadByIdAsync(id.Value);
            }
            #endregion

            return PartialView("_AddOrEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(CourseModel model)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (model.Id == null || model.Id == 0) await model.AddAsync();
                else await model.UpdateAsync();

                TempData["SuccessNotify"] = "Course has been successfully saved";
                return RedirectToAction("Index");
            }

            TempData["ErrorNotify"] = "Course could not be saved";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new CourseModel();
            await model.DeleteAsync(id);
            return Json(true);
        }

        public async Task<IActionResult> GetCourses()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CourseModel();
            var data = await model.GetAllAsync(tableModel);
            return Json(data);
        }
    }
}