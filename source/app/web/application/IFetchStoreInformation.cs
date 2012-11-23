using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.models;

namespace app.web.application
{
    public interface IFetchStoreInformation
    {
        IEnumerable<Department> get_the_main_departments();
        IEnumerable<Department> get_the_departments_using(ViewSubDepartmentsRequest request);
        IEnumerable<Product> get_the_products_using(ViewProductsInDepartmentRequest request);
    }
}