using System.Web;

namespace app.web.core
{
    public class ActionNameParser : IGetActionNameFromRequest
    {
        public string parse_action_name(HttpRequest request)
        {
            return request.QueryString["action"];
        }
    }
}