using System.Web;

namespace app.web.core
{
    public class ControllerRequestFactory : ICreateControllerRequests
    {
        private readonly IGetViewNameFromRequest view_name_parser;
        private readonly IGetActionNameFromRequest action_name_parser;
        private readonly IGetParameterNameFromRequest parameter_name_parser;

        public ControllerRequestFactory(IGetViewNameFromRequest view_name_parser, IGetActionNameFromRequest action_name_parser, IGetParameterNameFromRequest parameter_name_parser)
        {
            this.view_name_parser = view_name_parser;
            this.action_name_parser = action_name_parser;
            this.parameter_name_parser = parameter_name_parser;
        }

        public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
        {
            return new RequestDetails(() => a_raw_aspnet_request, view_name_parser, action_name_parser,parameter_name_parser);
        }
    }
}