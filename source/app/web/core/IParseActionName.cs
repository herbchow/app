using System.Web;

namespace app.web.core
{
    public interface IGetActionNameFromRequest
    {
        string parse_action_name(HttpRequest request);
    }
}