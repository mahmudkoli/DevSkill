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
    public class StudentRegistrationsController : Controller
    {
        private readonly ILogger<StudentRegistrationsController> _logger;

        public StudentRegistrationsController(ILogger<StudentRegistrationsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new StudentRegistrationModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            var model = new StudentRegistrationModel();
            await model.LoadAllSelectListAsync();

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
        public async Task<IActionResult> AddOrEdit(StudentRegistrationModel model)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (model.Id == null || model.Id == 0) await model.AddAsync();
                else await model.UpdateAsync();

                TempData["SuccessNotify"] = "Student Registration has been successfully saved";
                return RedirectToAction("Index");
            }

            TempData["ErrorNotify"] = "Student Registration could not be saved";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new StudentRegistrationModel();
            await model.DeleteAsync(id);
            return Json(true);
        }

        public async Task<IActionResult> GetStudentRegistrations()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentRegistrationModel();
            var data = await model.GetAllAsync(tableModel);
            return Json(data);
        }
    }
}