using app.web.core.aspnet;

namespace app.web.core
{
    public class RequestDetails : IContainRequestDetails
    {
        private readonly IGetTheCurrentlyExecutingRequest current_context;
        private readonly IGetViewNameFromRequest _viewNameFromRequestParser;
        private readonly IGetActionNameFromRequest action_parser;
        private readonly IGetParameterNameFromRequest _parameterNameFromRequestParser;

        public RequestDetails(IGetTheCurrentlyExecutingRequest current_context, 
            IGetViewNameFromRequest _viewNameFromRequestParser,
            IGetActionNameFromRequest action_parser,
            IGetParameterNameFromRequest parameterByName_parser)
        {
            this.current_context = current_context;
            this._viewNameFromRequestParser = _viewNameFromRequestParser;
            this.action_parser = action_parser;
        }

        public string get_view_name()
        {
            return _viewNameFromRequestParser.parse_view_name(current_context().Request);
        }

        public string get_action()
        {
            return action_parser.parse_action_name(current_context().Request);
        }

        public string get_parameter_by_name(string name)
        {
            return _parameterNameFromRequestParser.parse_parameter_by_name(current_context().Request,name);
        }

        public ModelData map<ModelData>()
        {
            return (ModelData) current_context().Items["Model"];
        }
    }
}