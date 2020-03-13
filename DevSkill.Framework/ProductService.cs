using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (IList<Product> records, int total, int totalFiltered) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            using var dbProvider = new SqlServerDataProvider<Product>(_connectionString);
            var result = dbProvider.GetData("spProducts_GetAll", new List<(string, object, bool)>
            {
                ("PageIndex", pageIndex, false),
                ("PageSize", pageSize, false),
                ("SearchText", searchText, false),
                ("OrderBy", sortText, false),
                ("TotalCount", 0, true),
                ("FilteredCount", 0, true)
            });

            return (result.records, result.total, result.totalFiltered);
        }
    }
}
