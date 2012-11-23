using System.Web;

namespace app.web.core
{
    public class ParameterByNameParser : IGetParameterNameFromRequest
    {
        public string parse_parameter_by_name(HttpRequest request, string name)
        {
            return request.QueryString[name];
        }
    }
}
