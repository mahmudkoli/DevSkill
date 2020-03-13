using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSkill.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DevSkill.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new ProductsModel(_configuration);
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductsModel(_configuration);
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
    }
}