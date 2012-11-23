using System.Collections;
using System.Collections.Generic;
using System.Web;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            // yield break;

            yield return
                new RequestCommand(x => true,
                                   new ViewAReport<IEnumerable<Product>>(
                                       new WebFormsDisplayEngine(new ViewFactory(), () => HttpContext.Current),
                                       x =>
                                       new StubCatalog().get_the_products_using(x.map<ViewProductsInDepartmentRequest>())))
                ;
        }

        public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
        {
            public IEnumerable<Department> fetch_using(IContainRequestDetails request)
            {
                return new StubCatalog().get_the_main_departments();
            }
        }

    }
}