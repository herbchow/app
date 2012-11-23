using System.Web;

namespace app.web.core
{
    public interface IGetParameterNameFromRequest
    {
        string parse_parameter_by_name(HttpRequest request,string name);
    }
}
