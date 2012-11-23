using System.Web;

namespace app.web.core
{
    public interface IGetViewNameFromRequest
    {
        string parse_view_name(HttpRequest request);
    }
}