using System.Collections;
using System.Collections.Generic;
using System.Web;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class CommandList : IEnumerable<IProcessOneRequest>
    {
        private readonly List<IProcessOneRequest> _commands;

        public CommandList()
        {
            _commands = new List<IProcessOneRequest>();

            _commands.Add(new RequestCommand(x => x.get_view_name() == "products" && x.get_action() == "display",
                                             new ViewAReport<IEnumerable<Product>>(
                                                 new WebFormsDisplayEngine(new ViewFactory(), () => HttpContext.Current),
                                                 x =>
                                                 new StubCatalog().get_the_products_using(
                                                     x.map<ViewProductsInDepartmentRequest>()))));

            _commands.Add(new RequestCommand(x => x.get_view_name() == "departments" && x.get_action() == "main",
                                             new ViewAReport<IEnumerable<Department>>(
                                                 new WebFormsDisplayEngine(new ViewFactory(), () => HttpContext.Current),
                                                 x =>
                                                 new StubCatalog().get_the_main_departments())));

            _commands.Add(new RequestCommand(x => x.get_view_name() == "departments" && x.get_action() == "sub",
                                             new ViewAReport<IEnumerable<Department>>(
                                                 new WebFormsDisplayEngine(new ViewFactory(), () => HttpContext.Current),
                                                 x =>
                                                 new StubCatalog().get_the_departments_using(
                                                     x.map<ViewSubDepartmentsRequest>()))));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            return ((IEnumerable<IProcessOneRequest>) _commands).GetEnumerator();
        }

        //public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
        //{
        //    public IEnumerable<Department> fetch_using(IContainRequestDetails request)
        //    {
        //        return new StubCatalog().get_the_main_departments();
        //    }
        //}

    }
}