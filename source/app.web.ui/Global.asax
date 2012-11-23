<%@ Application Language="C#" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core" %>
<%@ Import Namespace="app.web.core.aspnet" %>
<%@ Import Namespace="app.web.core.stubs" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        IFindDependencies container = new Container();
        RegisterDepenenciesInContainer(container);

        Dependencies.resolution = () => container;
    }

    private void RegisterDepenenciesInContainer(IFindDependencies container)
    {
        container.register_dependency<ICreateControllerRequests, StubRequestFactory>();
        container.register_dependency<IFindCommands, StubRequestFactory>();
        container.register_dependency<IProcessRequests, FrontController>();
        container.register_dependency<IHttpHandler, BasicHandler>();
    }

</script>
