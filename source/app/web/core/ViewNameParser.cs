using System.Web;

namespace app.web.core
{
    public class ViewNameParser : IGetViewNameFromRequest
    {
        public string parse_view_name(HttpRequest request)
        {
            return request.QueryString["view"];
        }
    }
}