using System.Web;

namespace app.web.core
{
    public interface ICreateControllerRequests
    {
        IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request);
    }
}