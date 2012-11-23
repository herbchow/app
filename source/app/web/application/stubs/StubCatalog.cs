using System.Collections.Generic;
using System.Linq;
using app.web.application.catalogbrowsing;

namespace app.web.application.stubs
{
    public class StubCatalog : IFetchStoreInformation
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return Enumerable.Range(1, 1000).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_the_departments_using(ViewSubDepartmentsRequest request)
        {
            return Enumerable.Range(1, 5).Select(x => new Department {name = x.ToString("Sub Department 0")});
        }

        public IEnumerable<Product> get_the_products_using(ViewProductsInDepartmentRequest request)
        {
            return Enumerable.Range(1, 5).Select(x => new Product {name = x.ToString("Product 0")});
        }
    }
}