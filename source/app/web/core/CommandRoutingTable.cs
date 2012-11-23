using System;
using System.Collections;
using System.Collections.Generic;
using app.utility.service_locator;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;

namespace app.web.core
{
    public class CommandRoutingTable : IEnumerable<IProcessOneRequest>
    {
        private readonly List<IProcessOneRequest> _commands;

        public CommandRoutingTable()
        {
            _commands = new List<IProcessOneRequest>();

            _commands.Add(new RequestCommand(x => x.get_view_name() == "products" && x.get_action() == "display",
                                             create_view_for_query(
                                                 x =>
                                                 new StubCatalog().get_the_products_using(
                                                     x.map<ViewProductsInDepartmentRequest>()))));

            _commands.Add(new RequestCommand(x => x.get_view_name() == "departments" && x.get_action() == "main",
                                             create_view_for_query(x => new StubCatalog().get_the_main_departments())));

            _commands.Add(new RequestCommand(x => x.get_view_name() == "departments" && x.get_action() == "sub",
                                             create_view_for_query(x => new StubCatalog().get_the_departments_using(
                                                 x.map<ViewSubDepartmentsRequest>()))));
        }

        private ViewAReport<TPresentationModel> create_view_for_query<TPresentationModel>(
            IGetPresentationDataFromARequest<TPresentationModel> query)
        {
            return new ViewAReport<TPresentationModel>(Dependencies.fetch.an<IDisplayInformation>(), query);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            return ((IEnumerable<IProcessOneRequest>) _commands).GetEnumerator();
        }

        public static ICreateTheCommandWhenOneCantBeFound command_not_found_strategy()
        {
            return () =>
                {
                    throw new ApplicationException("Command that can process request not found.");
                };
        }
    }
}