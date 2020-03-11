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
            var products = dbProvider.GetData("select * from Products");

            var filteredProducts = products.Where(x => x.Name.Contains(searchText) || x.Description.Contains(searchText));

            var filteredProductsCount = filteredProducts.Count();
            var totalProducts = products.Count();

            var filteredProductList = filteredProducts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return (filteredProductList, totalProducts, filteredProductsCount);
        }
    }
}
