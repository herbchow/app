<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Compilation" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core" %>
<%@ Import Namespace="app.web.core.aspnet" %>
<%@ Import Namespace="app.web.core.stubs" %>
<script runat="server">

    private void Application_Start(object sender, EventArgs e)
    {
        IFindDependencies container = new Container();
        Dependencies.resolution = () => container;

        container.register_dependency_instance<IGetTheCurrentlyExecutingRequest>(() => HttpContext.Current);
        container.register_dependency_instance<ICreateAspxPageInstances>(BuildManager.CreateInstanceFromVirtualPath);
        container.register_dependency_instance(CommandRoutingTable.command_not_found_strategy());
        container.register_dependency<ICreateControllerRequests, ControllerRequestFactory>();
        container.register_dependency<ICreateViews, ViewFactory>();
        container.register_dependency<IDisplayInformation, WebFormsDisplayEngine>();
        container.register_dependency<IGetThePathToAViewThatCanDisplay, StubPathRegistry>();
        container.register_dependency<IEnumerable<IProcessOneRequest>, CommandRoutingTable>();
        container.register_dependency<IFindCommands, CommandRegistry>();

        container.register_dependency<IProcessRequests, FrontController>();
        container.register_dependency<IHttpHandler, BasicHandler>();
    }
    
</script>
