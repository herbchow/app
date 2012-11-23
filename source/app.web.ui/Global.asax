<%@ Application Language="C#" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core" %>
<%@ Import Namespace="app.web.core.aspnet" %>
<%@ Import Namespace="app.web.core.stubs" %>
<script runat="server">

    private void Application_Start(object sender, EventArgs e)
    {
        IFindDependencies container = new Container();
        Dependencies.resolution = () => container;

        container.register_dependency<ICreateControllerRequests, StubRequestFactory>();
        container.register_dependency<IFindCommands, CommandRegistry>();

        container.register_dependency<IProcessRequests, FrontController>();
        container.register_dependency<IHttpHandler, BasicHandler>();
    }
    
</script>
