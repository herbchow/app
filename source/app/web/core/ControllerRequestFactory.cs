using System.Web;

namespace app.web.core
{
    public class ControllerRequestFactory : ICreateControllerRequests
    {
        public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
        {
            return new RequestDetails(() => a_raw_aspnet_request, new ViewNameParser(), new ActionNameParser(), new ParameterByNameParser());
        }
    }
}