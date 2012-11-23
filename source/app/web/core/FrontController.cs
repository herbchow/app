using app.utility.service_locator;

namespace app.web.core
{
    public class FrontController : IProcessRequests
    {
        private IFindCommands command_registry;

        public FrontController() : this (new StubCommandRegistry())
        {
            
        }

        public FrontController(IFindCommands commandRegistry)
        {
            command_registry = commandRegistry;
        }

        public void process(IContainRequestDetails request)
        {
            command_registry.get_the_command_that_can_process(request).run(request);
        }
    }
}