using System;
using System.Collections.Generic;
using System.Linq;
using app.web.application.catalogbrowsing;

namespace app.web.application.stubs
{
    public class StubCatalog : IFetchStoreInformation
    {
        private static IEnumerable<Department> main_departments =
            Enumerable.Range(1, 10)
                          .Select(x =>
                                  new Department
                                  {
                                      name = x.ToString("Department 0"),
                                      has_sub_departments = x / 2 == 0,
                                      departmentId = x,
                                  });
        private const int subDepartmentStart = 0;
        private const int productsStart = 5;

        public IEnumerable<Department> get_the_main_departments()
        {
            return main_departments;
        }

        public IEnumerable<Department> get_the_departments_using(ViewSubDepartmentsRequest request)
        {
            var subDepartments = new List<Department>();
            for (int i = 0; i < 5; i++ )
            {
                subDepartments.Add(new Department
                                       {
                                           name = "Sub Department " + (i + 1),
                                           departmentId = main_departments.ElementAt(i + subDepartmentStart).departmentId,
                                       });
            }
            return subDepartments;
        }

        public IEnumerable<Product> get_the_products_using(ViewProductsInDepartmentRequest request)
        {
            var products = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                products.Add(new Product
                {
                    name = "Product " + (i + 1),
                    departmentId = main_departments.ElementAt(i + productsStart).departmentId,
                });
            }
            return products;
        }
    }
}