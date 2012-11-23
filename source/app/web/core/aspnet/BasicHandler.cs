using System.Web;
using app.utility.service_locator;

namespace app.web.core.aspnet
{
    public class BasicHandler : IHttpHandler
    {
        private IProcessRequests front_controller;
        private ICreateControllerRequests request_factory;

        public BasicHandler(IProcessRequests front_controller, ICreateControllerRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public BasicHandler()
            : this(Dependencies.fetch.an<IProcessRequests>(),
                   Dependencies.fetch.an<ICreateControllerRequests>())
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_a_controller_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}