using app.web.application.stubs;
using app.web.core;

namespace app.web.application.commands
{
    public class DisplayMainDepartmentsCommand : RequestCommand
    {
        public DisplayMainDepartmentsCommand()
            : base(x => x.get_view_name() == "departments" && x.get_action() == "main",
                   create_view_for_query(x => new StubCatalog().get_the_main_departments()))
        {
        }
    }
}