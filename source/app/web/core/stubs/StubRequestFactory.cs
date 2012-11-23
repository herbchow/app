using System;
using System.Web;

namespace app.web.core.stubs
{
    public class StubRequestFactory : ICreateControllerRequests
    {
        public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
        {
            return new StubRequest();
        }

        private class StubRequest : IContainRequestDetails
        {
            public ModelData map<ModelData>()
            {
                return Activator.CreateInstance<ModelData>();
            }

            public string get_view_name()
            {
                return string.Empty;
            }

            public string get_action()
            {
                return string.Empty;
            }

            public string get_parameter_by_name(string name)
            {
                return string.Empty;
            }
        }
    }
}