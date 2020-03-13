using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework
{
    public interface IProductService
    {
        (IList<Product> records, int total, int totalFiltered) GetProducts(int pageIndex, int pageSize, string searchText, string sortText);
        (IList<Product> records, int total, int totalFiltered) GetProductsByStoreProc(int pageIndex, int pageSize, string searchText, string orderBy, string orderDir);
    }
}
