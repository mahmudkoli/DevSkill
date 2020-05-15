using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DevSkill.Framework.Exceptions;
using DevSkill.Web.Areas.Admin.Enums;
using DevSkill.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevSkill.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(ILogger<ExpensesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new CreateExpenseModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            [Bind(nameof(CreateExpenseModel.Title),
            nameof(CreateExpenseModel.Description),
            nameof(CreateExpenseModel.Amount),
            nameof(CreateExpenseModel.ExpenseType),
            nameof(CreateExpenseModel.ExpenseDate))] CreateExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await model.AddAsync();
                    model.Response = new ResponseModel("Expense creation successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Expense creation failured.", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditExpenseModel();
            await model.LoadByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind(nameof(EditExpenseModel.Id),
            nameof(CreateExpenseModel.Title),
            nameof(CreateExpenseModel.Description),
            nameof(CreateExpenseModel.Amount),
            nameof(CreateExpenseModel.ExpenseType),
            nameof(CreateExpenseModel.ExpenseDate))] EditExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdateAsync();
                    model.Response = new ResponseModel("Expense edit successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Expense edit failured.", ResponseType.Failure);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new ExpenseModel();
            await model.DeleteAsync(id);
            return Json(true);
        }

        public async Task<IActionResult> GetExpenses()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            var data = await model.GetAllAsync(tableModel);
            return Json(data);
        }
    }
}