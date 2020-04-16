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
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new StudentModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            var model = new StudentModel();

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
        public async Task<IActionResult> AddOrEdit(StudentModel model)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (model.Id == null || model.Id == 0) await model.AddAsync();
                else await model.UpdateAsync();

                TempData["SuccessNotify"] = "Student has been successfully saved";
                return RedirectToAction("Index");
            }

            TempData["ErrorNotify"] = "Student could not be saved";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new StudentModel();
            await model.DeleteAsync(id);
            return Json(true);
        }

        public async Task<IActionResult> GetStudents()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentModel();
            var data = await model.GetAllAsync(tableModel);
            return Json(data);
        }
    }
}