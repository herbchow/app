using System.Web.UI;

namespace app.web.core.aspnet
{
    public class SimpleView<Model> : Page, IDisplayA<Model>
    {
        public Model model { get; set; }
    }
}