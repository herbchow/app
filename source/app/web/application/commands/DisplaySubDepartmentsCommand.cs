using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core;

namespace app.web.application.commands
{
    public class DisplaySubDepartmentsCommand : RequestCommand
    {
        public DisplaySubDepartmentsCommand()
            : base(x => x.get_view_name() == "departments" && x.get_action() == "sub",
                   create_view_for_query(
                       x => new StubCatalog().get_the_departments_using(x.map<ViewSubDepartmentsRequest>())))
        {
        }
    }
}