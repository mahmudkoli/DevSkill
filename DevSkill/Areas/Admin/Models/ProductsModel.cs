using DevSkill.Framework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSkill.Areas.Admin.Models
{
    public class ProductsModel : AdminBaseModel
    {
        private readonly IProductService _productService;

        public ProductsModel(IConfiguration configuration)
        {
            _productService = new ProductService(configuration.GetConnectionString("DefaultConnection"));
        }

        public object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _productService.GetProducts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Description", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalFiltered,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Description,
                                record.Price.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetProductsByStoreProc(DataTablesAjaxRequestModel tableModel)
        {
            var order = tableModel.GetOrder(new string[] { "Name", "Description", "Price" });
            var data = _productService.GetProductsByStoreProc(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                order.OrderBy,
                order.OrderDir);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalFiltered,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Description,
                                record.Price.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}
