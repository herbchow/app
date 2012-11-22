<%@ Application Language="C#" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core.aspnet" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        IFindDependencies container = new Container();
        RegisterDepenenciesInContainer(container);

        Dependencies.resolution = () => container;
    }

    private void RegisterDepenenciesInContainer(IFindDependencies container)
    {
        container.register_dependency<IHttpHandler, BasicHandler>();
    }

</script>
