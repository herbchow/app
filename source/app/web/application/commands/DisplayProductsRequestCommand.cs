using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core;

namespace app.web.application.commands
{
    public class DisplayProductsRequestCommand : RequestCommand
    {
        public DisplayProductsRequestCommand()
            : base(x => x.get_view_name() == "products" && x.get_action() == "display",
                   create_view_for_query(x =>
                                         new StubCatalog().get_the_products_using(
                                             x.map<ViewProductsInDepartmentRequest>()))
                )
        {
        }
    }
}