using app.web.application.stubs;
using app.web.core;

namespace app.web.application.commands
{
    public class DisplayStoreCommand : RequestCommand
    {
        public DisplayStoreCommand() 
           : base(x => x.get_view_name() == "store" && x.get_action() == "display",
                   create_view_for_query(x => new StubCatalog().get_store()))
        {
        }
    }
}